using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.CompilerServices;

namespace DLCF_Parser
{
    public class Parser
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);
        public IDictionary<string, string> parseFile(string path) {
            int status = checkForSpec(path);
            string beforeEqual;
            string afterEqual;
            IDictionary<string, string> data = new Dictionary<string, string>();
            switch (status)
            {
                case 0:
                    string[] lines = File.ReadAllLines(path);
                    foreach(string line in lines)
                    {
                        if (line.StartsWith('&'))
                        {
                            break;
                        }
                        beforeEqual = line.Split('=')[0];
                        afterEqual = line.Substring(line.LastIndexOf('=') + 1);
                        data.Add(beforeEqual, afterEqual);
                    }
                    break;
                case 1:
                    MessageBox((IntPtr)0, "Invalid file", "Invalid file", 0);
                    break;
                default:
                    throw new Exception("Unspecified error code, if you see this, please report the incident");
            }
            return data;
        }

        private int checkForSpec(string file)
        {
            int statusCode;
            string[] lines = File.ReadAllLines(file);
            if (lines[0] == "&DLFC 1.0 Private")
            {
                statusCode = 0;
            } else
            {
                statusCode = 1;
            }
            return statusCode;
        }
    }
}