using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TetsesUi.ViewModels
{
    public partial class Utente : Form
    {
        public Utente()
        {
            InitializeComponent();
        }

        private void UtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Reject the input
            }
        }

        private void UtNum_Enter(object sender, EventArgs e)
        {

        }

        private void UtNum_Leave(object sender, EventArgs e)
        {

        }

        private void LogUten_Click(object sender, EventArgs e)
        {
            // Example: Verify if the TextBox is not empty
            if (string.IsNullOrWhiteSpace(UtNum.Text) || string.IsNullOrWhiteSpace(PassTxt.Text))
            {
                MessageBox.Show("Prencha todos os dados", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution if the validation fails
            }

            // Example: Verify if the input is numeric
            if (!int.TryParse(UtNum.Text, out int result))
            {
                MessageBox.Show("Preencha com o seu número", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution if the validation fails
            }

            // If validation passes, open the new form
            UtenteView newForm = new UtenteView();
           newForm.Show(); // Open the new form
            this.Hide();
        }
    }
}
