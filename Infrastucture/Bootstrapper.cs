using TestApp.IocInstallers;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class Bootstrapper
    {
        public static readonly Container Container;


        static Bootstrapper()
        {
            Container = new Container();
            Installer.Register(Container);
            Container.Verify();
        }

    }
}

