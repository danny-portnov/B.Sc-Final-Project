using Common.HwControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.HwControl.UI.Utility
{
    public static class ControlsExtractor
    {
        /// <summary>
        /// Recursive generic method which gets from the current parent <see cref="Control"/> all the controls of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"><see cref="Type"/> of controls needed from <paramref name="parent"/></typeparam>
        /// <param name="parent">When first called, has to be the current <see cref="CommonHwControlAppView"/> instance</param>
        /// <param name="list">New <see cref="List{T}"/> which will be populated with said controls.</param>
        /// <returns>All controls within the parent that match said type.</returns>
        public static List<T> GetAllCtrlsOfTypeT<T>(Control parent, List<T> list, bool getInherited = false) where T : Control
        {
            foreach (Control child in parent.Controls)
            {
                GetAllCtrlsOfTypeT(child, list, getInherited);
                bool getControls = getInherited ? child is T : child.GetType() == typeof(T);
                if (getControls)
                {
                    T ctrlToAdd = getInherited ? (T)child : (T)Convert.ChangeType(child, typeof(T));
                    list.Add(ctrlToAdd);
                }
            }
            return list;
        }
    }
}