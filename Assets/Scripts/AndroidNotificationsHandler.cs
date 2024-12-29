using System;
using Unity.Notifications.Android;
using UnityEngine;

public class AndroidNotificationsHandler : MonoBehaviour
{
    private const string ChannelId = "notification_channel";

    //private DateTime datetimeExample = DateTime.Now.AddHours(1);
    public void ScheduleNotification(DateTime datetime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel{
            Id = ChannelId,
            Name = "Notification Channel",
            Description = "Some random description",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification
        {
            Title = "Hey you!",
            Text = "Your energy is full",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = datetime
        };

        AndroidNotificationCenter.SendNotification(notification, ChannelId);

    }
}
