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
    public partial class Eliminar : Form
    {
        string user, pass;
       public Eliminar(string user,string pass)
        {
            this.user = user;
            this.pass = pass;
        }

        public void Set(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
        }

        public Eliminar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                label5.Text = "El Id esta vacio";
            }else if (textBox1.Text.Length>0 )
            {
                //Se valida que solo se ingrese numweros
                try
                {
                    int m = Int32.Parse(textBox1.Text);
                    Cliente c = new Cliente(user, pass, textBox1.Text);
                }
                catch (FormatException ex)
                {
                    label5.Text = "Solo se permiten numeros";
                }

                textBox1.Text = "";
            }
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mostrar m = new Mostrar();
            m.Set(user, pass);
            m.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
