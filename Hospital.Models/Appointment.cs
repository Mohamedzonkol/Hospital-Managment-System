namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public ApplecationUser Doctor { get; set; }
        public ApplecationUser Patiant { get; set; }
       

    }
}