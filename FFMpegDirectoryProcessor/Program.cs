using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {


            var largs = args.Where(o=>!string.IsNullOrEmpty(o)). 
                Select(o=>o.ToLower().Trim()).ToList();

            
            FFMPegDirectoryProcessor dirprocess =
                new FFMPegDirectoryProcessor(@"C:\Users\John\Desktop\Combined Photos etc\mp4s");


            if (largs.Contains("--crf"))
            {
                int i = largs.IndexOf("--crf");
                if (i+1 < largs.Count)
                {
                    dirprocess.OverrrideCRF = true;

                    if (!int.TryParse(largs[i + 1], out dirprocess.Crf))
                    {
                        Console.WriteLine("Invalid CRF Value: " + largs[i + 1]);
                        return;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Required CRF Value not supplied.");
                    return;
                }
            }



            dirprocess.OnStart += Dirprocess_OnStart;
            dirprocess.OnVideoLength += Dirprocess_OnVideoLength;
            dirprocess.OnSkippedFile += Dirprocess_OnSkippedFile;
            dirprocess.OnProgress += Dirprocess_OnProgress;
            dirprocess.OnAbort += Dirprocess_OnAbort;
            dirprocess.OnExit += Dirprocess_OnExit;
            dirprocess.OnMessage += Dirprocess_OnMessage;

            dirprocess.Start();

            Console.ReadLine();


        }

        private static void Dirprocess_OnMessage(object sender, string e)
        {
            Console.WriteLine(e);
        }

        private static void Dirprocess_OnExit(string fileName)
        {
            Console.WriteLine(fileName + " finished processing.");
        }

        private static void Dirprocess_OnAbort(string fileName, string Message, Exception error = null)
        {
            Console.WriteLine("Aborted:" + fileName + " for the following reason\r\n" + Message);
        }

        private static void Dirprocess_OnProgress(string currentFrame, string currentSize, string inputTimeStamp)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("                                                                                         ");
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("Frame: " + currentFrame + "  FileSize: " + currentSize + " Processing:" + inputTimeStamp);
        }

        private static void Dirprocess_OnSkippedFile(string fileName, string Message, Exception error = null)
        {
            Console.WriteLine("Skipped File: " + fileName + " with message:" + Message);
        }

        private static void Dirprocess_OnVideoLength(string length)
        {
            Console.WriteLine("Video Length: " + length);
        }

        private static void Dirprocess_OnStart(string fileName)
        {
            Console.WriteLine("Conversion of " + fileName + "started.");
        }
    }
      

}
