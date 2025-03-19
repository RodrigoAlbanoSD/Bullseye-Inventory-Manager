using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeProject
{
    public class txnItems
    {
        //txnItems and txn fields
        public int itemID;
        public string name;
        public int quantity;
        public int quantityInSite;
        public double costPrice;
        public double totalCost;
        public int txnID;
        public string status;
        public double weight;

        //Constructor
        public txnItems(int inItemID, double inTotalCost, string inName, int inQuantity)
        {
            itemID = inItemID;
            totalCost = inTotalCost;
            name = inName;
            quantity = inQuantity;
           
        }

        //Constructor 2
        public txnItems(int inTxnID, int inItemID, double inCostPrice, int inQuantity, string inStatus, int inQuantityInSite)
        {
            txnID = inTxnID;
            itemID = inItemID;
            costPrice = inCostPrice;
            quantity = inQuantity;
            status = inStatus;
            quantityInSite = inQuantityInSite;
            totalCost = costPrice * quantity;
        }

        //Constructor 3
        public txnItems(int inItemID, int inQuantity)
        {
            itemID = inItemID;
            quantity = inQuantity;

        }




        //Return a string with the current fields values
        //Linked with first constructor
       public string ToString()
        {
            if(name.Length >= 15)
            {
                return " " + quantity + "\t" + name.Substring(0, 15) + "\t\t" + totalCost;
            }
            return " " + quantity + "\t" + name + "\t\t" + totalCost;
        }
    
        //Return a string with the current fields values
        //Linked with second constructor
        public string ToStringWithStatus()
        {
            return txnID.ToString() + "\t" + itemID.ToString() + "\t" + quantity + "\t" + totalCost + "\t" + status;
        }
    }



        /*public int sku;
        public string description;
        public string category;
        public double weight;
        public double retailPrice;
        public int supplierID;
        public bool active;
        public string notes;
        public int caseSize;
        
        
         
public txnItems(int inTxnID, int inItemID, string inName, int inSKU,
            string inDescription, string inCategory, double inWeight, double inCostPrice, double inRetailPrice, int inSupplierID,
            bool inActive, string inNotes, int inCaseSize, int inQuantity, string inStatus, int inQuantityInSite)
        {
            txnID = inTxnID;
            itemID = inItemID;
            name = inName;
            sku = inSKU;
            description = inDescription;
            category = inCategory;
            weight = inWeight;
            costPrice = inCostPrice;
            retailPrice = inRetailPrice;
            supplierID = inSupplierID;
            active = inActive;
            notes = inNotes;
            caseSize = inCaseSize;
            quantity = inQuantity;
            status = inStatus;
            quantityInSite = inQuantityInSite;
            totalCost = costPrice * quantity;
        }  
         
         
         
         
         
         
         */



}
