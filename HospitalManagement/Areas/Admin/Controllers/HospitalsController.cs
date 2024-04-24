using Hospital.Models;
using Hospital.Repositories;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace HospitalManagement.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HospitalsController : Controller
    {
        private const string accountSid = "AC672275a3050b593aeedf43c32a107d65";
        private const string authToken = "6d84a16fc0f3dcbd042cffff5efcdc3b";
        private const string twilioPhoneNumber = "+14153197531";
        private IHospitalInfo _hospitalInfo;
        private readonly ApplicationDbContext _context;

        public HospitalsController(IHospitalInfo hospitalInfo, ApplicationDbContext context)
        {
            _hospitalInfo = hospitalInfo;
            _context = context;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_hospitalInfo.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _hospitalInfo.GetHospitalById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(HospitalInfoViewModel vm)
        {
            _hospitalInfo.UpdateHospitalInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(HospitalInfoViewModel vm)
        {
            _hospitalInfo.InsertHospitalInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _hospitalInfo.DeleteHospitalInfo(id);
            return RedirectToAction("Index");
        }
        public IActionResult SendSMS()
        {
            SendSMSViewModel vm = new SendSMSViewModel();
            ViewBag.Hospital = new SelectList(_context.HospitalInfos, "Id", "Name");
            return View(vm);
        }

        // POST: Twilio/SendSMS
        [HttpPost]
        public IActionResult SendSMS(string to, SendSMSViewModel model)
        {
            try
            {
                // Initialize Twilio client
                TwilioClient.Init(accountSid, authToken);
                Random random = new Random();
                int tokenNumber = random.Next(1, 20);
                // Send SMS message
                var smsMessage = MessageResource.Create(
                    body: $"Appointment scheduled for {model.PatientName} on {model.Date} {model.Time}. Your token number is {tokenNumber}.",
                    from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(to)
                );

                ViewBag.Message = "SMS sent successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }

            return View();
        }
    }
}
