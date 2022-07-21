using app.erpweb.rmab.Entity;
using app.erpweb.rmab.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace app.erpweb.rmab.Models
{
    public class ProductoTestDao : IProductoDataAccess
    {
        public void create(Producto t, SqlConnection cn)
        {
            throw new NotImplementedException();
        }

        public void delete(Producto t, SqlConnection cn)
        {
            throw new NotImplementedException();
        }

        public Producto findForId(Producto t, SqlConnection cn)
        {
            throw new NotImplementedException();
        }

        public List<Producto> readAll(SqlConnection cn)
        {
            throw new NotImplementedException();
        }

        public void update(Producto t, SqlConnection cn)
        {
            throw new NotImplementedException();
        }
    }
}