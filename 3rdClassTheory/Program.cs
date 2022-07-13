using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdClassTheory
{
    internal class Program
    {
        private static SqlConnection Connection = new SqlConnection();
        private static SqlTransaction transaction = null;

        static void Main(string[] args)
        {
            //InsertPerson();
            GetVisitas(); 
        }

        static void OpenConnection()
        {
            //string s = ConfigurationManager.AppSettings["Lugar"];
            string cs = ConfigurationManager.ConnectionStrings["Cn"].ConnectionString;
            Connection.ConnectionString = cs;

            Connection.Open();
        }
        static void CloseConnection()
        {
            Connection.Close();
        }

        public static void InsertPerson()
        {
            string nombre;
            string apellido;
            string cedula;
            string sexo;
            string lugar;

            OpenConnection();

            SqlCommand cmd = Connection.CreateCommand();


            cmd.Connection = Connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            Console.WriteLine("Cedula");
            cedula = Console.ReadLine();

            cmd.CommandText = "ppGetClient";

            cmd.Parameters.AddWithValue("@cedula", cedula);
            SqlDataReader dr = cmd.ExecuteReader();

            //cmd.ExecuteNonQuery();

            if(dr.HasRows)
            {
                dr.Read();

                Console.WriteLine($"Nombre: {dr["nombre"]}");
                nombre =   dr["nombre"].ToString();

                Console.WriteLine($"Apellido:  {dr["apellido"]}");
                apellido = dr["apellido"].ToString();

                dr.Close();
            }
            else
            {
                dr.Close();
                cmd.Parameters.Clear();

                transaction = Connection.BeginTransaction();
                cmd.Transaction = transaction;


                Console.WriteLine("Nombre");
                nombre = Console.ReadLine();

                Console.WriteLine("Apellido");
                apellido = Console.ReadLine();

                Console.WriteLine("Sexo(M o F)");
                sexo = Console.ReadLine();

                try
                {
                    cmd.CommandText = "ppInsertClient";

                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@sexo", sexo);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Err: " + ex);
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Lugar: ");
            lugar = Console.ReadLine();

            cmd.CommandText = "ppInsertVisita";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@lugar", lugar);

            cmd.ExecuteNonQuery();

            CloseConnection();
        } 

        private static void GetVisitas()
        {
            OpenConnection();

            SqlCommand cmd = Connection.CreateCommand();


            cmd.Connection = Connection;
            cmd.Transaction = transaction;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;



            cmd.CommandText = "ppGetVisitas";
            cmd.Parameters.AddWithValue("@cedula", -1);

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                Console.WriteLine($"Cedula\t  |  Nombre\t  |  Lugar\t\t  |  Fecha ");
                while (dr.Read())
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine($"{dr["cedula"]}\t  |  {dr["nombre"]}\t  |  {dr["lugar"]}\t\t  |  {dr["fecha"]}"); //
                }
            }

            Console.ReadKey();
            //cmd.ExecuteNonQuery();

            CloseConnection();
        }
    }
    
}
