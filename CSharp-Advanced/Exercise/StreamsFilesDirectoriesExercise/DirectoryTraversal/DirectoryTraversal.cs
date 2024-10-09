namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();
            string[] files = Directory.GetFiles(inputFolderPath);
            
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if(!dictionary.ContainsKey(fileInfo.Extension))
                {
                    dictionary.Add(fileInfo.Extension, new Dictionary<string, double>());
                    dictionary[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length);
                }
                else
                {
                    if(!dictionary[fileInfo.Extension].ContainsKey(fileInfo.Name))
                    {
                        dictionary[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var key in dictionary.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
            {
                sb.AppendLine(key.Key);
                foreach (var item in key.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{item.Key} - {item.Value / 1024:f3}kb");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            using (StreamWriter sw = new StreamWriter($"{path}{reportFileName}"))
            {
                sw.WriteLine(textContent);
            }
            
        }
    }
}
