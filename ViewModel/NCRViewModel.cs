using System;

namespace Capstonep2.ViewModel
{
    public class NCRViewModel
    {
        public Guid? ConsultationRecordID { get; set; }
        public Guid? PatientID { get; set; }
        public string? Symptoms { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid? FindingID { get; set; }
        public string? FTags { get; set; }
        public string? FDescription { get; set; }
        public Guid? PrescriptionID { get; set; }
        public string? PTags { get; set; }
        public string? PDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Symptom { get; set; }
        
        public Infrastructure.Domain.Models.Enums.Status Status { get; set; }
        public Infrastructure.Domain.Models.Enums.Purpose Purpose { get; set; }
    }
}
