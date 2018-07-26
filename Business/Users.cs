using DB.Common.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    [DBDocumentTypeName("Users", DBCollectionNames.COLLECTION_USER)]
    class Users: IDbDocument
    {
        public object Id { get; set; }

        public string type { get; set; }

        public string UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Department { get; set; }

        public Users(string userID, string userName, string email, string department)
        {
            this.Id = Guid.NewGuid().ToString("N");
            this.UserID = userID;
            this.Username = userName;
            this.Email = email;
            this.Department = department;
        }

        public UserRole[] Roles { get; set; }
        
    }
}
