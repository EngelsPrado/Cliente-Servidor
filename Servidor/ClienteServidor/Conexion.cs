
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using System;
using System.Data;


namespace c
{
    public class Conexion
    {

        private string usuario, pass;

        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public Conexion(string cadena, string cad)
        {
            usuario = cadena;
            pass = cad;
       
            conexion.ConnectionString = setconection();
        }

        public Conexion()
        {

        }

        public void recibir(Socket s)
        {
           
            byte[] n = new byte[100];
            int m = s.Receive(n,0);
           
        
            // Convierte e iprime el contenido de la cadena 
            string nombre = "";
            for (int i = 0; i < m; i++)
            {
                nombre = nombre + Convert.ToChar(n[i]);
            }
            Console.WriteLine("Recibido..."+nombre);
            byte[] d = new byte[100];
            int des = s.Receive(d, 0);
            // Convierte e iprime el contenido de la cadena 
            string desc = "";
            for (int i = 0; i < des; i++)
            {
                desc = desc + Convert.ToChar(d[i]);
            }

          
            Console.WriteLine("Recibido..."+desc);
            byte[] ma = new byte[100];
            int mar = s.Receive(ma, 0);
            // Convierte e iprime el contenido de la cadena 
            string marca = "";
            for (int i = 0; i < mar; i++)
            {
                marca = marca + Convert.ToChar(ma[i]);
            }

            byte[] pr = new byte[100];
            int pre = s.Receive(pr, 0);
            Console.WriteLine("Recibido..."+marca);
            // Convierte e iprime el contenido de la cadena 
            string precio = "";
            for (int i = 0; i < pre; i++)
            {
                precio = precio + Convert.ToChar(pr[i]);
            }


            byte[] ca = new byte[100];
            int c = s.Receive(ca, 0);
            Console.WriteLine("Recibido..."+precio);
            // Convierte e iprime el contenido de la cadena 
            string cantidad = "";
            for (int i = 0; i < c; i++)
            {
                cantidad = cantidad + Convert.ToChar(ca[i]);
            }
            Console.WriteLine("Recibido..." + cantidad);
            insertar(nombre, desc, marca, Convert.ToDouble(precio), Int32.Parse(cantidad));
          
        }



        public SqlConnection Abriconexion()
        {

            if (conexion.State == ConnectionState.Closed)
                conexion.Open();

            return conexion;


        }


        public SqlConnection Cerrarconexion()
        {

            if (conexion.State == ConnectionState.Open)
                conexion.Close();

            return conexion;


        }
        public void Eliminar(int id)
        {
            comando.Connection =Abriconexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void insertar(string nombre, string desc, string marca, double precio, int stock)
        {

            comando.Connection = Abriconexion();
            comando.CommandText = "InsetarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
         //   comando.Connection = Cerrarconexion();
        }


        public string setconection()
        {
            return "Data Source=INGENIEROS-PC\\SA;Database=Practica;User ID=" + this.usuario + ";Password=" + this.pass;
        }

        public string getUser()
        {
            return this.usuario;
        }
        public string getPass()
        {
            return pass;
        }






    }

}