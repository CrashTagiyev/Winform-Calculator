using System.Text;

namespace Winform_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Num_Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Calculator_Label.Text += button.Text;
        }
        private void Op_Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Text == "+" || button.Text == "-" || button.Text == "x" || button.Text == "/")
            {
                Summary_Button.Enabled = false;
                Minus_Button.Enabled = false;
                Multiply_Button.Enabled = false;
                Divide_Button.Enabled = false;
            }
            StrOpStr.OP=button.Text;
            Plus_Minus_Button.Enabled = true;
            Calculator_Label.Text += button.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Calculator_Label.Text != "")
                {

                    Summary_Button.Enabled = true;
                    Minus_Button.Enabled = true;
                    Multiply_Button.Enabled = true;
                    Divide_Button.Enabled = true;
                    decimal num1 = Convert.ToDecimal(StrOpStr.Num1String(Calculator_Label.Text));
                    char op = StrOpStr.findOP(Calculator_Label.Text);
                    decimal num2 = Convert.ToDecimal(StrOpStr.Num2String(op, Calculator_Label.Text));

                    switch (op)
                    {
                        case '+':
                            Calculator_Label.Text = Convert.ToString(num1 + num2);
                            break;
                        case '-':
                            Calculator_Label.Text = Convert.ToString(num1 - num2);
                            break;
                        case 'x':
                            Calculator_Label.Text = Convert.ToString(num1 * num2);
                            break;
                        case '/':
                            if (num2 == 0) throw new DivideByZeroException();
                            Calculator_Label.Text = Convert.ToString(num1 / num2);
                            break;
                    }
                    StrOpStr.PlusCheck = false;
                    StrOpStr.PlusCheck2 = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Calculator_Label.Text.Length > 0)
            {
                string temp;
                temp = Calculator_Label.Text.Remove(Calculator_Label.Text.Length - 1);
                Calculator_Label.Text = temp;
            }
            if (StrOpStr.findOP(Calculator_Label.Text) == ' ')
            {
                Summary_Button.Enabled = true;
                Minus_Button.Enabled = true;
                Multiply_Button.Enabled = true;
                Divide_Button.Enabled = true;
            }
        }

        private void Plus_Minus_Button_Click(object sender, EventArgs e)
        {

            if (Summary_Button.Enabled == true)
            {
                StringBuilder sb = new StringBuilder(Calculator_Label.Text);
                if (StrOpStr.PlusCheck == false)
                {

                    sb.Insert(0, '-');
                    StrOpStr.PlusCheck = true;
                }
                else
                {
                    sb.Remove(0,1);
                    StrOpStr.PlusCheck = false;

                }
                
                Calculator_Label.Text = sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder(Calculator_Label.Text);
                if (StrOpStr.PlusCheck == false)
                {

                    sb.Insert(Calculator_Label.Text.IndexOf(StrOpStr.OP)+1, '-');
                    StrOpStr.PlusCheck = true;
                }
                else
                {
                    sb.Remove(Calculator_Label.Text.IndexOf(StrOpStr.OP) + 1, 1);
                    StrOpStr.PlusCheck = false;

                }

                Calculator_Label.Text = sb.ToString();
            }
        }
    }
}