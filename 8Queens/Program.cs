using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace _8Queens
{
    class Program
    {
        public static int GRID_SIZE = 8;
        static void Main(string[] args)
        {
            List<int[]> results = new List<int[]>();

            int[] columns = new int[GRID_SIZE];
            Clear(columns);
            PlaceQueens(0, columns, results);
            PrintBoards(results);
            Console.WriteLine(results.Count);
        }

        private static void PrintBoards(List<int[]> boards)
        {
            for (int i = 0; i < boards.Count; i++)
            {
                int[] board = boards[i];
                PrintBoard(board);
            }
        }

        private static void PrintBoard(int[] columns)
        {
            DrawLine();
            for (int i = 0; i < GRID_SIZE; i++)
            {
                Console.WriteLine("|");
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if(columns[i] == j)
                    {
                        Console.Write("Q|");
                    }
                    else
                    {
                        Console.Write(" |");
                    }
                }
                Console.Write("\n");
                DrawLine();
            }
            Console.WriteLine("");
        }

        private static void DrawLine()
        {
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < GRID_SIZE*2+1; i++)
            {
                line.Append('-');
            }
            Console.WriteLine(line.ToString());
        }

        public static void PlaceQueens(int row, int[] columns, List<int[]> results)
        {
            if(row == GRID_SIZE)
            {
                results.Add((int[])columns.Clone());
            }
            else
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    if (CheckValid(columns, row, col))
                    {
                        columns[row] = col; //place queen
                        PlaceQueens(row + 1, columns, results);
                    }
                }
            }
        }

        public static bool CheckValid(int[] columns, int row1, int col1)
        {
            for (int row2 = 0; row2 < row1; row2++)
            {
                int col2 = columns[row2];

                if(col1 == col2)
                {
                    return false;
                }

                int colDistance = Math.Abs(col2 - col1);
                int rowDistance = row1 - row2;

                if(rowDistance == colDistance)
                {
                    return false;
                }
            }

            return true;
        }
        //private static void PlaceQueens(int row, int[] columns, List<int[]> results)
        //{
        //    if (row == GRID_SIZE)
        //    {
        //        results.Add(columns);
        //    }
        //    else
        //    {
        //        for (int col = 0; col < GRID_SIZE; col++)
        //        {
        //            if (CheckValid(columns, row, col))
        //            {
        //                columns[row] = col;
        //                PlaceQueens(row + 1, columns, results);
        //            }
        //        }
        //    }


        //}

        //private static bool CheckValid(int[] columns, int row1, int col1)
        //{
        //    for (int row2 = 0; row2 < row1; row2++)
        //    {
        //        int col2 = columns[row2];

        //        if(col1 == col2)
        //        {
        //            return false;
        //        }

        //        int colDistance = Math.Abs(col2 - col1);
        //        int rowDistance = row1 - row2;

        //        if(rowDistance == colDistance)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        private static void Clear(int[] columns)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                columns[i] = -1;
            }
        }
    }
}
