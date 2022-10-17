namespace Princeware_Encryption
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
            #region directory creation
            //create the directory needed for function unless it already exists
            //encryption wheels
            string _directory = @"C:\Users\Public\PRINCEWARE\WHLS";
            System.IO.Directory.CreateDirectory(_directory);
            //switchboards
            _directory = @"C:\Users\Public\PRINCEWARE\SWTCHBRDS";
            System.IO.Directory.CreateDirectory(_directory);
            //files (input and output defaults)
            _directory = @"C:\Users\Public\PRINCEWARE\INP-OUT";
            System.IO.Directory.CreateDirectory(_directory);
            #endregion
            #region file creation
            //create required files (txt)
            //default wheels
            string filePath = "";
            //WHL 1
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 01.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 2
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 02.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 3
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 03.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 4
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 04.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 5
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 05.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 6
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 06.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 7
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 07.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 8
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 08.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 9
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 09.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //WHL 10
            filePath = @"C:\Users\Public\PRINCEWARE\WHLS\WHL 10.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;

            //switchboards
            //SWTCHBRD 1
            filePath = @"C:\Users\Public\PRINCEWARE\SWTCHBRDS\SWTCHBRD 01.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //SWTCHBRD 2
            filePath = @"C:\Users\Public\PRINCEWARE\SWTCHBRDS\SWTCHBRD 02.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //SWTCHBRD 3
            filePath = @"C:\Users\Public\PRINCEWARE\SWTCHBRDS\SWTCHBRD 03.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;

            //inp & out
            //INP
            filePath = @"C:\Users\Public\PRINCEWARE\INP-OUT\INP.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            //OUT
            filePath = @"C:\Users\Public\PRINCEWARE\INP-OUT\OUT.txt";
            using (StreamWriter w = File.AppendText(filePath)) ;
            #endregion
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