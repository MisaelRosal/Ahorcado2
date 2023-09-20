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
    public partial class frmPaises : Form
    {
        char[] PalabrasAdivinadas;
        int Oportunidades;
        char[] PalabraSeleccionada;
        char[] Alfabeto;
        String[] Palabras;
        public frmPaises()
        {
            InitializeComponent();
        }
        public void IniciarJuego()
        {
            flFichas.Controls.Clear();
            flFichas.Enabled = true;
            picPaises.Image = null;
            lblTulomataste.Visible = false;
            Oportunidades = 0;
            Palabras = new string[] { "africa", "nicaragua", "colombia", "panama", "costarica", "holanda", "argentina", "chile", "guatemala", "honduras", "brasil", "italia", "francia", "uruguay" };

            Alfabeto = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ".ToCharArray();

            Random random = new Random();
            int IndicePalabraSeleccionada = random.Next(0, Palabras.Length);
            PalabraSeleccionada = Palabras[IndicePalabraSeleccionada].ToUpper().ToCharArray();
            PalabrasAdivinadas = PalabraSeleccionada;

            foreach (char LetraAlfabeto in Alfabeto)
            {
                Button btnLetra = new Button();
                btnLetra.Tag = "";
                btnLetra.Text = LetraAlfabeto.ToString();
                btnLetra.Width = 70;
                btnLetra.Height = 45;
                btnLetra.Click += Compara;
                btnLetra.ForeColor = Color.Black;
                btnLetra.Font = new Font(btnLetra.Font.Name, 15, FontStyle.Bold);
                btnLetra.BackgroundImageLayout = ImageLayout.Center;
                btnLetra.BackColor = Color.Beige;
                btnLetra.Name = LetraAlfabeto.ToString();
                flFichas.Controls.Add(btnLetra);

            }
            flPalabras.Controls.Clear();

            for (int IndiceValorLetra = 0; IndiceValorLetra < PalabraSeleccionada.Length; IndiceValorLetra++)
            {
                Button Letra = new Button();
                Letra.Tag = PalabraSeleccionada[IndiceValorLetra].ToString();
                Letra.Width = 60;
                Letra.Height = 80;
                Letra.ForeColor = Color.Orange;
                Letra.Text = "";
                Letra.Font = new Font(Letra.Font.Name, 25, FontStyle.Bold);
                Letra.BackgroundImageLayout = ImageLayout.Center;
                Letra.BackColor = Color.White;
                Letra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Letra.Name = "Adivinado" + IndiceValorLetra.ToString();
                flPalabras.Controls.Add(Letra);
            }

        }

        void Compara(object sender, EventArgs e)
        {
            bool encontrado = false;

            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Enabled = false;

            for (int IndiceRevisar = 0; IndiceRevisar < PalabrasAdivinadas.Length; IndiceRevisar++)
            {
                if (PalabrasAdivinadas[IndiceRevisar] == Char.Parse(btn.Text))
                {
                    Button tbx = this.Controls.Find("Adivinado" + IndiceRevisar, true).FirstOrDefault() as Button;
                    tbx.Text = PalabrasAdivinadas[IndiceRevisar].ToString();
                    PalabrasAdivinadas[IndiceRevisar] = '-';
                    encontrado = true;
                }
            }

            bool Ganaste = true;

            for (int indiceAnalizadorGanador = 0; indiceAnalizadorGanador < PalabrasAdivinadas.Length; indiceAnalizadorGanador++)
            {

                if (PalabrasAdivinadas[indiceAnalizadorGanador] != '-')
                {
                    Ganaste = false;
                }
            }


            if (Ganaste)
            {
                MessageBox.Show("Felicidades!!, has Ganado");
            }

            if (!encontrado)
            {
                Oportunidades = Oportunidades + 1;
                picPaises.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Paises" + Oportunidades);


                if (Oportunidades == 5)
                {
                    lblTulomataste.Visible = true;

                    for (int IndiceValorLetra = 0; IndiceValorLetra < PalabraSeleccionada.Length; IndiceValorLetra++)
                    {
                        Button btnLetra = this.Controls.Find("Adivinado" + IndiceValorLetra, true).FirstOrDefault() as Button;
                        btnLetra.Text = btnLetra.Tag.ToString();

                    }

                    flFichas.Enabled = false;
                }
            }
        }
        private void frmPaises_Load(object sender, EventArgs e)
        {
            IniciarJuego();
        }

        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {

            IniciarJuego();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmCategorias frmCategorias = new FrmCategorias();
            frmCategorias.Show(); this.Close();
        }
    }
}
