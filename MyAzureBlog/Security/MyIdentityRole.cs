using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// 03.01.2015 ypala
namespace MyAzureBlog.Security
{
    public class MyIdentityRole : IdentityRole
    {

        public MyIdentityRole()
        {

        }

        public MyIdentityRole(string roleName) : base(roleName)
        {

        }
    }
}