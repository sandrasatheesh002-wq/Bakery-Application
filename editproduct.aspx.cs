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
    public partial class editproduct : System.Web.UI.Page
    {
        Connectionclass ob = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind_grid();
            }

        }
        public void bind_grid()
        {
            string str = "select *from Product_Tab";
            DataSet ds = ob.Fn_Dataset(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind_grid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind_grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label5.Visible = true;
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);

            TextBox txtprice = (TextBox)GridView1.Rows[i].FindControl("txtPrice");
            TextBox txtdescription = (TextBox)GridView1.Rows[i].FindControl("txtDescription");
            FileUpload fu = (FileUpload)GridView1.Rows[i].FindControl("FileUpload1");
            TextBox txtstock = (TextBox)GridView1.Rows[i].FindControl("txtStock");
            TextBox txtstatus = (TextBox)GridView1.Rows[i].FindControl("txtStatus");
            HiddenField hfOldImage = (HiddenField)GridView1.Rows[i].FindControl("hfOldImage");
            string p = hfOldImage != null ? hfOldImage.Value : "";


            if (fu.HasFile)
            {
                p = "~/proimg/" + fu.FileName;
                fu.SaveAs(Server.MapPath(p));
            }

            string str = "update Product_Tab set product_price=" + txtprice.Text + ", product_discription='" + txtdescription.Text + "',product_image='" + p + "'," +
                "product_stock=" + txtstock.Text + ",product_status='" + txtstatus.Text + "' where product_id=" + getid + "";
            int s = ob.Fn_Nonquery(str);
            if (s == 1)

                Label5.Text = "Updated Successfully";

            GridView1.EditIndex = -1;
            bind_grid();
        }
    }
}