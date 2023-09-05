using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C_Launcher.Clases.Controles
{
    public class MenuColorTable : ProfessionalColorTable
    {
        private Color backColor;
        private Color leftColumnColor;
        private Color borderColor;
        private Color menuItemBorderColor;
        private Color menuItemSelectedColor;

        //Constructor
        public MenuColorTable(bool mainMenu, Color primaryColor)
        {
            if (mainMenu)
            {
                backColor = Color.FromArgb(23, 29, 37);
                leftColumnColor = Color.FromArgb(23, 29, 37);
                borderColor = Color.FromArgb(23, 29, 37);
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            } else
            {
                backColor = Color.FromArgb(36, 40, 47);
                leftColumnColor = Color.FromArgb(36, 40, 47);
                borderColor = Color.FromArgb(36, 40, 47);
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            }
        }

        //Anulaciones
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return backColor;
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return borderColor;
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return menuItemBorderColor;
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return menuItemSelectedColor;
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return leftColumnColor;
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return leftColumnColor;
            }
        }
    }
}
