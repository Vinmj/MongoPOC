using System;
using System.Collections.Generic;
using System.Text;
using DB.Common.Util;
namespace Business
{
    [DBDocumentTypeName("Role", DBCollectionNames.COLLECTION_ROLE)]
    class UserRole : IDbDocument
    {
        public object Id { get; set; }

        public string type { get; set; }

        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public UserRole(string roleID, string roleName, string description)
        {
            this.Id = Guid.NewGuid().ToString("N");
            this.RoleID = roleID;
            this.RoleName = roleName;
            this.Description = description;
        }

        public void Calcultate()
        {
            int i = 9;
            int j = 8;
            int result = i + j;
        }
    }
}
