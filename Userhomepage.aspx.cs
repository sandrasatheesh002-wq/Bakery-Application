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
    public partial class Userhomepage : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CategoryBind();
            }

        }
        public void CategoryBind()
        {
            string s = "select * from Cat_Tab where cat_status='Available'";
            DataSet ds = obj.Fn_Dataset(s);
            DataList1.DataSource = ds;
            DataList1.DataBind(); 

        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["catid"] = id;
            Response.Redirect("viewallproduct.aspx");

        }
    }
}