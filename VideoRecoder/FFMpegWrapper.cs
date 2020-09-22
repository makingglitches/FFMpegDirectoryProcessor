using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace VideoRecoder
{
   public  class FFMpegWrapper
    {

        private EventBlock _events;
        private string _parameterstring;

        public FFMpegWrapper(string _infile, string _outfile, RecodeOptions options, EventBlock events)
        {
            currentfile = _infile;
            outfile = _outfile;
            _parameterstring = options.GetParameterFormat(_infile, _outfile);
        }


        private Process daProcess;

        private string currentfile = null;
        private string outfile = null;

        private long _currentFileSize;
        private long _newFileSize;

        private DateTime _startTime;
        private DateTime _endTime;

       


   

        private void P_Exited(object sender, EventArgs e)
        {
            _endTime = DateTime.Now;

            if (OnExit != null)
            {
                OnExit(currentfile);
            }

            _newFileSize = new FileInfo(outfile).Length;

            // apparently android recording apps are incredibly fucking lazy when it comes to compression.

            if (OnMessage != null)
            {
                OnMessage(this, "New filesize was:" + toMb(_newFileSize));
                OnMessage(this, "Saved: " + toMb(_currentFileSize - _newFileSize));
                OnMessage(this, "Total Processing Time:" + (_endTime.Subtract(_startTime)).ToString());
            }

            daProcess = null;

            // betcha i shit the same way from eating things in the same fucking order
            // obviously the shit they had walk by and the way these people have been pretending to
            // act indicates a similar repetition they just built some other shit around
            // fuck them. seriously.
            File.AppendAllText(Path.GetDirectoryName(outfile) + "\\" + "finished.txt", "\r\n" + outfile);


            mr.Set();
        }

        /// <summary>
        /// helper function to convert bytes to megabytes
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string toMb(long length)
        {
            return ((double)length / 1024.0 / 1024.0).ToString("F4") + " Mb";
        }

        /// <summary>
        /// Standard error redirect almost all data is sent here by ffmpeg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (CheckFree())
            {
                // onabort will be called at the beginning of the start() loop.
                daProcess.Kill();
                mr.Set();
                return;
            }

            // wouldnt seem necessary would it ? but is. sick of rewriting things.
            if (string.IsNullOrEmpty(e.Data))
            {
                return;
            }

            // if processing has started begin raising the progress event
            if (e.Data.StartsWith("frame="))
            {
                string frametrimmed = e.Data.Replace("frame=", "");
                int fpsstart = frametrimmed.IndexOf("fps=");
                int sizestart = frametrimmed.IndexOf("size=");
                int timestart = frametrimmed.IndexOf("time=");
                int bitstart = frametrimmed.IndexOf("bitrate=");

                string frameval = frametrimmed.Substring(0, fpsstart - 1).Trim();
                string sizeval = frametrimmed.Substring(sizestart + 5,
                    timestart - sizestart - 5).Trim();
                string timeval = frametrimmed.Substring(timestart + 5,
                    bitstart - timestart - 7).Trim();

                if (OnProgress != null)
                {
                    OnProgress(frameval, sizeval, timeval);
                }


            }
            else
            {
                if (e.Data.StartsWith("Input #"))
                {
                    processingInput = true;
                }
                else if (processingInput)
                {
                    if (e.Data.Trim().StartsWith("Duration:"))
                    {
                        string duration = e.Data.Substring(11, e.Data.IndexOf(",") - 11);
                        // notify subscriber of video length
                        processingInput = false;

                        if (OnVideoLength != null)
                        {
                            OnVideoLength(duration);
                        }
                    }
                }
                else
                {
                    //       Console.WriteLine(e.Data);
                }
            }
        }

        /// <summary>
        /// Indicates if processing input data from error stream is occurring
        /// </summary>
        public bool processingInput = false;

        /// <summary>
        /// Thread code
        /// </summary>
        /// <param name="o"></param>
        private void StartProcess(object o)
        {
            try
            {
                //  Console.WriteLine("Worker Thread Started.");

                string ffmpegcmd = "-i {0}  -map_metadata 0 -c:v libx265  -x265-params -crf=19 {1}";

                string[] names = (string[])o;

                if (OnStart != null)
                {
                    OnStart(names[0]);
                }

                // this needs to be changed to wherever the hell the file resides.
                string ffmpeg = @"C:\Program Files\ImageMagick-7.0.10-Q16-HDRI\ffmpeg.exe";

                ffmpeg = "\"" + ffmpeg + "\"";

                Process p = new Process();
                daProcess = p;
                ProcessStartInfo startup =
                   new ProcessStartInfo(ffmpeg,
                   string.Format(ffmpegcmd, names[0], names[1]));

                Console.WriteLine(startup.FileName + " " + startup.Arguments);

                startup.CreateNoWindow = false;
                startup.RedirectStandardOutput = true;
                startup.RedirectStandardError = true;
                startup.UseShellExecute = false;

                p.ErrorDataReceived += P_ErrorDataReceived;
                p.OutputDataReceived += P_OutputDataReceived;
                p.EnableRaisingEvents = true;

                p.Exited += P_Exited;
                p.StartInfo = startup;

                _startTime = DateTime.Now;

                if (!p.Start()) { mr.Set(); }

                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                mr.Set();
            }
        }

        /// <summary>
        /// Standard output stream redirect, not much happens here if anything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckFree()
        {
            var drives = DriveInfo.GetDrives();
            var root = Path.GetPathRoot(DirectoryName);

            return (drives.Where(o => o.Name.Equals(root)).First().TotalFreeSpace <= LowDiskMBWarning * 1024 * 1024);
        }

        private bool terminate = false;
        public void ForceStop()
        {
            if (daProcess != null)
            {
                terminate = true;
                daProcess.Kill();
                mr.Set();
            }
        }

        public void Start()
        {

            if (CheckFree())
            {
                if (OnAbort != null)
                {
                    OnAbort("", "Drive is below the " + LowDiskMBWarning.ToString() + " MB level in free space. Exiting.");

                }

                if (OnLowDisk!=null)
                {
                    OnLowDisk();
                }

                return;
            }

            string outputname = "\"" + Path.GetDirectoryName(file) + "\\recode\\"
                    + Path.GetFileNameWithoutExtension(file) + "_recode.mp4" + "\"";

            // personally kind of sick of being placataed, it will die.
            outfile = outputname.Replace("\"", "");

            if (!File.Exists(file))
            {
                Console.WriteLine("Input File:" + file + " no longer exists.");
                continue;
            }




        }
    }
}
