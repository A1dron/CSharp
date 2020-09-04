using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GenID
    {
        public string id;
        public GenID(string id)
        {
            this.id = id;
            AddID(id);
        }

        public void AddID(string id)
        {
            string path = @"D:\t.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == id) 
                    {
                        int i = Convert.ToInt32(id);
                        i++;
                        id = i.ToString();
                    }
                }
                sr.Close();
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    sw.WriteLine(id);
                }

            }
            
            
        }
    }
}
