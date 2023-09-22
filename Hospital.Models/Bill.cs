namespace Hospital.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string BillNumber { get; set; }
        public ApplecationUser Patiant {  get; set; }
        public Insurance Insurance { get; set; }
        public int DoctorCharge { get; set; }
        public int NursingCharge { get; set; }
        public int LapCharge { get; set; }

        public decimal MedicineCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal OperationCharge { get; set; }
        public int NoOfDay { get; set; }
        public decimal Advance { get; set; }
        public decimal TotalBill { get; set; }
   
    }
}