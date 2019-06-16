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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void conectar_Click(object sender, EventArgs e)
        {
            string usuario, contra;
            Cliente cli;
            usuario = user.Text;
            contra = pass.Text;
            
            if (user.Text == "" || pass.Text == "")
                valida.Visible=true;
            else
            {
                   cli = new Cliente(usuario, contra,aviso);
                  if (aviso.Text == "Usuario Correcto")
                  {
                     
                    this.Hide();
                    Mostrar m = new Mostrar();
                    m.Set(usuario, contra);
                    m.Show();

                }
                valida.Visible = false;

               

            }

         
            user.Text = "";
            pass.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void valida_Click(object sender, EventArgs e)
        {

        }
    }
}
