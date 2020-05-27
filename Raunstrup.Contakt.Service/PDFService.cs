using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf; //To be used for creating PDF
using PdfSharp.Drawing; //to be used for creating PDF
//using System.Drawing;
using Raunstrup.Contakt.Service.Interface;
using Raunstrup.Contract.DTOs;
using System.Reflection;
using Raunstrup.DataAccess.Model;
//using Raunstrup.DataAccess;

namespace Raunstrup.Contakt.Service
{
    public class PDFservice : IPDFService
    {
        public string CreatePDF(ProjectDetailsDto project)
        {
            // Her bruges classen pdfDocument.
            PdfDocument document = new PdfDocument();

            // Her laver jeg et pdf dokument og kalder det Faktura
            document.Info.Title = "Tilbud";

            // Her laves en side
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Opret skrift størelse og stil
            XFont companyAndDebtor = new XFont("Calibri", 10, XFontStyle.Regular);
            XFont tilbud = new XFont("Calibri", 15, XFontStyle.Bold);
            XFont beskrivelse = new XFont("Calibri", 15, XFontStyle.Bold);
            XFont smallHeadLine = new XFont("Calibri", 10, XFontStyle.Bold);

            // Draw the text. Dette er hvad der skal være på teksten, og hvor det skal være. Der kan laves lige så mange som man vil 
            //Kunde Oplysninger------------------------------------------------------------------------------------------------------------------------------
            if (project == null)
            {

            }
            else
            {
                
                gfx.DrawString(project.Customer.Name, companyAndDebtor, XBrushes.Black,
                new XRect(80, -270, page.Width, page.Height),
                XStringFormats.CenterLeft);

                gfx.DrawString(project.Customer.Address, companyAndDebtor, XBrushes.Black,
                     new XRect(80, -260, page.Width, page.Height),
                     XStringFormats.CenterLeft);

                gfx.DrawString(project.Customer.Email, companyAndDebtor, XBrushes.Black,
                    new XRect(80, -250, page.Width, page.Height),
                    XStringFormats.CenterLeft);

                gfx.DrawString(project.Customer.Phone, companyAndDebtor, XBrushes.Black,
                 new XRect(80, -230, page.Width, page.Height),
                 XStringFormats.CenterLeft);
            }
            gfx.DrawString( ("Dato: " + DateTime.Now.ToShortDateString()), companyAndDebtor, XBrushes.Black,
                new XRect(80, -200, page.Width, page.Height),
                XStringFormats.CenterLeft);

            //FAKTURA---------------------------------------------------------------------------------------------------------------------------------------
            

            gfx.DrawString((project.Description.ToString()), smallHeadLine, XBrushes.Black,
               new XRect(80, -150, page.Width, page.Height),
               XStringFormats.CenterLeft);

            //Firma informationer----------------------------------------------------------------------------------------------------------------------------
            gfx.DrawString("Raunstrup A/S", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -300, page.Width, page.Height),
                XStringFormats.CenterRight);

            gfx.DrawString("Karetmagervej 10b", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -290, page.Width, page.Height),
                XStringFormats.CenterRight);

            gfx.DrawString("7100 Vejle", companyAndDebtor, XBrushes.Black,
                new XRect(-60, -280, page.Width, page.Height),
                XStringFormats.CenterRight);

            //Navn på vare antal pris beløb-------------------------------------------------------------------------------------------------------------
            //varens navn
            gfx.DrawString("Beskrivelse", smallHeadLine, XBrushes.Black,
                new XRect(80, -125, page.Width, page.Height),
                XStringFormats.CenterLeft);

            gfx.DrawString("Startdato: " + (project.StartDate.ToShortDateString()), companyAndDebtor, XBrushes.Black,
                new XRect(80, -115, page.Width, page.Height),
                XStringFormats.CenterLeft);

            gfx.DrawString("Slutdato: " + (project.EndDate.ToShortDateString()), companyAndDebtor, XBrushes.Black,
                new XRect(80, -105, page.Width, page.Height),
                XStringFormats.CenterLeft);

            //Materialer

            gfx.DrawString("Materialer", smallHeadLine, XBrushes.Black,
               new XRect(80, -90, page.Width, page.Height),
               XStringFormats.CenterLeft);

            gfx.DrawString("Vare", companyAndDebtor, XBrushes.Black,
            new XRect(80, -80, page.Width, page.Height),
            XStringFormats.CenterLeft);

            //Antal 
            gfx.DrawString("Antal", companyAndDebtor, XBrushes.Black,
                new XRect(-80, -80, page.Width, page.Height),
                XStringFormats.Center);

            //Stykpris
            gfx.DrawString("Stykpris i kr", companyAndDebtor, XBrushes.Black,
               new XRect(60, -80, page.Width, page.Height),
               XStringFormats.Center);

            //Stykpris
            gfx.DrawString("Rabat", companyAndDebtor, XBrushes.Black,
               new XRect(130, -80, page.Width, page.Height),
               XStringFormats.Center);

            //I alt
            //gfx.DrawString("I alt", companyAndDebtor, XBrushes.Black,
            //   new XRect(200, -90, page.Width, page.Height),
            //   XStringFormats.Center);



            gfx.DrawString("___________________________________________________________________________________________ ", smallHeadLine, XBrushes.Black,
                new XRect(80, -75, page.Width, page.Height),
                XStringFormats.CenterLeft);

            int lineSpace = 0;
            int counter = 0;
            for (int i = 0; i < project.AssignedItems.Count; i++)
            {
                counter++;
                //Her bliver Variablen sat til 15. så hver gange der bliver kørt GetLeaseOrders(tilføjet en ny vare linje bliver der pludset 15 til y aksens position)
                lineSpace = 15 * i;

                //varens navn
                gfx.DrawString(project.AssignedItems[i].Item.Name, companyAndDebtor, XBrushes.Black,
                new XRect(80, -65 + lineSpace, page.Width, page.Height),
                XStringFormats.CenterLeft);

                //Antal 
                gfx.DrawString(project.AssignedItems[i].Amount.ToString(), companyAndDebtor, XBrushes.Black,
                    new XRect(-80, -65 + lineSpace, page.Width, page.Height),
                    XStringFormats.Center);

                

                //Stykpris
                gfx.DrawString((project.AssignedItems[i].Price.ToString()), companyAndDebtor, XBrushes.Black,
                   new XRect(60, -65 + lineSpace, page.Width, page.Height),
                   XStringFormats.Center);

                //rabat

                gfx.DrawString((calculateDiscount(project.AssignedItems[i]).ToString()), companyAndDebtor, XBrushes.Black,
                    new XRect(130, -65 + lineSpace, page.Width, page.Height),
                    XStringFormats.Center);


                //I alt



            }
            decimal priceSum = project.TotalAssignedItems;
            gfx.DrawString(("Ialt " + priceSum.ToString() + " Kr"), companyAndDebtor, XBrushes.Black,
               new XRect(200, -55 + lineSpace, page.Width, page.Height),
               XStringFormats.Center);



            //Timer

            

            gfx.DrawString("Timer", smallHeadLine, XBrushes.Black,
                    new XRect(80, 15*counter-50, page.Width, page.Height),
                    XStringFormats.CenterLeft);

            

            gfx.DrawString("Antal timer", companyAndDebtor, XBrushes.Black,
                    new XRect(80, 15*counter-40, page.Width, page.Height),
                    XStringFormats.CenterLeft);

            gfx.DrawString("___________________________________________________________________________________________ ", smallHeadLine, XBrushes.Black,
               new XRect(80, 15*counter-35, page.Width, page.Height),
               XStringFormats.CenterLeft);

            gfx.DrawString((calculateHours(project.ProjectEmployees).ToString()), companyAndDebtor, XBrushes.Black,
                    new XRect(80, 15 * counter-20, page.Width, page.Height),
                    XStringFormats.CenterLeft);

            //gfx.DrawString("Pris ialt", companyAndDebtor, XBrushes.Black,
            //    new XRect(200, -40, page.Width, page.Height),
            //    XStringFormats.CenterLeft);


           
            decimal HoursSum = project.TotalAssignedHours;
            gfx.DrawString(("Ialt " + HoursSum.ToString() + " Kr"), companyAndDebtor, XBrushes.Black,
               new XRect(200, 15 + lineSpace-10, page.Width, page.Height),
               XStringFormats.Center);


            gfx.DrawString(("Samlet pris "+(HoursSum+priceSum)+" Kr"), companyAndDebtor, XBrushes.Black,
               new XRect(185, 15 + lineSpace+20, page.Width, page.Height),
               XStringFormats.Center);


          

            //Her Laves navnet på filen
            string filename = "Tilbud" + project.Id.ToString() + DateTime.Now.ToShortDateString()+ ".pdf";

            
            //Dette er til at gemme pdf
            
            document.Save(filename);
            return filename;
          

            
        }
        private decimal calculateDiscount(ProjectAssignedItemDto projectAssignedItemDto)
        {
            if (projectAssignedItemDto.Item.Discounts == null || projectAssignedItemDto.Amount < projectAssignedItemDto.Item.Discounts.Amount)
            {
                return 0;
            }
            else
            {
                return Math.Round((projectAssignedItemDto.Amount * projectAssignedItemDto.Price) * projectAssignedItemDto.Item.Discounts.DiscountPercentage / 100, 2);
            }

        }
        private int calculateHours(List<ProjectEmployeeDto> projectEmployeeDtos)
        {
            int sum = 0;
            foreach (var item in projectEmployeeDtos)
            {
                sum += item.EstWorkingHours;


            }
            return sum;
        }


    }

}




