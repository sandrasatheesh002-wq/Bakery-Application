using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace projectapplication
{
    public partial class Loginpage : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(reg_id) from Login_Tab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string cid = obj.Fn_scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select reg_id from Login_Tab  where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string regid = obj.Fn_scalar(str1);
                Session["userid"] = regid;

                string str2 = "select log_type from Login_Tab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string logtype = obj.Fn_scalar(str2);
                if (logtype == "Admin")
                {
                    Response.Redirect("Adminhomepage.aspx");
                }
                else if (logtype == "User")
                {
                    Response.Redirect("Userhomepage.aspx");
                }


            }
            else
            {
                Label3.Text = "invalid username and password";
            }

        }
    }
}