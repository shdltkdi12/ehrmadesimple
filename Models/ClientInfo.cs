using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehrmadesimple.Models
{
    public class ClientInfo
    {
        [Key]
        public int ClientInfoId { get; set; }
        [ForeignKey("Client")]
        public string ClientId {get;set;}
        public string FullName { get; set; }
        public string ClientEmail { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string BdayMonth { get; set; }
        public string BdayDay { get; set; }
        public string BdayYear { get; set; }
        public string Sex { get; set; }
        public string RelationshipStatus { get; set; }
        public string EmploymentStatus { get; set; }
        public string EmergencyFname { get; set; }
        public string EmergencyLname { get; set; }
        public string EmergencyRelationship { get; set; }
        public string EmergencyEmail { get; set; }
        public string EmergencyPhone { get; set; }
        public virtual Client Client { get; set; }
    }
}
