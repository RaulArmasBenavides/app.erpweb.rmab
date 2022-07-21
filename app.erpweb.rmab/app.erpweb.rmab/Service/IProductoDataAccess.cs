using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using app.erpweb.rmab.Entity;

namespace app.erpweb.rmab.Service
{
    public interface IProductoDataAccess
    {
        //definir las firmas
        void create(Producto t, SqlConnection cn);
        void update(Producto t, SqlConnection cn);
        void delete(Producto t, SqlConnection cn);
        Producto findForId(Producto t, SqlConnection cn);
        List<Producto> readAll(SqlConnection cn);
    }
}
