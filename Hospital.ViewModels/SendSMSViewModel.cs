using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class SendSMSViewModel
    {
        public string To { get; set; }
        public string Message { get; set; }
        public string PatientName { get; set; }
        public int HospitalId { get; set; }
        public HospitalInfo Hospital { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }
}
