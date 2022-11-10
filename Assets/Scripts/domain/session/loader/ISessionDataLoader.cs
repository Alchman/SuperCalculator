public interface ISessionDataLoader
{
    void SaveData(SessionData data);
    SessionData LoadData();
}
