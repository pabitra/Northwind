using System;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Api.DataAccess
{
    public class NorthwindPopulator
    {
        private static readonly NorthwindPopulator northwindPopulator = new NorthwindPopulator();

        private NorthwindPopulator()
        {
          
        }

        public static NorthwindPopulator Singleton()
        {
            return northwindPopulator;
        }

        public void Initialize(DbContext context)
        {

        }
    }
}
