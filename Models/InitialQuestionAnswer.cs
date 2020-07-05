using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ehrmadesimple.Models
{
    public class InitialQuestionAnswer
    {
        [Key]
        public int RowNumber { get; set; }
        [ForeignKey("Client")]
        public string ClientId {get;set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }
        public string InitialDetails { get; set; }
        public bool isConsultedBefore { get; set; }
        public string MedicationDetails { get; set; }
        public string PrescribingMdDetails { get; set; }
        public string PrimaryPhysicianDetails { get; set; }
        public bool isAlcohol { get; set; }
        public bool isDrug { get; set; }
        public bool isSuicidal { get; set; }
        public bool isAttemptedSuicide { get; set; }
        public bool isHarmOthers { get; set; }
        public bool isHospitalized { get; set; }
        public bool isFamilyMemberIll { get; set; }
        public string RelationshipDetails { get; set; }
        public string LivingStatus { get; set; }
        public string OccupationDetails { get; set; }
        public string PastMonthSymptoms { get; set; }
        public string GeneralSymptoms { get; set; }
        public string Extra { get; set; }
        public virtual Client Client { get; set; }
    }
}
