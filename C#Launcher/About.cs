using CoverPadLauncher.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoverPadLauncher
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            loadTheme();
        }

        private void loadTheme()
        {
            Configurations config = new Configurations();
            Themes theme = new Themes($"System\\Themes\\{config.ThemeName}.css");

            BackColor = theme.WindowBackground;

            //Textos
            labelTittle.ForeColor = theme.LabelText;
            labelDescription.ForeColor = theme.LabelText;

            //Links
            linkWebPage.ForeColor = theme.LabelText;
            linkWebPage.LinkColor = theme.LabelText;
            linkWebPage.VisitedLinkColor = theme.LabelText;
            linkSource.ForeColor = theme.LabelText;
            linkSource.VisitedLinkColor = theme.LabelText;
            linkSource.LinkColor = theme.LabelText;
        }
    }
}
