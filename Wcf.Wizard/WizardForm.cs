﻿using System;
using System.Windows.Forms;

namespace Wcf.Wizard
{
    public partial class WizardForm : Form
    {
        public WizardForm()
        {
            InitializeComponent();
        }

        public bool Wizard_IsRestService
        {
            get
            {
                return checkBox1.Checked;
            }
        }

        public bool Wizard_IsDuplexService
        {
            get
            {
                return checkBox2.Checked;
            }
        }

        public string Wizard_ServiceContract
        {
            get
            {
                return textBox1.Text;
            }
        }

        public string Wizard_ServiceImplClass
        {
            get
            {
                return textBox2.Text;
            }
        }

        public string Wizard_CallbackContract
        {
            get
            {
                return textBox3.Text;
            }
        }

        public string Wizard_CallbackImplClass
        {
            get
            {
                return textBox4.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var chkBox = sender as CheckBox;
            bool isChecked = chkBox.Checked;

            checkBox2.Enabled = !isChecked;

            if (isChecked)
            {
                textBox3.Enabled = !isChecked;
                textBox4.Enabled = !isChecked;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var chkBox = sender as CheckBox;
            bool isChecked = chkBox.Checked;

            checkBox1.Enabled = !isChecked;
            textBox3.Enabled = isChecked;
            textBox4.Enabled = isChecked;
        }
    }
}
