using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                    new Author
                    {
                        Name = "Eric",
                        Lastname = "Ries",
                        BirthDate = new DateTime(1978, 09, 22)
                    },
                    new Author
                    {
                        Name = "Charlotte Perkins",
                        Lastname = "Gilman",
                        BirthDate = new DateTime(1935, 08, 17)
                    },
                    new Author
                    {
                        Name = "Frank",
                        Lastname = "Herbert",
                        BirthDate = new DateTime(1920, 10, 08)
                    }
            );
        }
    }
}
