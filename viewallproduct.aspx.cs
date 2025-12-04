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
    public partial class productview : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                productbind();


            }

        }
        public void productbind()
        {
            string s = "select * from Product_Tab where cat_id=" + Session["catid"] + "and product_status='Available'";
            DataSet ds = obj.Fn_Dataset(s);
            DataList1.DataSource = ds;
            DataList1.DataBind(); 

        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["proid"] = id;
            Response.Redirect("viewoneproduct.aspx");

        }
    }
}