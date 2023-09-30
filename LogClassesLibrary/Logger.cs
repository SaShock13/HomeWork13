using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkillboxHomework10_1
{
    public class Logger
    {
        private string path="log.txt";
        public void LogMessage(string message)
        {
            //MessageBox.Show($"Логгер пишет в файл сообщение {message}");
            string spliter = $"-----";
            bool isAppend=false ;
            if (File.Exists(path))
            {
                isAppend = true;
            }

            using (StreamWriter sw = new StreamWriter(path, isAppend))
            {
                

                sw.WriteLine(message);
                sw.WriteLine(spliter);

            }

        }

    }
}
