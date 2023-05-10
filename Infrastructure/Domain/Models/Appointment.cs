using System.ComponentModel.DataAnnotations.Schema;

namespace Capstonep2.Infrastructure.Domain.Models
{
    public class Appointment
    {
        public Guid? ID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string? Symptom { get; set; }
        public Enums.Purpose PurposeOfVisit { get; set; }
        public Guid? PatientID { get; set; }
        public Enums.Status Status { get; set; }
        public Enums.Visit Visit { get; set; }

        [ForeignKey("PatientID")]
        public Patient? Patient { get; set; }

    }
}