using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ehrmadesimple.Models
{
    public class Appointment
    {
        private string base64Guid = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
        [Key]
        public string AppointmentId { get { return base64Guid; } set { base64Guid = value; } }
        [Required]
        public string Clientname { get; set; }
        [ForeignKey("Client")]
        public string ClientId { get; set; }
        [ForeignKey("Bill")]
        public string BillId {get;set;}
        public DateTime Timestamp {get;set;}
        public int Duration {get;set;}
        public bool isAllDay { get; set; }
        public string Location {get;set;}
        public bool isRepeating {get;set;}
        public string ServiceType {get;set;}
        public string ProgressNote {get;set;}
        public string PsychoNote {get;set;}
        public virtual Bill Bill { get; set; }
        public virtual Client Client { get; set; }
    }
}
