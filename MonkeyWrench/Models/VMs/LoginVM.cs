using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MonkeyWrench.Models.VMs
{
    public class LoginVM
    {
        [Required]
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [Required]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }
    }
}
