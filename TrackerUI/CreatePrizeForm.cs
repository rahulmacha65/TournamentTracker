using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequestor callingFrom;
        public CreatePrizeForm(IPrizeRequestor caller)
        {
            InitializeComponent();
            callingFrom = caller;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void createPrizeBtn_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                PrizeModel model = new PrizeModel();
                model.PlaceName = placeNameValue.Text;
                model.PlaceNumber = Int32.Parse(PlaceNumebrValue.Text);
                model.PriceAmount = Decimal.Parse(prizeAmountValue.Text);
                model.PricePercentage = Double.Parse(prizePercentageValue.Text);

                GlobalConfig.Connection.CreatePrize(model);

                callingFrom.PrizeComplete(model);
                this.Close();

                //PlaceNumebrValue.Text = "";
                //placeNameValue.Text = "";
                //prizeAmountValue.Text = "0";
                //prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form is not valid please check your inputs..");
            }
        }
        private bool validateForm()
        {
            bool output = true;

            if (Int32.Parse(PlaceNumebrValue.Text) < 0)
            {
                output = false; 
            }
            if(placeNameValue.Text.Length==0)
            {
                output = false;
            }
            if (Int32.Parse(prizeAmountValue.Text) < 0)
            {
                output = false;
            }
            if (Int32.Parse(prizePercentageValue.Text) < 0)
            {
                output = false;
            }
            if(Int32.Parse(prizePercentageValue.Text)<0 || Int32.Parse(prizePercentageValue.Text) >= 100)
            {
                output = false;
            }
            return output;
        }
    }
}
