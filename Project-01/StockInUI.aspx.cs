using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_01
{
    public partial class StockInUI : System.Web.UI.Page
    {
        ShopManager aShopManager=new ShopManager();
        Item aItem ;
        private int companyId, itemID;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                availableQTextBox.Text = "";
                reorderTextBox.Text = "";
                List<Company> companies = aShopManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataValueField = "SL";
                companyDropDownList.DataBind();

                companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                List<Item> item = aShopManager.GetAllItem(companyId);
                itemDropDownList.DataSource = item;
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataValueField = "ID";
                itemDropDownList.DataBind();

                aItem = new Item();
                itemID = Convert.ToInt32(itemDropDownList.SelectedValue);
                aItem = aShopManager.GetItemDetails(itemID);
                availableQTextBox.Text = aItem.AvilableQuantity.ToString();
                reorderTextBox.Text = aItem.ReorderLevel.ToString();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int itemid=Convert.ToInt32(itemDropDownList.SelectedValue);
            int quantity = Convert.ToInt32(stockInQTextBox.Text);

            aShopManager.StockIn(itemid, quantity);

            aItem = aShopManager.GetItemDetails(itemid);
            availableQTextBox.Text = aItem.AvilableQuantity.ToString();

            stockInQTextBox.Text = "";
        }


        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            availableQTextBox.Text = "";
            reorderTextBox.Text = "";
            companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            List<Item> item = aShopManager.GetAllItem(companyId);
            itemDropDownList.DataSource = item;
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "ID";
            itemDropDownList.DataBind();
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            availableQTextBox.Text = "";
            reorderTextBox.Text = "";
            aItem = new Item();
            itemID = Convert.ToInt32(itemDropDownList.SelectedValue);
            aItem = aShopManager.GetItemDetails(itemID);
            availableQTextBox.Text = aItem.AvilableQuantity.ToString();
            reorderTextBox.Text = aItem.ReorderLevel.ToString();
            if (aItem.AvilableQuantity < aItem.ReorderLevel)
            {
                ReorderAlertLebel.Text = "Reorder Level crossed";
            }
        }
    }
}