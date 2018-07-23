using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_01
{
    public class ShopManager
    {
        Gateway aGateway=new Gateway();

        //category manager
        public bool AddCategory(string category)
        {
            if (aGateway.IsExistCategory(category))
            {
                return false;
            }
            return aGateway.AddCategory(category);
        }

        public List<Category> GetCategories()
        {
            return aGateway.GetCategories();
        }


        //Company manager
        public bool AddCompany(string company)
        {
            if (aGateway.IsExistCompany(company))
            {
                return false;
            }
            return aGateway.AddCompany(company);
        }

        public List<Company> GetCompanies()
        {
            return aGateway.GetCompany();
        }

        //Item manager
        public List<Category> GetAllCategories()
        {
            return aGateway.GetAllCategories();
        }
        public List<Company> GetAllCompanies()
        {
            return aGateway.GetAllCompany();
        }

        public bool AddItem(Item aItem)
        {
            return aGateway.AddItem(aItem);
        }

        public List<Item> GetAllItem(int companyId)
        {
            return aGateway.GetAllItem(companyId);
        }
        public Item GetItemDetails(int itemID)
        {
            return aGateway.GetItemDetails(itemID);
        }

        public CatComSearch GetSearchItem(int itemID)
        {
            return aGateway.GetSearchItem(itemID);
        }


        //stockIn

        Item aItem = new Item();
        internal Item StockIn(int itemID, int quantity)
        {
            if (quantity < 1 )
            {
                return aGateway.GetItemDetails(itemID);
            }
            else
            {
                aItem = aGateway.GetItemDetails(itemID);
                aGateway.StockIn(itemID, quantity);
                return aGateway.GetItemDetails(itemID);
            }
        }

        //StockOut manager
        public bool StockOutData(StockOut aStockOut)
        {
            return aGateway.StockOutData(aStockOut);
        }

        public List<DateSearch> GetStockOutData(string to, string from)
        {
            return aGateway.GetStockOutData(to, from);
        }

        public List<CatComSearch> GetItemList(int companyid, int catagoryid)
        {
            return aGateway.GetItemList(companyid, catagoryid);
        }
    }
}