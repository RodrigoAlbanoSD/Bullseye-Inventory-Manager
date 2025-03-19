using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BullseyeProject
{
    public class Txn
    {
        public int txnID;
        public int siteIDFrom;
        public int siteIDTo;
        public string status;
        public DateTime shipDate;
        public string txnType;
        public string barcode;
        public DateTime createdDate;
        public int deliveryID;
        public int emergencyDelivery;

        private static string connString = "server=localhost;database=bullseyedb2022;" +
           "userid=Rodrigo;password=rororo0808";
        MySqlConnection conn = new MySqlConnection(connString);
        public Txn(int inTxnID, int inSiteIDFrom, int inSiteIDTo, string inStatus, DateTime inShipDate, string inTxnType, string inBarcode, DateTime inCreateDate, int inDeliveryID, int inEO)
        {
            txnID = inTxnID;
            siteIDFrom = inSiteIDFrom;
            siteIDTo = inSiteIDTo;
            status = inStatus;
            shipDate = inShipDate;
            txnType = inTxnType;
            barcode = inBarcode;
            createdDate = inCreateDate;
            deliveryID = inDeliveryID;
            emergencyDelivery = inEO;
        }


        public Txn(int inSiteIDFrom, int inSiteIDTo, string inStatus, DateTime inShipDate, string inTxnType, string inBarcode, DateTime inCreateDate, int inDeliveryID, int inEO)
        {
            siteIDFrom = inSiteIDFrom;
            siteIDTo = inSiteIDTo;
            status = inStatus;
            shipDate = inShipDate;
            txnType = inTxnType;
            barcode = inBarcode;
            createdDate = inCreateDate;
            deliveryID = inDeliveryID;
            emergencyDelivery = inEO;
        }

        public Txn() { }
        
    }
}
