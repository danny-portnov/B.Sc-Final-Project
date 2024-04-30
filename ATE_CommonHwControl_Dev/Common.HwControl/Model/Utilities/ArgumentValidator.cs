using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HwControl.Model.Utilities
{
    public static class ArgumentValidator
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if any of the arguments in <paramref name="args"/> are <see langword="null"/>.
        /// </summary>
        /// <param name="args">The arguments to check for <see langword="null"/></param>
        public static void ThrowIfAnyNull(params object[] args)
        {
            if (args.Any(arg => arg == null))
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// <inheritdoc cref="ArgumentValidator.ThrowIfAnyNull(ArgumentNullException, object[])"></inheritdoc>
        /// 
        /// <paramref name="args"/> Includes the arguments' name as keys.
        /// </summary>
        /// <param name="argumentNullException"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void ThrowIfAnyNull(Dictionary<string, object> args)
        {
            foreach (KeyValuePair<string, object> arg in args.Where(arg => arg.Value == null))
            {
                throw new ArgumentNullException(arg.Key);
            }
        }
    }
}
