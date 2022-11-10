using UnityEngine;

public class SimpleBoot : MonoBehaviour
{
    public CalculationPresenter CalculationPresenter;

    private ISession _session;

    // Start is called before the first frame update
    void Start()
    {
        ICalculator calculator = new SumCalculator();

        ISessionDataLoader sessionLoader = new PlayerPrefsSessionLoader();
        _session = new UserSession(sessionLoader);

        Calculation calculationModel = new Calculation(calculator, _session);
        CalculationPresenter.Construct(calculationModel);
    }

    private void OnDestroy()
    {
        _session.SaveSession();
    }
}
