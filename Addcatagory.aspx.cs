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
    public partial class Addcatagory : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string im = "~/catimg/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(im));

            string s = "Insert into Cat_Tab values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + im + "'," +
                "'Available')";
            int i = obj.Fn_Nonquery(s);
            if (i == 1)
            {
                Label4.Text = "Successfully Added Catagory";
            }
            else
            {
                Label4.Text = "Invalid";
            }


        }
    }
}