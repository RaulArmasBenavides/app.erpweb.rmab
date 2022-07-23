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
        void create(Producto t);
        void update(Producto t);
        void delete(Producto t);
        Producto findForId(Producto t);
        List<Producto> readAll();
    }
}
