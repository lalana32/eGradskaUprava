namespace API.Models
{
    public class RequestSubtype
    {
        [Key]
        public int RequestSubtypeID { get; set; }
        public string RequestSubtypeName { get; set; }
    }
}