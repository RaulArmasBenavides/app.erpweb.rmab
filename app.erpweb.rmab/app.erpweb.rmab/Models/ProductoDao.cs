using app.erpweb.rmab.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using app.erpweb.rmab.Service;
using app.erpweb.rmab.DataBase;
using System.Configuration;

namespace app.erpweb.rmab.Models
{
    public class ProductoDao :  IProductoDataAccess
    {
        //IDBConnection conex ;
        //propiedad
        //variables       
        SqlCommand cmd = null;
        public string CadenaConexion { get; set; }
        public ProductoDao()
        {
            //conex = new AccesoDB(CadenaConexion);
            CadenaConexion=  ConfigurationManager.ConnectionStrings["neptuno"].ConnectionString;
        }

        public void create(Producto t)
        {
            using (var cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
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
        }

        public void delete(Producto t)
        {
            using (var cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
                using (cmd = new SqlCommand("usp_Producto_Eliminar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", t.IdProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Producto findForId(Producto t)
        {
            Producto pro=null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
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
            }
            return pro;
        }

        public List<Producto> readAll()
        {
            List<Producto> lista=null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
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
            }   
            return lista;
        }

        public void update(Producto t)
        {
            using (var cn = new SqlConnection(CadenaConexion))
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
}
