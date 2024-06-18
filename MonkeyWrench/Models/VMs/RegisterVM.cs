using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MonkeyWrench.Models.VMs
{
    public class RegisterVM
    {
        [Required]
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [Required]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }
        [Required]
        [DisplayName("نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Required]
        [DisplayName("شماره تلفن")]
        public string PhoneNumber { get; set; }
        [DisplayName("مشتری هستم")]
        public bool IsCustomer { get; set; }
        [DisplayName("متخصص هستم")]
        public bool IsExpert { get; set; }
        public bool IsAdmin {  get; set; }
    }
}
