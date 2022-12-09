/// <summary>
/// 被訂閱物件<Interface>
/// </summary>
public interface ISubjection
{
    /// <summary>
    /// 新增訂閱者
    /// </summary>
    /// <param name="observer"></param>
    void RegisterObserver(IObserver observer);
    /// <summary>
    /// 移除訂閱者
    /// </summary>
    /// <param name="observer"></param>
    void UnRegisterObserver(IObserver observer);
    // /// <summary>
    // /// 發送訊息給訂閱者
    // /// </summary>
    // /// <param name="message"></param>
    // void GlobalMessage(string message);
}

/// <summary>
/// 被訂閱物件實作
/// </summary>
public class Subjection : ISubjection
{
    // public delegate void AnnouncementChangedHandler(string message);
    // public AnnouncementChangedHandler OnAnnouncementChanged;

    /// <summary>
    /// 訂閱變更
    /// </summary>
    public event EventHandler<string> OnListChanged;
    /// <summary>
    /// 公告變更
    /// </summary>
    public event EventHandler<string> OnAnnouncementChanged;
    public string SubjectionName { get; }
    string _announcement { get; set; }
    /// <summary>
    /// 公告
    /// </summary>
    /// <value></value>
    public string Announcement
    {
        get => _announcement;
        set
        {
            var oldValue = _announcement;
            // OnAnnouncementChanged.Invoke(value);
            if (oldValue != value)
            {
                _announcement = value;
                if (OnAnnouncementChanged != null)
                    OnAnnouncementChanged(this, value);
            }
        }
    }

    public Subjection(string name)
    {
        SubjectionName = name;
        // OnAnnouncementChanged = AnnouncementChanged;
    }
    List<IObserver> _observerList { get; set; } = new List<IObserver>();

    /// <summary>
    /// 新增訂閱
    /// </summary>
    /// <param name="observer"></param>
    public void RegisterObserver(IObserver observer)
    {
        //check if this observer in the list
        if (!_observerList.Contains(observer))
        {
            _observerList.Add(observer);
            if (OnListChanged != null)
                OnListChanged(this, $"新訂閱者 【{observer.GetObserverName()}】");
            //全事件訂閱
            this.OnListChanged += observer.GetMessageFromSubjectionEvent;
            this.OnAnnouncementChanged += observer.GetMessageFromSubjectionEvent;
            //個別訊息
            observer.GetMessageFromSubjectionEvent(this, "已訂閱");
        }
    }

    /// <summary>
    /// 取消訂閱
    /// </summary>
    /// <param name="observer"></param>
    public void UnRegisterObserver(IObserver observer)
    {
        if (_observerList.Contains(observer))
        {
            //全事件取消訂閱
            this.OnListChanged -= observer.GetMessageFromSubjectionEvent;
            this.OnAnnouncementChanged -= observer.GetMessageFromSubjectionEvent;
            _observerList.Remove(observer);
            //個別訊息
            observer.GetMessageFromSubjectionEvent(this, "已取消訂閱");
        }
    }
    // public void GlobalMessage(string GlobalMessage) => _observerList.ForEach(x => x.OnSubjectionSendMessage(GlobalMessage));
    // void AnnouncementChanged(string message) => Console.WriteLine($"【{SubjectionName}】公告訊息變更 : 【{message}】");
}