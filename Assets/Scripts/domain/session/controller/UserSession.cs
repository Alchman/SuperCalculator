public class UserSession : ISession
{
    private ISessionDataLoader _sessionLoader;

    public SessionData CurrentSession { get; set; }

    public UserSession(ISessionDataLoader sessionLoader)
    {
        _sessionLoader = sessionLoader;
        
        LoadSession();
    }

    public void SaveSession()
    {
        _sessionLoader.SaveData(CurrentSession);
    }

    private void LoadSession()
    {
        CurrentSession = _sessionLoader.LoadData();
    }
}
