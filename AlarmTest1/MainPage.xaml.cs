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

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void OnInstantNotifClicked(object sender, EventArgs e)
	{
		Console.WriteLine("Instant Notification Clicked");
		notificationNumber++;
        string title = $"Local Notification #{notificationNumber}";
        string message = $"You have now received {notificationNumber} notifications!";
        notificationManager.SendNotification(title, message);
	}

	private void OnTimedNotifClicked(object sender, EventArgs e)
	{
		Console.WriteLine("Timed Notification Clicked");
		notificationNumber++;
        string title = $"Local Notification #{notificationNumber}";
        string message = $"You have now received {notificationNumber} notifications!";
		Console.WriteLine("TimeEntry.Text: " + TimeEntry.Text);
		notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(Convert.ToInt32(TimeEntry.Text)));
	}
}

