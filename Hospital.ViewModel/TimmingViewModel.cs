using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class TimmingViewModel
    {
        public int Id { get; set; }
        public ApplecationUser DooctorId { get; set; }
        public DateTime DateTime { get; set; }
        public int MornningShiftStrartingTime { get; set; }
        public int MornningShiftEndingTime { get; set; }
        public int afternoonShiftStrartingTime { get; set; }
        public int afternoonShiftEndingTime { get; set; }
        public int Duratoin { get; set; }
        public Status Status { get; set; }
        List<SelectListItem> MornningShiftStrart { get; set; } = new List<SelectListItem>();
        List<SelectListItem> MornningShiftEnd { get; set; } = new List<SelectListItem>();
        List<SelectListItem> afternoonShiftStrart { get; set; } = new List<SelectListItem>();
        List<SelectListItem> afternoonShiftEnd { get; set; } = new List<SelectListItem>();
        public bool IsDoctor { get; set; }
        public TimmingViewModel()
        {

        }
        public TimmingViewModel(Timing model)
        {
            Id = model.Id;
            DooctorId = model.DooctorId;
            DateTime = model.DateTime;
            MornningShiftEndingTime = model.MornningShiftEndingTime;
            MornningShiftStrartingTime = model.MornningShiftStrartingTime;
            afternoonShiftEndingTime = model.afternoonShiftEndingTime;
            afternoonShiftStrartingTime = model.afternoonShiftStrartingTime;
            Duratoin = model.Duratoin;
            Status = model.Status;
        }
        public Timing ConvertViewModel(TimmingViewModel model)
        {
            return new Timing
            {
                Id = model.Id,
                DooctorId = model.DooctorId,
                DateTime = model.DateTime,
                MornningShiftEndingTime = model.MornningShiftEndingTime,
                MornningShiftStrartingTime = model.MornningShiftStrartingTime,
                afternoonShiftEndingTime = model.afternoonShiftEndingTime,
                afternoonShiftStrartingTime = model.afternoonShiftStrartingTime,
                Duratoin = model.Duratoin,
                Status = model.Status

        };
} } }
