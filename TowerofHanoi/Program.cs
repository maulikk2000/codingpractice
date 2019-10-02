using System;
using System.Collections.Generic;

namespace TowerofHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            char startPeg = 'A';
            char endPeg = 'C';
            char tempPeg = 'B';
            int totalDisks = 5;
            MoveDisks(totalDisks, startPeg, endPeg, tempPeg);
        }

        static void MoveDisks(int n, char startPeg, char endPeg, char tempPeg)
        {
            if(n > 0)
            {
                MoveDisks(n - 1, startPeg, tempPeg, endPeg);
                Console.WriteLine($"Moved disk from {startPeg} to {endPeg}" );
                MoveDisks(n - 1, tempPeg, endPeg, startPeg);
            }
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int n = 3;
    //        Tower[] towers = new Tower[3];
    //        for (int i = 0; i < 3; i++)
    //        {
    //            towers[i] = new Tower(i);
    //        }

    //        for (int i = n-1; i >= 0; i--)
    //        {
    //            towers[0].Add(i);
    //        }

    //        towers[0].MoveDisks(n, towers[2], towers[1]);
    //    }
    //}

    //public class Tower
    //{
    //    private Stack<int> disks;
    //    private int index;
    //    public Tower(int i)
    //    {
    //        disks = new Stack<int>();
    //        index = i;
    //    }

    //    public int Index()
    //    {
    //        return index;
    //    }

    //    public void Add(int d)
    //    {
    //        if(disks.Count != 0 && disks.Peek() <= d)
    //        {
    //            Console.WriteLine($"error placing disk {d}");
    //        }
    //        else
    //        {
    //            disks.Push(d);
    //        }
    //    }

    //    public void MoveTopTo(Tower t)
    //    {
    //        int top = disks.Pop();
    //        t.Add(top);
    //    }

    //    public void MoveDisks(int n, Tower destination, Tower buffer)
    //    {
    //        if(n > 0)
    //        {
    //            MoveDisks(n - 1, buffer, destination);
    //            MoveTopTo(destination);
    //            buffer.MoveDisks(n - 1, destination, this);
    //        }
    //    }
    //}
}
