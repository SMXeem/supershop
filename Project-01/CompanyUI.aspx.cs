using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_01
{
    public partial class CompanyUI : System.Web.UI.Page
    {
        ShopManager aShopManager = new ShopManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            companyGridView.DataSource = aShopManager.GetCompanies();
            companyGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string company = companyTextBox.Text;
            bool result = aShopManager.AddCompany(company);
            if (result)
            {
                resultLabel.Text = "Insert Successful";
            }
            else
            {
                resultLabel.Text = "Duplicate Company";
            }
            companyGridView.DataSource = aShopManager.GetCompanies();
            companyGridView.DataBind();
        }
    }
}