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
    public partial class FmMakePizza : Form
    {
        public FmMakePizza()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {

            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lbSize.Text = "Small";
                return;
            }

            if (rbMeduim.Checked)
            {
                lbSize.Text = "Meduim";
                return;
            }

            if (rbLarge.Checked)
            {
                lbSize.Text = "Large";
                return;
            }
        }

        void UpdateCrust()
        {
            UpdateTotalPrice();

            if (rbThinCrust.Checked)
            {
                lbCurstType.Text = "Thin Crust";
                return;
            }

            if (rbThickCrust.Checked)
            {
                lbCurstType.Text = "Tick Crust";
                return;
            }

        }

        void UpdateToppings()
        {

            UpdateTotalPrice();

            string sToppings = "";

            if (cbExtraCheese.Checked)
                sToppings = "Extra Cheese";

            if (cbMushrooms.Checked)
                sToppings += ", Mushrooms";

            if (cbTomatoes.Checked)
                sToppings += ", Tomatoes";

            if (cbOnion.Checked)
                sToppings += ", Onion";

            if (cbOlives.Checked)
                sToppings += ", Olives";

            if (cbGreenPeppers.Checked)
                sToppings += ", Green Peppers";

            if (sToppings == "")
                sToppings = "No Toppings.";

            if (sToppings.StartsWith(","))
                sToppings = sToppings.Substring(1 , sToppings.Length - 1).Trim();

            lbToppings.Text = sToppings;
        }

        void UpdateWhereToEat()
        {
            if (rbEatIn.Checked)
            {
                lbWhereToEat.Text = "Eat In";
                return;
            }

            if (rbTakeOut.Checked)
            {
                lbWhereToEat.Text = "Take Out";
            }
        }

        float GetSizePrice()
        {
            if (rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }

            else
            {
                if (rbMeduim.Checked)
                    return Convert.ToSingle(rbMeduim.Tag);
                else
                    return Convert.ToSingle(rbLarge.Tag);
            }
        }

        float GetCrustPrice()
        {
            if (rbThinCrust.Checked)
                return Convert.ToSingle(rbThinCrust.Tag);
            else
                return Convert.ToSingle(rbThickCrust.Tag);
        }

        float GetToppingsPrice()
        {
            float TotalPrice = 0;

            if (cbExtraCheese.Checked)
                TotalPrice = Convert.ToSingle(cbExtraCheese.Tag);

            if (cbMushrooms.Checked)
                TotalPrice += Convert.ToSingle(cbMushrooms.Tag);

            if (cbTomatoes.Checked)
                TotalPrice += Convert.ToSingle(cbTomatoes.Tag);

            if (cbOnion.Checked)
                TotalPrice += Convert.ToSingle(cbOnion.Tag);

            if (cbOlives.Checked)
                TotalPrice += Convert.ToSingle(cbOlives.Tag);

            if (cbGreenPeppers.Checked)
                TotalPrice += Convert.ToSingle(cbGreenPeppers.Tag);

            return TotalPrice;
        }

        void UpdateTotalPrice()
        {
            lbTotalPrice.Text = "$" + (GetSizePrice()+ GetCrustPrice() + GetToppingsPrice()).ToString();
        }

        void OrderSummary()
        {

            UpdateSize();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateToppings();

        }

        void Reset()
        {

            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;

            cbExtraCheese.Checked = false;
            cbMushrooms.Checked = false;
            cbOlives.Checked = false;
            cbGreenPeppers.Checked = false;
            cbOnion.Checked = false;
            cbTomatoes.Checked = false;

            rbSmall.Checked = true;
            rbEatIn.Checked = true;
            rbThinCrust.Checked = true;

            btnSubmit.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void cbExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void FmMakePizza_Load(object sender, EventArgs e)
        {
            OrderSummary();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                MessageBox.Show("Confirm Successfuly!", "Confirm", MessageBoxButtons.OK);

                gbSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;

                btnSubmit.Enabled = false;
            }

            else
            {
                MessageBox.Show("Make Your Pizza As You Want", "Confirm", MessageBoxButtons.OK);

            }
        }
    }
}
