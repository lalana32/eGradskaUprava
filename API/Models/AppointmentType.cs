namespace API.Models
{
    public class AppointmentType
    {
        [Key]
        public int AppointmentTypeID { get; set; }
        public string AppointmentTypeName { get; set; }
    }
}