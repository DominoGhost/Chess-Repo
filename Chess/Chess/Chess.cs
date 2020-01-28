using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Chess.Pieces;

namespace Chess
{
    public partial class Chess : Form
    {
        public static readonly int MAX_TILES = 8;
        readonly Image greenBack = Properties.Resources.Green, brownBack = Properties.Resources.Brown, woodBack = Properties.Resources.Wood;

        internal static Tile[,] tiles = new Tile[MAX_TILES, MAX_TILES];
        bool isWhitesTurn = true;
        King[] kingPieces = new King[2];
        Piece[] whitePieces = new Piece[16];
        Piece[] blackPieces = new Piece[16];

        public Chess()
        {
            InitializeComponent();

            // Colorswitch is to tell which color to make the tile
            bool colorSwitch = false;
            for (int i = 0; i < MAX_TILES; ++i)
            {
                if (colorSwitch)
                {
                    colorSwitch = false;
                }
                else
                {
                    colorSwitch = true;
                }

                for (int j = 0; j < MAX_TILES; ++j)
                {
                    const int SIZE_OF_TILES = 64;
                    const int OFFSET_FROM_TOP_LEFT = 30; // Offset from the top left of the window

                    Tile tile = new Tile();
                    tile.Size = new Size(SIZE_OF_TILES, SIZE_OF_TILES);
                    tile.Location = new Point(j * SIZE_OF_TILES + OFFSET_FROM_TOP_LEFT, i * SIZE_OF_TILES + OFFSET_FROM_TOP_LEFT);
                    tile.SizeMode = PictureBoxSizeMode.Zoom;
                    tile.Click += Tile_Clicked;
                    if (colorSwitch)
                    {
                        tile.BackgroundImage = woodBack;
                        tile.Background = woodBack;
                        colorSwitch = false;
                    }
                    else
                    {
                        tile.BackgroundImage = brownBack;
                        tile.Background = brownBack;
                        colorSwitch = true;
                    }

                    tiles[i, j] = tile;
                    Controls.Add(tile);
                }
            }

            // Adds the pawns to how they should be
            for (int i = 0; i < MAX_TILES; i++)
            {
                tiles[1, i].Image = Properties.Resources.BlackPawn;
                tiles[1, i].PieceOnTile = new Pawn(Properties.Resources.BlackPawn, false)
                {
                    Row = 1,
                    Column = i
                };
                whitePieces[i] = tiles[1, i].PieceOnTile;

                tiles[6, i].Image = Properties.Resources.Pawn;
                tiles[6, i].PieceOnTile = new Pawn(Properties.Resources.Pawn, true)
                {
                    Row = 6,
                    Column = i
                };
                blackPieces[i] = tiles[6, i].PieceOnTile;
            }

            // Sets the board up for white pieces
            tiles[7, 0].Image = Properties.Resources.Rook;
            tiles[7, 0].PieceOnTile = new Rook(Properties.Resources.Rook, true)
            {
                Row = 7,
                Column = 0
            };
            whitePieces[8] = tiles[7, 0].PieceOnTile;

            tiles[7, 1].Image = Properties.Resources.Knight;
            tiles[7, 1].PieceOnTile = new Knight(Properties.Resources.Knight, true)
            {
                Row = 7,
                Column = 1
            };
            whitePieces[9] = tiles[7, 1].PieceOnTile;

            tiles[7, 2].Image = Properties.Resources.Bishop;
            tiles[7, 2].PieceOnTile = new Bishop(Properties.Resources.Bishop, true)
            {
                Row = 7,
                Column = 2
            };
            whitePieces[10] = tiles[7, 2].PieceOnTile;

            tiles[7, 3].Image = Properties.Resources.Queen;
            tiles[7, 3].PieceOnTile = new Queen(Properties.Resources.Queen, true)
            {
                Row = 7,
                Column = 3
            };
            whitePieces[11] = tiles[7, 3].PieceOnTile;

            tiles[7, 4].Image = Properties.Resources.King;
            tiles[7, 4].PieceOnTile = new King(Properties.Resources.King, true)
            {
                Row = 7,
                Column = 4
            };
            kingPieces[0] = (King)tiles[7, 4].PieceOnTile;
            whitePieces[12] = tiles[7, 4].PieceOnTile;

            tiles[7, 5].Image = Properties.Resources.Bishop;
            tiles[7, 5].PieceOnTile = new Bishop(Properties.Resources.Bishop, true)
            {
                Row = 7,
                Column = 5
            };
            whitePieces[13] = tiles[7, 5].PieceOnTile;

            tiles[7, 6].Image = Properties.Resources.Knight;
            tiles[7, 6].PieceOnTile = new Knight(Properties.Resources.Knight, true)
            {
                Row = 7,
                Column = 6
            };
            whitePieces[14] = tiles[7, 6].PieceOnTile;

            tiles[7, 7].Image = Properties.Resources.Rook;
            tiles[7, 7].PieceOnTile = new Rook(Properties.Resources.Rook, true)
            {
                Row = 7,
                Column = 7
            };
            whitePieces[15] = tiles[7, 7].PieceOnTile;

            // Sets the board up for black pieces
            tiles[0, 0].Image = Properties.Resources.BlackRook;
            tiles[0, 0].PieceOnTile = new Rook(Properties.Resources.BlackRook, false)
            {
                Row = 0,
                Column = 0
            };
            blackPieces[8] = tiles[0, 0].PieceOnTile;

            tiles[0, 1].Image = Properties.Resources.BlackKnight;
            tiles[0, 1].PieceOnTile = new Knight(Properties.Resources.BlackKnight, false)
            {
                Row = 0,
                Column = 1
            };
            blackPieces[9] = tiles[0, 1].PieceOnTile;

            tiles[0, 2].Image = Properties.Resources.BlackBishop;
            tiles[0, 2].PieceOnTile = new Bishop(Properties.Resources.BlackBishop, false)
            {
                Row = 0,
                Column = 2
            };
            blackPieces[10] = tiles[0, 2].PieceOnTile;

            tiles[0, 3].Image = Properties.Resources.BlackQueen;
            tiles[0, 3].PieceOnTile = new Queen(Properties.Resources.BlackQueen, false)
            {
                Row = 0,
                Column = 3
            };
            blackPieces[11] = tiles[0, 3].PieceOnTile;

            tiles[0, 4].Image = Properties.Resources.BlackKing;
            tiles[0, 4].PieceOnTile = new King(Properties.Resources.BlackKing, false)
            {
                Row = 0,
                Column = 4
            };
            kingPieces[1] = (King)tiles[0, 4].PieceOnTile;
            blackPieces[12] = tiles[0, 4].PieceOnTile;

            tiles[0, 5].Image = Properties.Resources.BlackBishop;
            tiles[0, 5].PieceOnTile = new Bishop(Properties.Resources.BlackBishop, false)
            {
                Row = 0,
                Column = 5
            };
            blackPieces[13] = tiles[0, 5].PieceOnTile;

            tiles[0, 6].Image = Properties.Resources.BlackKnight;
            tiles[0, 6].PieceOnTile = new Knight(Properties.Resources.BlackKnight, false)
            {
                Row = 0,
                Column = 6
            };
            blackPieces[14] = tiles[0, 6].PieceOnTile;

            tiles[0, 7].Image = Properties.Resources.BlackRook;
            tiles[0, 7].PieceOnTile = new Rook(Properties.Resources.BlackRook, false)
            {
                Row = 0,
                Column = 7
            };
            blackPieces[15] = tiles[0, 7].PieceOnTile;
        }

        private void Tile_Clicked(object sender, EventArgs e)
        {
            /* Checks if the tile is green and reverts it back to its original color,
               additionally checks if you clicked on the green tile and moves your piece to it */
            Tile tile = (Tile)sender;
            for (int i = 0; i < MAX_TILES; i++)
            {
                for (int j = 0; j < MAX_TILES; j++)
                {
                    Tile currentTile = tiles[i, j];
                    if (currentTile.BackgroundImage == greenBack)
                    {
                        // Checks if the tile clicked was a tile a piece could move on
                        if (currentTile == tile)
                        {
                            Piece pieceMoving = currentTile.PieceToMove;
                            tiles[pieceMoving.Row, pieceMoving.Column].Image = null;
                            tiles[pieceMoving.Row, pieceMoving.Column].PieceOnTile = null;

                            // Changes the pieces location to the new tile and updates the new tiles information
                            currentTile.PieceToMove.Row = i;
                            currentTile.PieceToMove.Column = j;
                            currentTile.Image = pieceMoving.PieceImage;
                            currentTile.PieceOnTile = pieceMoving;

                           // CheckForCheckMate();
                            if (isWhitesTurn)
                            {
                                isWhitesTurn = false;
                                turnLabel.Text = "Black's Turn!";
                            }
                            else
                            {
                                isWhitesTurn = true;
                                turnLabel.Text = "White's Turn!";
                            }

                            // Checks if the piece moving is a pawn and makes sure they can't move twice again
                            if (pieceMoving is Pawn)
                            {
                                Pawn pawnMoved = (Pawn)pieceMoving;
                                pawnMoved.HasMoved = true;
                            }
                        }
                        currentTile.BackgroundImage = currentTile.Background;
                    }
                }
            }

            if (tile.PieceOnTile != null)
            {
                Piece pieceClicked = tile.PieceOnTile;
                if (pieceClicked.OnWhiteTeam == isWhitesTurn)
                {
                    List<Point> moveableSpots = pieceClicked.Piece_Clicked();

                    Point originalLocation = new Point(pieceClicked.Row, pieceClicked.Column);
                    foreach (Point value in moveableSpots)
                    {
                        // Changes the piece's location temporarily to change the background images to green
                        pieceClicked.X += value.X;
                        pieceClicked.Y += value.Y;

                        Tile spaceToGreen = tiles[pieceClicked.Row, pieceClicked.Column];
                        spaceToGreen.BackgroundImage = greenBack;
                        spaceToGreen.PieceToMove = pieceClicked;

                        // Sets the pieces location back to it's original location
                        pieceClicked.Row = originalLocation.X;
                        pieceClicked.Column = originalLocation.Y;
                    }
                }
            }
        }

        private void CheckForCheckMate()
        {
            for (int i = 0; i < kingPieces.Length; i++)
            {
                if (kingPieces[i].OnWhiteTeam != isWhitesTurn)
                {
                    List<Point> movementAreas = kingPieces[i].Piece_Clicked();
                    Point originalLocation = new Point(kingPieces[i].Row, kingPieces[i].Column);
                    //int moveCounter = 0;
                    bool inCheck = false;

                    if (isWhitesTurn)
                    {
                        for (int j = 0; j < whitePieces.Length; j++)
                        {
                            if (!inCheck)
                            {
                                List<Point> pieceMoves = whitePieces[j].Piece_Clicked();
                                foreach (Point value in pieceMoves)
                                {
                                    Point arrayLocation = Piece.ConvertMovesToLocations(value, new Point(whitePieces[i].X, whitePieces[i].Y));
                                    if (arrayLocation == new Point(kingPieces[i].Row, kingPieces[i].Column))
                                    {
                                        inCheck = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }                    
                        }
                    }
                    else
                    {
                        for (int j = 0; j < blackPieces.Length; j++)
                        {
                            if (!inCheck)
                            {
                                List<Point> pieceMoves = blackPieces[j].Piece_Clicked();
                                foreach (Point value in pieceMoves)
                                {
                                    Point arrayLocation = Piece.ConvertMovesToLocations(value, new Point(blackPieces[i].X, blackPieces[i].Y));
                                    if (arrayLocation == new Point(kingPieces[i].Row, kingPieces[i].Column))
                                    {
                                        inCheck = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    //if (inCheck)
                    //{
                    //    foreach (Point move in movementAreas)
                    //    {
                    //        // Changes the piece's location temporarily to add to the possible moves
                    //        tiles[kingPieces[i].Row, kingPieces[i].Column].PieceOnTile = null;
                    //        kingPieces[i].X += move.X;
                    //        kingPieces[i].Y += move.Y;
                    //        tiles[kingPieces[i].Row, kingPieces[i].Column].PieceOnTile = kingPieces[i];

                    //        if (isWhitesTurn)
                    //        {
                    //            for (int j = 0; j < whitePieces.Length; j++)
                    //            {
                    //                List<Point> pieceMoves = whitePieces[j].Piece_Clicked();
                    //                foreach (Point value in pieceMoves)
                    //                {
                    //                    if (value == move)
                    //                    {
                    //                        ++moveCounter;
                    //                        break;
                    //                    }
                    //                }
                    //            }
                    //        }

                    //        // Sets the pieces location back to it's original location
                    //        tiles[kingPieces[i].Row, kingPieces[i].Column].PieceOnTile = null;
                    //        kingPieces[i].Row = originalLocation.X;
                    //        kingPieces[i].Column = originalLocation.Y;
                    //        tiles[kingPieces[i].Row, kingPieces[i].Column].PieceOnTile = kingPieces[i];
                    //    }
                    //}
                }
            }
        }
    }
}