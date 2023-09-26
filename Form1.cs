using System;
using System.Windows.Forms;

public class CalculatorForm : Form
{
    private TextBox display;
    private Button[] btn;
    private char operation = '\0';
    private double firstNumber, secondNumber, result;

    public CalculatorForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        display = new TextBox
        {
            Left = 10,
            Top = 10,
            Width = 260
        };
        Controls.Add(display);

        btn = new Button[16];
        string[] btnText = { "7", "8", "9", "+", "4", "5", "6", "-", "1", "2", "3", "*", "C", "0", "=", "/" };

        int x = 10, y = 50;
        for (int i = 0; i < 16; i++)
        {
            btn[i] = new Button
            {
                Text = btnText[i],
                Left = x,
                Top = y,
                Width = 60,
                Height = 40
            };
            Controls.Add(btn[i]);

            btn[i].Click += Btn_Click;

            x += 70;
            if ((i + 1) % 4 == 0)
            {
                x = 10;
                y += 50;
            }
        }
    }

    private void Btn_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (char.IsDigit(button.Text[0]))
        {
            display.Text += button.Text;
        }
        else
        {
            switch (button.Text)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    firstNumber = Convert.ToDouble(display.Text);
                    operation = button.Text[0];
                    display.Clear();
                    break;
                case "=":
                    secondNumber = Convert.ToDouble(display.Text);
                    switch (operation)
                    {
                        case '+':
                            result = firstNumber + secondNumber;
                            break;
                        case '-':
                            result = firstNumber - secondNumber;
                            break;
                        case '*':
                            result = firstNumber * secondNumber;
                            break;
                        case '/':
                            if (secondNumber != 0)
                                result = firstNumber / secondNumber;
                            else
                                display.Text = "Error";
                            break;
                    }
                    display.Text = result.ToString();
                    operation = '\0';
                    break;
                case "C":
                    display.Clear();
                    firstNumber = 0;
                    secondNumber = 0;
                    operation = '\0';
                    break;
            }
        }
    }

   
}
