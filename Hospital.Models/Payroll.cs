namespace Hospital.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public  ApplecationUser EmloyerId { get; set; }
        public decimal Salary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal BounsSalary { get; set; }
        public decimal Compensataion { get; set; }
        public string AccountNoumber { get; set; }
    }
}