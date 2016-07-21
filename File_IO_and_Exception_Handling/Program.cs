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
* Version: 0.0.4 - added all comments
*/

namespace File_IO_and_Exception_Handling
{
    /** 
  * <summary> 
  * This is the driver class for read text file and handle exceptions 
  * </summary> 
  *  
  * @class Program 
  */

    class Program
    {
        //PRIVATE INSTANCE VARIABLE+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static List<List<string>> _studentData = new List<List<string>>();

        //MAIN MATHOD+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * The main method for our driver class Program
        * </summary>
        * @method Main
        * @param {sting[]} args
        * @returns {void}
        */
        static void Main(string[] args)
        {
            _programMenu();
            
        }
        //PRIVATE MATHODS+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This method creates option to select program menue
        * </summary>
        * @method _programMenu
        * @field {sting} choice
        * @returns {void}
        */
        private static void _programMenu()
        {
            string choice;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                _displayMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _readFile();
                        _displaRecords();
                        break;
                    case "2":
                        Console.WriteLine("\nThank you for using this program");
                        break;
                    default:
                        Console.WriteLine("Error in entry");
                        break;

                }

            } while (choice != "2");


        }
        /**
        * <summary>
        * This method display program menue
        * </summary>
        * @method _displayMenu
        * @returns {void}
        */
        private static void _displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=============Student Information System===================");
            Console.WriteLine("|         1. Display Grade                               |");
            Console.WriteLine("|         2. Exit                                        |");
            Console.WriteLine("==========================================================\n");
            Console.Write("{0,15}", "Enter the number of your choice -> ");
        }

        /**
         * <summary>
         * This method read data from files
         * </summary>
         * @method _readFile
         * @field {const string} FILENAME
         * @field {const char} DELIM
         * @field {FileStream} fileStream
         * @field {StreamReader} streamReader
         * @field {string} recordString
         * @field {string[]} recordArray
         * @field {int} counter
         * @returns {void}
         */
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
        /**
        * <summary>
        * This method display records of file
        * </summary>
        * @method _displayMenu
        * @returns {void}
        */
        private static void _displaRecords()
        {
            try
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < _studentData.Count; i++)
                {
                    Console.WriteLine("{0}, {1}: {2} {3}, {4}", _studentData[i][1],
                        _studentData[i][2], _studentData[i][0], _studentData[i][3], _studentData[i][1]);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
                
            }
            Console.WriteLine();
        }
    }
}
