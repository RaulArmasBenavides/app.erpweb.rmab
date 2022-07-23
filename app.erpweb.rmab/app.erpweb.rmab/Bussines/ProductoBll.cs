using app.erpweb.rmab.DataBase;
using app.erpweb.rmab.Entity;
using app.erpweb.rmab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using app.erpweb.rmab.Service;

namespace app.erpweb.rmab.Bussines
{
    public class ProductoBll
    {
        private readonly IProductoDataAccess _ProductDataAccess;
        
        public ProductoBll()
        {
            _ProductDataAccess = DataAccessFactory.GetProductDataAccessObj();
        }

        public List<Producto> ProductoListar()
        {
                try
                {
                    return _ProductDataAccess.readAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

       //public List<Producto> ProductoListar()
       // {
       //     List<Producto> lista = null;
       //     using (var cn=new SqlConnection(CadenaConexion) )
       //     {
       //         ProductoDao dao = null;
       //         try
       //         {
       //             dao = new ProductoDao();
       //             cn.Open();
       //             lista = dao.readAll(cn);
       //         }
       //         catch (Exception ex)
       //         {
       //             throw ex;
       //         }
       //     }//cn.close()
       //     return lista;
       // }

        public Producto ProductoConsultar(Producto p)
        {
            Producto pro = null;
             try
             {
                pro = _ProductDataAccess.findForId(p);
             }
             catch (Exception ex)
             {
                    throw ex;
             }
            return pro;
        }

        public void ProductoAdicionar(Producto p)
        {
                try
                {
                    _ProductDataAccess.create(p);
                }
                catch (Exception ex)
                {
                    throw ex;
                }       
        }

        public void ProductoActualizar(Producto p)
        {
                try
                {
                 _ProductDataAccess.update(p);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        public void ProductoEliminar(Producto p)
        {
                try
                {
                    _ProductDataAccess.delete(p);
                }
                catch (Exception ex)
                {
                    throw ex;
                }         
        }



    }
}
