using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Final.Models

{
    [Serializable]
    public class UserModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "username is required")]
        [Remote("IsUserNameAvaliable", "Account", ErrorMessage = "User name already in use")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "confirm password is required")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
    }
}
