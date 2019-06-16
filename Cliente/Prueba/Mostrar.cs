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
    public partial class Mostrar : Form
    {

        string user, pass;
        public Mostrar()
        {
            InitializeComponent();
           
        }
        public void Set(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
            mostrar();
        }

       

        public void mostrar()
        {
            //aqui vamos a recibir los datos
            Cliente c = new Cliente(user, pass,dataGridView1);

      
       //     dataGridView1.Rows.Add("Tu madre");
       // estas cagado


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Eliminar del = new Eliminar();
            del.Set(user, pass);
            del.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insertar inser = new Insertar();
            inser.Set(user, pass);
            inser.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
