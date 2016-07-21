using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*  
*Author: Md Mamunur Rahman  
* Student ID: 300872772   
*  
* Date last modified: July 20, 2016  
* Description: This program read text file and handle exceptions   
*   
* Version: 0.0.3 - added displayRecord method
*/

namespace File_IO_and_Exception_Handling
{
    class Program
    {
        private static List<List<string>> _studentData = new List<List<string>>();

        static void Main(string[] args)
        {
            _readFile();
            _displaRecords();
            Console.ReadKey();
        }

        private static void _readFile()
        {
             try
             {
            const string FILENAME = "..\\..\\grade.txt";
            const char DELIM = ',';

            //Opening filestream
            FileStream fileStream = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);

            StreamReader streamReader = new StreamReader(fileStream);


            // temporary data holder
            string recordString;
            string[] recordArray;


            recordString = streamReader.ReadLine();

            int counter = 0;
            while (recordString != null)
            {
                _studentData.Add(new List<string>());

                recordArray = recordString.Split(DELIM);
                foreach (string record in recordArray)
                {
                    _studentData[counter].Add(record);

                }
                counter++;
                recordString = streamReader.ReadLine();
            }


                streamReader.Close();
                fileStream.Close();
            }
             catch (Exception exception)
             {
                Console.WriteLine("Error: " + exception.Message);

            }

            
        }

        private static void _displaRecords()
        {
            for (int i = 0; i < _studentData.Count; i++)
            {
                Console.WriteLine("{0}, {1}: {2} {3}, {4}", _studentData[i][1],
                    _studentData[i][2], _studentData[i][0], _studentData[i][3], _studentData[i][1]);
            }
        }
    }
}
