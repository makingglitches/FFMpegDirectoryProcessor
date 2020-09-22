using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRecoder
{
    public delegate void ProgressEvent(string currentFrame, string currentSize, string inputTimeStamp);
    public delegate void VideoLength(string length);
    public delegate void SkippingOrError(string fileName, string Message, Exception error = null);
    public delegate void FileEvent(string fileName);
    public delegate void LowDiskSpace();
}
