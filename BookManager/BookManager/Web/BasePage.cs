using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManager.Web
{
    public class BasePage : System.Web.UI.Page
    {
        public void Page_PreInit(object sender, EventArgs e)
        {
            Theme = Request.Cookies["Theme"]?.Value ?? "White";
        }
    }
}