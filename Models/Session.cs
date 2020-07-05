using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ehrmadesimple.Models
{
    public class Session
    {
        [Key]
        public int RowNumber { get; set; }
        [ForeignKey("Appointment")]
        public string AppointmentId { get; set; }
        [ForeignKey("Client")]
        public string ClientId {get;set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }
        public string NoteType {get;set;}
        public string Diagnosis {get;set;}
        public string TreatmentPlan {get;set;}
        public string ChartNote {get;set;}
        public string ProgressNote {get;set;}
        public string PsychoNote {get;set;}
        

        public virtual Appointment Appointment { get; set; }
        public virtual Client Client { get; set; }
    }
}
