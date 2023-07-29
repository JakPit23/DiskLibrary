using System;
using System.Collections.Generic;
using System.IO;

namespace DLCF_Parser
{
    public class Parser
    {
        public IDictionary<string, string> ParseFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }

            if (!CheckForSpec(path))
            {
                throw new InvalidOperationException("Invalid file");
            }

            string[] lines = File.ReadAllLines(path);
            Console.WriteLine($"Read {lines.Length} lines from the file.");
            IDictionary<string, string> data = new Dictionary<string, string>();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrEmpty(line) || line.StartsWith("#"))
                {
                    continue;
                }

                string[] parts = line.Split(new char[] { '=' }, 2);
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    data.Add(key, value);
                }
            }

            return data;
        }

        private bool CheckForSpec(string file)
        {
            string[] lines = File.ReadAllLines(file);
            return (lines.Length > 0 && lines[0] == "&DLFC 1.0 Private");
        }
    }
}
