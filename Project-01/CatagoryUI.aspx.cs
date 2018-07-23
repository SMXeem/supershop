using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_01
{
    public partial class CatagoryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryGridView.DataSource = aShopManager.GetCategories();
            categoryGridView.DataBind();

        }


        ShopManager aShopManager=new ShopManager();

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string category = categoryTextBox.Text;
            bool result = aShopManager.AddCategory(category);
            if (result)
            {
                resultLabel.Text = "Insert Successful";
            }
            else
            {
                resultLabel.Text = "Duplicate Category";
            }
            categoryGridView.DataSource = aShopManager.GetCategories();
            categoryGridView.DataBind();
        }
    }
}