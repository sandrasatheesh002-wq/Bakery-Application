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
    public partial class viewoneproduct : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductDetails();    // load once only
            }
        }



        private void LoadProductDetails()
        {
            if (Session["proid"] == null)
            {
                lblMsg.Text = "Product not found";
                return;
            }

            string s = "select * from Product_Tab where product_id=" + Session["proid"] + " and product_status='Available'";
            SqlDataReader dr = obj.Fn_Reader(s);

            if (dr.Read())
            {
                // ALWAYS load product details
                Image1.ImageUrl = dr["product_image"].ToString();
                Label1.Text = dr["product_name"].ToString();
                Label2.Text = dr["product_discription"].ToString();
                Label3.Text = dr["product_price"].ToString();

                Session["prdtprice"] = Convert.ToInt32(dr["product_price"]);

                int prostk = Convert.ToInt32(dr["product_stock"]);

                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("--select--");

                for (int i = 1; i <= prostk; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
            }
            else
            {
                lblMsg.Text = "Product not found";
            }
        }




        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (Page.IsValid)
        //    {
        //            int qty = Convert.ToInt32(DropDownList1.SelectedItem.Text);
        //            int price = Convert.ToInt32(Session["prdtprice"]);
        //            int subtotal = qty * price;
        //            int sts = 1;

        //            string ins = "insert into Cart_Tab(User_id, product_id, Qty, subtotal, status) values("
        //                         + Session["userid"] + ","
        //                         + Session["proid"] + ","
        //                         + qty + ","
        //                         + subtotal + ","
        //                         + sts + ")";

        //            int i = obj.Fn_Nonquery(ins);



        //    }



        //}



        protected void Button1_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (DropDownList1.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select quantity";
                return;
            }

            if (Session["prdtprice"] == null)
            {
                lblMsg.Text = "Price not found";
                return;
            }

            int qty = Convert.ToInt32(DropDownList1.SelectedItem.Text);
            int price = Convert.ToInt32(Session["prdtprice"]);
            int subtotal = qty * price;
            int sts = 1;

            string ins = "insert into Cart_Tab(User_id, product_id, Qty, subtotal, status) values(" + Session["userid"] + "," + Session["proid"] + "," +
                              qty + "," + subtotal + "," + sts + ")";





            int i = obj.Fn_Nonquery(ins);

            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Product added to cart";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Error adding product";
            }
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Userhomepage.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewcart.aspx");

        }
    }
}