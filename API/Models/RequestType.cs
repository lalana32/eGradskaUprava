namespace API.Models
{
    public class RequestType
    {
        [Key]
        public int RequestTypeID { get; set; }
        public string RequestTypeName { get; set; }
        public ICollection<RequestSubtype> RequestTypeList{ get; set;}
    }
}