using System;
using System.IO;
using System.Threading.Tasks;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Identity;
using API.Models;
using API.Services.Interfaces;
using System.Text;


public class PDFService : IPDFService
{
    private readonly UserManager<User> _userManager;

    public PDFService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

   public async Task<byte[]> CreatePdfFromUserDataAsync(string userId)
{
    var user = await _userManager.FindByIdAsync(userId);
    if (user == null)
    {
        throw new Exception("User not found");
    }

    // HTML template
    var htmlTemplate = @"
    <!DOCTYPE html>
    <html lang='bs'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>PRIMJERAK CIPS PRIJAVNICE</title>
        <style>
            body { font-family: Arial, sans-serif; background-color: #f5f5f5; margin: 0; padding: 20px; }
            .form-container { max-width: 800px; margin: auto; padding: 20px; background-color: #ffffff; border: 1px solid #dddddd; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1); }
            h1, h2 { text-align: center; color: #333333; }
            h1 { margin-bottom: 20px; }
            h2 { margin: 20px 0; }
            .section-top, .section-middle, .section-main { margin-bottom: 20px; }
            .row { display: flex; justify-content: space-between; margin-bottom: 10px; }
            label { flex: 1; margin-right: 10px; font-weight: bold; }
            input[type='text'], input[type='date'] { flex: 2; padding: 5px; border: 1px solid #cccccc; border-radius: 4px; }
            p { text-align: center; margin-bottom: 20px; font-style: italic; color: #666666; }
            .legal-section { margin-top: 30px; font-size: 14px; color: #555555; border-top: 1px solid #dddddd; padding-top: 20px; }
            .consent-section { margin-top: 20px; font-size: 14px; }
        </style>
    </head>
    <body>
        <div class='form-container'>
            <h1>PRIMJERAK CIPS PRIJAVNICE</h1>
            <section class='section-top'>
                <div class='row'>
                    <label>Naziv organa:</label>
                    <input type='text' name='nazivOrgana' value='{0}' readonly>
                </div>
                <div class='row'>
                    <label>Broj:</label>
                    <input type='text' name='broj' value='{1}' readonly>
                </div>
                <div class='row'>
                    <label>Datum:</label>
                    <input type='date' name='datum' value='{2}' readonly>
                </div>
            </section>
            <section class='section-middle'>
                <div class='row'>
                    <label>Ime:</label>
                    <input type='text' name='ime' value='{3}' readonly>
                </div>
                <div class='row'>
                    <label>Prezime:</label>
                    <input type='text' name='prezime' value='{4}' readonly>
                </div>
            </section>
            <section class='section-main'>
                <h2>OBAVJEŠTENJE / OBAVIJEST / ОБАВЈЕШТЕЊЕ</h2>
                <p>da je uveden u evidenciju prebivališta-boravišta sa ličnim/osobnim podacima / да је уведен у евиденцију пребивалишта-боравишта са личним подацима</p>
                <div class='row'>
                    <label>JMB/МБ:</label>
                    <input type='text' name='jmb' value='{5}' readonly>
                </div>
                <div class='row'>
                    <label>Ime/Име:</label>
                    <input type='text' name='ime2' value='{6}' readonly>
                </div>
                <div class='row'>
                    <label>Prezime/Презиме:</label>
                    <input type='text' name='prezime2' value='{7}' readonly>
                </div>
                <div class='row'>
                    <label>Spol/Пол:</label>
                    <input type='text' name='spol' value='{8}' readonly>
                </div>
                <div class='row'>
                    <label>Datum rođenja:</label>
                    <input type='date' name='datumRodjenja' value='{9}' readonly>
                </div>
                <div class='row'>
                    <label>Općina prebivališta/Општина пребивалишта:</label>
                    <input type='text' name='opcinaPrebivalista' value='{10}' readonly>
                </div>
                <div class='row'>
                    <label>Adresa prebivališta/Адреса пребивалишта:</label>
                    <input type='text' name='adresaPrebivalista' value='{11}' readonly>
                </div>
            </section>
            <section class='legal-section'>
                <h2>Zakonska regulativa</h2>
                <p>Prikupljanje, obrada, i čuvanje podataka u ovoj prijavnici vrši se u skladu sa Zakonom o zaštiti ličnih podataka Bosne i Hercegovine ('Službeni glasnik BiH', br. 49/06, 76/11) i Zakonom o prebivalištu i boravištu državljana Bosne i Hercegovine ('Službeni glasnik BiH', br. 32/01, 56/08, 58/15).</p>
                <p>Podaci iz ove prijavnice koriste se isključivo za potrebe evidentiranja prebivališta-boravišta i neće biti korišteni u druge svrhe bez vaše saglasnosti, osim u slučajevima predviđenim zakonom.</p>
            </section>
            <section class='consent-section'>
                <h2>Saglasnost</h2>
                <p>Molimo vas da potvrdite vašu saglasnost za obradu podataka u skladu sa navedenim zakonskim propisima:</p>
                <div class='row'>
                    <input type='checkbox' name='consent' id='consent'>
                    <label for='consent'>Saglasan/saglasna sam sa obradom mojih ličnih podataka.</label>
                </div>
            </section>
        </div>
    </body>
    </html>";

    // Formatiraj HTML sa korisničkim podacima
    var formattedHtml = string.Format(htmlTemplate,
        "Naziv organa", // Replace with actual data
        "Broj",         // Replace with actual data
        "Datum",        // Replace with actual data
        user.FirstName,
        user.LastName,
        user.JMBG,
        user.FirstName,
        user.LastName,
        user.Pol,
        user.DatumRodjenja.ToString("yyyy-MM-dd"),
        user.OpstinaPrebivalista,
        user.AdresaPrebivalista);

    using (var memoryStream = new MemoryStream())
    {
        using (var pdfWriter = new PdfWriter(memoryStream))
        {
            using (var pdfDocument = new PdfDocument(pdfWriter))
            {
                // Convert HTML to PDF using the memory stream
                HtmlConverter.ConvertToPdf(new MemoryStream(Encoding.UTF8.GetBytes(formattedHtml)), pdfDocument);
            }
        }

        return memoryStream.ToArray();
    }
}

    
}
