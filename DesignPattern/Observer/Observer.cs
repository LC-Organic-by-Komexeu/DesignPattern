/// <summary>
/// 訂閱者<Interface>
/// </summary>
public interface IObserver
{
    // /// <summary>
    // /// 當訂閱物件發出消息
    // /// </summary>
    // /// <param name="message"></param>
    // void OnSubjectionSendMessage(string message);
    string GetObserverName();
    // /// <summary>
    // /// 公告變更
    // /// </summary>
    // /// <param name="sender"></param>
    // /// <param name="e"></param>
    // void OnAnnouncementChangedEvent(object sender, string e);
    // /// <summary>
    // /// 取得被訂閱者的新訂閱通知
    // /// </summary>
    // /// <param name="sender"></param>
    // /// <param name="e"></param>
    // void OnListChangedEvent(object sender, IObserver e);
    /// <summary>
    /// 接收來自被訂閱者的訊息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void GetMessageFromSubjectionEvent(object sender, string e);
}

/// <summary>
/// 訂閱者
/// </summary>
public class Observer : IObserver
{
    string _observerName { get; }
    Subjection _subjectionTracker;

    public string GetObserverName() => _observerName;

    // /// <summary>
    // /// 公告變更
    // /// </summary>
    // /// <param name="sender"></param>
    // /// <param name="e"></param>
    // public void OnAnnouncementChangedEvent(object sender, string e)
    // {
    //     Console.WriteLine($"【{_observerName}】 get message : {e}");
    // }

    // /// <summary>
    // /// 取得被訂閱者的新訂閱通知
    // /// </summary>
    // /// <param name="sender"></param>
    // /// <param name="e"></param>
    // public void OnListChangedEvent(object sender, IObserver e)
    // {
    //     var subjection = sender as Subjection;
    //     Console.WriteLine($"【{_observerName}】{subjection.SubjectionName} get a new observer : {e.GetObserverName()}");
    // }

    public Observer(string name)
    {
        _observerName = name;
    }
    // public void OnSubjectionSendMessage(string message)
    // {
    //     Console.WriteLine($"【{_observerName}】 get message : {message}");
    // }

    public void GetMessageFromSubjectionEvent(object sender, string message)
    {
        var subjection = sender as Subjection;
        Console.WriteLine($"【{_observerName}】 get message From 【{subjection.SubjectionName}】 : {message}");
    }
}