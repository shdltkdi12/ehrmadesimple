using ehrmadesimple.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ehrmadesimple.Models
{
    public class Bill
    {
        private string base64Guid = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
        [Key]
        public string BillId { get { return base64Guid; } set { base64Guid = value; } }
        [ForeignKey("Client")]
        public string ClientId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Fee { get; set; }
        public bool isPaid { get; set; }

        public string BillingType { get; set; }



        public virtual Client Client { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
