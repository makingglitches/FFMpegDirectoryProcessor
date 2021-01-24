using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VideoRecoder
{
    public class RecodeOptions
    {
        public RecodeOptions()
        {
            
        }

        /// <summary>
        /// Not used yet, for scenarios where maximizing threads runs multiple encoder jobs similatenously.
        /// </summary>
        public int ConcurrentJobs { get; set; } 


        /// <summary>
        /// These are repeat little experiments which actually arent very necessary.
        /// </summary>
        /// <returns></returns>
        public string GetParameterFormat(string infile, string outfile)
        {

            string ffmpegcmd = "-i {0}  -map_metadata 0 -c:v libx265  - x265 -params -crf="+ CRF.ToString() + " {1} ";

             return String.Format( ffmpegcmd,infile, outfile);
        }


        public string FileSuffix { get; set; }
        public string OutputDirectory { get; set; }
        public List<string> InputFiles { get; set; }

        public List<string> OutputFiles
        {
            get
            {

                string outdir = OutputDirectory + (OutputDirectory.Trim().EndsWith("\\") ? string.Empty : "\\");

               return InputFiles.Select(o => outdir+
                    Path.GetFileNameWithoutExtension(o) + FileSuffix).ToList();
            }
        }

        private int _crf = 19;

   
        public bool DoExtractMetaDataViaExif { get; set; }
        public string ExifOutputFile { get; set; }
        public bool DoSplitFileByTime { get; set; }

        public TimeSpan SplitToMax { get; set; }

        private int lowdiskwarningmb=4096;

        public int LowDiskWarningMB {  get { return lowdiskwarningmb; } set { lowdiskwarningmb = value; } }

        public int CRF
        {
            get
            {
                return _crf;
            }

            set
            {
                if (value > 51 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("CRf must be between 0 and 51");
                }

                _crf = value;
            }
        }
        
    }
}
