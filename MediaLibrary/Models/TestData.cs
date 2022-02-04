using MediaLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaLibrary.Models
{
    public class TestData
    {



        public static void AddTestData(MediaLibraryContext mediaLibraryContext)
        {


            var chadUser = new MediaLibraryUser
            {
                Id = 1,
                UserName = "chadb",
                Password = "WormHole$99",
                IsSuperUser = true
            };

            var testUser2 = new MediaLibraryUser
            {
                Id = 2,
                UserName = "testuser2",
                Password = "P@ssw0rd$1",
                IsSuperUser = false

            };

            mediaLibraryContext.MediaLibraryUsers.AddRange(chadUser, testUser2);

            mediaLibraryContext.SaveChanges();


        }
    }
}
