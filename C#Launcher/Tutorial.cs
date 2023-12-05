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
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
            loadTheme();
        }

        private void loadTheme()
        {
            Configurations config = new Configurations();
            Themes theme = new Themes($"System\\Themes\\{config.ThemeName}.css");

            BackColor = theme.WindowBackground;
            tabPage1.BackColor = theme.WindowBackground;
            tabPage2.BackColor = theme.WindowBackground;
            tabPage3.BackColor = theme.WindowBackground;
            tabPage4.BackColor = theme.WindowBackground;

            //Textos
            labelWelcome.ForeColor = theme.LabelText;
            labelWelcomeDescription.ForeColor = theme.LabelText;
            labelElements.ForeColor = theme.LabelText;
            labelDescriptionElement.ForeColor = theme.LabelText;
            labelCollections.ForeColor = theme.LabelText;
            labelCollectionDescription.ForeColor = theme.LabelText;
            labelFinish.ForeColor = theme.LabelText;
            labelDescriptionFinish.ForeColor = theme.LabelText;

            //Botones
            buttonContinue1.BackColor = theme.ButtonBackground;
            buttonContinue1.ForeColor = theme.ButtonText;
            buttonElementsContinue.BackColor = theme.ButtonBackground;
            buttonElementsContinue.ForeColor = theme.ButtonText;
            buttonElementsBack.BackColor = theme.ButtonBackground;
            buttonElementsBack.ForeColor = theme.ButtonText;
            buttonColContinue.BackColor = theme.ButtonBackground;
            buttonColContinue.ForeColor = theme.ButtonText;
            buttonColBack.BackColor = theme.ButtonBackground;
            buttonColBack.ForeColor = theme.ButtonText;
            buttonFinish.BackColor = theme.ButtonBackground;
            buttonFinish.ForeColor = theme.ButtonText;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = (tabControl1.SelectedIndex + 1 < tabControl1.TabCount) ?
                             tabControl1.SelectedIndex + 1 : tabControl1.SelectedIndex;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex -= 1;
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
