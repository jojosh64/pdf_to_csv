using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;


namespace pdf_to_csv
{
    public class ParseCzech
    {
        public static readonly String DEST = @"C:\Users\JSBru\OneDrive\Desktop\pdfcsvprojectfiles\parsed_pdf.txt";

        public static readonly String SRC = @"C:\Users\JSBru\OneDrive\Desktop\pdfcsvprojectfiles\OMMA Growers List.pdf";

        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            new ParseCzech().ManipulatePdf(DEST);

            //addLine("Jimmy", "12345", "jimmy@Gmail.com", "123-456-7891", "medicine hat", "toj2p0", "alberta", "updatedCsv.txt");
        }

        protected virtual void ManipulatePdf(String dest)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(SRC));

            LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();

            
                PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
                    
                parser.ProcessPageContent(pdfDoc.GetFirstPage());

                byte[] array = Encoding.UTF8.GetBytes(strategy.GetResultantText());
                using (FileStream stream = new FileStream(dest, FileMode.Create))
                {
                    stream.Write(array, 0, array.Length);
                    
                }
                
            
            pdfDoc.Close();
        }
    }

       
        
        /*public static void addLine(string name, string licenseNo, string email, string phone, string city, string zip, string county, string filepath)
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
        }*/
        
        
    }


