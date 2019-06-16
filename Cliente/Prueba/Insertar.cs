using CteP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Insertar : Form
    {

        string user, pass;

        public Insertar()
        {
            InitializeComponent();
        }

        public void Set(string user,string pass)
        {
            this.user = user;
            this.pass = pass;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Insertar_Load(object sender, EventArgs e)
        {

        }

        private void cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void descripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mostrar m = new Mostrar();
            m.Set(user,pass);
            m.Show();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (nombre.Text=="" ||descripcion.Text==""||marca.Text==""||precio.Text==""||cantidad.Text=="")
            {
                label6.Text = "Ninguno de los campos puede quedar vacio";
            }
            else
            {
                try
                {
                    int c = Int32.Parse(cantidad.Text);
                    float p = (float)Convert.ToDouble(precio.Text);
//proba ahora
                    Cliente cli = new Cliente(user, pass, nombre.Text, descripcion.Text, marca.Text, precio.Text, cantidad.Text);
                    // cli.InsertarProd();
                    nombre.Text = "";
                    descripcion.Text = "";
                    marca.Text = "";
                    precio.Text= "";
                    cantidad.Text = "";
                    label6.Text = ""; 
                }
                catch (Exception ex)
                {
                    label6.Text = "Solo se permite Numeros en precio y cantidad";
                   
                }

              
               

            }
                 

           


        }
    }
}
