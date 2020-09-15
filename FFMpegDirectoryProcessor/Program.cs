using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {


            FFMPegDirectoryProcessor dirprocess =

                new FFMPegDirectoryProcessor(@"<put a directory path here>");

            dirprocess.OnStart += Dirprocess_OnStart;
            dirprocess.OnVideoLength += Dirprocess_OnVideoLength;
            dirprocess.OnSkippedFile += Dirprocess_OnSkippedFile;
            dirprocess.OnProgress += Dirprocess_OnProgress;
            dirprocess.OnAbort += Dirprocess_OnAbort;
            dirprocess.OnExit += Dirprocess_OnExit;

            dirprocess.Start();

            Console.ReadLine();


        }

        private static void Dirprocess_OnExit(string fileName)
        {
            throw new NotImplementedException();
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
