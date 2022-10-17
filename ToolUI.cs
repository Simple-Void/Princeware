namespace Princeware_Encryption
{
    public partial class ToolUI : Form
    {
        #region system explanation
        //this is effectively a 5 wheel enigma
        //in bigger terms it's a progressive quintuple asynchronous wheel cipher with switchboard ciphering
        //the wheels and swtichboard must be set the same between encoding and decoding users, else the system will not work
        //this program works using extended unicode which should be standard on any modern computer
        //your text is swapped from a string character to the raw unicode code
        //this code is then passed through each of the wheels in turn, 1-5, then finally the switchboard
        //the unicode code will be reduced until a valid integer is met and then transformed back to a character to display
        //after one cycle the final wheel will rotate
        //when this final wheel has done a full rotation the second will also rotate
        //this continues for each subsequent wheel
        //it would take a very large amount of text to encounter a character encrypted the same way twice
        //it is up to you how you include or whether you include the relevant information for decoding
        //however, without this information chances are it can't be deciphered and read
        #endregion

        #region dictionaries setup
        //the wheels dictionary is a dictionary of all the wheels I could read from the file structure
        //each item in the wheels dictionary is an array of all the manipulation within the wheel
        //when selected from the combobox the requested wheels are written to the individual wheel dictionaries
        //this means the search always takes a set amount of time for the transformation

        //dictionary of all wheels read
        //first int is the index, second int list is all the switches
        Dictionary<int, int[]> AllWheelsDictionary = new Dictionary<int, int[]>();
        //list of the file names to display them properly in the comboboxes
        List<string> AllWheelsNames = new List<string>();
        //stores which wheels are in use in which slots
        int[] WheelsInUse = new int[5];

        //wheel 1 variables
        public int Wheel1CurrentPosition;
        public int Wheel1TotalLength;
        //wheel 2 variables
        public int Wheel2CurrentPosition;
        public int Wheel2TotalLength;
        //wheel 3 variables
        public int Wheel3CurrentPosition;
        public int Wheel3TotalLength;
        //wheel 4 variables
        public int Wheel4CurrentPosition;
        public int Wheel4TotalLength;
        //wheel 5 variables
        public int Wheel5CurrentPosition;
        public int Wheel5TotalLength;
        

        //switchboard variables
        Dictionary<int, string[]> SwitchBoardDictionary = new Dictionary<int, string[]>();
        Dictionary<int, string> CurrentSwitchBoardDictionary = new Dictionary<int, string>();
        //list of the file names to display them properly in the comboboxes
        List<string> AllBoardNames = new List<string>();
        #endregion

        public ToolUI()
        {
            InitializeComponent();
            startup();
            //get the unicode vals
            //string absfvh = "ASCII wdym";
            //byte[] AsciiCodes = Encoding.Unicode.GetBytes(absfvh);
        }

        public void startup()
        {
            //setup all the beginning jazz
            //select something by default to avoid errors
            rdENCODE.Select();
            rdTEXT.Select();
            //scan for all the files and upload them to the UI
            readAllFiles();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            //what does this even do
        }

        public void readAllFiles()
        {
            //wheels
            //get all the files in the directories
            //encoding wheels
            string[] AllWheelFiles = Directory.GetFiles(@"C:\Users\Public\PRINCEWARE\WHLS");
            List<string> UsableWheelFiles = new List<string>();

            //quick check to remove all non-text files to allow proper displaying
            for (int c = 0; c < AllWheelFiles.Length; c++)
            {
                //if it is a text file it adds it
                if (AllWheelFiles[c].Substring((AllWheelFiles[c].Length - 4), 4) == ".txt")
                {
                    //adds to the real usable files
                    UsableWheelFiles.Add(AllWheelFiles[c]);
                }
            }

            //read them into the hashtable
            //variable to give a proper ID for dictionary
            int ID = 0;
            for (int c = 0; c < ((UsableWheelFiles).ToArray()).Length; c++)
            {
                //manipulate file name into JUST the name without .txt
                string fileName = (Path.GetFileName(UsableWheelFiles[c]));
                fileName = fileName.Substring(0, fileName.Length - 4);
                AllWheelsNames.Add(fileName);
                //add the string into all the comboboxes
                cmbW1Select.Items.Add(fileName);
                cmbW2Select.Items.Add(fileName);
                cmbW3Select.Items.Add(fileName);
                cmbW4Select.Items.Add(fileName);
                cmbW5Select.Items.Add(fileName);
                //all non txt files have been removed
                //gets the function to read into the dictionary
                //next available ID is given and the program moves on
                readWheelFile(ID, UsableWheelFiles[c]);
                ID++;
            }
            
            //###

            //switchboards
            string[] AllBoardFiles = Directory.GetFiles(@"C:\Users\Public\PRINCEWARE\SWTCHBRDS");
            Dictionary<int, int> currentBoardContents = new Dictionary<int, int>();
            List<string> UsableBoardFiles = new List<string>();

            //these checks are laid out to remove as many files as possible with each step to
            //limit CPU time as much as possible
            //quick check to remove all non-text files to allow proper displaying
            //this is big code but is REALLY robust
            for (int c = 0; c < AllBoardFiles.Length; c++)
            {
                //clear previous cycle
                currentBoardContents.Clear();
                //if it is a text file it checks length before adding
                if (AllBoardFiles[c].Substring((AllBoardFiles[c].Length - 4), 4) == ".txt")
                {
                    string[] boardAsLines = System.IO.File.ReadAllLines(AllBoardFiles[c]);
                    //check it is a complete switchboard
                    if (boardAsLines.Length == 65536)
                    {
                        //check all the lines are parsable
                        bool valid = true;
                        for (int i = 0; i <= 65535; i++)
                        {
                            //is it parsable, if yes add to the dictionary, else it's invalid
                            if (int.TryParse(boardAsLines[i], out int placeHolder) == true)
                            {
                                //THIS DICTIONARY CHECK IS REALLY REALLY SLOW
                                //PLEASE FIND A BETTER WAY
                                //check if it is already present within the dictionary
                                if (currentBoardContents.ContainsValue(int.Parse(boardAsLines[i])))
                                {
                                    //contains it already, invalid board
                                    valid = false;
                                } else
                                {
                                    //not present, add to dict for checks
                                    currentBoardContents.Add(i, int.Parse(boardAsLines[i]));
                                }
                            } else
                            {
                                //not full of ints
                                valid = false;
                            }
                        }
                        //if it has passed the divine trials it has earnt its right among the gods
                        //add to the list
                        if (valid == true)
                        {
                            //adds to the real usable files
                            UsableBoardFiles.Add(AllBoardFiles[c]);
                        }
                    }
                }
            }

            //read them into the hashtable
            //variable to give a proper ID for dictionary
            ID = 0;
            for (int c = 0; c < ((UsableBoardFiles).ToArray()).Length; c++)
            {
                //manipulate file name into JUST the name without .txt
                string fileName = (Path.GetFileName(UsableBoardFiles[c]));
                fileName = fileName.Substring(0, fileName.Length - 4);
                AllWheelsNames.Add(fileName);
                //add the string into all the comboboxes
                cmbSwtch.Items.Add(fileName);
                //only text files get this far
                //gets the function to read into the dictionary
                //next available ID is given and the program moves on
                //readBoardFile(ID, UsableWheelFiles[c]);
                ID++;
            }
        }

        public void readWheelFile(int _index, string _filePath)
        {
            //get all the lines
            List<int> parsedNumsList = new List<int>();
            parsedNumsList.Clear();
            string[] wheelAsLines = System.IO.File.ReadAllLines(_filePath);
            //swap the stored values to integers, if not an int do not read
            for (int c = 0; c < wheelAsLines.Length - 1; c++)
            {
                //check if it is an int to avoid crashing
                string currentLine = wheelAsLines[c];
                if (int.TryParse(currentLine, out int num) == true)
                {
                    //it can be parsed, parse it and add it
                    parsedNumsList.Add(int.Parse(wheelAsLines[c]));
                }
            }
            //AllWheelsDictionary.Add(_index, wheelAsLines);
            int[] parsedNumsArray = parsedNumsList.ToArray();
            AllWheelsDictionary.Add(_index, parsedNumsArray);
        }

        public void readBoardFile(int _index, string _filePath)
        {
            //formatting sorted :sunglasses:
            //get all the lines
            List<int> parsedNumsList = new List<int>();
            parsedNumsList.Clear();
            string[] boardAsLines = System.IO.File.ReadAllLines(_filePath);
            //all the values are parsable, it was checked earlier in a compulsory check
            //swap the stored values to integers
            for (int c = 0; c < boardAsLines.Length - 1; c++)
            {
                //check if it is an int to avoid crashing
                string currentLine = boardAsLines[c];
                if (int.TryParse(currentLine, out int num) == true)
                {
                    //it can be parsed, parse it and add it
                    parsedNumsList.Add(int.Parse(boardAsLines[c]));
                }
            }
            //AllWheelsDictionary.Add(_index, wheelAsLines);
            int[] parsedNumsArray = parsedNumsList.ToArray();
            AllWheelsDictionary.Add(_index, parsedNumsArray);
        }

        private void cmbW1Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this DOES only trigger once when a new index is selected so updates
            //can safely happen regarding the index
            //update the wheel in use
            WheelsInUse[0] = cmbW1Select.SelectedIndex;
            //then populate the possible start positions
            cmbW1Position.Items.Clear();
            for (int c = 0; c <= AllWheelsDictionary[WheelsInUse[0]].Length; c++)
            {
                cmbW1Position.Items.Add(c);
            }
            //select 0 position
            cmbW1Position.SelectedIndex=0;
        }
    }
}
