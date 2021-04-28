using SoftUniServer.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.MVC
{
    public interface IMvcApp
    {
        void Configuration(List<Route> routeTable);

        void ConfigureServices();
    }
}
