using System;
namespace TicTacToe_Challenge
{
    public class Matrix
    {
        private static int row = 3;
        private static int innerRow = 4;
        private innerBox[] matrixUi = new innerBox[row * row];
        private string[] matrixUx = new string[row * innerRow];
        private enum Position
        {
            LEFT,
            RIGHT,
            TOP,
            BOTTOM,
            TOP_LEFT,
            TOP_RIGHT,
            BOTTOM_LEFT,
            BOTTOM_RIGHT
        };

        public Matrix()
        {
            InitializeMatrix();
        }

        public void InitializeMatrix()
        {
            for (int i = 1; i <= (row * row); ++i)
            {
                if (i % row == 0 && i != row * row)
                {
                    matrixUi[i - 1] = new innerBox(i, true, false);
                }
                else if (i > row * (row - 1) && i < row * row)
                {
                    matrixUi[i - 1] = new innerBox(i, false, true);
                }
                else if (i == row * row)
                {
                    matrixUi[i - 1] = new innerBox(i, true, true);
                }
                else
                {
                    matrixUi[i - 1] = new innerBox(i, false, false);
                }

            }
        }
        public void DisplayMatrix()
        {
            ComposeMatrixUx();
            for (int i = 0; i < matrixUx.Length; ++i)
            {
                Console.WriteLine(matrixUx[i]);
            }

            Console.WriteLine("");
        }
        public void ComposeMatrixUx()
        {
            for (int i = 0; i < matrixUx.Length; ++i)
            {
                matrixUx[i] = string.Empty;
                //Console.WriteLine("Index i: " + i);
                for (int j = 0; j < row; ++j)
                {
                    //Console.WriteLine("Index j: " + j);
                    //Console.WriteLine("MatrixUi index: " + (j + (i / innerRow * row)));
                    //Console.WriteLine("GetInnerRow Index: " + (i % innerRow));
                    matrixUx[i] += matrixUi[j + (i / innerRow * row)].GetInnerRow(i % innerRow);
                }
                //Console.WriteLine("MatrixUx[{0}]: {1}", i, matrixUx[i]);
            }
        }
        public int MoveSelector(bool player1)
        {
            string player = player1 ? "Player 1" : "Player 2";
            int result = 0;
            do
            {
                Console.Write($"{player}: Choose your field! ");
                if (int.TryParse(Console.ReadLine(), out int field) && field > 0 && field <= row * row && Char.IsDigit(matrixUi[field - 1].GetInnerValue()[0]))
                {
                    result = field;
                }
                else
                {

                    Console.WriteLine("Error: Value must be an Integer and between 1 and 9 and the box must be unchosen yet!");
                }
            } while (result == 0);
            return result;
        }
        public void ApplyMove(int field, bool isPlayerOne)
        {
            string ticToe = isPlayerOne ? "X" : "O";
            matrixUi[field - 1].ChangeInnerValue(ticToe);
        }
        public bool checkWin(int field)
        {
            bool result = false;
            int index = field - 1;
            if (index % row == 0 || index % row == row)
            {
                if (CheckPosition(index) == "UPPER")
                {
                    if (CheckAdjacentBox(index, Position.RIGHT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.RIGHT), Position.RIGHT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.BOTTOM_RIGHT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.BOTTOM_RIGHT), Position.BOTTOM_RIGHT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.BOTTOM))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.BOTTOM), Position.BOTTOM))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
                else if (CheckPosition(index) == "CENTRAL")
                {
                    if (CheckAdjacentBox(index, Position.RIGHT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.RIGHT), Position.RIGHT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.TOP))
                    {
                        if (CheckAdjacentBox(index, Position.BOTTOM))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
                else
                {
                    if (CheckAdjacentBox(index, Position.RIGHT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.RIGHT), Position.RIGHT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.TOP))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.TOP), Position.TOP))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.TOP_RIGHT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.TOP_RIGHT), Position.TOP_RIGHT))
                        {
                            result = true;
                            return result;
                        }
                    }

                }
            }
            else if (index % row == 1)
            {
                if (CheckPosition(index) == "UPPER")
                {
                    if (CheckAdjacentBox(index, Position.RIGHT))
                    {
                        if (CheckAdjacentBox(index, Position.LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.BOTTOM))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.BOTTOM), Position.BOTTOM))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
                else if (CheckPosition(index) == "CENTRAL")
                {
                    if (CheckAdjacentBox(index, Position.TOP))
                    {
                        if (CheckAdjacentBox(index, Position.BOTTOM))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.RIGHT))
                    {
                        if (CheckAdjacentBox(index, Position.LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.TOP_RIGHT))
                    {
                        if (CheckAdjacentBox(index, Position.BOTTOM_LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.TOP_LEFT))
                    {
                        if (CheckAdjacentBox(index, Position.BOTTOM_RIGHT))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
                else
                {
                    if (CheckAdjacentBox(index, Position.TOP))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.TOP), Position.TOP))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.RIGHT))
                    {
                        if (CheckAdjacentBox(index, Position.LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
            }
            else
            {
                if (CheckPosition(index) == "UPPER")
                {
                    if (CheckAdjacentBox(index, Position.BOTTOM))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.BOTTOM), Position.BOTTOM))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.LEFT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.LEFT), Position.LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.BOTTOM_LEFT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.BOTTOM_LEFT), Position.BOTTOM_LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
                else if (CheckPosition(index) == "CENTRAL")
                {
                    if (CheckAdjacentBox(index, Position.LEFT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.LEFT), Position.LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.TOP))
                    {
                        if (CheckAdjacentBox(index, Position.BOTTOM))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
                else
                {
                    if (CheckAdjacentBox(index, Position.TOP))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.TOP), Position.TOP))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.LEFT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.LEFT), Position.LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                    if (CheckAdjacentBox(index, Position.TOP_LEFT))
                    {
                        if (CheckAdjacentBox(AdjacentIndex(index, Position.TOP_LEFT), Position.TOP_LEFT))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
            }
            return result;
        }
        public bool CheckTie()
        {
            bool result = true;
            for (int i = 0; i < matrixUi.Length; ++i)
            {
                if (int.TryParse(matrixUi[i].GetInnerValue(), out int value))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        private string CheckPosition(int index)
        {
            return index / row == 0 ? "UPPER" : index / row == 1 ? "CENTRAL" : "LOWER";
        }
        private bool CheckAdjacentBox(int field, Position position)
        {
            switch (position)
            {
                case Position.LEFT:
                    return matrixUi[field].GetInnerValue() == matrixUi[field - 1].GetInnerValue();
                case Position.RIGHT:
                    return matrixUi[field].GetInnerValue() == matrixUi[field + 1].GetInnerValue();
                case Position.TOP:
                    return matrixUi[field].GetInnerValue() == matrixUi[field - row].GetInnerValue();
                case Position.BOTTOM:
                    return matrixUi[field].GetInnerValue() == matrixUi[field + row].GetInnerValue();
                case Position.TOP_LEFT:
                    return matrixUi[field].GetInnerValue() == matrixUi[field - row - 1].GetInnerValue();
                case Position.TOP_RIGHT:
                    return matrixUi[field].GetInnerValue() == matrixUi[field - row + 1].GetInnerValue();
                case Position.BOTTOM_LEFT:
                    return matrixUi[field].GetInnerValue() == matrixUi[field + row - 1].GetInnerValue();
                case Position.BOTTOM_RIGHT:
                    return matrixUi[field].GetInnerValue() == matrixUi[field + row + 1].GetInnerValue();
                default:
                    return false;
            }
        }
        private int AdjacentIndex(int index, Position position)
        {
            switch (position)
            {
                case Position.LEFT:
                    return index - 1;
                case Position.RIGHT:
                    return index + 1;
                case Position.TOP:
                    return index - row;
                case Position.BOTTOM:
                    return index + row;
                case Position.TOP_LEFT:
                    return index - row - 1;
                case Position.TOP_RIGHT:
                    return index - row + 1;
                case Position.BOTTOM_LEFT:
                    return index + row - 1;
                case Position.BOTTOM_RIGHT:
                    return index + row + 1;
                default:
                    return index;
            }
        }

        private class innerBox
        {
            private string[,] innerObj = new string[innerRow, innerRow];
            private int index;
            private bool isLastCol;
            private bool isLastRow;

            public innerBox(int index, bool isLastCol, bool isLastRow)
            {
                this.index = index;
                this.isLastCol = isLastCol;
                this.isLastRow = isLastRow;
                //Console.WriteLine("index: " + this.index);
                //Console.WriteLine("isLastCol: " + this.isLastCol);
                //Console.WriteLine("isLastRow: " + this.isLastRow);
                for (int i = 0; i < innerObj.GetLength(0); ++i)
                {
                    for (int j = 0; j < innerObj.GetLength(1); ++j)
                    {
                        innerObj[i, j] = ((j + 1) % innerObj.GetLength(0) == 0 && !this.isLastCol) ? "|"
                            : ((i + 1) % innerObj.GetLength(0) == 0 && !this.isLastRow && ((j + 1) % innerObj.GetLength(0) != 0)) ? "_"
                            : (i == 1 && j == 1) ? this.index.ToString()
                            : " ";
                        //Console.WriteLine("Element [" + i + "," + j + "]: " + innerObj[i, j]);
                    }
                }
                //DisplayInnerBox();
            }
            public void DisplayInnerBox()
            {
                for (int i = 0; i < innerObj.GetLength(0); ++i)
                {
                    for (int j = 0; j < innerObj.GetLength(1); ++j)
                    {
                        Console.Write(innerObj[i, j] + " ");
                    }
                    if (i != innerObj.GetLength(0) - 1)
                    {
                        Console.Write("\n");
                    }
                }
            }
            public void ChangeInnerValue(string ticToe)
            {
                innerObj[1, 1] = ticToe;
            }
            public string GetInnerValue()
            {
                return innerObj[1, 1];
            }
            //utilities for debugging
            public void DisplayArray()
            {
                for (int i = 0; i < innerObj.GetLength(0); ++i)
                {
                    for (int j = 0; j < innerObj.GetLength(1); ++j)
                    {
                        Console.Write(innerObj[i, j]);
                    }
                    Console.WriteLine("");
                }
            }
            public void DisplayIndex()
            {
                Console.WriteLine("Index is: " + index);
            }
            public string GetInnerRow(int rowIndex)
            {
                string innerRow = string.Empty;
                for (int j = 0; j < innerObj.GetLength(0); ++j)
                {
                    innerRow += innerObj[rowIndex, j];
                }
                //Console.WriteLine("InnerRow{0} : {1}", rowIndex, innerRow);
                return innerRow;
            }
        }

    }
}
