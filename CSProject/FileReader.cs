using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSProject
{
    class FileReader
    {

        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] seperator = { "," };

            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.EndOfStream != true)
                        {
                            result = sr.ReadLine().Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                            if (result[1] == "Manager")
                                myStaff.Add(new Manager(result[0]));//**

                            else if (result[1] == "Admin")
                                myStaff.Add(new Admin(result[0]));//**
                            
                        }
                        sr.Close();
                    }
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return myStaff;
        } 
    }
}
