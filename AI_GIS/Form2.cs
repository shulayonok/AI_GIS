using System;
using System.Drawing;
using System.Windows.Forms;

namespace AI_GIS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Point p;

        #region Функции для win form
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - p.X;
                this.Top += e.Y - p.Y;
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Form1.isClicked = true;
            this.Close();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if(!(maskedTextBoxDirection.Text == "") && !(maskedTextBoxSpeed.Text == "") && 
                !(maskedTextBoxSpill.Text == "") && !(maskedTextBoxTime.Text == "") && 
                !(maskedTextBoxVolume.Text == "") && !(maskedTextBoxTemperature.Text == ""))
            {
                if(Proverka())
                {
                    Form1.speed = Convert.ToDouble(maskedTextBoxSpeed.Text);
                    Form1.direction = maskedTextBoxDirection.Text;
                    Form1.spill = Convert.ToDouble(maskedTextBoxSpill.Text);
                    Form1.time = Convert.ToDouble(maskedTextBoxTime.Text);
                    Form1.storageVolume = Convert.ToDouble(maskedTextBoxVolume.Text);
                    Form1.subType = checkedListBoxSubstance.SelectedIndex == 0;
                    Form1.atmoState = ((byte)checkedListBoxAtmoState.SelectedIndex);
                    Form1.isClicked = true;
                    Form1.isModified = true;
                    this.Close();
                }
                else
                {
                    // тут проверки всякие на поля 
                }
            }
            else
            {
                MessageBox.Show("Одно или несколько полей были не заполнены", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool Proverka()
        {
            return true;
        }
    }
}
