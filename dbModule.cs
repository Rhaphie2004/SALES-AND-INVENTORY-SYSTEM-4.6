using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sims
{
    internal class dbModule
    {
        private MySqlConnection connection;
        private MySqlCommand cmd;
        private MySqlDataAdapter adapter;

        public MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=sims;user=root;password=");
            }
            return connection;
        }

        public MySqlCommand GetCommand()
        {
            if (cmd == null)
            {
                cmd = new MySqlCommand();
            }
            return cmd;
        }

        public MySqlDataAdapter GetAdapter()
        {
            if (adapter == null)
            {
                adapter = new MySqlDataAdapter();
            }
            return adapter;
        }
    }
}
