using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    /// <summary>
    /// Definition of pile locations
    /// </summary>
    public enum PileLocation
    {
        /// <summary>
        /// Left
        /// </summary>
        Left=0,
        /// <summary>
        /// Center
        /// </summary>
        Center=1,
        /// <summary>
        /// Right
        /// </summary>
        Right=2,
    }
    public class Tower
    {
        /// <summary>
        /// Initialize a Tower by pile locations.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        public void Init(int length, PileLocation src, PileLocation dest)
        {
            disks = new PileLocation[length];
            for (int i = 0; i < length; i++)
            {
                disks[i] = src;
            }
            this.length = length;
            turn = 0;
            srcPile = src;
            destPile = dest;
            Moves = new List<Move>();
        }
        /// <summary>
        /// Initialize a tower by integer.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        public void Init(int length, int src, int dest)
        {
            disks = new PileLocation[length];
            turn = 0;
            for (int i = 0; i < length; i++)
            {
                switch (src)
                {
                    case 0:
                        disks[i] = PileLocation.Left;
                        break;
                    case 1:
                        disks[i] = PileLocation.Center;
                        break;
                    case 2:
                        disks[i] = PileLocation.Right;
                        break;
                }
            }
            this.length = length;
            switch (src)
            {
                case 0:
                    srcPile = PileLocation.Left;
                    break;
                case 1:
                    srcPile = PileLocation.Center;
                    break;
                case 2:
                    srcPile = PileLocation.Right;
                    break;
                default:
                    srcPile = PileLocation.Left;
                    break;
            }
            switch (dest)
            {
                case 0:
                    destPile = PileLocation.Left;
                    break;
                case 1:
                    destPile = PileLocation.Center;
                    break;
                case 2:
                    destPile = PileLocation.Right;
                    break;
                default:
                    destPile = PileLocation.Left;
                    break;
            }
            Moves = new List<Move>();
        }

        PileLocation[] disks;
        int length;
        int turn;
        PileLocation srcPile;
        PileLocation destPile;
        /// <summary>
        /// List of moves
        /// </summary>
        public List<Move> Moves { get; set; }
        /// <summary>
        /// An event that fires when a disk moved
        /// </summary>
        public event Action<Move> DiskMoved = delegate { };
        /// <summary>
        /// Solve the puzzle
        /// </summary>
        /// <param name="callback">A method when the puzzle is solved.</param>
        public void Solve(Action<IEnumerable<Move>> callback)
        {
            Solve(disks, length, srcPile, destPile);
            callback(Moves);
        }
        private void Solve(PileLocation[] array, int length, PileLocation src, PileLocation dest)
        {
            if (length == 0)
            {
                //This is the end of recursion.
                return;
            }
            else if (src == PileLocation.Left && dest == PileLocation.Center)
            {
                MoveOnce(array, length, src, dest, PileLocation.Right);
            }
            else if (src == PileLocation.Left && dest == PileLocation.Right)
            {
                MoveOnce(array, length, src, dest, PileLocation.Center);
            }
            else if (src == PileLocation.Center && dest == PileLocation.Left)
            {
                MoveOnce(array, length, src, dest, PileLocation.Right);
            }
            else if (src == PileLocation.Center && dest == PileLocation.Right)
            {
                MoveOnce(array, length, src, dest, PileLocation.Left);
            }
            else if (src == PileLocation.Right && dest == PileLocation.Left)
            {
                MoveOnce(array, length, src, dest, PileLocation.Center);
            }
            else if (src == PileLocation.Right && dest == PileLocation.Center)
            {
                MoveOnce(array, length, src, dest, PileLocation.Left);
            }
            else
            {
                //Error
                throw new InvalidOperationException("Invalid inputs.");
            }
        }
        private void MoveOnce(PileLocation[] array, int length, PileLocation src, PileLocation dest, PileLocation rest)
        {
            Solve(array, length - 1, src, rest);
            array[length - 1] = dest;
            Move move = new Move()
            {
                Order = ++turn,
                DiskNum = length - 1,
                SrcPile = src,
                DestPile = dest
            };
            Moves.Add(move);
            DiskMoved(move);
            Solve(array, length - 1, rest, dest);
        }
    }
}
