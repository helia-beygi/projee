using System;

namespace poroje
{

    class SudokuPuzzleSolver
    {
        private const int Empty = 0;
        private int[,] sudokuBoard;

        public SudokuPuzzleSolver()
        {
            sudokuBoard = new int[9, 9];
        }

        public void SolvePuzzle()
        {
            Console.WriteLine("Enter the Sudoku puzzle (use 0 for empty cells):");

            for (int i = 0; i < 9; i++)
            {
                string row = Console.ReadLine();
                string[] numbers = row.Split(' ');

                for (int j = 0; j < 9; j++)
                {
                    sudokuBoard[i, j] = int.Parse(numbers[j]);
                }
            }

            if (SolveSudoku())
            {
                Console.WriteLine("Solution:");
                PrintSudokuBoard();
            }
            else
            {
                Console.WriteLine("No solution exists!");
            }
        }

        private bool SolveSudoku()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (GetCellValue(row, col) == Empty)
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsValidMove(row, col, num))
                            {
                                SetCellValue(row, col, num);

                                if (SolveSudoku())
                                {
                                    return true;
                                }

                                SetCellValue(row, col, Empty);
                            }
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsValidMove(int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (GetCellValue(row, i) == num || GetCellValue(i, col) == num)
                {
                    return false;
                }
            }

            int blockRowStart = (row / 3) * 3;
            int blockColStart = (col / 3) * 3;

            for (int i = blockRowStart; i < blockRowStart + 3; i++)
            {
                for (int j = blockColStart; j < blockColStart + 3; j++)
                {
                    if (GetCellValue(i, j) == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int GetCellValue(int row, int col)
        {
            return sudokuBoard[row, col];
        }
        private void SetCellValue(int row, int col, int num)
        {
            sudokuBoard[row, col] = num;
        }
        private void PrintSudokuBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(GetCellValue(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main()
        {
            SudokuPuzzleSolver solver = new SudokuPuzzleSolver();
            solver.SolvePuzzle();
        }
    }
}
