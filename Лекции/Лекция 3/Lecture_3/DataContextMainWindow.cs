namespace Lecture_3;

public class DataContextMainWindow
{
    private string _text = "Hello World";

    public string Text
    {
        get
        {
            return _text;
        }

        set
        {
            _text = value;
        }
    }

    public void ExecuteCommand()
    {
        Text = "Hello Avalonia";
    }
}