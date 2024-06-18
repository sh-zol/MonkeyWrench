using Domain.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Entities
{
    public abstract class Person
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Required]
        [DisplayName("ایمیل")]
        public string Email {  get; set; }
        [Required]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }
        [DisplayName("درباره من")]
        public string? AboutMe { get; set; }
        [DisplayName("شماره تلفن")]
        public string PhoneNumber { get; set; }
        [DisplayName("آدرس")]
        public string? Address { get; set; }
        public Role Role { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? FileLocation { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
