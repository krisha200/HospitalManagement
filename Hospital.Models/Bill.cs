﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNo { get; set; }
        public ApplicationUser Patient { get; set; }
        public Insurance Insurance { get; set; }
        public int DoctorCharge { get; set; }
        public decimal MedicineCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal OperationCharge { get; set; }
        public int NoOfDays {  get; set; }
        public int NursingCharge { get; set; }
        public int LabCharge { get; set; }
        public decimal Advance {  get; set; }
        public decimal TotalBill{  get; set; }
    }
}
