
using System.Configuration;

namespace app.erpweb.rmab.DataBase
{
    public class AccesoDB
    {
        //propiedad
        public string CadenaConexion { get; set; }

        //constructor
        public AccesoDB()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["neptuno"].ConnectionString;
        }
    }
}
