using Capstonep2.Infrastructure.Domain;
using Capstonep2.Infrastructure.Domain.Models;
using Capstonep2.Infrastructure.Domain.Models.Enums;
using Capstonep2.Infrastructure.Domain.Security;
using Capstonep2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstonep2.Pages.Manage.Admin
{
    [Authorize(Roles = "admin")]
    public class ViewpatientModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;
        [BindProperty]
        public ViewModel View { get; set; }




        public ViewpatientModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }
        public IActionResult OnGet(Guid? id = null, Guid? crid =null)
        {

            ViewData["id"] = id;
            var patient = _context?.Patients?.Where(a => a.ID == id).FirstOrDefault();
            if (patient != null)
            {


                ViewData["address"] = patient.Address;
                ViewData["birthdate"] = patient.BirthDate.ToString("dd/MM/yyyy");
                ViewData["firstname"] = patient.FirstName;
                ViewData["middlename"] = patient.MiddleName;
                ViewData["lastname"] = patient.LastName;
                ViewData["gender"] = patient.Gender;

                

                var apptsRecords = _context.Appointments?.Where(a => a.PatientID == id).ToList();
                View.Appointments = apptsRecords;

              
                var consultations =_context?.ConsultationRecords?.ToList();
                View.ConsultationRecords= consultations;  

                var findings = _context?.Findings?.ToList();
                var prescriptions = _context?.Prescriptions?.ToList();

                View.Findings = findings;
                View.Prescriptions = prescriptions;




            }












            return Page();
        }

        public IActionResult OnPostNewRecord()
        {
            Guid NewR = Guid.NewGuid();
            Guid CRGuid = Guid.NewGuid();
           
            ConsultationRecord consultation = new ConsultationRecord()
            {
                ID = CRGuid,
                AppointmentID = NewR,
                PatientID = View.Patient.ID,
            };

            Appointment appointment = new Appointment()
            {
                ID = NewR,
                Symptom = View.Symptom,
                
                StartTime =View.StartTime,
                EndTime = View.StartTime.Value.AddHours(1),
                PurposeOfVisit = View.Purpose,
                PatientID = View.Patient.ID


            };

            Finding finding = new Finding()
            {
                ID = Guid.NewGuid(),
                ConsultationRecordID = CRGuid,
                Tags  = View.FTags,
                Description= View.FDescription
                
            };
            Prescription prescription = new Prescription()
            {
                ID = Guid.NewGuid(),
                ConsultationRecordID= CRGuid,
                Tags = View.PTags,
                Description= View.PDescription,

            };
           

            _context?.ConsultationRecords?.Add(consultation);
            _context?.Appointments?.Add(appointment);
            _context?.Findings?.Add(finding);
            _context?.Prescriptions?.Add(prescription);
            _context?.SaveChanges();

            return RedirectPermanent("~/manage/admin/dashboard");

        }






            
        public class ViewModel : UserViewModel
        {
            [ForeignKey("PatientID")]
            public Infrastructure.Domain.Models.Patient? Patient { get; set; }
            public List<Finding>? Findings { get; set; }
            public List<Prescription>? Prescriptions { get; set; }
            public List<ConsultationRecord>? ConsultationRecords { get; set; }
            public List<Appointment>? Appointments { get; set; }
            
            public string? FTags { get; set; }
            public string? FDescription { get; set; }
           
           
            public string? PTags { get; set; }
            public string? PDescription { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public string? Symptom { get; set; }

            public Infrastructure.Domain.Models.Enums.Status Status { get; set; }
            public Infrastructure.Domain.Models.Enums.Purpose Purpose { get; set; }


        }

    }
   

}
