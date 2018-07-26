using Data.Connections;
using DatabaseAPI;
using DB.Common.Util;
using System;
using System.Collections.Generic;

namespace Business
{
    public class Utils
    {


        public void Start()
        {
            try
            {
                DatabaseUtil context = new DatabaseUtil();
                DatabaseContext dbContext = context.GetDBContext("tenant1");

                UserRole tempRole1 = new UserRole("id-101", "manager900", "testing9");
                UserRole tempRole2 = new UserRole("id-101", "manager900", "testing9");
                Users user = new Users("user-id6969", "user1", "user100@gmail.com", "testomg");
                user.Roles = new UserRole[2];
                user.Roles[0] = tempRole1;
                user.Roles[1] = tempRole2;
                List<UserRole> roleList = new List<UserRole>();
                roleList.Add(tempRole1);
                roleList.Add(tempRole2);


                
                dbContext.BasicLookup.InsertSingleRecord<Users>(user);
                dbContext.BasicLookup.InsertMultipleRecords<UserRole>(roleList);
                Users item = dbContext.BasicLookup.GetRecordFromID<Users>("user - id6969");
                if (item != null)
                {
                    Console.WriteLine("Record exists");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
            }

        }

        private static List<object> GetUserList()
        {
            List<object> list = new List<object>();

            Users role1 = new Users("user-id2", "user1", "user100@gmail.com", "testomg");
            list.Add(role1);

            UserRole tempRole = new UserRole("role-id3", "manager900", "testing9");

            role1 = new Users("user-id3", "user2", "user200@gmail.com", "development");
            list.Add(role1);

            return (list);
        }
    }
}
