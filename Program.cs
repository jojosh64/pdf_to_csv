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

            getTextFromPdf(DEST);

            textToString(DEST);
            
        }

        //converting pdf to a txt file
        public static void getTextFromPdf(String dest)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(SRC));

            SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                
                PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
            for (var i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {

                parser.ProcessPageContent(pdfDoc.GetPage(i));

                byte[] array = Encoding.UTF8.GetBytes(strategy.GetResultantText());
                using (FileStream stream = new FileStream(dest, FileMode.OpenOrCreate))
                {
                    
                    stream.Write(array, 0, array.Length);
                    
                }
            } 
        }

        //parsing txt file to a string
        public static void textToString(string filepath)
        {
            using (StreamReader sr = File.OpenText(DEST))
            {
                string text = "";
                while ((text = sr.ReadLine()) != null)
                {
                    Console.WriteLine(text);
                }
            }
        }

        public static void toCSV(string text)
        {
            
        }
        

       }
    }


