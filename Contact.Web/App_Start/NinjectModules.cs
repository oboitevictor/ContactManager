using Contact.Core.DataAccess;
using Contact.Core.Interfaces;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.Managers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Parameters;
using Ninject.Web.Mvc;
using Ninject.Web.Common;

namespace Contact.Web.App_Start
{
    public class NinjectModules
    {
        public static NinjectModule[] Modules
        {
            get
            {
                //Return Modules you want to use for DI
                return new NinjectModule[] { new MainModule(), new ManagerModule() };
            }
        }

        //Main Module For Application. 
        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                Bind<DbContext>().To<DataEntities>().InRequestScope();
                Bind<IDataRepository>().To<DataRepository>();
            }
        }

        //You can create as many Modules as you wish
        public class ManagerModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IManager>().To<Manager>();
                Bind<IUserManager>().To<UserManager>();
                Bind<IRoleManager>().To<RoleManager>();
                Bind<IDepartmentManager>().To<DepartmentManager>();
                Bind<IEmployeeManager>().To<EmployeeManager>();
                Bind<IBranchManager>().To<BranchManager>();
                Bind<IContactManager>().To<ContactManager>();
            }
        }
    }
}