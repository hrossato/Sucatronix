using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    class Banco {
        private static string ConnectionString = "Server=localhost;Port=3306;Database=sucatronix;Uid=sucatronix;Pwd=sucatronix;Pooling=True;Connection Reset=False;Connection Lifetime=300;Cache Server Properties=True;Max Pool Size=4";

        public static void InitConnection(string server, int port, string database, string user, string pass) {
            ConnectionString = $"Server={server};Port={port};Database={database};Uid={user};Pwd={pass}";
        }

        public static bool ExecuteNonQuery(string statement, List<MySqlParameter> parameters = null) =>
            MySqlHelper.ExecuteNonQuery(ConnectionString, statement, parameters != null ? parameters.ToArray() : new MySqlParameter[] { }) > 0;

        public static object ExecuteScalar(string statement, List<MySqlParameter> parameters = null) =>
            MySqlHelper.ExecuteScalar(ConnectionString, statement, parameters != null ? parameters.ToArray() : new MySqlParameter[] { });

        public static MySqlDataReader ExecuteReader(string statement, List<MySqlParameter> parameters = null) =>
            MySqlHelper.ExecuteReader(ConnectionString, statement, parameters != null ? parameters.ToArray() : new MySqlParameter[] { });
    }
}
