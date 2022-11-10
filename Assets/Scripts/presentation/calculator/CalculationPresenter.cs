using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculationPresenter : MonoBehaviour
{
    private static string ErrorText = "Error";

    [Header("Model")]
    [SerializeField] private Calculation _calculation;

    [Header("View")]
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _resultBtn;

    public void Construct(Calculation calculation)
    {
        _calculation = calculation;
        _calculation.OnResultChanged += UpdateResult;
        _calculation.OnError += OnError;
        UpdateResult();
    }

    private void Start()
    {
        _resultBtn.onClick.AddListener(CalculateResult);
        _inputField.onEndEdit.AddListener(UpdateLastInput);
    }

    private void CalculateResult()
    {
        _calculation.UpdateCalculation(_inputField.text);
    }

    private void UpdateLastInput(string newValue)
    {
        _calculation.SaveInputValue(newValue);
    }

    private void UpdateResult()
    {
        _inputField.text = _calculation.Result;
    }

    private void OnError()
    {
        _inputField.text = ErrorText;
    }

    private void OnDestroy()
    {
        _calculation.OnResultChanged -= UpdateResult;
        _calculation.OnError -= OnError;
    }
}
