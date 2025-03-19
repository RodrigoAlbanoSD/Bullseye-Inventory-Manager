using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeProject
{
    public class User
    {

        //User fields
        public int userID;
        public string userName;
        public string FirstName;
        public string LastName;
        public string Email;
        public List<string> userPermissionID;

        public int siteID;
        /// 1 truck
        /// 2 wh
        /// 3 corps
        /// 4 sj

        public int positionID;
        public string permissionLevel;
        /// 1 regional m
        /// 2 financial m
        /// 3 store m
        /// 4 wh m
        /// 5 truck
        /// 6 wh emp
        /// 7 admin


        public User(int inUserID, string inFirstName, string inLastName, string inEmail, int inSiteID, int inPositionID, string inPermissionLevel, List<string> inUserPermissionID)
        {
            userID = inUserID;
            FirstName = inFirstName;
            LastName = inLastName;
            Email = inEmail;
            userPermissionID = inUserPermissionID;
            siteID = inSiteID;
            positionID = inPositionID;
            permissionLevel = inPermissionLevel;

            userName = FirstName + " " + LastName;
        }
    }
}
