using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerOfHanoi;

namespace Test
{
    class Program
    {
        static int length;
        static int src;
        static int dest;
        static void Main(string[] args)
        {
            //Main entry point
            Console.WriteLine("Input a length of the tower(Default: 5):");
            if (!int.TryParse(Console.ReadLine(), out length)) length = 5;
            Console.WriteLine("Input the source pile(Left:0, Center:1, Right: 2, Default: Left):");
            if (!int.TryParse(Console.ReadLine(), out src)) src = 0;
            Console.WriteLine("Input the destination pile(Left:0, Center:1, Right: 2, Default: Center):");
            if(!int.TryParse(Console.ReadLine(), out dest)) dest = 1;
            var tower = new Tower();
            tower.Init(length, src, dest);
            tower.DiskMoved += Tower_DiskMoved;
            try
            {
                tower.Solve((res) =>
                {
                    Console.WriteLine("Solved in {0} turns.", res.Count());
                });
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void Tower_DiskMoved(Move obj)
        {
            Console.WriteLine(obj);
        }
    }
}
