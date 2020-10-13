using System.ComponentModel.DataAnnotations;

namespace GatCrmApi.Models
{
    public class KontaktPerson
    {
        [Key]
        public int Id { get; set; }
        public int KundeNr { get; set; }
        public string Etternavn { get; set; }
        public string Fornavn { get; set; }
        public string Tittel { get; set; }
        public int MobilNr { get; set; }
        public string Epost { get; set; }
    }
}
