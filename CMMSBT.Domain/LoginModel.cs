using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMSBT.Domain
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Nhập mật khẩu")]
        public string Password { get; set; } = null!;

        [Display(Name = "Nhớ mật khẩu")]
        public bool KeepLoggedIn { get; set; }
    }
}