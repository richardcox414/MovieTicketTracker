﻿using System.Web;
using System.Web.Mvc;

namespace Sp16_p3_g__1_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
