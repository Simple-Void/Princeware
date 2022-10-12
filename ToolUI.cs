using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Princeware_Encryption
{
    public partial class ToolUI : Form
    {
        #region system explanation
        //this is effectively a 5 wheel enigma
        //in bigger terms it's a progressive quintuple asynchronous wheel cipher with switchboard ciphering
        //the wheels and swtichboard must be set the same between encoding and decoding users, else the system will not work
        //this program works using extended ASCII which should be standard on any modern computer
        //your text is swapped from a string character to the raw ASCII code
        //this code is then passed through each of the wheels in turn, 1-5, then finally the switchboard
        //the ASCII code will be reduced until a valid integer is met and then transformed back to a character to display
        //after one cycle the final wheel will rotate
        //when this final wheel has done a full rotation the second will also rotate
        //this continues for each subsequent wheel
        //it would take a very large amount of text to encounter a character encrypted the same way twice
        //it is up to you how you include or whether you include the relevant information for decoding
        //however, without this information chances are it can't be deciphered and read
        #endregion



        //each wheel needs:
        //a dictionary with all the movements
        //a position on the wheel
        //and a total wheel length

        //wheel 1 variables
        Dictionary<int, int> Wheel1Dictionary = new Dictionary<int, int>();
        public int Wheel1CurrentPosition;
        public int Wheel1TotalLength;
        //wheel 2 variables
        Dictionary<int, int> Wheel2Dictionary = new Dictionary<int, int>();
        public int Wheel2CurrentPosition;
        public int Wheel2TotalLength;
        //wheel 3 variables
        Dictionary<int, int> Wheel3Dictionary = new Dictionary<int, int>();
        public int Wheel3CurrentPosition;
        public int Wheel3TotalLength;
        //wheel 4 variables
        Dictionary<int, int> Wheel4Dictionary = new Dictionary<int, int>();
        public int Wheel4CurrentPosition;
        public int Wheel4TotalLength;
        //wheel 5 variables
        Dictionary<int, int> Wheel5Dictionary = new Dictionary<int, int>();
        public int Wheel5CurrentPosition;
        public int Wheel5TotalLength;
        

        //switchboard variables
        Dictionary<int, string[]> SwitchBoardDictionary = new Dictionary<int, string[]>();

        public ToolUI()
        {
            InitializeComponent();
            //select something by default to avoid errors
            rdENCODE.Select();
            rdTEXT.Select();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            //what does this even do
        }
    }
}
