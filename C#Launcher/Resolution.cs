using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Launcher
{
    public partial class Resolution : Form
    {
        public Resolution()
        {
            InitializeComponent();
        }


        private void dataGridViewResolutions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridViewResolutions.Rows[e.RowIndex];

            string name = "name";
            int widthCover = 0;
            int heightCover = 0;
            int coverLayout = 0;

            if (selectedRow.Cells[0].Value != null) name = selectedRow.Cells[0].Value.ToString();
            if (selectedRow.Cells[1].Value != null)
            {
                widthCover = int.Parse(selectedRow.Cells[1].Value.ToString());
                MessageBox.Show("width "+selectedRow.Cells[1].Value.ToString());
            }
            if (selectedRow.Cells[2].Value != null)
            {
                heightCover = int.Parse(selectedRow.Cells[2].Value.ToString());
                MessageBox.Show("height " + selectedRow.Cells[2].Value.ToString());
            }

            if (widthCover != 0 && heightCover != 0)
            {
                pictureBoxCoverSon.Width = widthCover;
                pictureBoxCoverSon.Height = heightCover;
            }
        }

        private void buttonSearchSonCoverTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCoverSon.BackgroundImage = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
