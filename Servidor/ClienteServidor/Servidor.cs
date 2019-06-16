
// Programa Servidor using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using System;
using System.Data;
using c;
using System.Threading;

namespace SvrP
{
    class Servidor
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Server Application ***");
           // Conexion conexion;
            // Se ejecuta el Listener en un ciclo para que se repita // de forma indefinida y acepte tantas conexiones sean posibles 
            while (true)
            {
                try
                {
                    // Inicializar Listener 

                    IPAddress localAddr = IPAddress.Parse("192.168.137.211");
                    TcpListener myList = new TcpListener(localAddr, 8002);
                    myList.Start();
                    Console.WriteLine("Servidor corriendo en Puerto 8002...");
                    Console.WriteLine("Local End Point:" + myList.LocalEndpoint);
                    Console.WriteLine("Esperando conexión...");
                    Socket s = myList.AcceptSocket();
                    Console.WriteLine("Conexión recibida desde: " + s.RemoteEndPoint);
                    // Guardar en una variable la información // recibida del cliente 

                    ////////////////////////////////////////
                    byte[] b = new byte[10];
                    byte[] pass = new byte[100];

                    
                    int k = s.Receive(b);
                    
                    Console.WriteLine("Recibido...");
                    // Convierte e iprime el contenido de la cadena 
                    string cadena = "";
                    for (int i = 0; i < k; i++)
                    {
                        cadena = cadena + Convert.ToChar(b[i]);
                    }

                    Console.WriteLine("Datos: " + cadena);
                   
                    if (cadena == "insertar")
                    {
                        Console.WriteLine("Usted va a insertar datos");
                        byte[] c = new byte[100];
                        byte[] p = new byte[100];
                        byte[] po = new byte[100];
                        int t = s.Receive(c,0);
                       
                        Console.WriteLine("Recibido...");
                        // Convierte e iprime el contenido de la cadena 
                        string cad = "";
                        for (int i = 0; i < t; i++)
                        {
                            
                            cad = cad + Convert.ToChar(c[i]);
                        }

                        Console.WriteLine("Recibido usuario: " + cad );


                        int l = s.Receive(p, 0);
                        // Convierte e iprime el contenido de la cadena 
                        string contra = "";
                        for (int i = 0; i < l; i++)
                        {
                            contra += Convert.ToChar(p[i]);
                        }

                        Console.WriteLine("Pass...\n"+contra);
                       
                        Conexion  co = new Conexion(cad,contra);
                         co.recibir(s);
                       //  co.insertar(nombre, "Virgen1212", "Sasa1", 22.3, 5);
                      
                         s.Close();
                         myList.Stop();
                    }else
                    {
                        if (cadena == "eliminar")
                        {
                            Console.WriteLine("Usted va a eliminar datos");
                            byte[] c = new byte[100];
                            byte[] p = new byte[100];
                            byte[] po = new byte[100];
                            byte[] par = new byte[100];
                            int t = s.Receive(c, 0);

                            Console.WriteLine("Recibido...");
                            // Convierte e iprime el contenido de la cadena 
                            string cad = "";
                            for (int i = 0; i < t; i++)
                            {

                                cad = cad + Convert.ToChar(c[i]);
                            }

                            Console.WriteLine("Recibido usuario: " + cad);


                            int l = s.Receive(p, 0);
                            // Convierte e iprime el contenido de la cadena 
                            string contra = "";
                            for (int i = 0; i < l; i++)
                            {
                                contra += Convert.ToChar(p[i]);
                            }

                            Console.WriteLine("Pass...\n" + contra);

                            int bc = s.Receive(par, 0);
                            // Convierte e iprime el contenido de la cadena 
                            string param = "";
                            for (int i = 0; i < bc; i++)
                            {
                                param += Convert.ToChar(par[i]);
                            }

                            Console.WriteLine("Param...\n" + param);

                            Conexion co = new Conexion(cad, contra);
                            co.Eliminar(Convert.ToInt32(param));

                            s.Close();
                            myList.Stop();
                        }
                        else
                        {
                            if (cadena == "mostrar")
                            {
                                byte[] c = new byte[100];
                                int t = s.Receive(c, 0);

                                Console.WriteLine("Recibido...");
                                // Convierte e iprime el contenido de la cadena 
                                string cad1 = "";
                                for (int i = 0; i < t; i++)
                                {

                                    cad1 = cad1 + Convert.ToChar(c[i]);
                                }

                                Console.WriteLine("Recibido usuario: " + cad1);
                                int j = s.Receive(pass);
                                string cad = "";
                                for (int l = 0; l < j; l++)
                                {
                                    cad = cad + Convert.ToChar(pass[l]);
                                }

                                Console.WriteLine("Pass " + cad);

                                ASCIIEncoding asen = new ASCIIEncoding();
                                Conexion co = new Conexion(cad1, cad);
                                SqlCommand comando = new SqlCommand();
                                comando.Connection = co.Abriconexion();
                                try
                                {

                                    DataTable tabla = new DataTable();
                                    SqlDataReader leer;
                                    //
                                    comando.CommandText = "MostrarProductos";
                                    comando.CommandType = CommandType.StoredProcedure;
                                    leer = comando.ExecuteReader();
                                    tabla.Load(leer);

                                    for (int i = 0; i < tabla.Rows.Count; i++)
                                    {
                                        string datoDT = tabla.Rows[i]["Id"].ToString();
                                        string datoDT1 = tabla.Rows[i]["Nombre"].ToString();
                                        string datoDT2 = tabla.Rows[i]["Descripcion"].ToString();
                                        string datoDT3 = tabla.Rows[i]["Marca"].ToString();
                                        string datoDT4 = tabla.Rows[i]["Precio"].ToString();
                                        string datoDT5 = tabla.Rows[i]["Stock"].ToString();
                                        Console.WriteLine(datoDT1 + "Stock" + datoDT5);
                                        s.Send(asen.GetBytes(datoDT));
                                        Thread.Sleep(100);
                                        s.Send(asen.GetBytes(datoDT1));
                                        Thread.Sleep(100);
                                        s.Send(asen.GetBytes(datoDT2));
                                        Thread.Sleep(100);
                                        s.Send(asen.GetBytes(datoDT3));
                                        Thread.Sleep(100);
                                        s.Send(asen.GetBytes(datoDT4));
                                        Thread.Sleep(100);
                                        s.Send(asen.GetBytes(datoDT5));
                                        //me parece que aqui habia algo mas
                                        //Voy buscar info 
                                    }


                                    //  s.Send(asen.GetBytes("Usuario Correcto"));


                                    co.Cerrarconexion(); // Enviar señal exitosa al Cliente // Esta señal puede variar dependiendo //del proceso ejecutado

                                    s.Close();
                                    myList.Stop();

                                }
                                catch (Exception ex)
                                {


                                  //  s.Send(asen.GetBytes("Error en la conexion"));
                                    Console.WriteLine("Error");
                                    co.Cerrarconexion(); // Enviar señal exitosa al Cliente // Esta señal puede variar dependiendo //del proceso ejecutado

                                    s.Close();
                                    myList.Stop();
                                }
                            }else
                            {
                                int j = s.Receive(pass);
                                string cad = "";
                                for (int l = 0; l < j; l++)
                                {
                                    cad = cad + Convert.ToChar(pass[l]);
                                }

                                Console.WriteLine("Pass " + cad);

                                ASCIIEncoding asen = new ASCIIEncoding();
                                Conexion co = new Conexion(cadena, cad);
                                SqlCommand comando = new SqlCommand();
                                comando.Connection = co.Abriconexion();
                                try
                                {

                                   


                                    s.Send(asen.GetBytes("Usuario Correcto"));


                                    co.Cerrarconexion(); // Enviar señal exitosa al Cliente // Esta señal puede variar dependiendo //del proceso ejecutado

                                    s.Close();
                                    myList.Stop();

                                }
                                catch (Exception ex)
                                {


                                    s.Send(asen.GetBytes("Error en la conexion"));
                                    Console.WriteLine("Error");
                                    co.Cerrarconexion(); // Enviar señal exitosa al Cliente // Esta señal puede variar dependiendo //del proceso ejecutado

                                    s.Close();
                                    myList.Stop();
                                }
                            }

                            // Convierte e iprime el contenido de la cadena 
                           




                        }
                       



                    }



                }
                catch (Exception e)
                {
                    Console.WriteLine("nError... " + e.StackTrace);
                }

            }
        }
    }
}
