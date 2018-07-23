using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_01
{
    public class Gateway
    {
        private SqlCommand cmd;
        private SqlDataReader itemIdReader;
        Connection oConnectionClass = new Connection();

        //category gateway
        public bool AddCategory(string aCategory)
        {
            int rowCount = 0;
            string querry = "INSERT INTO T_Category VALUES('" + aCategory + "')";
            try
            {
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                rowCount = cmd.ExecuteNonQuery();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return true;
        }

        List<Category> categories;
        public List<Category> GetCategories()
        {
            string querry = "SELECT * FROM T_Category ";
            try
            {
                int count = 0;
                categories = new List<Category>();
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                cmd.ExecuteNonQuery();
                itemIdReader = cmd.ExecuteReader();
                while (itemIdReader.Read())
                {
                    Category category = new Category();
                    category.SL = count += 1;
                    category.Name = itemIdReader["CatName"].ToString();
                    categories.Add(category);
                }
         }
         finally
         {
                oConnectionClass.GetClose();
         }
            return categories;
        }
        

        public bool IsExistCategory(string catName)
        {
            string querry = "SELECT CatName FROM  T_Category where CatName = '" + catName + "'";
            try
            {
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                int count = cmd.ExecuteNonQuery();
                itemIdReader = cmd.ExecuteReader();
                if (itemIdReader.Read())
                {
                    return true;
                }
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return false;
        }

        // End of category gateway


        //company gateway starts
        public bool AddCompany(string aCompany)
        {
            int rowCount = 0;
            string querry = "INSERT INTO T_Company VALUES('" + aCompany + "')";
            try
            {
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                rowCount = cmd.ExecuteNonQuery();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return true;
        }

        List<Company> aCompany;
        public List<Company> GetCompany()
        {
            string querry = "SELECT * FROM T_Company ";
            try
            {
                int count = 0;
                aCompany = new List<Company>();
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                cmd.ExecuteNonQuery();
                itemIdReader = cmd.ExecuteReader();
                while (itemIdReader.Read())
                {
                    Company company = new Company();
                    company.SL = count += 1;
                    company.Name = itemIdReader["ComName"].ToString();
                    aCompany.Add(company);
                }
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return aCompany;
        }

        public bool IsExistCompany(string comName)
        {
            string querry = "SELECT ComName FROM  T_Company where ComName = '" + comName + "'";
            try
            {
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                int count = cmd.ExecuteNonQuery();
                itemIdReader = cmd.ExecuteReader();
                if (itemIdReader.Read())
                {
                    return true;
                }
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return false;
        }
        //End of COMPANY Gateway
    
    
        //Item Gatway starts
        public bool AddItem(Item aItem)
        {
            string querry = "INSERT INTO T_Item VALUES('" + aItem.ComID + "','" + aItem.CatID + "','" + aItem.ItemName + "','" + aItem.ReorderLevel + "')";
            try
            {
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                cmd.ExecuteNonQuery();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return true;
        }


        public List<Category> GetAllCategories()
        {
            string querry = "Select * from T_Category";
            List<Category> aList = new List<Category>();
            try
            {
                Category aCategory = new Category();
                aCategory.SL = 0;
                aCategory.Name = "Select Category";
                aList.Add(aCategory);
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                itemIdReader = cmd.ExecuteReader();
                while (itemIdReader.Read())
                {
                    aCategory = new Category();
                    aCategory.SL = (int)itemIdReader["CatID"];
                    aCategory.Name = itemIdReader["CatName"].ToString();
                    aList.Add(aCategory);
                }
                itemIdReader.Close();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return aList;
        }


        public List<Company> GetAllCompany()
        {
            string querry = "Select * from T_Company";
            List<Company> aList = new List<Company>();
            try
            {
                Company aCompany = new Company();
                aCompany.SL = 0;
                aCompany.Name = "Select Company";
                aList.Add(aCompany);
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                itemIdReader = cmd.ExecuteReader();
                while (itemIdReader.Read())
                {
                    aCompany = new Company();
                    aCompany.SL = (int)itemIdReader["ComID"];
                    aCompany.Name = itemIdReader["ComName"].ToString();
                    aList.Add(aCompany);
                }
                itemIdReader.Close();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return aList;
        }

        //stockin gateway
        public List<Item> GetAllItem(int companyID)
        {
            string querry = "Select * from T_Item where CompanyID="+companyID+"";
            List<Item> aList = new List<Item>();
            try
            {
                Item aItem = new Item();
                aItem.ID = 0;
                aItem.ItemName = "Select Item";
                aList.Add(aItem);
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                itemIdReader = cmd.ExecuteReader();
                while (itemIdReader.Read())
                {
                    aItem = new Item();
                    aItem.ID = (int)itemIdReader["ID"];
                    aItem.ItemName = itemIdReader["ItemName"].ToString();
                    aList.Add(aItem);
                }
                itemIdReader.Close();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return aList;
        }

        public bool StockIn(int itemID, int quantity)
        {
            string querry = "INSERT INTO T_StockIn VALUES(" + itemID + ", '" + quantity + "')";
            try
            {
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                cmd.ExecuteNonQuery();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return true;
        }


        //item details



        //Stockout Gateway
        public bool StockOutData(StockOut aStockOut)
        {
            int rowCount = 0;
            string querry = "INSERT INTO T_StockOut VALUES((select ID from T_Item,T_Company where T_Company.ComID=T_Item.CompanyID AND ItemName='" + aStockOut.ItemName + "' AND ComName='" + aStockOut.companyName + "'), " + aStockOut.Quantity + ", '" + aStockOut.StockOutCategory + "', '" + aStockOut.Date + "')";
            try
            {
                cmd = new SqlCommand(querry, oConnectionClass.GetConnection());
                rowCount = cmd.ExecuteNonQuery();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return true;
        }

        //Date Search
        public List<DateSearch> GetStockOutData(string to, string from)
        {
            string query = "select ItemName,StockOutQuantity from T_StockOut,T_Item WHERE T_Item.ID = T_StockOut.ItemID AND StockOutDate BETWEEN '" + from + "' AND '" + to + "'  AND StockOutCategory = 'sell'";
            List<DateSearch> stockOutList = new List<DateSearch>();
            
            try
            {
                DateSearch aStockOut;
                int count = 0;
                cmd = new SqlCommand(query, oConnectionClass.GetConnection());
                itemIdReader = cmd.ExecuteReader();
                while (itemIdReader.Read())
                {
                    aStockOut = new DateSearch();
                    aStockOut.SL = count += 1;
                    aStockOut.Item = itemIdReader["ItemName"].ToString();
                    aStockOut.SaleQuantity = (int)itemIdReader["StockOutQuantity"];
                    stockOutList.Add(aStockOut);
                }
                itemIdReader.Close();
            }
            finally
            {
                oConnectionClass.GetClose();
            }
            return stockOutList;
        }

        public List<CatComSearch> GetItemList(int companyid, int catagoryid)
        {
            List<CatComSearch> aList = new List<CatComSearch>();
            List<int> itemIdList=new List<int>();
            string itemIdQuery;
            if (companyid > 0 && catagoryid > 0)
            {
                itemIdQuery = "SELECT ID FROM T_Item WHERE categoryID = " + catagoryid + " AND companyID = " + companyid + "";
            }
            else if (companyid > 0)
            {
                itemIdQuery = "SELECT ID FROM T_Item WHERE companyID = " + companyid + "";
            }
            else
            {
                itemIdQuery = "SELECT ID FROM T_Item WHERE categoryID = " + catagoryid + "";
            }
            CatComSearch aItem;
            try
            {
                cmd = new SqlCommand(itemIdQuery, oConnectionClass.GetConnection());
                itemIdReader = cmd.ExecuteReader();

                while (itemIdReader.Read())
                {
                    aItem = new CatComSearch();
                    int itemid = (int) itemIdReader["ID"];
                    itemIdList.Add(itemid);
                }

                foreach (int item in itemIdList)
                {
                    aItem = GetSearchItem(item);
                    aList.Add(aItem);
                }
               
            }

            finally
            {
                itemIdReader.Close();
                oConnectionClass.GetClose();
            }
            return aList;
        }

        public Item GetItemDetails(int itemID)
        {
            string query = "select ItemName,ReorderLevel, AvailableQuantity = ISNULL((select SUM(Stockin) from T_StockIn WHERE ItemID=" + itemID + "),0) - ISNULL((select SUM(StockOutQuantity) from T_StockOut WHERE ItemID=" + itemID + "),0) from T_Item where ID=" + itemID + "";
            Item aItem = new Item();
            try
            {
                cmd = new SqlCommand(query, oConnectionClass.GetConnection());
                itemIdReader = cmd.ExecuteReader();
                while (itemIdReader.Read())
                {
                    aItem.ItemName = itemIdReader["ItemName"].ToString();
                    aItem.ReorderLevel = (int)itemIdReader["ReorderLevel"];
                    aItem.AvilableQuantity = (int)itemIdReader["AvailableQuantity"];

                }
            }
            finally
            {
                itemIdReader.Close();
                oConnectionClass.GetClose();
            }
            return aItem;
        }

        //category and company search
        public CatComSearch GetSearchItem(int itemID)
        {
            string query = "select ComName,catName,ItemName,ReorderLevel, AvailableQuantity = ISNULL((select SUM(Stockin) from T_StockIn WHERE ItemID=" + itemID + "),0) - ISNULL((select SUM(StockOutQuantity) from T_StockOut WHERE ItemID=" + itemID + "),0) from T_Item,T_Category,T_Company WHERE T_Category.catID=T_Item.CategoryID AND T_Company.ComID=T_Item.CompanyID AND ID=" + itemID + "";
            CatComSearch aItem = new CatComSearch();
            try
            {
                cmd = new SqlCommand(query, oConnectionClass.GetConnection());
                itemIdReader = cmd.ExecuteReader();
                while (itemIdReader.Read())
                {
                    aItem.Company = itemIdReader["ComName"].ToString();
                    aItem.Category = itemIdReader["catName"].ToString();
                    aItem.Item = itemIdReader["ItemName"].ToString();
                    aItem.ReorderLevel = (int)itemIdReader["ReorderLevel"];
                    aItem.AvilableQuantity = (int)itemIdReader["AvailableQuantity"];
                }
            }
            finally
            {
                itemIdReader.Close();
                oConnectionClass.GetClose();
            }
            return aItem;
        }
    }
}