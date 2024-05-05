using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.AccessoDati
{
    public class DataConnection
    {
        public OleDbConnection Connect(string connect)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connect;
            conn.Open();
            return conn;
        }

        public DataTable Select(string select, OleDbConnection con)
        {
            OleDbCommand com = new OleDbCommand(select, con);
            OleDbDataAdapter adapter = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public OleDbDataReader ExecuteReader(string select, OleDbConnection con)
        {
            OleDbCommand com = new OleDbCommand();
            com.CommandText = select;
            com.Connection = con;
            com.ExecuteNonQuery();
            OleDbDataReader data = com.ExecuteReader();
            return data;
        }

        public void Execute(string execute, OleDbConnection con)
        {
            OleDbCommand cm = new OleDbCommand();
            cm.CommandText = execute;
            cm.Connection = con;
            cm.ExecuteNonQuery();
        }

        public void Disconnect(OleDbConnection connect)
        {
             connect.Close();
        }

    }
}
