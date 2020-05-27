using System;

namespace PDFPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatePDF pdf = new CreatePDF();
            Console.WriteLine("Hello World!");

            pdf.makePDF();
        }
    }
}
