namespace Princeware_Encryption
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void PRINCEWARE_GIF_Click(object sender, EventArgs e)
        {
            //summon tool form when main is clicked
            //yes this panel is unnecessary
            //yes I like it though
            ToolUI smnTUI = new ToolUI();
            smnTUI.Show();
            this.Hide();
        }
    }
}