using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPizza
{
    public partial class FmPizzaOrder : Form
    {
        public FmPizzaOrder()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Form frm1 = new FmMakePizza();
            frm1.ShowDialog();
        }
    }
}
