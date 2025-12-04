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
    public partial class WebForm2 : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sel = "select max(reg_id) from Login_Tab ";
            string maxregid = obj.Fn_scalar(sel);
            int reg_id = 0;
            if (maxregid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(maxregid);
                reg_id = newregid + 1;
            }
            string ins = "insert into Admin_RegTab values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "'," + TextBox4.Text + ")";
            int i = obj.Fn_Nonquery(ins);
            if (i == 1)
            {
                string ins1 = "insert into  Login_Tab values(" + reg_id + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','Admin') ";
                int j = obj.Fn_Nonquery(ins1);
                if (i == 1 && j == 1)
                {
                    Label7.Text = "Successfully Registered";
                }
                else
                {
                    Label7.Text = "invalid entry";
                }
            }
        }
    }
}
        
    

