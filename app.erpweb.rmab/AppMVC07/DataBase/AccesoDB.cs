
using System.Configuration;

namespace AppMVC07.DataBase
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
