namespace API.Services.Interfaces
{
    public interface IPDFService
    {
         // public byte[] CreatePdf(string password, string username);
         public  Task<byte[]> CreatePdfFromUserDataAsync(string userId);
         public  Task<byte[]> CreateDriverLicensePdfFromUserDataAsync(string userId);
    }
}