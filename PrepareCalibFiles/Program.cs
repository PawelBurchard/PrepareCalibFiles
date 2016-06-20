using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace editFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Studia\Hokuyo-Kinect\Pictures"; //insert write path to files
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] infos = d.GetFiles();
            long num = 1465679400;
            using (StreamWriter sw = File.CreateText(path + @"\laser.txt"))
            {
                foreach (FileInfo f in infos)
                {
                    if (f.FullName.IndexOf("laser") != -1)
                    {
                        using (StreamReader sr = File.OpenText(f.FullName))
                        {

                            string s = sr.ReadLine(); 
                            string s2 = "";
                            s = s.Remove(0, 12);
                            string sDist = s.Remove(0, 34);

                            string[] distances = sDist.Split(',');
                            string pyk;
                            for (int i = 0; i < 256; i++)
                            {
                                pyk = distances[510 - i];
                                distances[510 - i] = distances[i];
                                distances[i] = pyk;

                            }
                            for (int i = 0; i < 511; i++)
                            {
                                if (i != 510)
                                    s2 = s2 + distances[i] + ',';
                                else
                                    s2 = s2 + distances[i];
                            }
                            s = s.Insert(0, num.ToString());
                            s = s.Substring(0, 43);
                            s = s + s2;
                            sw.WriteLine(s);
                            num += 10;
                        }
                    }
                }
            }
            num = 1465679400;
            using (StreamWriter sw2 = File.CreateText(path + @"\camera.txt"))
            {
                foreach (FileInfo f in infos)
                {
                    if (f.FullName.IndexOf("camera") != -1)
                    {
                        using (StreamReader sr = File.OpenText(f.FullName))
                        {
                            string s = sr.ReadLine();
                            sw2.WriteLine(num.ToString());
                            num += 10;
                        }
                    }
                }
            }
        }
    }
}