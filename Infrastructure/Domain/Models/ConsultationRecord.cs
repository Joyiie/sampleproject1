using System.ComponentModel.DataAnnotations.Schema;

namespace Capstonep2.Infrastructure.Domain.Models
{
    public class ConsultationRecord
    {
        public Guid? ID { get; set; }
        public Guid? PatientID { get; set; }
        public Guid? AppointmentID { get; set; }

        [ForeignKey("PatientID")]
        public Patient? Patient { get; set; }

        [ForeignKey("AppointmentID")]
        public Appointment? Appointment { get; set; }
    }
}
