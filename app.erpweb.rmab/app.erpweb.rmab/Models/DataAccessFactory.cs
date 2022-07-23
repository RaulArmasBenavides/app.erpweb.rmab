using app.erpweb.rmab.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.erpweb.rmab.Models
{
    abstract class DataAccessFactory
    {
        public static IProductoDataAccess GetProductDataAccessObj()
        {
            return new ProductoDao();
        }

        public static IProductoDataAccess GetProductDataAccessObj2()
        {
            return new ProductoTestDao();
        }
    }
}