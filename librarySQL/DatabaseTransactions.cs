using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Data.SqlClient;

namespace librarySQL
{
    internal class DatabaseTransactions
    {
        //App.Config dosyasinin icindeki veritabani baglanti cumlesi bir degiskene atandi.
        string ConnectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        public SqlConnection Connect()
        {
            //Veritabani baglantisi olusturuldu.
            SqlConnection connect = new SqlConnection(ConnectionString);
            //Onceki baglantilar temizlendi.
            SqlConnection.ClearPool(connect);
            return connect;
        }
    }
}
