using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace DownloadAndModifyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string url = "https://mail.univ.net.ua/forum/forum.html";
            string originalFileName = "Forum.txt";
            string simplifiedFileName = "Forum-LIGHT.txt";

            Console.Write("Введіть новий рядок для заміни всіх рядків, що містять 'youtu.be': ");
            string replaceString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(replaceString))
            {
                replaceString = "[REDACTED]";
            }

            if (File.Exists(originalFileName))
                File.Delete(originalFileName);
            if (File.Exists(simplifiedFileName))
                File.Delete(simplifiedFileName);

            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, originalFileName);

            using (StreamReader reader = new StreamReader(originalFileName, Encoding.GetEncoding("windows-1251")))
            {
                using (StreamWriter writer = new StreamWriter(simplifiedFileName, false, Encoding.UTF8))
                {
                    string line;
                    Regex regex = new Regex("youtu\\.be", RegexOptions.IgnoreCase);

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (regex.IsMatch(line))
                        {
                            writer.WriteLine(replaceString);
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            Console.WriteLine("Файл успішно створено: " + simplifiedFileName);
        }
    }
}
"# lab1_asm" 
"# lab2" 
"# lab2.ipynb" 
