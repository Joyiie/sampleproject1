using Capstonep2.Infrastructure.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Capstonep2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Capstonep2.Infrastructure.Domain;
using Capstonep2.Infrastructure.Domain.Models.Enums;

namespace Capstonep2.Pages.Manage.Consultation
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        private ILogger<System.Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public IndexModel(DefaultDBContext context, ILogger<System.Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }
        public void OnGet(Guid? id = null)

        {
            var appts = _context?.Appointments?.Where(a => a.ID == id).Include(a => a.Patient).ToList();
            View.Appointments = appts;
        }
        public IActionResult OnPost(Guid? id = null)
        {

            Guid CRGuid = Guid.NewGuid();
            var appts = _context?.Appointments?.FirstOrDefault(a => a.ID == id);


            if (string.IsNullOrEmpty(View.FTags))
            {
                ModelState.AddModelError("", "Finding Tags cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.FDescription))
            {
                ModelState.AddModelError("", "Finding Description name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.PTags))
            {
                ModelState.AddModelError("", "Prescription Tags cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.PDescription))
            {
                ModelState.AddModelError("", "Prescription Description name cannot be blank.");
                return Page();
            }
            else
            {
                ConsultationRecord consultationRecords = new ConsultationRecord()
                {
                    ID = CRGuid,
                    AppointmentID = id,
                    PatientID = appts.PatientID

                };
                Infrastructure.Domain.Models.Prescription prescription = new Infrastructure.Domain.Models.Prescription()
                {
                    ID = Guid.NewGuid(),
                    ConsultationRecordID = CRGuid,
                    Tags = View.PTags,
                    Description = View.PDescription
                };
                Finding finding = new Finding()
                {
                    ID = Guid.NewGuid(),
                    ConsultationRecordID = CRGuid,
                    Tags = View.FTags,
                    Description = View.FDescription
                };

                var appointment = _context?.Appointments?.FirstOrDefault(a => a.ID == Guid.Parse(View.AppointmentId));

                if (appointment != null)
                {

                    appointment.Status = Status.Completed;
                }


                _context?.Appointments?.Update(appointment);
                _context?.Findings?.Add(finding);
                _context?.Prescriptions?.Add(prescription);
                _context?.ConsultationRecords?.Add(consultationRecords);
                _context?.SaveChanges();

                return RedirectPermanent("~/manage/admin/dashboard");
            }
        }





        public class ViewModel : CRViewModel
        {
            public List<Appointment>? Appointments { get; set; }
            public string? AppointmentId { get; set; }
        }
    }
}


