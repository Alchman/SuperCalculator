public class SessionData
{
    public string LastInputValue { get; set; }

    public SessionData()
    {
    }

    public SessionData(string lastInput)
    {
        LastInputValue = lastInput;
    }
}
