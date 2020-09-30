using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrsAndCrl
{
    class TTTImplementation
    {
        bool CrossOrCircle = true;

        Grid grid;
        Label label_score;
        Label label_text;
        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

        int crs_score = 0;
        int crl_score = 0;

        int[,] table = new int[3, 3];

        public TTTImplementation(Grid grid_, Label label_score_, Label label_text_)
        {
            grid = grid_;
            label_score = label_score_;
            label_text = label_text_;

            CreateGestureForImage();
            CreateImageGrid();
        }

        public void CreateGestureForImage()
        {
            tapGestureRecognizer.Tapped += (s, e) => {
                Image boxi = (Image)s;
                if (boxi.Source.ToString().Equals("File: empty.png"))
                {
                    if (CrossOrCircle)
                    {
                        boxi.Source = "cross.png";
                        table[Grid.GetRow(boxi), Grid.GetColumn(boxi)] = 1;
                    }
                    else
                    {
                        boxi.Source = "circle.png";
                        table[Grid.GetRow(boxi), Grid.GetColumn(boxi)] = 0;
                    }
                }
                CrossOrCircle = !CrossOrCircle;
                CheckTheWinner();
                CheckTheDraw();
                label_score.Text = "Cross - " + crs_score.ToString() + " : " + crl_score.ToString() + " - Circle";
            };
        }

        public void CreateImageGrid()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Image box = new Image
                    {
                        BackgroundColor = Color.White,
                        Opacity = 0.7,
                        Margin = 2,
                        Source = "empty.png"
                    };
                    table[y, x] = 170173;
                    box.GestureRecognizers.Add(tapGestureRecognizer);
                    grid.Children.Add(box, y, x);
                }
            }
        }

        public void RefreshTheGrid()
        {
            grid.Children.Clear();
            CreateImageGrid();
            label_text.Text = "TicTacToe";
        }

        public string CheckTheTable()
        {
            string winner = "";

            // Vertical left
            if (table[0, 0] == 1 && table[1, 0] == 1 && table[2, 0] == 1)
            {
                winner = "crs";
            }
            else if (table[0, 0] == 0 && table[1, 0] == 0 && table[2, 0] == 0)
            {
                winner = "crl";
            }

            // Vertical center
            if (table[0, 1] == 1 && table[1, 1] == 1 && table[2, 1] == 1)
            {
                winner = "crs";
            }
            else if (table[0, 1] == 0 && table[1, 1] == 0 && table[2, 1] == 0)
            {
                winner = "crl";
            }

            // Vertical right
            if (table[0, 2] == 1 && table[1, 2] == 1 && table[2, 2] == 1)
            {
                winner = "crs";
            }
            else if (table[0, 2] == 0 && table[1, 2] == 0 && table[2, 2] == 0)
            {
                winner = "crl";
            }

            // Horizontal top
            if (table[0, 0] == 1 && table[0, 1] == 1 && table[0, 2] == 1)
            {
                winner = "crs";
            }
            else if (table[0, 0] == 0 && table[0, 1] == 0 && table[0, 2] == 0)
            {
                winner = "crl";
            }

            // Horizontal center
            if (table[1, 0] == 1 && table[1, 1] == 1 && table[1, 2] == 1)
            {
                winner = "crs";
            }
            else if (table[1, 0] == 0 && table[1, 1] == 0 && table[1, 2] == 0)
            {
                winner = "crl";
            }

            // Horizontal bottom
            if (table[2, 0] == 1 && table[2, 1] == 1 && table[2, 2] == 1)
            {
                winner = "crs";
            }
            else if (table[2, 0] == 0 && table[2, 1] == 0 && table[2, 2] == 0)
            {
                winner = "crl";
            }

            // Diagonal top-left bottom-right
            if (table[0, 0] == 1 && table[1, 1] == 1 && table[2, 2] == 1)
            {
                winner = "crs";
            }
            else if (table[0, 0] == 0 && table[1, 1] == 0 && table[2, 2] == 0)
            {
                winner = "crl";
            }

            // Diagonal bottom-left top-right
            if (table[2, 0] == 1 && table[1, 1] == 1 && table[0, 2] == 1)
            {
                winner = "crs";
            }
            else if (table[2, 0] == 0 && table[1, 1] == 0 && table[0, 2] == 0)
            {
                winner = "crl";
            }

            return winner;
        }

        public void CheckTheWinner()
        {
            if(CheckTheTable() == "crs")
            {
                crs_score += 1;
                RefreshTheGrid();
            }
            else if(CheckTheTable() == "crl")
            {
                crl_score += 1;
                RefreshTheGrid();
            }
        }

        public void CheckTheDraw()
        {
            int count_turns = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if(table[y, x] == 1 || table[y, x] == 0)
                    {
                        count_turns++;
                    }
                }
            }
            if(count_turns == 9)
            {
                RefreshTheGrid();
            }
        }
    }
}
