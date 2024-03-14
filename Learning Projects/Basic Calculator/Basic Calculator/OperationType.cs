using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Calculator
{
    /// <summary>
    /// A type of operation the calculator can perform
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// Adds two values together
        /// </summary>
        Add,

        /// <summary>
        /// Substracts one value from another
        /// </summary>
        Minus,

        /// <summary>
        /// Divides one value by another
        /// </summary>
        Divide,

        /// <summary>
        /// Multiplies one value by another
        /// </summary>
        Multiply
    }
}
