namespace TodoApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoApp.Models.TodoesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;　// 列が削除されてもマイグレーションに反映されても良いかのオプション

            ContextKey = "TodoApp.Models.TodoesContext";
        }

        protected override void Seed(TodoApp.Models.TodoesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            User admin = new User()
            {
                Id = 1,
                UserName = "admin",
                Password = "password",
                // 空のロールを登録
                Roles = new List<Role>()
            };

            // 一般ユーザー							
            User sato = new User()
            {
                Id = 2,
                UserName = "sato",
                Password = "password",
                Roles = new List<Role>()
            };

            Role administrators = new Role()
            {
                Id = 1,
                RoleName = "Administrators",
                Users = new List<User>()
            };

            Role users = new Role()
            {
                Id = 2,
                RoleName = "Users",
                Users = new List<User>()
            };

            admin.Roles.Add(administrators);
            administrators.Users.Add(admin);
            sato.Roles.Add(users);
            users.Users.Add(sato);

            // ＤＢへ登録（有れば更新、無ければ追加）							
            context.Users.AddOrUpdate(user => user.Id, new User[] { admin, sato });
            context.Roles.AddOrUpdate(role => role.Id, new Role[] { administrators, users });

            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
