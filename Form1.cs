namespace Game
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategorias frmCategorias = new FrmCategorias();
            frmCategorias.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}