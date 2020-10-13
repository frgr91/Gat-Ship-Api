using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GatCrmApi.Models
{
    public partial class KundeType
    {
        [Key]
        public int Id { get; set; }
        public string KundeTypeNavn { get; set; }
        public string Beskrivelse { get; set; }
    }
}
