using System.ComponentModel.DataAnnotations;

namespace GatCrmApi.Models
{
    public class Kunde
    {
        [Key]
        public int KundeNr { get; set; }
        public string KundeTypeNavn { get; set; }
        public string FirmaNavn { get; set; }
        public int TelefonNr { get; set; }
        public string Epost { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }
    }
}
