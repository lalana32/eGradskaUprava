namespace API.Models
{
    public class Municipality
    {
        [Key]
        public string ZipCode { get; set; }
        public string MunicipalityName { get; set; }
    }
}