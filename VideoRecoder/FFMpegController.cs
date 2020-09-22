using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace VideoRecoder
{
    /// <summary>
    /// This class just serves as a communicator between the various processes this program will call and the GUI
    /// that is its only purpose. In replacing ffmpegdirprocessor in the command line prompt.
    /// </summary>
   public class FFMpegController
    {

        // FUCKING HINDI POPULATED FUCKING MICROSOFT USING GODDAMN SLAVE LABOR TO MAKE THINGS
        // ANNOYING NO WONDER THE WHOLE COUNTRY WAS QUIETLY STUFFED WITH CHOMO TRASH 
        // FUCKING SERENE INSPIRING RAPEY MOTHERFUCKERS AND THEIR UGLY BROWN SKIN AND UGLY GODDAMN
        // BEADY BLACK FUCKING EYES FUCKING KIDDY TOUCHING IMPOVERSHED FAKE ASS NON-HINDU MOTHERFUCKERS !
        // NO OFFENSE TO ACTUAL HINDUS. BUT THESE WORK AT MICROSOFT.
        // ANYWAY FUCKING ASSHOLES MAKING A 2 SECOND OPERATION A FUCKING 10 MINUTES WASTE OF FUCKING
        // TIME NOT MAKING PROJECT TYPES COMPATIBLE WHEN THE RUNTIMES ALL INSTALLED SHOULD BE 
        // FUCKING FINE !!!!

        // this marks another time john was here for no valid reason and wrote this goddamn code.
        // i really need to suck him off. repeatedly.
        // apparently another time x2
        // and another time. x3
        // no this is not permission to keep being pieces of garbage
        // the example herein made is they want everyone on a predictable track
        // so they frustrate people into inaction until they kill someone.

        /// <summary>
        /// The directory containing mp4's currently being processed
        /// </summary>

        RecodeOptions _options;
        private ManualResetEvent mr = new ManualResetEvent(false);
        private EventBlock _events;
        private Thread _thread;
        

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="directoryName">Specifies the directory name containing the input mp4s</param>
        public FFMpegController(RecodeOptions options, EventBlock events)
        {
            _options = options;
            _events = events;
        }


        private void ThreadCode()
        {

            var outfiles = _options.OutputFiles;

            if (!Directory.Exists(_options.OutputDirectory))
            {
                try
                {
                    Directory.CreateDirectory()
                }
                catch (Exception e)
                {
                    if (_events.)
                }
            }

            for (int i = 0; i < _options.InputFiles.Count; i++)
            {
                if (File.Exists(outfiles[i]))
                {

                }
            }

        }

        public void Start()
        {
            // this is accessed by a gui thread, therefore must work differently than 
            // a console app or the gui will freeze.
            // something dumbass web devs dont tend to know.
            _thread = new Thread(new ThreadStart(ThreadCode));
            _thread.Start();
        }

         



              

                

                if (!Directory.Exists(Path.GetDirectoryName(file) + "\\recode\\"))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(file) + "\\recode\\");
                }

                string inname = "\"" + file + "\"";

                //Console.WriteLine("Input File: " + inname);
                //Console.WriteLine("Output File: " + outname);

                if (File.Exists(outputname.Replace("\"", "")))
                {
                    if (OnSkippedFile != null)
                    {
                        OnSkippedFile(inname, "File Exists.");
                    }

                    Console.WriteLine("File Exists. Skipping: " + outputname);
                    continue;
                }

                mr.Reset();

                currentfile = inname.Replace("\"", "");
                FileInfo f = new FileInfo(currentfile);
                _currentFileSize = f.Length;

                // the only thing that is acceptable is for the bastards here in this fucked up org to back off 
                // and leave john and his offspring the fuck alone to live their lives
                // unless they, in kidnapping them through their whore mothers and fort collins
                // and john quay, are so fucked up they would be a liability to children.
                // in which case they owe us a healthy child that will be our heir and will be raised
                // by their father safely since obviously these fucks want to stuff the world with garbage.
                if (OnMessage != null)
                {
                    OnMessage(this, "Current File Size: " + toMb(_currentFileSize));
                }

                System.Threading.Thread t = new Thread(new ParameterizedThreadStart(StartProcess));

                t.Start(new string[] { inname, outputname });

                mr.WaitOne();

                if (terminate) { break; }
            }
        }
    }
}

