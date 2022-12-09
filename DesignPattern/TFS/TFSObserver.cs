/// <summary>
/// 訂閱者<Interface>
/// </summary>
public interface IObserver_Tfs
{
    /// <summary>
    /// 當有新議題
    /// </summary>
    /// <param name="message"></param>
    void OnNewIssue();
    string OnNew();
}

public class TRSObserver
{

}