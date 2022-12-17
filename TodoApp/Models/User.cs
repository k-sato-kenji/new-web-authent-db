using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class User
    {
        // 主キー
        public int Id { get; set; }

        // 必須
        [Required]
        // 重複制限
        [Index(IsUnique = true)]
        [StringLength(256)]  // 長さ指定
        [DisplayName("ユーザー名")]
        public string UserName { get; set; }

        // 必須
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("パスワード")]
        public string Password { get; set; }

        // 必須
        [Required]
        [NotMapped]
        [DisplayName("ロール")]
        //ViewBag.RoleIds = list; のロール名と同じにする。
        public List<int> RoleIds { get; set; }

        // ナビゲーションプロパティー
        // 一つのユーザーが複数のロールを持つことが出来る。
        public virtual ICollection<Role> Roles { get; set; }

    }
}