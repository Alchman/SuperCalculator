using System;

public class Calculation
{
    public Action OnResultChanged;
    public Action OnError;

    public string Result
    {
        get
        {
            return _result;
        }
        private set
        {
            _result = value;
            OnResultChanged?.Invoke();
        }
    }

    private string _result;
    private ICalculator _calculator;
    private ISession _session;

    public Calculation(ICalculator calculator, ISession session)
    {
        _calculator = calculator;
        _session = session;

        LoadLastSession();
    }

    private void LoadLastSession()
    {
        Result = _session.CurrentSession.LastInputValue;
    }

    public void UpdateCalculation(string calculationString)
    {
        float calculationResult;
        bool success = _calculator.TryCalculate(calculationString, out calculationResult);
        if (success)
        {
            Result = calculationResult.ToString();
        }
        else
        {
            OnError?.Invoke();
        }
    }

    public void SaveInputValue(string inputValue)
    {
        _session.CurrentSession.LastInputValue = inputValue;
    }
}
