using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_01
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        string date;
        private int companyId, itemID;
        StockOut aStockOut;
        Item aItem;
        ShopManager aShopManager = new ShopManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            date = DateTime.Now.ToString("yyyy/MM/dd");

            if (!IsPostBack)
            {
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

                sellButton.Enabled = false;
                damageButton.Enabled = false;
                lostButton.Enabled = false;

                List<StockOutItem> stockOutItems = new List<StockOutItem>();
                Session["items"] = stockOutItems;
                StockOutGridView.DataSource = stockOutItems;
                StockOutGridView.DataBind();
            }
        }

        //add button to insert into gridview
        protected void addButton_Click(object sender, EventArgs e)
        {
            List<StockOutItem> stockOutItems = new List<StockOutItem>();
            if (Session["items"] != null)
            {
                stockOutItems = (List<StockOutItem>)Session["items"];
            }
            StockOutItem stockItem = new StockOutItem();
           
            stockItem.ItemName = itemDropDownList.SelectedItem.Text;
            stockItem.companyName = companyDropDownList.SelectedItem.Text;
            stockItem.Quantity = Convert.ToInt32(stockOutQTextBox.Text);
            stockOutItems.Add(stockItem);
            StockOutGridView.DataSource = stockOutItems;
            StockOutGridView.DataBind();
            Session["items"] = stockOutItems;

            stockOutQTextBox.Text = "";
            sellButton.Enabled = true;
            damageButton.Enabled = true;
            lostButton.Enabled = true;
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {

            if (StockOutGridView != null)
            {
                List<StockOutItem> stockOutItems = (List<StockOutItem>)Session["items"];
                foreach (StockOutItem items in stockOutItems)
                {
                    aStockOut = new StockOut();
                    aStockOut.ItemName = items.ItemName;
                    aStockOut.companyName = items.companyName;
                    aStockOut.Quantity = Convert.ToInt32(items.Quantity);
                    aStockOut.StockOutCategory = "sell";
                    aStockOut.Date = date;
                    aShopManager.StockOutData(aStockOut);
                }
                stockOutQTextBox.Text = "0";
                StockOutGridView.DataSource = null;
                StockOutGridView.DataBind();
            }
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            if (StockOutGridView != null)
            {
                List<StockOutItem> stockOutItems = (List<StockOutItem>)Session["items"];
                foreach (StockOutItem items in stockOutItems)
                {
                    aStockOut = new StockOut();
                    aStockOut.ItemName = items.ItemName;
                    aStockOut.companyName = items.companyName;
                    aStockOut.Quantity = Convert.ToInt32(items.Quantity);
                    aStockOut.StockOutCategory = "damage";
                    aStockOut.Date = date;
                    aShopManager.StockOutData(aStockOut);
                }
                stockOutQTextBox.Text = "0";
                StockOutGridView.DataSource = null;
                StockOutGridView.DataBind();
            }
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            if (StockOutGridView != null)
            {
                List<StockOutItem> stockOutItems = (List<StockOutItem>)Session["items"];
                foreach (StockOutItem items in stockOutItems)
                {
                    aStockOut = new StockOut();
                    aStockOut.ItemName = items.ItemName;
                    aStockOut.companyName = items.companyName;
                    aStockOut.Quantity = Convert.ToInt32(items.Quantity);
                    aStockOut.StockOutCategory = "lost";
                    aStockOut.Date = date;
                    aShopManager.StockOutData(aStockOut);
                }
                stockOutQTextBox.Text = "0";
                StockOutGridView.DataSource = null;
                StockOutGridView.DataBind();
            }
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

        protected void stockOutQTextBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}