using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_01
{
    public partial class DateSearchUI : System.Web.UI.Page
    {
        ShopManager aShopManager = new ShopManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string from = fromDate.Text;
            string to = toDate.Text;

            if (from != null && to !=null)
            {
                searchResultsGridView.DataSource = aShopManager.GetStockOutData(to,from);
                searchResultsGridView.DataBind();
            }
            
        }
    }
}