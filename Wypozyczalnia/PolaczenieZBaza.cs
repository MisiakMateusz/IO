using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public class PolaczenieZBaza
    {
        SqlConnection connection;
        SqlConnectionStringBuilder connectionBuilder;

        public SqlConnection Connection { get => connection; set => connection = value; }
        public SqlConnectionStringBuilder ConnectionBuilder { get => connectionBuilder; set => connectionBuilder = value; }

        public void ConnectTo()
        {
            //Data Source=DESKTOP-N72L5PJ;Initial Catalog=Wypozyczalnia;Integrated Security=True
            connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-N72L5PJ";
            connectionBuilder.InitialCatalog = "Wypozyczalnia";
            connectionBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(connectionBuilder.ToString());
        }
    }
}
