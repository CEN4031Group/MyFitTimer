using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Stopwatch0005.Data
{
    public static class TimeTrack
    {
        public static SqlConnection Get_DB_Connection()
        {
            string cnn_String = Properties.Settings.Default.Connection_String;
            SqlConnection cnnn_connection = new SqlConnection(cnn_String);
            if (cnnn_connection.State != ConnectionState.Open) cnnn_connection.Open();
            return cnnn_connection;
        }

        public static DataTable Get_DataTable(string SQL_Text)
        {
            SqlConnection cnnn_connection = Get_DB_Connection();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cnnn_connection);
            adapter.Fill(table);
            return table;
        }

        public static void Execute_SQL(string SQl_Text)
        {
            SqlConnection cnnn_connection = Get_DB_Connection();
            SqlCommand cmd_Command = new SqlCommand(SQl_Text, cnnn_connection);
            cmd_Command.ExecuteNonQuery();
        }

        public static void Close_DB_Connection()
        {
            string cnn_String = Properties.Settings.Default.Connection_String;
            SqlConnection connection = new SqlConnection(cnn_String);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
}
