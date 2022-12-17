using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class LoginViewModel
    {
        // 必須項目
        [Required]
        [DisplayName("ユーザー名")]
        public string UserName { get; set; }

        // 必須項目
        [Required]
        [DataType(DataType.Password)]  // パスワード型に成ります。
        [DisplayName("パスワード")]
        public string Password { get; set; }

    }
}