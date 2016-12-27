using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sp16_p3_g__1_.Utilities;
using System.Web.Mvc;

namespace Sp16_p3_g__1_.Helpers
{
    public static class JsonHtmlHelpers
    {
        public static IHtmlString JsonFor<T>(this HtmlHelper helper, T obj)
        {
            return helper.Raw(obj.ToJson());
        }
    }
}