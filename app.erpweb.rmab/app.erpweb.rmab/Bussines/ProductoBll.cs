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
    public class ProductoBll : AccesoDB
    {
       
       IProductoDataAccess _ProductDataAccess;


        public ProductoBll()
        {
            _ProductDataAccess = DataAccessFactory.GetProductDataAccessObj2();
        }


        public List<Producto> ProductoListar2()
        {

            using (var cn = new SqlConnection(CadenaConexion))
            {
                ProductoDao dao = null;
                try
                {
                    dao = new ProductoDao();
                    cn.Open();
                    return _ProductDataAccess.readAll(cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
        
        }

       public List<Producto> ProductoListar()
        {
            List<Producto> lista = null;
            using (var cn=new SqlConnection(CadenaConexion) )
            {
                ProductoDao dao = null;
                try
                {
                    dao = new ProductoDao();
                    cn.Open();
                    lista = dao.readAll(cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
            return lista;
        }

        public Producto ProductoConsultar(Producto p)
        {
            Producto pro = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ProductoDao dao = null;
                try
                {
                    dao = new ProductoDao();
                    cn.Open();
                    pro = dao.findForId(p, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
            return pro;
        }

        public void ProductoAdicionar(Producto p)
        {
           using (var cn = new SqlConnection(CadenaConexion))
            {
                ProductoDao dao = null;
                try
                {
                    dao = new ProductoDao();
                    cn.Open();
                    dao.create(p, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()            
        }

        public void ProductoActualizar(Producto p)
        {
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ProductoDao dao = null;
                try
                {
                    dao = new ProductoDao();
                    cn.Open();
                    dao.update(p, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()            
        }

        public void ProductoEliminar(Producto p)
        {
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ProductoDao dao = null;
                try
                {
                    dao = new ProductoDao();
                    cn.Open();
                    dao.delete(p, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()            
        }



    }
}
