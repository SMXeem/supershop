using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_01
{
    public partial class ItemSetupUI : System.Web.UI.Page
    {

        ShopManager aShopManager=new ShopManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<Category> aList = aShopManager.GetAllCategories();
                catagoryDropDownList.DataSource = aList;
                catagoryDropDownList.DataTextField = "Name";
                catagoryDropDownList.DataValueField = "SL";
                catagoryDropDownList.DataBind();

                List<Company> companies = aShopManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataValueField = "SL";
                companyDropDownList.DataBind();
            }
           
        }

        Item aItem;
        protected void saveButton_Click(object sender, EventArgs e)
        {
            aItem = new Item();
            aItem.CatID = Convert.ToInt32(catagoryDropDownList.SelectedValue);
            aItem.ComID = Convert.ToInt32(companyDropDownList.SelectedValue);
            aItem.ItemName = itemNameTextBox.Text;
            aItem.ReorderLevel = Convert.ToInt32(reorderTextBox.Text);
            if (aShopManager.AddItem(aItem))
            {
                resultLebel.Text = "Item Add Successful";
            }
            else
            {
                resultLebel.Text = "Dublicate Item";
            }
            
        }
    }
}