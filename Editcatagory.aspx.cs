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
    public partial class Editcatagory : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            gridbind();

        }
        public void gridbind()
        {
            string sel = "select * from Cat_Tab";
            DataSet ds = obj.Fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridbind();


        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridbind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if(!IsPostBack)
            {
                int i = e.RowIndex;
                int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
                TextBox TextBox1 = (TextBox)GridView1.Rows[i].FindControl("TextBox1");
                TextBox TextBox2 = (TextBox)GridView1.Rows[i].FindControl("TextBox2");
                FileUpload FileUpload1 = (FileUpload)GridView1.Rows[i].FindControl("FileUpload1");
                DropDownList DropDownList1 = (DropDownList)GridView1.Rows[i].FindControl("DropDownList1");
                string p = "~/catimg/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(p));
                string sts = DropDownList1.SelectedItem.Text;
                string s = "update Cat_Tab set Name='" + TextBox1.Text + "',Description='" + TextBox2.Text + "',Image='" + p + "',Status='" + sts + "' where cat_id='" + id + "'";
                obj.Fn_Nonquery(s);
                GridView1.EditIndex = -1;
                gridbind();

            }

        }
    }
}