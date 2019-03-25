using System;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;

namespace myApp
{
    class Program
    {
        static string str1;
        static void Main(string[] args)
        {
            //Server=ACTKPTP115\\SQLTEST;Database=StudentsDB;Trusted_Conn‌ection=True;Multiple‌​ActiveResultSets=tru‌​e;
            SqlConnection con = new SqlConnection(@"Server=ipservidor\instanciabd;Database=bbddname;Persist Security Info=True;User ID=sa;Password=call");
            con.Open();

            SqlCommand cmd = new SqlCommand("SP_mystoredproc", con);
            cmd.Parameters.AddWithValue("@param1", "stringValue1");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (dt.Select("NombreColumna='VALOR'").GetLength(0) > 0 )
                {
                    // comandos si se cumple la condición
                }
 
                con.Close();
  
            }

            str1 = "Hola, mundo!";
            Console.WriteLine(str1);
        }
    }
}
