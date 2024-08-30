using API.Services.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace API.Services
{
    public class PDFService:IPDFService
    {
         public byte[] CreatePdf(string password, string username)
                {
            using (var memoryStream = new MemoryStream())
            {
               
                using (var writer = new PdfWriter(memoryStream))
                {
                 
                    using (var pdf = new PdfDocument(writer))
                    {
                       
                        var document = new Document(pdf);
                       
                        document.Add(new Paragraph("username: " + username));
                        document.Add(new Paragraph("password: " + password));
                       
                        document.Close();
                    }
                }
               
                return memoryStream.ToArray();
            }
    }
}
}