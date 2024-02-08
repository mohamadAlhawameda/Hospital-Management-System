using System.ComponentModel;

namespace Final.Models
{
    public class Visits
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        [DisplayName("Date of visit")]
        public string DateOfVisit { get; set; }

        public string Complaint { get; set; }

        public virtual Doctor? doctor { get; set; }

        public virtual Patient? patient { get; set; }
    }
}
