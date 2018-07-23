using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_01
{
    public partial class SearchUI : System.Web.UI.Page
    {
        ShopManager aShopManager = new ShopManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Company> companies = aShopManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataValueField = "SL";
                companyDropDownList.DataBind();

                List<Category> aList = aShopManager.GetAllCategories();
                categoryDropDownList.DataSource = aList;
                categoryDropDownList.DataTextField = "Name";
                categoryDropDownList.DataValueField = "SL";
                categoryDropDownList.DataBind();
            }
            
        }

        private int companyid, catagoryid;
        protected void searchButton_Click(object sender, EventArgs e)
        {
            companyid=Convert.ToInt32(companyDropDownList.SelectedValue);
            catagoryid=Convert.ToInt32(categoryDropDownList.SelectedValue);

            searchResultGridView.DataSource = aShopManager.GetItemList(companyid, catagoryid);
            searchResultGridView.DataBind();
        }
    }
}