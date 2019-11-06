using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManager
{
    public partial class MainTheme : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string themeName = Request.Cookies["Theme"]?.Value;
                if (themeName != null)
                {
                    themeList.SelectedValue = themeName;
                }
            }
            themeList.SelectedIndexChanged += (themeListSender, themeListE) =>
            {
                string themeName = themeList.SelectedValue;
                HttpCookie cookie = new HttpCookie("Theme");
                cookie.Value = themeName;
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                Response.Redirect(Request.Url.ToString());
            };
        }
    }
}