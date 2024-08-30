namespace API.Services.Interfaces
{
    public interface IPDFService
    {
          public byte[] CreatePdf(string password, string username);
    }
}