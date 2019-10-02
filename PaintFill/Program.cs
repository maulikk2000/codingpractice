using System;

namespace PaintFill
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            Color[,] screen = new Color[N,N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    screen[i,j] = Color.Black;
                }
            }

            for (int i = 0; i < 100; i++)
            {
                screen[RandomInt(N),RandomInt(N)] = Color.Green;
            }

            PrintScreen(screen);
            PaintFill(screen, 2, 2, Color.White);
            Console.WriteLine();
            PrintScreen(screen);
        }

        public enum Color
        {
            Black, White, Red, Yellow, Green
        }

        public static string PrintColor(Color c)
        {
            switch (c)
            {
                case Color.Black:
                    return "B";
                case Color.White:
                    return "W";
                case Color.Red:
                    return "R";
                case Color.Yellow:
                    return "Y";
                case Color.Green:
                    return "G";
            }
            return "X";
        }

        public static void PrintScreen(Color[,] screen)
        {
            for (int r = 0; r < screen.GetLength(0); r++)
            {
                for (int c = 0; c < screen.GetLength(1); c++)
                {
                    Console.Write(PrintColor(screen[r,c]));
                }
                Console.WriteLine();
            }
        }

        public static int RandomInt(int n)
        {
            Random rand = new Random();
            var test = (int)(rand.Next(1, 10));
            return test;
        }

        public static bool PaintFill(Color[,] screen, int r, int c, Color oColor, Color nColor)
        {

            if(r < 0 || r >= screen.GetLength(0) || c < 0 || c >= screen.GetLength(1))
            {
                return false;
            }

            if(screen[r,c] == oColor)
            {
                screen[r,c] = nColor;
                PaintFill(screen, r - 1, c, oColor, nColor);
                PaintFill(screen, r + 1, c, oColor, nColor);
                PaintFill(screen, r, c - 1, oColor, nColor);
                PaintFill(screen, r, c + 1, oColor, nColor);
            }
            return true;
        }

        public static bool PaintFill(Color[,]screen, int r, int c, Color nColor)
        {
            if (screen[r,c] == nColor) return false;
            return PaintFill(screen, r, c, screen[r,c], nColor);
        }


    }
}
