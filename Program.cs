using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_to_csv
{
    class Program
    {
        static void Main(string[] args)
        {
            //filepath to downloaded pdf
            string filePath = @"C:\Users\JSBru\OneDrive\Desktop\pdfcsvprojectfiles\OMMA Growers List.pdf";

            //fetching pdf file from filepath
            Console.WriteLine(File.ReadAllText(filePath));

            
            
        
            
            
            addLine("Jimmy", "12345", "jimmy@Gmail.com", "123-456-7891", "medicine hat", "toj2p0", "alberta", "updatedCsv.txt");
        }

        public static void addLine(string name, string licenseNo, string email, string phone, string city, string zip, string county, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(name + ',' + licenseNo + ',' + email + ',' + phone + ',' + city + ',' + zip + ',' + county);
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("There was an error :", ex);
            }
        }
        
        
    }
}
