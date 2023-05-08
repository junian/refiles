using System.Drawing;

namespace CorePOS;

public static class NotificationTypes
{
	public static Color Success;

	public static Color Warning;

	public static Color Notification;

	static NotificationTypes()
	{
		Class26.Ggkj0JxzN9YmC();
		Success = Color.FromArgb(65, 168, 95);
		Warning = Color.FromArgb(235, 107, 86);
		Notification = Color.FromArgb(244, 164, 96);
	}
}
