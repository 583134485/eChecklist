﻿using System.Web;
using System.Web.Mvc;

namespace Gdc.Apps.Echecklist.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
