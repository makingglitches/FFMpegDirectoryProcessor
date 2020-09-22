using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRecoder
{
    /// <summary>
    /// For events that are going to be wired to the same handlers no matter what object uses them.
    /// </summary>
    public class EventBlock
    {
        /// <summary>
        /// This is the amount of disk space left before we refuse to run ffmpeg, default is 4000 Mb or 4 Gb
        /// </summary>
        public int LowDiskMBWarning = 4000;


        public void RaiseOnStart(string filename)
        {
            if (OnStart !=null)
            {
                OnStart(filename);
            }
        }

        public void RaiseProgressEvent(string frame, string size, string timestamp)
        {
            if (OnProgress !=null)
            {
                OnProgress(frame, size, timestamp);
            }
        }

        public void RaiseSkipFile(string filename, string message, Exception error=null)
        {
            if (OnSkippedFile!=null)
            {
                OnSkippedFile(filename, message, error);
            }
        }

        public void RaiseVideoLength(string length)
        {
            if (OnVideoLength !=null)
            {
                OnVideoLength(length);
            }
        }

        public void RaiseExit(string filename)
        {
            if (OnExit !=null)
            {
                OnExit(filename);
            }
        }


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

        /// <summary>
        /// Fires when the amount of disk space available dips beneath the warning level.
        /// </summary>
        public event LowDiskSpace OnLowDisk;



    }
}
