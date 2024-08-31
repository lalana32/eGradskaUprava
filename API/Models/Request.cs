namespace API.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set;}
        public DateTime CreatedAt { get; set;} = DateTime.Now;
        public bool Approved { get; set; } = false;

        public ICollection<RequestType> RequestTypeList{ get; set;}
    }
}