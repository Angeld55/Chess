using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.GUI
{
    public partial class window : Form
    {
        private ChessGame currentGame;
        private List<PictureBox> boxes;
        private bool isWhitePlayersTurn;
        private PictureBox markedBox;
        private Color color;
        public window(string firstName, string SecondName)
        {
           
            boxes = new List<PictureBox>(64);
            InitializeComponent();
            AddBoxes();
            currentGame = new ChessGame();
            //this.playerWhiteName.Text = firstName;
            //this.playerBlackName.Text = SecondName;
            
            RefreshItColors();
            RefreshFigures();
            isWhitePlayersTurn = true;

            
        }
        public void StartGame()
        {
            while(true)
            {
                GetWhitePlayersTurn();
                GetBlackPlayersTurn();
            }
        }
        private void GetWhitePlayersTurn()
        {
            isWhitePlayersTurn = true;
        }
        private void GetBlackPlayersTurn()
        {
            isWhitePlayersTurn = false;
        }
        private void MarkOrUnMarkOrMove()
        {
            
        }
        private ChessBox getChessBoxByPicBox(PictureBox box)
        {
            int boxNum = Convert.ToInt32(box.Name.Substring(10));
            if (boxNum < 9)
            {
                int yCoord = 1;
                char X = Convert.ToChar(64 + boxNum);
                return currentGame.Board.getChessBoxByCoordinates(X, yCoord);
            }
            else
            {


                int y = (boxNum % 8) ;
                char Xcord;
                switch (y)
                {
                    case 0: Xcord = 'A'; break;
                    case 7: Xcord = 'B'; break;
                    case 6: Xcord = 'C'; break;
                    case 5: Xcord = 'D'; break;
                    case 4: Xcord = 'E'; break;
                    case 3: Xcord = 'F'; break;
                    case 2: Xcord = 'G'; break;
                    case 1: Xcord = 'H'; break;
                    default: Xcord = 'Z'; break;
                        
                }
                int yC = boxNum / 8;
                if (boxNum%8!=0)
                {
                    yC++;
                }
             ;
             return currentGame.Board.getChessBoxByCoordinates(Xcord, yC);
            }

          
            
          
            
        }
        public void RefreshItColors()
        {
            foreach (var box in boxes)
            {
                if (getChessBoxByPicBox(box).IsWhite)
                {
                    box.BackColor = Color.White;
                }
                else
	            {
                    box.BackColor=Color.Gray;
	            }
            }
        }
        public void RefreshFigures()
        {
            foreach (var box in boxes)
            {
                if (getChessBoxByPicBox(box).isFigureOn())
                {
                    ChessBox currentBox = getChessBoxByPicBox(box);
                    switch (currentBox.Figure.getFigureType())
                    {
                        case "Pawn": if (currentBox.Figure.isWhite)
                                        {
                                            box.Image = Image.FromFile("pawnWhite.agd");
                                        }
                            else
                            {
                                box.Image = Image.FromFile("pawnBlack.agd");
                            }
                            break;
                        case "Rook": if (currentBox.Figure.isWhite)
                            {
                                box.Image = Image.FromFile("rookWhite.agd");
                            }
                            else
                            {
                                box.Image = Image.FromFile("rookBlack.agd");
                            }
                            break;
                        case "Queen": if (currentBox.Figure.isWhite)
                            {
                                box.Image = Image.FromFile("queenWhite.agd");
                            }
                            else
                            {
                                box.Image = Image.FromFile("queenBlack.agd");
                            }
                            break;
                        case "King": if (currentBox.Figure.isWhite)
                            {
                                box.Image = Image.FromFile("kingWhite.agd");
                            }
                            else
                            {
                                box.Image = Image.FromFile("kingBlack.agd");
                            }
                            break;
                        case "Bishop": if (currentBox.Figure.isWhite)
                            {
                                box.Image = Image.FromFile("bishopWhite.agd");
                            }
                            else
                            {
                                box.Image = Image.FromFile("bishopBlack.agd");
                            }
                            break;
                        case "Knight": if (currentBox.Figure.isWhite)
                            {
                                box.Image = Image.FromFile("knightWhite.agd");
                            }
                            else
                            {
                                box.Image = Image.FromFile("knightBlack.agd");
                               
                            }
                            break;
                        default: box.Image = null;
                            break;
                    }
                }
                else
                {
                    box.Image = null;
                }
            }
        }

        public void AddEvents()
        {
            pictureBox1.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox2.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox3.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox4.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox5.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox6.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox7.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox8.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox9.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox10.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox11.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox12.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox13.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox14.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox15.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox16.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox17.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox18.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox19.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox20.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox21.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox22.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox23.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox24.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox25.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox26.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox27.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox28.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox29.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox30.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox31.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox32.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox33.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox34.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox35.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox36.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox37.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox38.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox39.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox40.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox41.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox42.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox43.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox44.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox45.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox46.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox47.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox48.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox49.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox50.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox51.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox52.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox53.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox54.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox55.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox56.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox57.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox58.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox59.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox60.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox61.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox62.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox63.MouseClick += new MouseEventHandler(pictureBox_Click);
            pictureBox64.MouseClick += new MouseEventHandler(pictureBox_Click);




        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            PictureBox clickedBox = (PictureBox)sender;
           /// clickedBox.BackColor = Color.Green;
            bool wasLastRocade = false;
            if (isWhitePlayersTurn)
            {
                if (getChessBoxByPicBox(clickedBox).isFigureOn())
                {


                    if (getChessBoxByPicBox(clickedBox).Figure.isWhite)
                    {
                        if (MarkedBox!=null)
                        {
                            if ((getChessBoxByPicBox(MarkedBox).Figure!=null)&&(getChessBoxByPicBox(MarkedBox).Figure.getFigureType().Equals("King"))&&(getChessBoxByPicBox(clickedBox).Figure.getFigureType().Equals("Rook")))
                            {
                                try
                                {
                            Chess.Figures.Figure f = getChessBoxByPicBox(MarkedBox).Figure;
                            currentGame.Move(getChessBoxByPicBox(markedBox), getChessBoxByPicBox(clickedBox), isWhitePlayersTurn);
                            RefreshFigures();
                            MarkedBox.BackColor = color;
                            Console.WriteLine(currentGame.Board);
                            MarkedBox = null;
                            changePlayersTurn();
                            wasLastRocade = true;

                                }
                                catch (Exception ex)
                                {
                                    MarkedBox.BackColor = color;
                                   
                                    MarkedBox = null;
                                    errorProvider.SetError(clickedBox,"Invalid rocade!");
                                }
                            }
                            else
                            {
                                
                                    MarkedBox.BackColor = color;
                                    MarkedBox = null;
                                
                              

                            }

                        }
                        //if (MarkedBox!=null)
                        //{
                        //    MarkedBox.BackColor = color;
                        //    MarkedBox = null;
                        //}
                        if (!wasLastRocade)
                        {
                            color = clickedBox.BackColor;
                            clickedBox.BackColor = Color.Green;
                            MarkedBox = clickedBox;
                        }
                    }
                    else
                    {
                        try
                        {
                            if (markedBox==null)
                            {
                                throw new ArgumentException("It's the other player's turn!");
                            }
                            Chess.Figures.Figure f = getChessBoxByPicBox(MarkedBox).Figure;
                            currentGame.Move(getChessBoxByPicBox(markedBox), getChessBoxByPicBox(clickedBox), isWhitePlayersTurn);
                            RefreshFigures();
                            MarkedBox.BackColor = color;
                            Console.WriteLine(currentGame.Board);
                            MarkedBox = null;
                            changePlayersTurn();
                        }
                        catch (Exception err)
                        {

                            errorProvider.SetError(clickedBox, err.Message);
                        }
                      
                    }
               

                }
                else
                {
                    if (MarkedBox!=null)
                    {
                        try
                        {

                            if (markedBox == null)
                            {
                                throw new ArgumentException("It's the other player's turn!");
                            }
                            Chess.Figures.Figure f = getChessBoxByPicBox(MarkedBox).Figure;
                            currentGame.Move(getChessBoxByPicBox(markedBox), getChessBoxByPicBox(clickedBox), isWhitePlayersTurn);
                            RefreshFigures();
                            MarkedBox.BackColor = color;
                            Console.WriteLine(currentGame.Board);
                            MarkedBox = null;
                            changePlayersTurn();
                        }
                        catch (Exception err)
                        {

                            errorProvider.SetError(clickedBox, err.Message);
                        }
                    }
                }
            }
            else
            {
                if (getChessBoxByPicBox(clickedBox).isFigureOn())
                {


                    if (!getChessBoxByPicBox(clickedBox).Figure.isWhite)
                    {
                        if (MarkedBox != null)
                        {
                            if ((getChessBoxByPicBox(MarkedBox).Figure != null) && (getChessBoxByPicBox(MarkedBox).Figure.getFigureType().Equals("King")) && (getChessBoxByPicBox(clickedBox).Figure.getFigureType().Equals("Rook")))
                            {
                                try
                                {
                                    Chess.Figures.Figure f = getChessBoxByPicBox(MarkedBox).Figure;
                                    currentGame.Move(getChessBoxByPicBox(markedBox), getChessBoxByPicBox(clickedBox), isWhitePlayersTurn);
                                    RefreshFigures();
                                    MarkedBox.BackColor = color;
                                    Console.WriteLine(currentGame.Board);
                                    MarkedBox = null;
                                    changePlayersTurn(); 
                                    wasLastRocade = true;
                                }
                                catch (Exception ex)
                                {

                                    errorProvider.SetError(clickedBox, "Invalid rocade!");
                                }
                            }

                        }
                        if (MarkedBox != null)
                        {
                            MarkedBox.BackColor = color;
                            MarkedBox = null;
                        }
                        if (!wasLastRocade)
                        {
                            color = clickedBox.BackColor;
                            clickedBox.BackColor = Color.Green;
                            MarkedBox = clickedBox;
                        }
                     
                    }
                    else
                    {
                        try
                        {

                            if (markedBox == null)
                            {
                                throw new ArgumentException("It's the other player's turn!");
                            }
                            Chess.Figures.Figure f = getChessBoxByPicBox(MarkedBox).Figure;
                            currentGame.Move(getChessBoxByPicBox(markedBox), getChessBoxByPicBox(clickedBox), isWhitePlayersTurn);
                            RefreshFigures();
                            MarkedBox.BackColor = color;
                            Console.WriteLine(currentGame.Board);
                            MarkedBox = null;
                            changePlayersTurn();
                        }
                        catch(Exception err)
                        {
                            errorProvider.SetError(clickedBox, err.Message);
                        }
                    }


                }
                else
                {
                   
                        if (MarkedBox != null)
                        {
                            try
                            {



                                Chess.Figures.Figure f = getChessBoxByPicBox(MarkedBox).Figure;
                                currentGame.Move(getChessBoxByPicBox(markedBox), getChessBoxByPicBox(clickedBox), isWhitePlayersTurn);
                                RefreshFigures();
                                MarkedBox.BackColor = color;
                                Console.WriteLine(currentGame.Board);
                                MarkedBox = null;
                                changePlayersTurn();
                            }
                            catch (Exception err)
                            {

                                errorProvider.SetError(clickedBox, err.Message);
                            }
                        }
                    
                }
            }
           
        }
        public PictureBox MarkedBox 
        { get{return this.markedBox;}
            set
            {
                
                    this.markedBox = value;
                
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void AddBoxes()
        {

            boxes.Add(pictureBox1);
            boxes.Add(pictureBox2);
            boxes.Add(pictureBox3);
            boxes.Add(pictureBox4);
            boxes.Add(pictureBox5);
            boxes.Add(pictureBox6);
            boxes.Add(pictureBox7);
            boxes.Add(pictureBox8);
            boxes.Add(pictureBox9);
            boxes.Add(pictureBox10);
            boxes.Add(pictureBox11);
            boxes.Add(pictureBox12);
            boxes.Add(pictureBox13);
            boxes.Add(pictureBox14);
            boxes.Add(pictureBox15);
            boxes.Add(pictureBox16);
            boxes.Add(pictureBox17);
            boxes.Add(pictureBox18);
            boxes.Add(pictureBox19);
            boxes.Add(pictureBox20);
            boxes.Add(pictureBox21);
            boxes.Add(pictureBox22);
            boxes.Add(pictureBox23);
            boxes.Add(pictureBox24);
            boxes.Add(pictureBox25);
            boxes.Add(pictureBox26);
            boxes.Add(pictureBox27);
            boxes.Add(pictureBox28);
            boxes.Add(pictureBox29);
            boxes.Add(pictureBox30);
            boxes.Add(pictureBox31);
            boxes.Add(pictureBox32);
            boxes.Add(pictureBox33);
            boxes.Add(pictureBox34);
            boxes.Add(pictureBox35);
            boxes.Add(pictureBox36);
            boxes.Add(pictureBox37);
            boxes.Add(pictureBox38);
            boxes.Add(pictureBox39);
            boxes.Add(pictureBox40);
            boxes.Add(pictureBox41);
            boxes.Add(pictureBox42);
            boxes.Add(pictureBox43);
            boxes.Add(pictureBox44);
            boxes.Add(pictureBox45);
            boxes.Add(pictureBox46);
            boxes.Add(pictureBox47);
            boxes.Add(pictureBox48);
            boxes.Add(pictureBox49);
            boxes.Add(pictureBox50);
            boxes.Add(pictureBox51);
            boxes.Add(pictureBox52);
            boxes.Add(pictureBox53);
            boxes.Add(pictureBox54);
            boxes.Add(pictureBox55);
            boxes.Add(pictureBox56);
            boxes.Add(pictureBox57);
            boxes.Add(pictureBox58);
            boxes.Add(pictureBox59);
            boxes.Add(pictureBox60);
            boxes.Add(pictureBox61);
            boxes.Add(pictureBox62);
            boxes.Add(pictureBox63);
            boxes.Add(pictureBox64);

        }

        private void changePlayersTurn()
        {
            isWhitePlayersTurn = !isWhitePlayersTurn;
            if (isWhitePlayersTurn)
            {
                label1.Text = "It's white's turn!";
            }
            else
            {
                label1.Text = "It's black's turn!";
            }
        }
        private void window_Load(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
