using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MonkeyWrenchAPI.Models
{
    public class RegisterVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsExpert { get; set; }
        public bool IsAdmin { get; set; }
    }
}
