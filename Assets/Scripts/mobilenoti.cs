using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class mobilenoti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();


        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification();
        var notification1 = new AndroidNotification();
        
        notification.Title = "Hey! Come Back :)";
        notification.Text = "Play a Game...";
        notification.FireTime = System.DateTime.Now.AddHours(12);

        notification1.Title = "Hey! Come Back :)";
        notification1.Text = "Play a Game...";
        notification1.FireTime = System.DateTime.Now.AddHours(18);

        

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id)==NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
