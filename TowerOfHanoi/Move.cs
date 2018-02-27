using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    /// <summary>
    /// A move of a disk
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Disk No.
        /// </summary>
        public int DiskNum { get; set; }
        /// <summary>
        /// Order of move
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        public PileLocation SrcPile { get; set; }
        /// <summary>
        /// Destination
        /// </summary>
        public PileLocation DestPile { get; set; }
        /// <summary>
        /// Stringify a move
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: Move {1} from {2} to {3}", Order, DiskNum, SrcPile, DestPile);
        }
    }
}
