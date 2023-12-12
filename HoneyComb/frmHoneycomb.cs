using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoneyComb
{
    public partial class frmHoneyComb : Form
    {
        // Definición de un objeto de tipo CRectangle.
        private CHoneyComb ObjHoney = new CHoneyComb();
        public frmHoneyComb()
        {
            InitializeComponent();
        }

        private void frmHexagon_Load(object sender, EventArgs e)
        {
            // Inicialización de los datos y controles.
            // Llamada a la función InitializeData.
            ObjHoney.InitializeData(txtSide, picCanvas);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ObjHoney.ReadData(txtSide);
            ObjHoney.PlotHoneyComb(picCanvas);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjHoney.InitializeData(txtSide, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjHoney.CloseForm(this);
        }
    }
}
