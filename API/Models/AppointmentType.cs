namespace API.Models
{
    public class AppointmentType
    {
        [Key]
        public string AppointmentTypeID { get; set; }
        public string AppointmentTypeName { get; set; }
    }
}