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

        public delegate void ProgressEvent(string currentFrame, string currentSize, string inputTimeStamp);
        public delegate void VideoLength(string length);
        public delegate void SkippingOrError(string fileName, string Message, Exception error = null);
        public delegate void FileEvent(string fileName);

        public event FileEvent OnStart;
        public event ProgressEvent OnProgress;
        public event SkippingOrError OnSkippedFile;
        public event VideoLength OnVideoLength;
        public event FileEvent OnExit;
        public event SkippingOrError OnAbort;

        private Process daProcess;

        private string currentfile = null;

        /// <summary>
        /// This is the amount of disk space left before we refuse to run ffmpeg, default is 4000 Mb or 4 Gb
        /// </summary>
        public int LowDiskMBWarning = 4000;

        
        public ManualResetEvent mr = new ManualResetEvent(false);

        public string DirectoryName { get; set; }

        public FFMPegDirectoryProcessor(string directoryName)
        {
            DirectoryName = directoryName;
        }

        private  void P_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("ffmpeg exited");
            // make sure there is not a race condition in case of error based exit.
            Thread.Sleep(500);
            mr.Set();

            if (OnExit!=null)
            {
                OnExit(currentfile);
            }

            daProcess = null;
        }

        private  void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (CheckFree())
            {
                // onabort will be called at the beginning of the start() loop.
                daProcess.Kill();
                mr.Set();
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
                    //Console.WriteLine(e.Data);
                }
            }
        }

        public bool processingInput = false;

        private  void StartProcess(object o)
        {
            try
            {

            
              //  Console.WriteLine("Worker Thread Started.");

                string ffmpegcmd = "-i {0} -c:v libx265  -x265-params -crf=19 {1}";

                string[] names = (string[])o;

                if (OnStart != null)
                {
                    OnStart(names[0]);
                }

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

                p.Exited += P_Exited;
                p.StartInfo = startup;


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

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

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

                string outputname = "\"" + Path.GetDirectoryName(file) + "\\recode\\"
                    + Path.GetFileNameWithoutExtension(file) + "_recode.mp4" + "\"";

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

                currentfile = inname;

                System.Threading.Thread t = new Thread(new ParameterizedThreadStart(StartProcess));

                t.Start(new string[] { inname, outputname });

                mr.WaitOne();

                if (terminate) { break; }
            }
        }
    }
}

