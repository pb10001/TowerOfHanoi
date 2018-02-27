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
            return string.Format("Move {0} from {1} to {2}", DiskNum, SrcPile, DestPile);
        }
    }
}
