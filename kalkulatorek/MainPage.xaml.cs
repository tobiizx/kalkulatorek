namespace kalkulatorek;

public partial class MainPage : ContentPage
{
    private string currentEntry = "";
    private double firstNumber = 0;
    private string operation = "";
    private bool isNewEntry = true;

    public MainPage()
    {
        InitializeComponent();
    }

    void OnDigitClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        string digit = button.Text;

        if (isNewEntry)
        {
            currentEntry = digit;
            isNewEntry = false;
        }
        else
        {
            currentEntry += digit;
        }

        Display.Text = currentEntry;
    }

    void OnOperatorClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        operation = button.Text;

        if (double.TryParse(currentEntry, out firstNumber))
        {
            isNewEntry = true;
        }
    }

    void OnEqualsClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(currentEntry, out double secondNumber))
            return;

        double result = 0;
        bool validOperation = true;

        switch (operation)
        {
            case "+":
                result = firstNumber + secondNumber; break;
            case "-":
                result = firstNumber - secondNumber; break;
            case "×":
                result = firstNumber * secondNumber; break;
            case "÷":
                if (secondNumber == 0)
                {
                    Display.Text = "nie dziel przez zero xd";
                    validOperation = false;
                }
                else
                {
                    result = firstNumber / secondNumber;
                }
                break;
        }

        if (validOperation)
        {
            Display.Text = result.ToString();
            currentEntry = result.ToString();
        }

        isNewEntry = true;
    }

    void OnClearClicked(object sender, EventArgs e)
    {
        currentEntry = "";
        firstNumber = 0;
        operation = "";
        isNewEntry = true;
        Display.Text = "0";
    }
}
