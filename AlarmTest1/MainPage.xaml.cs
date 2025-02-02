namespace AlarmTest1;

public partial class MainPage : ContentPage
{
	int count = 0;

	INotificationManagerService notificationManager;
    int notificationNumber = 0;


	public MainPage(INotificationManagerService manager)
	{
		InitializeComponent();
		notificationManager = manager;
        notificationManager.NotificationReceived += (sender, eventArgs) =>
        {
            var eventData = (NotificationEventArgs)eventArgs;
        };
	}

	private void OnInstantNotifClicked(object sender, EventArgs e)
	{
		notificationNumber++;
        string title = $"Local Notification #{notificationNumber}";
        string message = $"You have now received {notificationNumber} notifications!";
        notificationManager.SendNotification(title, message);
	}

	private void OnTimedNotifClicked(object sender, EventArgs e)
	{
		notificationNumber++;
        string title = $"Local Alarm #{notificationNumber}";
        //string message = $"You have now received {notificationNumber} notifications!";
		string message = $"Your alarm is ringing!";
		Console.WriteLine("TimeEntry.Text: " + TimeEntry.Text);
		notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(Convert.ToInt32(TimeEntry.Text)));
	}
}

