using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity.EntityFramework;
using MyAzureBlog.DAL;
using MyAzureBlog.Security;
using Microsoft.AspNet.Identity;

namespace MyAzureBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // 03.01.2015 ypala
            BlogContext context = new BlogContext();
            RoleStore<MyIdentityRole> roleStore = new RoleStore<MyIdentityRole>(context);
            RoleManager<MyIdentityRole> roleManager = new RoleManager<MyIdentityRole>(roleStore);

            if (!roleManager.RoleExists("Admin"))
            {
                MyIdentityRole adminRole = new MyIdentityRole("Admin");
                roleManager.Create(adminRole);
            }

            if (!roleManager.RoleExists("User"))
            {
                MyIdentityRole userRole = new MyIdentityRole("User");
                roleManager.Create(userRole);
            }

        }
    }
}
