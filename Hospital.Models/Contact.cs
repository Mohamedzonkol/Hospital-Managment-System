namespace Hospital.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public HospitalInfo Hospital { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}