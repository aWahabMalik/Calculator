namespace Calculator
{
    public partial class Form1 : Form
    {
        String clickedOperator = "";
        bool operatorCalled = false;
        Double lastEntered = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            
            if (Result.Text == "0")
            {
                operatorCalled = false;
                Result.Text = ((Button)sender).Text;
            }
            else
            {
                if (((Button)sender).Text == ".") 
                {
                    if (!Result.Text.Contains("."))
                    {
                        Result.Text += ((Button)sender).Text;
                    }
                }
                else
                {
                    Result.Text += ((Button)sender).Text;
                }

            }
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            
            if (clickedOperator == "")
            {
                if(((Button)sender).Text != "X")
                    values.Text = Result.Text + " " + ((Button)sender).Text;
                else
                    values.Text = Result.Text + " *";

                clickedOperator = ((Button)sender).Text;
                lastEntered = Double.Parse(Result.Text);
                Result.Text = "";
                operatorCalled = true;
            }
            else
            {
                ComputeResult(this, EventArgs.Empty);
                clickedOperator = ((Button)sender).Text;
                if (((Button)sender).Text != "X")
                    values.Text = Result.Text + " " + ((Button)sender).Text;
                else
                    values.Text = Result.Text + " *";
                operatorCalled = true;
                Result.Text = "";
            }
        }

        
        private void ComputeResult(object sender, EventArgs e)
        {

            //checks if the operator is called
            //checks which operator is called
            //compute result

            if (operatorCalled)
            {
                
                switch (clickedOperator)
                {
                    case "+":
                        values.Text = lastEntered + " " + clickedOperator + " " + Result.Text;
                        lastEntered += Double.Parse(Result.Text);
                        break;
                    case "-":
                        values.Text = lastEntered + " " + clickedOperator + " " + Result.Text;
                        lastEntered -= Double.Parse(Result.Text);
                        break;
                    case "X":
                        values.Text = lastEntered + " * " + Result.Text;
                        lastEntered *= Double.Parse(Result.Text);
                        break;
                    case "÷":
                        values.Text = lastEntered + " " + clickedOperator + " " + Result.Text;
                        lastEntered /= Double.Parse(Result.Text);
                        break;
                    default:
                        break;

                }
                
                Result.Text = lastEntered.ToString();
                clickedOperator = "";
                operatorCalled = false;
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            //erase all data
            Result.Text = "0";
            clickedOperator = "";
            operatorCalled = false;
            lastEntered = 0;
            values.Text = "";
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            //just clea the textbox
            Result.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit the application when the exit button is clicked
            Application.Exit();
        }

    }
}