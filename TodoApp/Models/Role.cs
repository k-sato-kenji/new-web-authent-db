using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Role
    {
        // 主キー
        public int Id { get; set; }

        // ロール名
        public String RoleName { get; set; }

        // 一つのロールに対して複数のユーザー
        public virtual ICollection<User> Users { get; set; }
    }
}