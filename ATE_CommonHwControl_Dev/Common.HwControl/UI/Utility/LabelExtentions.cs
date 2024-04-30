using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.HwControl.UI.Utility
{
    public static class LabelExtentions
    {
        //private const int Spacing = 20;

        public static void AutoSizeFont(this Label label, float width)
        {
            float fontSize = label.Font.Size;
            //Graphics graphics = label.CreateGraphics();
            Font font;
            do
            {
                font = new(label.Font.FontFamily, fontSize);
                fontSize -= 0.1f;
            } while (TextRenderer.MeasureText(label.Text, font).Width /*+ Spacing*/ > width);
            label.Font = font;
        }
    }
}