﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// The yupe of value a cell in the game is currently aat
    /// </summary>
    internal enum MarkType
    {
        /// <summary>
        /// The cell hasn't been clicked yet
        /// </summary>
        Free,

        /// <summary>
        /// The cell is a 0
        /// </summary>
        Nought,

        /// <summary>
        /// The cell is an X
        /// </summary>
        Cross
    }
}
