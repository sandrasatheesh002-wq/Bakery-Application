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
    public partial class Addproduct : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sel="select cat_id , cat_name from Cat_Tab where cat_status='Available'";
                DataSet ds = obj.Fn_Dataset(sel);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "cat_name";
                DropDownList1.DataValueField = "cat_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0,"select");
            }

        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string imgp = "~/proimg/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(imgp));

            string ins = "insert into Product_Tab values('" + DropDownList1.SelectedItem.Value + "','"+TextBox1.Text+"','"+TextBox2.Text+"',"+TextBox3.Text+",'"+imgp+"',"+TextBox4.Text+",'Available')";
            int i = obj.Fn_Nonquery(ins);
            if(i==1)
            {
                Label7.Text = "Product added successfully";

            }
            

        }
    }
}