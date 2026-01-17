using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteRx.Interface.Domain.Entities
{
    [Table("hl7_message")]
    public class Hl7Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("sending_application")]
        public string? SendingApplication { get; set; }

        [Column("sending_facility")]
        public string? SendingFacility { get; set; }

        [Column("receiving_application")]
        public string? ReceivingApplication { get; set; }

        [Column("receiving_facility")]
        public string? ReceivingFacility { get; set; }

        [Column("message_type")]
        public string? MessageType { get; set; }

        [Column("trigger_event")]
        public string? TriggerEvent { get; set; }

        [Column("message_control_id")]
        public string? MessageControlId { get; set; }

        [Column("version")]
        public string? Version { get; set; }

        [Column("patient_id")]
        public string? PatientId { get; set; }

        [Column("patient_name")]
        public string? PatientName { get; set; }

        [Column("facility")]
        public string? Facility { get; set; }

        [Column("attending_doctor")]
        public string? AttendingDoctor { get; set; }

        [Column("visit_number")]
        public string? VisitNumber { get; set; }

        [Column("order_control")]
        public string? OrderControl { get; set; }

        [Column("placer_order_number")]
        public string? PlacerOrderNumber { get; set; }

        [Column("filler_order_number")]
        public string? FillerOrderNumber { get; set; }

        [Column("order_status")]
        public string? OrderStatus { get; set; }

        [Column("datetime_of_transaction")]
        public DateTime? DateTimeOfTransaction { get; set; }

        [Column("ordering_provider")]
        public string? OrderingProvider { get; set; }

        [Column("diagnosis_code")]
        public string? DiagnosisCode { get; set; }

        [Column("diagnosis_description")]
        public string? DiagnosisDescription { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }
    }
}
