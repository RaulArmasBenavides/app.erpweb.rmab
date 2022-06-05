using app.erpweb.rmab.Entity;
using app.erpweb.rmab.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace app.erpweb.rmab.Models
{
    public class ProductoDao : ICrudDao<Producto>
    {
        //variables       
        SqlCommand cmd = null;
        public void create(Producto t, SqlConnection cn)
        {
            using (cmd=new SqlCommand("usp_Producto_Adicionar",cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", t.NombreProducto);
                cmd.Parameters.AddWithValue("@IdProveedor", t.IdProveedor);
                cmd.Parameters.AddWithValue("@IdCategoria", t.IdCategoria);
                cmd.Parameters.AddWithValue("@Precio", t.Precio);
                cmd.Parameters.AddWithValue("@Stock", t.Stock);
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                t.IdProducto = (int)cmd.Parameters["@IdProducto"].Value;
            }
        }

        public void delete(Producto t, SqlConnection cn)
        {
            using (cmd = new SqlCommand("usp_Producto_Eliminar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", t.IdProducto);
                cmd.ExecuteNonQuery();
            }
        }

        public Producto findForId(Producto t, SqlConnection cn)
        {
            Producto pro=null;
            using (cmd = new SqlCommand("usp_Producto_Buscar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", t.IdProducto);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {                   
                    int posIdPro = dr.GetOrdinal("IdProducto");
                    int posNom = dr.GetOrdinal("NombreProducto");
                    int posIdProv = dr.GetOrdinal("IdProveedor");
                    int posIdCat = dr.GetOrdinal("IdCategoría");
                    int posPre = dr.GetOrdinal("PrecioUnidad");
                    int posStk = dr.GetOrdinal("Stock");                  
                    if (dr.Read())
                    {
                        pro = new Producto()
                        {
                            IdProducto = dr.GetInt32(posIdPro),
                            NombreProducto = dr.GetString(posNom),
                            IdProveedor = dr.GetInt32(posIdProv),
                            IdCategoria = dr.GetInt32(posIdCat),
                            Precio = dr.GetDecimal(posPre),
                            Stock = dr.GetInt16(posStk)
                        };                      
                    }                   
                }
                dr.Close();
            }
            return pro;
        }

        public List<Producto> readAll(SqlConnection cn)
        {
            List<Producto> lista=null;

            using (cmd = new SqlCommand("usp_Producto_Listar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();              
                if (dr != null)
                {
                    Producto pro;
                    int posIdPro = dr.GetOrdinal("IdProducto");
                    int posNom = dr.GetOrdinal("NombreProducto");
                    int posIdProv = dr.GetOrdinal("IdProveedor");
                    int posIdCat = dr.GetOrdinal("IdCategoría");
                    int posPre = dr.GetOrdinal("PrecioUnidad");
                    //int posStk = dr.GetOrdinal("Stock");
                    lista = new List<Producto>();
                    while (dr.Read())
                    {
                        pro = new Producto()
                        {
                            IdProducto = dr.GetInt32(posIdPro),
                            NombreProducto = dr.GetString(posNom),
                            IdProveedor = dr.GetInt32(posIdProv),
                            IdCategoria = dr.GetInt32(posIdCat),
                            Precio = dr.GetDecimal(posPre),
                            //Stock = dr.GetInt16(posStk)
                        };
                        lista.Add(pro);
                    }
                    dr.Close();
                }
            }
            return lista;
        }

        public void update(Producto t, SqlConnection cn)
        {
            using (cmd = new SqlCommand("usp_Producto_Actualizar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", t.NombreProducto);
                cmd.Parameters.AddWithValue("@IdProveedor", t.IdProveedor);
                cmd.Parameters.AddWithValue("@IdCategoria", t.IdCategoria);
                cmd.Parameters.AddWithValue("@Precio", t.Precio);
                cmd.Parameters.AddWithValue("@Stock", t.Stock);
                cmd.Parameters.AddWithValue("@IdProducto",t.IdProducto);
                cmd.ExecuteNonQuery();               
            }
        }
    }
}
