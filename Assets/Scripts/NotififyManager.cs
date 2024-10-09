using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;

public class NotififyManager : MonoBehaviour
{
    private void Start()
    {
#if UNITY_ANDROID
        CreateAndroidNotificationChannel();
#endif

        // Configura la notificaci�n diaria
        ScheduleDailyNotification();
    }

    // Crea el canal para Android (solo es necesario hacerlo una vez)
    private void CreateAndroidNotificationChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "daily_reminder_channel",
            Name = "Daily Reminder",
            Importance = Importance.Default,
            Description = "Canal para recordatorios diarios del juego",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    private void ScheduleDailyNotification()
    {
        // Tiempo para la notificaci�n (al d�a siguiente a la misma hora)
        System.DateTime notificationTime = System.DateTime.Now.AddDays(1);

#if UNITY_ANDROID
        var androidNotification = new AndroidNotification
        {
            Title = "�Vuelve al espacio!",
            Text = "Sigue destruyendo meteoritos y consigue m�s puntos.",
            SmallIcon = "default", // Aseg�rate de tener un �cono configurado
            LargeIcon = "default",
            FireTime = notificationTime
        };

        AndroidNotificationCenter.SendNotification(androidNotification, "daily_reminder_channel");

#endif
    }
}
