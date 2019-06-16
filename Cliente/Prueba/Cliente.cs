using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace CteP
{
    public class Cliente
    {
        private Label aviso;
        private DataGridView data;
        string usuario, password,nombre,descripcion,marca;
       string cantidad;
        string precio;
        string param;

      public Cliente(string usuario, string password,string txt)
        {
            this.usuario = usuario;
            this.password = password;
            param = txt;
            eliminarProd();
        }
       
       //necesito poner tu editor con la pantalla blanca
           
        public Cliente(string usuario, string password,Label aviso)
        {
            this.usuario = usuario;
            this.password = password;
            this.aviso = aviso;
            Main();
        }

        public Cliente(string usuario, string password, DataGridView data)
        {
            this.usuario = usuario;
            this.password = password;
            this.data = data;
            mostrarProd();
        }

        public Cliente(string usuario, string password,string nombre,string descripcion,string marca,string precio,string cantidad )
        {
            this.usuario = usuario;
            this.password = password;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.marca = marca;
            this.precio = precio;
            this.cantidad = cantidad;
            InsertarProd();
        }
        public void mostrarProd()
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect("192.168.137.211", 8002);
                Console.WriteLine("*** Conectado con el servidor ***");
                NetworkStream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();

                byte[] inser = Encoding.ASCII.GetBytes("mostrar");
                byte[] u = Encoding.ASCII.GetBytes(usuario);
                byte[] p = Encoding.ASCII.GetBytes(password);
             






                stm.Write(inser, 0, inser.Length);
                Thread.Sleep(200);
                stm.WriteAsync(u, 0, u.Length);
                Thread.Sleep(200);
                stm.WriteAsync(p, 0, p.Length);



                // Se descachimba despues de una accion 

                // recibir acuse, se debe converir a string

                Thread.Sleep(100);
                // recibir acuse, se debe converir a string
                do
                {
                    byte[] id = new byte[100];
                    int k0 = stm.Read(id, 0, 100);
                    Console.WriteLine("Entro");
                    string recibir = "";
                    for (int i = 0; i < k0; i++)
                        recibir = recibir + Convert.ToChar(id[i]);
                    byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);
                    Console.WriteLine("Entro");
                    string recibir1 = "";
                    for (int i = 0; i < k; i++)
                        recibir1 = recibir1 + Convert.ToChar(bb[i]);

                    byte[] b2 = new byte[100];
                    int k2 = stm.Read(b2, 0, 100);
                    string recibir2 = "";
                    for (int i = 0; i < k2; i++)
                        recibir2 = recibir2 + Convert.ToChar(b2[i]);

                    byte[] b3 = new byte[100];
                    int k3 = stm.Read(b3, 0, 100);
                    string recibir3 = "";
                    for (int i = 0; i < k3; i++)
                        recibir3 += Convert.ToChar(b3[i]);
                    byte[] b4 = new byte[100];
                    int k4 = stm.Read(b4, 0, 100);
                    string recibir4 = "";
                    for (int i = 0; i < k4; i++)
                        recibir4 += Convert.ToChar(b4[i]);
                    byte[] b5 = new byte[100];
                    int k5 = stm.Read(b5, 0, 100);
                    string recibir5 = "";
                    for (int i = 0; i < k5; i++)
                        recibir5 += Convert.ToChar(b5[i]);

                    data.Rows.Add(recibir,recibir1, recibir2, recibir3, recibir4, recibir5);
                    Thread.Sleep(100);
                } while (stm.DataAvailable);
                Console.WriteLine("cierro"); 
              
                stm.Close();
                tcpclnt.Close();
                tcpclnt = null;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }



        }
        public void eliminarProd()
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect("192.168.137.211", 8002);
                Console.WriteLine("*** Conectado con el servidor ***");
                NetworkStream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();

                byte[] inser = Encoding.ASCII.GetBytes("eliminar");
                byte[] u = Encoding.ASCII.GetBytes(usuario);
                byte[] p = Encoding.ASCII.GetBytes(password);
                byte[] ba = asen.GetBytes(param);
            
              




                stm.Write(inser, 0, inser.Length);
                Thread.Sleep(100);
                stm.WriteAsync(u, 0, u.Length);
                Thread.Sleep(100);
                stm.WriteAsync(p, 0, p.Length);
                Thread.Sleep(100);
                stm.WriteAsync(ba, 0, ba.Length);


                // recibir acuse, se debe converir a string
                

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                string recibir = "";
                for (int i = 0; i < k; i++)
                    recibir = recibir + Convert.ToChar(bb[i]);
                aviso.Text = recibir;
                tcpclnt.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            

        }
        //Ya vienen convertidos
        public void InsertarProd()
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect("192.168.137.211", 8002);
                Console.WriteLine("*** Conectado con el servidor ***");
                NetworkStream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();

                byte[] inser = Encoding.ASCII.GetBytes("insertar");
                byte[] u = Encoding.ASCII.GetBytes(usuario);
                byte[] p = Encoding.ASCII.GetBytes(password);
                byte[] ba = asen.GetBytes(nombre);
                byte[] bc = asen.GetBytes(descripcion);
                byte[] bd = asen.GetBytes(marca);
                byte[] bf = asen.GetBytes(precio);
                byte[] bg = Encoding.ASCII.GetBytes(cantidad);




                stm.Write(inser,0,inser.Length);
                Thread.Sleep(100);
                 stm.WriteAsync(u, 0, u.Length);
                Thread.Sleep(100);
                stm.WriteAsync(p, 0, p.Length);
                Thread.Sleep(100);
                stm.WriteAsync(ba, 0, ba.Length);
                Thread.Sleep(100);
                stm.WriteAsync(bc, 0, bc.Length);
                Thread.Sleep(100);
                stm.WriteAsync(bd, 0, bd.Length);
                Thread.Sleep(100);
                stm.WriteAsync(bf, 0, bf.Length);
                Thread.Sleep(100);
                stm.WriteAsync(bg, 0, bg.Length);
               // Me da curiosidad que cosa? hacer eso no tendrias q usar bytes por columna
               // si es solo por dar el gusto mejor que quede asi
               //Basicamente ya tenemos lo que pidio. pues si 
               // la cagdada es que si me pide mostrar lo que hize yo
               //Le mostras la parte del cliente 

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                string recibir = "";
                for (int i = 0; i < k; i++)
                    recibir = recibir + Convert.ToChar(bb[i]);

                tcpclnt.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
           
            // aviso.Text = recibir;

        } 

        public void Main()
        {
            Console.WriteLine("Client Application");
         
                try
                {
                    TcpClient tcpclnt = new TcpClient();
                    Console.WriteLine("Conectando.....");
                    // utilizar para este caso IP local ya que
                    // cliente y servidor corren en la misma PC
                    tcpclnt.Connect("192.168.137.211", 8002);
                    Console.WriteLine("*** Conectado con el servidor ***");

                   NetworkStream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();

                String[]datas = { usuario, password };
                byte[] ba;
                for (int i = 0; i < datas.Length; i++)
                {
                    ba= asen.GetBytes(datas[i]);
                    stm.Write(ba, 0, ba.Length);
                    Thread.Sleep(100);

                    ba = null;
                }
                // convertir cadena a ascii para transmitirla


                // recibir acuse, se debe converir a string
                //Realmente tendria que ser aqui
                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                string recibir = "";
                for (int i = 0; i < k; i++)
                    recibir = recibir + Convert.ToChar(bb[i]);
                aviso.Text = recibir;
                stm.Close();  
                    tcpclnt.Close();
                    tcpclnt = null;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error... " + e.StackTrace);
                }
            
        }
    }
}