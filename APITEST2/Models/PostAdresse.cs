using System.ComponentModel.DataAnnotations;

namespace GatCrmApi.Models
{
    public class PostAdresse
    {
        [Key]
        public int PostNr { get; set; }
        public string PostSted { get; set; }
    }
}
