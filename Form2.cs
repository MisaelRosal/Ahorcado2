using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show(); this.Close();
        }

        private void btnComida_Click(object sender, EventArgs e)
        {
            frmComida frmComida = new frmComida();
            frmComida.Show(); this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            frmAnimales frmAnimales = new frmAnimales();
            frmAnimales.Show(); this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            frmObjetos frmObjetos = new frmObjetos();
            frmObjetos.Show(); this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            frmPaises frmPaises = new frmPaises();
            frmPaises.Show(); this.Close();
        }
    }
}
