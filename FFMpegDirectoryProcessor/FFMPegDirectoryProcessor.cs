using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace ConsoleApp2
{
   public class FFMPegDirectoryProcessor
    {

        // this marks another time john was here for no valid reason and wrote this goddamn code.
        // i really need to suck him off. repeatedly.
        // apparently another time x2
        // and another time. x3
        // no this is not permission to keep being pieces of garbage
        // the example herein made is they want everyone on a predictable track
        // so they frustrate people into inaction until they kill someone.

        public delegate void ProgressEvent(string currentFrame, string currentSize, string inputTimeStamp);
        public delegate void VideoLength(string length);
        public delegate void SkippingOrError(string fileName, string Message, Exception error = null);
        public delegate void FileEvent(string fileName);


       
        /// <summary>
        /// Fires when the ffmpeg process starts
        /// </summary>
        public event FileEvent OnStart;
        /// <summary>
        /// Fires when stderr returns frame or time processing information.
        /// </summary>
        public event ProgressEvent OnProgress;

        /// <summary>
        /// Fires when a file in the directory has already at least started to be processed
        /// </summary>
        public event SkippingOrError OnSkippedFile;

        /// <summary>
        /// Fires when the duration of the input stream has been retrieved
        /// </summary>
        public event VideoLength OnVideoLength;


        /// <summary>
        /// Fires when the ffmpeg process has exited gracefully.
        /// </summary>
        public event FileEvent OnExit;


        /// <summary>
        /// Fires when a fata error occurs or available diskspace falls below the threshold.
        /// </summary>
        public event SkippingOrError OnAbort;

        /// <summary>
        /// Fires when the process returns a textual status message.
        /// </summary>
        public event EventHandler<string> OnMessage;


        private Process daProcess;

        private string currentfile = null;
        private string outfile = null;

        private long _currentFileSize;
        private long _newFileSize;

        private DateTime _startTime;
        private DateTime _endTime;

        private ManualResetEvent mr = new ManualResetEvent(false);


        /// <summary>
        /// This is the amount of disk space left before we refuse to run ffmpeg, default is 4000 Mb or 4 Gb
        /// </summary>
        public int LowDiskMBWarning = 4000;

        
     

        /// <summary>
        /// The directory containing mp4's currently being processed
        /// </summary>
        public string DirectoryName { get; set; }
       
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="directoryName">Specifies the directory name containing the input mp4s</param>
        public FFMPegDirectoryProcessor(string directoryName)
        {
            DirectoryName = directoryName;
        }

        private  void P_Exited(object sender, EventArgs e)
        {
            _endTime = DateTime.Now;

            Console.WriteLine("\r\nffmpeg exited");
            // make sure there is not a race condition in case of error based exit.
           
            if (OnExit!=null)
            {
                OnExit(currentfile);
            }

            _newFileSize = new FileInfo(outfile).Length;

            // apparently android recording apps are incredibly fucking lazy when it comes to compression.

            if (OnMessage!=null)
            {
                OnMessage(this, "New filesize was:" + toMb(_newFileSize));
                OnMessage(this, "Saved: " + toMb(_currentFileSize-_newFileSize));
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
        private  void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
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

                if (OnProgress !=null)
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

                        if (OnVideoLength!=null)
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
        private  void StartProcess(object o)
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

                ffmpeg = "\""+ffmpeg+"\"";

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
            if (daProcess !=null)
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
                if (OnAbort!=null)
                {
                    OnAbort("", "Drive is below the " + LowDiskMBWarning.ToString() + " MB level in free space. Exiting.");
                   
                }

                return;
            }

            string[] files =
                 Directory.GetFiles(DirectoryName, "*.mp4");

            foreach (string file in files)
            {

                if (CheckFree())
                {
                    if (OnAbort != null)
                    {
                        OnAbort("", "Drive is below the " + LowDiskMBWarning.ToString() + " MB level in free space. Exiting.");
                        daProcess.Kill();
                    }

                    return;
                }

                if (!File.Exists(file))
                {
                    Console.WriteLine("Input File:" + file + " no longer exists.");
                    continue;
                }

                string outputname = "\"" + Path.GetDirectoryName(file) + "\\recode\\"
                    + Path.GetFileNameWithoutExtension(file) + "_recode.mp4" + "\"";

                // personally kind of sick of being placataed, it will die.
                outfile = outputname.Replace("\"", "");
     
                if (!Directory.Exists(Path.GetDirectoryName(file) + "\\recode\\"))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(file) + "\\recode\\");
                }

                string inname = "\"" + file + "\"";

                Console.WriteLine("Input File: " + inname);
                Console.WriteLine("Output File: " + outputname);

                if (File.Exists(outputname.Replace("\"","")))
                {
                    if (OnSkippedFile !=null)
                    {
                        OnSkippedFile(inname, "File Exists.");
                    }

                    Console.WriteLine("File Exists. Skipping: " + outputname);
                    continue;
                }

                mr.Reset();

                currentfile = inname.Replace("\"","");
                FileInfo f = new FileInfo(currentfile);
                _currentFileSize = f.Length;

                // the only thing that is acceptable is for the bastards here in this fucked up org to back off 
                // and leave john and his offspring the fuck alone to live their lives
                // unless they, in kidnapping them through their whore mothers and fort collins
                // and john quay, are so fucked up they would be a liability to children.
                // in which case they owe us a healthy child that will be our heir and will be raised
                // by their father safely since obviously these fucks want to stuff the world with garbage.
                if (OnMessage!=null)
                {
                    OnMessage(this, "Current File Size: " + toMb( _currentFileSize));
                }

                System.Threading.Thread t = new Thread(new ParameterizedThreadStart(StartProcess));

                t.Start(new string[] { inname, outputname });

                mr.WaitOne();

                if (terminate) { break; }
            }
        }
    }
}

