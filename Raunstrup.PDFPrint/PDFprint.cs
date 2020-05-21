using System;
//using Raunstrup.UI.Models;
using Raunstrup.Contract.DTOs;
using System.Threading.Tasks;
using Raunstrup.PDFPrint.Interface;
using System.Web.Mvc;

namespace Raunstrup.PDFPrint
{
    public class PDFPrint: IPDFPrint
    { 
    public ActionResult GeneratePDF()
    {
        return View();
    }

    [HttpPost]
    public ActionResult DownloadPDF()
    {
        string inputText = Request.Form["inputText"];
        string checkedValues = Request.Form["checkedValues"];

        using (MemoryStream ms = new MemoryStream())
        {
            Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, BaseColor.BLUE);
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();
            doc.Add(new Paragraph(inputText));
            doc.Add(new Paragraph(checkedValues));
            doc.Close();
            byte[] bytes = ms.ToArray();
            ms.Close();

            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=Employee.pdf");
            //Response.ContentType = "application/pdf";
            //Response.Buffer = true;
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.BinaryWrite(bytes);
            //Response.End();
            //Response.Close();

            return File(bytes, "application/pdf", "fileName.pdf");
        }
    }
}