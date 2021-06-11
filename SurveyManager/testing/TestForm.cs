using SurveyManager.backend.wrappers;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.Enums;

namespace SurveyManager.testing
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "WILIAM MARSH";
            string phone = "409-252-4306";
            string fax = "DO NOT HAVE INFO";
            string email = "DO NOT HAVE INFO";
            Address a = new Address("DO NOT HAVE INFO", "DO NOT HAVE INFO", "DO NOT HAVE INFO");
            Client c = new Client(name, phone, email, a, fax);

            List<ValidatorError> errors = Validator.Client(c);
            StringBuilder bldr = new StringBuilder("Errors:\n");

            foreach (ValidatorError err in errors)
            {
                bldr.Append($"{err}: {err.ToDescriptionString()}\n");
            }
            txtBox.Text = bldr.ToString();
        }
    }
}
