using System.ComponentModel.DataAnnotations;

namespace SwiggyApp.Models
{
    public class Login
    {
        [Key]
        public string Email { get; set; }
        public string PWd { get; set; }
    }
}
