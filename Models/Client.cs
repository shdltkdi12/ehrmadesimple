using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ehrmadesimple.Models
{
    public class Client
    {
        private string base64Guid = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
        [Key]
        public string ClientId { get { return base64Guid; } set { base64Guid = value; } }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string BillingType { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? FirstJoined {get;set;}

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<ClientInfo> ClientInfoes { get; set; }
        public ICollection<InitialQuestionAnswer> InitialQuestionAnswers { get; set; }
        public ICollection<Session> Sessions {get;set;}
    }
}
