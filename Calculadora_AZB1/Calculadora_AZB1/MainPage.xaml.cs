using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora_AZB1
{
    public partial class MainPage : ContentPage
    {
        string currentExpression = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentExpression += button.Text;
            display.Text += button.Text;
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentExpression))
            {
                var button = (Button)sender;
                currentExpression += button.Text;
                display.Text += button.Text;
            }
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentExpression))
            {
                try
                {
                    DataTable dt = new DataTable();
                    var result = dt.Compute(currentExpression, "");
                    display.Text = result.ToString();
                    currentExpression = result.ToString();
                }
                catch (Exception ex)
                {

                    display.Text = "Error";
                    currentExpression = string.Empty;
                }
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            currentExpression = string.Empty;
            display.Text = string.Empty;
        }

        private void OnBackspaceClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentExpression))
            {
                currentExpression = currentExpression.Remove(currentExpression.Length - 1);
                display.Text = currentExpression;
            }
        }

        private void OnDecimalClicked(object sender, EventArgs e)
        {
            if (!currentExpression.Contains("."))
            {
                currentExpression += ".";
                display.Text += ".";
            }
        }

        private void OnPercentageClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentExpression))
            {
                var inputValue = double.Parse(currentExpression);
                inputValue /= 100;
                currentExpression = inputValue.ToString();
                display.Text = currentExpression;
            }
        }

        private void OnNegateClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentExpression))
            {
                if (currentExpression.StartsWith("-"))
                {
                    currentExpression = currentExpression.Substring(1);
                }
                else
                {
                    currentExpression = "-" + currentExpression;
                }
                display.Text = currentExpression;
            }
        }
    }
}
