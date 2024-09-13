using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _045_mesa_tuala
{
    public partial class frmScabrats : Form
    {
        public frmScabrats()
        {
            InitializeComponent();

            initializeNums();
            initializeChks();
            initializePrices();
        }

        // Add the checkBoxes and NumericUpdowns in a List<T>
        List<NumericUpDown> numericUpDowns = new List<NumericUpDown>();
        List<CheckBox> checkBoxes = new List<CheckBox>();

        // Create a key (checkbox) value (price) pair for the itme and the price
        Dictionary<CheckBox, double> itemPrices = new Dictionary<CheckBox, double>();

        // Initialize Fees

        const int membershipDiscount = 50;
        const int toGoFee = 10;
        const double ptsPerTransactionIfMember = 0.03;





        // Function for the initializations of the list and the hashmap
        private void initializePrices()
        {
            itemPrices.Add(chkCream, 120.00);
            itemPrices.Add(chkSalted, 110.00);
            itemPrices.Add(chkVanilla, 125.00);
            itemPrices.Add(chkBurnt, 150.00);
            itemPrices.Add(chkHot, 90.00);
            itemPrices.Add(chkIced, 135.00);
            itemPrices.Add(chkGreen, 155.00);
            itemPrices.Add(chkJava, 162.00);
        }
        private void initializeNums()
        {
            numericUpDowns.Add(numCream);
            numericUpDowns.Add(numSalted);
            numericUpDowns.Add(numVanilla);
            numericUpDowns.Add(numBurnt);
            numericUpDowns.Add(numHot);
            numericUpDowns.Add(numIced);
            numericUpDowns.Add(numGreen);
            numericUpDowns.Add(numJava);
        }
        private void initializeChks()
        {
            checkBoxes.Add(chkCream);
            checkBoxes.Add(chkSalted);
            checkBoxes.Add(chkVanilla);
            checkBoxes.Add(chkBurnt);
            checkBoxes.Add(chkHot);
            checkBoxes.Add(chkIced);
            checkBoxes.Add(chkGreen);
            checkBoxes.Add(chkJava);
        }
    

        // Compute Functions

        private double computeTotal(List<NumericUpDown> nummericUpdowns, List<CheckBox> checkBoxes, Dictionary<CheckBox, double> itemPrices)
        {

            double total = 0;
            
            for (int i = 0; i <  nummericUpdowns.Count; i++)
            {
                if (numericUpDowns[i].Value > 0)
                {
                    total = total + ((double) numericUpDowns[i].Value * itemPrices[checkBoxes[i]]);
                }
            }

            return total;
            
        }

        // WinForm Functions

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            double computedAmount = 0;
            double ptsAccumulated = 0.00;

            if (!isCheckBoxEmpty() && !isNumValuesEmpty() && (rdoHere.Checked || rdoGO.Checked) )
            {
                computedAmount = computeTotal(numericUpDowns, checkBoxes, itemPrices);

                if (chkMember.Checked)
                {
                    computedAmount += membershipDiscount;
                    ptsAccumulated = computedAmount * 0.03;
                }

                if (rdoGO.Checked)
                {
                    computedAmount += toGoFee;
                } 

                lblTotal.Text = "Total: " + computedAmount.ToString();
                lblPoints.Text = "Points: " + ptsAccumulated.ToString();

                //MessageBox.Show("Tama", "Sheesh");
            } else if (isCheckBoxEmpty())
            {
                MessageBox.Show("No order found", "Select Order", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            } else 
            {
                MessageBox.Show("Order found but no number of order assigned or No receiving option applied", "Insert Correct Order Option", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }



        private bool isNumValuesEmpty()
        {
            foreach (NumericUpDown numericUpDown in  numericUpDowns)
            {
                if (numericUpDown.Value > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isCheckBoxEmpty()
        {
            foreach (CheckBox checkBox in checkBoxes)
            {
                if (checkBox.Checked)
                {
                    return false;
                }
            }

            return true;
        }


        private void frmScabrats_Load(object sender, EventArgs e)
        {
            foreach (NumericUpDown numericUpDown in numericUpDowns)
            {
                numericUpDown.Enabled = false;
            }
        }

        private void chkCream_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCream.Checked)
            {
                numCream.Enabled = true;
            } else
            {
                numCream.Enabled = false;
                numCream.Value = 0;
            }
        }

        private void chkSalted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalted.Checked)
            {
                numSalted.Enabled = true;
            }
            else
            {
                numSalted.Enabled = false;
                numSalted.Value = 0;
            }
        }

        private void chkVanilla_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVanilla.Checked)
            {
                numVanilla.Enabled = true;
            }
            else
            {
                numVanilla.Enabled = false;
                numVanilla.Value = 0;
            }
        }

        private void chkBurnt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBurnt.Checked)
            {
                numBurnt.Enabled = true;
            }
            else
            {
                numBurnt.Enabled = false;
                numBurnt.Value = 0;
            }
        }

        private void chkHot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHot.Checked)
            {
                numHot.Enabled = true;
            }
            else
            {
                numHot.Enabled = false;
                numHot.Value = 0;
            }
        }

        private void chkIced_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIced.Checked)
            {
                numIced.Enabled = true;
            }
            else
            {
                numIced.Enabled = false;
                numIced.Value = 0;
            }
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked)
            {
                numGreen.Enabled = true;
            }
            else
            {
                numGreen.Enabled = false;
                numGreen.Value = 0;
            }
        }

        private void chkJava_CheckedChanged(object sender, EventArgs e)
        {
            if (chkJava.Checked)
            {
                numJava.Enabled = true;
            }
            else
            {
                numJava.Enabled = false;
                numJava.Value = 0;
            }
        }

    }
}
