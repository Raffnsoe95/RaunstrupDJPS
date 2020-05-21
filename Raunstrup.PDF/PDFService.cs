using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf; //To be used for creating PDF
using PdfSharp.Drawing; //to be used for creating PDF
using Raunstrup.PDF.Interface;
using Raunstrup.Contract.DTOs;

namespace PDFService
{
    public class PDFservice : IPDFService
    {
        public void CreatePDF(PDFDto pdf)
        {
            // Her bruges classen pdfDocument.
            PdfDocument document = new PdfDocument();

            // Her laver jeg et pdf dokument og kalder det Faktura
            document.Info.Title = "Faktura";

            // Her laves en side
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Opret skrift størelse og stil
            XFont companyAndDebtor = new XFont("Calibri", 10, XFontStyle.Regular);
            XFont fakture = new XFont("Calibri", 20, XFontStyle.Bold);
            XFont smallHeadLine = new XFont("Calibri", 10, XFontStyle.Bold);
            XFont priceFat = new XFont("Calibri", 10, XFontStyle.Bold);

            // Draw the text. Dette er hvad der skal være på teksten, og hvor det skal være. Der kan laves lige så mange som man vil 
            //Kunde Oplysninger------------------------------------------------------------------------------------------------------------------------------
            if (sale.customer == null)
            {

            }
            else
            {
                gfx.DrawString((string)sale.customer.name, companyAndDebtor, XBrushes.Black,
                new XRect(80, -270, page.Width, page.Height),
                XStringFormats.CenterLeft);

                gfx.DrawString((string)sale.customer.address, companyAndDebtor, XBrushes.Black,
                     new XRect(80, -260, page.Width, page.Height),
                     XStringFormats.CenterLeft);

                gfx.DrawString((string)sale.customer.email, companyAndDebtor, XBrushes.Black,
                    new XRect(80, -250, page.Width, page.Height),
                    XStringFormats.CenterLeft);

                gfx.DrawString((string)sale.customer.phone, companyAndDebtor, XBrushes.Black,
                 new XRect(80, -230, page.Width, page.Height),
                 XStringFormats.CenterLeft);
            }

            //FAKTURA---------------------------------------------------------------------------------------------------------------------------------------
            gfx.DrawString("FAKTURA", fakture, XBrushes.Black,
                new XRect(80, -170, page.Width, page.Height),
                XStringFormats.CenterLeft);

            //Billede af Firmallogo---------------------------------------------------------------------------------------
            //Mangler


            //Firma informationer----------------------------------------------------------------------------------------------------------------------------
            gfx.DrawString("Raunstrup", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -300, page.Width, page.Height),
                XStringFormats.CenterRight);

            gfx.DrawString("Karetmagervej 10b", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -290, page.Width, page.Height),
                XStringFormats.CenterRight);

            gfx.DrawString("7100 Vejle", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -280, page.Width, page.Height),
                XStringFormats.CenterRight);


            //BankOplysninger------------------------------------------------------------------------------------------------------------------------------
            gfx.DrawString("Bank ", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -250, page.Width, page.Height),
                XStringFormats.CenterRight);

            gfx.DrawString("Reg. Nr:3141", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -240, page.Width, page.Height),
                XStringFormats.CenterRight);

            gfx.DrawString("Konto Nr:5926535897932384 ", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -230, page.Width, page.Height),
                XStringFormats.CenterRight);

            gfx.DrawString("Ordrenummer " + sale.saleID.ToString(), companyAndDebtor, XBrushes.Black,
               new XRect(-60, -180, page.Width, page.Height),
               XStringFormats.CenterRight);

            gfx.DrawString("Dato " + sale.salesDay.ToString("dd-MM-yyyy"), companyAndDebtor, XBrushes.Black,
              new XRect(-60, -170, page.Width, page.Height),
              XStringFormats.CenterRight);

            //Navn på vare antal pris beløb-------------------------------------------------------------------------------------------------------------
            //varens navn
            gfx.DrawString("Vare", companyAndDebtor, XBrushes.Black,
            new XRect(80, -130, page.Width, page.Height),
            XStringFormats.CenterLeft);

            //Antal 
            gfx.DrawString("Antal", companyAndDebtor, XBrushes.Black,
                new XRect(-80, -130, page.Width, page.Height),
                XStringFormats.Center);

            //Stykpris
            gfx.DrawString("Stykpris", companyAndDebtor, XBrushes.Black,
               new XRect(90, -130, page.Width, page.Height),
               XStringFormats.Center);

            //I alt
            gfx.DrawString("I alt", companyAndDebtor, XBrushes.Black,
               new XRect(200, -130, page.Width, page.Height),
               XStringFormats.Center);

            gfx.DrawString("___________________________________________________________________________________________ ", smallHeadLine, XBrushes.Black,
                new XRect(80, -125, page.Width, page.Height),
                XStringFormats.CenterLeft);

            int lineSpace = 0;
            for (int i = 0; i < sale.saleLineItems.Count; i++)
            {
                //Her bliver Variablen sat til 15. så hver gange der bliver kørt GetLeaseOrders(tilføjet en ny vare linje bliver der pludset 15 til y aksens position)
                lineSpace = 15 * i;

                //varens navn
                gfx.DrawString((string)sale.saleLineItems[i].item.name, companyAndDebtor, XBrushes.Black,
                new XRect(80, -110 + lineSpace, page.Width, page.Height),
                XStringFormats.CenterLeft);

                //Antal 
                gfx.DrawString(sale.saleLineItems[i].amount.ToString(), companyAndDebtor, XBrushes.Black,
                    new XRect(-80, -110 + lineSpace, page.Width, page.Height),
                    XStringFormats.Center);

                //Stykpris
                gfx.DrawString((sale.saleLineItems[i].price.ToString() + " Kr"), companyAndDebtor, XBrushes.Black,
                   new XRect(90, -110 + lineSpace, page.Width, page.Height),
                   XStringFormats.Center);

                //I alt
                decimal priceSum = sale.Price();
                gfx.DrawString((priceSum.ToString() + " Kr"), companyAndDebtor, XBrushes.Black,
                   new XRect(200, -110 + lineSpace, page.Width, page.Height),
                   XStringFormats.Center);
            }

            //Hvis det er erhvers person
            if (sale.customer != null)
            {
                if (sale.customer.GetType() == typeof(BusinessCustomer))
                {
                    gfx.DrawString("Total: ", priceFat, XBrushes.Black,
                        new XRect(400, -20 + lineSpace, page.Width, page.Height),
                        XStringFormats.CenterLeft);



                    gfx.DrawString(sale.Price() + " Kr", companyAndDebtor, XBrushes.Black,
                        new XRect(-60, -20 + lineSpace, page.Width, page.Height),
                        XStringFormats.CenterRight);

                    gfx.DrawString("___________________________ ", smallHeadLine, XBrushes.Black,
                        new XRect(400, -15 + lineSpace, page.Width, page.Height),
                        XStringFormats.CenterLeft);
                }

                else
                {
                    decimal momsPrice = sale.Moms();
                    decimal totalPriceInkMoms = sale.TotalPriceInkMoms();

                    gfx.DrawString("Netto: ", companyAndDebtor, XBrushes.Black,
                   new XRect(400, -20 + lineSpace, page.Width, page.Height),
                   XStringFormats.CenterLeft);

                    gfx.DrawString("Moms (25%): ", companyAndDebtor, XBrushes.Black,
                        new XRect(400, -5 + lineSpace, page.Width, page.Height),
                        XStringFormats.CenterLeft);

                    gfx.DrawString("Total ink. Moms: ", priceFat, XBrushes.Black,
                        new XRect(400, 10 + lineSpace, page.Width, page.Height),
                        XStringFormats.CenterLeft);

                    //Viser den totate nettopris
                    gfx.DrawString(sale.Price() + " Kr", companyAndDebtor, XBrushes.Black,
                        new XRect(-60, -20 + lineSpace, page.Width, page.Height),
                        XStringFormats.CenterRight);

                    //Viser prisen på momsen
                    gfx.DrawString(momsPrice.ToString() + " Kr", companyAndDebtor, XBrushes.Black,
                        new XRect(-60, -5 + lineSpace, page.Width, page.Height),
                        XStringFormats.CenterRight);


                    //viser den totale pris ink moms
                    gfx.DrawString(totalPriceInkMoms.ToString() + " Kr", priceFat, XBrushes.Black,
                        new XRect(-60, 10 + lineSpace, page.Width, page.Height),
                       XStringFormats.CenterRight);

                    gfx.DrawString("___________________________ ", smallHeadLine, XBrushes.Black,
                        new XRect(400, 15 + lineSpace, page.Width, page.Height),
                        XStringFormats.CenterLeft);
                }
            }
            else
            {
                decimal momsPrice = sale.Moms();
                decimal totalPriceInkMoms = sale.TotalPriceInkMoms();

                gfx.DrawString("Netto: ", companyAndDebtor, XBrushes.Black,
               new XRect(400, -20 + lineSpace, page.Width, page.Height),
               XStringFormats.CenterLeft);

                gfx.DrawString("Moms (25%): ", companyAndDebtor, XBrushes.Black,
                    new XRect(400, -5 + lineSpace, page.Width, page.Height),
                    XStringFormats.CenterLeft);

                gfx.DrawString("Total ink. Moms: ", priceFat, XBrushes.Black,
                    new XRect(400, 10 + lineSpace, page.Width, page.Height),
                    XStringFormats.CenterLeft);

                //Viser den totate nettopris
                gfx.DrawString(sale.Price() + " Kr", companyAndDebtor, XBrushes.Black,
                    new XRect(-60, -20 + lineSpace, page.Width, page.Height),
                    XStringFormats.CenterRight);

                //Viser prisen på momsen
                gfx.DrawString(momsPrice.ToString() + " Kr", companyAndDebtor, XBrushes.Black,
                    new XRect(-60, -5 + lineSpace, page.Width, page.Height),
                    XStringFormats.CenterRight);


                //viser den totale pris ink moms
                gfx.DrawString(totalPriceInkMoms.ToString() + " Kr", priceFat, XBrushes.Black,
                    new XRect(-60, 10 + lineSpace, page.Width, page.Height),
                   XStringFormats.CenterRight);

                gfx.DrawString("___________________________ ", smallHeadLine, XBrushes.Black,
                    new XRect(400, 15 + lineSpace, page.Width, page.Height),
                    XStringFormats.CenterLeft);
            }

            gfx.DrawString("___________________________________________________________________________________________ ", smallHeadLine, XBrushes.Black,
                new XRect(80, -100 + lineSpace, page.Width, page.Height),
                XStringFormats.CenterLeft);

            //Her Laves navnet på filen
            string filename = "Faktura" + sale.saleID.ToString() + ".pdf";

            //Dette er til at gemme pdf
            document.Save(filename);
        }
    }
}
