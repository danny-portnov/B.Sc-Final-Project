using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.HwControl.UI.Utility
{
    public class RATEButton : CheckBox
    {
        public RATEButton() : base()
        {
            Anchor = AnchorStyles.Bottom;
            Appearance = Appearance.Button;
            AutoSize = true;
            BackColor = System.Drawing.Color.FromArgb(89, 97, 115);
            FlatStyle = FlatStyle.Flat;
            Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            ForeColor = System.Drawing.Color.White;
            Size = new System.Drawing.Size(59, 26);
            Text = "Action";
            UseVisualStyleBackColor = false;
        }
    }
}
