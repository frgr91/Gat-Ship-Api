using System.ComponentModel.DataAnnotations;

namespace GatCrmApi.Models
{
    public class Kunde_KundeType
    {
        [Key]
        public int Id { get; set; }
        public int KundeNr { get; set; }
        public string KundeTypeNavn { get; set; }
    }
}
