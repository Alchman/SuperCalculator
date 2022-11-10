public interface ISession
{
    SessionData CurrentSession { get; set; }
    void SaveSession();
}
