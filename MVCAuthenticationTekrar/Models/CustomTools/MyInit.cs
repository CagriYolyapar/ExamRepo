using MVCAuthenticationTekrar.Models.Context;
using MVCAuthenticationTekrar.Models.Entities;
using MVCAuthenticationTekrar.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAuthenticationTekrar.Models.CustomTools
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
      
        
        protected override void Seed(MyContext context)
        {
            AppUser item = new AppUser();
            item.UserName = "cagri123";
            item.Password = "123";
            item.Role = Enums.UserRole.Admin;

            context.AppUsers.Add(item);
            context.SaveChanges();
        }
    }
}