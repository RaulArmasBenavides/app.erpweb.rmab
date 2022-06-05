using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace app.erpweb.rmab.Service
{
    public interface ICrudDao<T>
    {
        //definir las firmas
        void create(T t, SqlConnection cn);
        void update(T t, SqlConnection cn);
        void delete(T t, SqlConnection cn);
        T findForId(T t, SqlConnection cn);
        List<T> readAll(SqlConnection cn);
    }
}
