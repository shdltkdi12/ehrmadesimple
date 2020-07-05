using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehrmadesimple.Models
{
    public class Event
    {
        [Key]
        public int RowNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }
        public string Crud { get; set; }
        public string Table { get; set; }
    }
}
