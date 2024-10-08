using System;
using Unity.Notifications.Android; 
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    void Start()
    {
        InitializeNotificationChannel();

        ScheduleDailyNotification();

        ScheduleHighScoreNotification();
        ScheduleWeeklyChallengeNotification();
    }

    void InitializeNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = "game_notifications",
            Name = "Game Notifications",
            Importance = Importance.High,
            Description = "Channel for game notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    void ScheduleDailyNotification()
    {
        var notification = new AndroidNotification
        {
            Title = "¡Es hora de jugar!",
            Text = "Vuelve y destruye más meteoritos.",
            FireTime = DateTime.Now.AddHours(24), 
            RepeatInterval = new TimeSpan(24, 0, 0) 
        };

        AndroidNotificationCenter.SendNotification(notification, "game_notifications");
    }

    public void ScheduleHighScoreNotification()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) < PlayerPrefs.GetInt("CurrentScore", 0))
        {
            var notification = new AndroidNotification
            {
                Title = "¡Nuevo récord!",
                Text = "Superaste tu récord anterior. ¿Listo para más desafíos?",
                FireTime = DateTime.Now.AddMinutes(1) 
            };
            AndroidNotificationCenter.SendNotification(notification, "game_notifications");
        }
    }

    void ScheduleWeeklyChallengeNotification()
    {
        var notification = new AndroidNotification
        {
            Title = "Desafío semanal",
            Text = "Sobrevive más tiempo y destruye más meteoritos esta semana.",
            FireTime = DateTime.Now.AddDays(7),
            RepeatInterval = new TimeSpan(7, 0, 0, 0) 
        };

        AndroidNotificationCenter.SendNotification(notification, "game_notifications");
    }

    public void ScheduleSpecialEventNotification()
    {
        var notification = new AndroidNotification
        {
            Title = "¡Evento especial activo!",
            Text = "Puntos dobles por tiempo limitado. ¡Vuelve al juego!",
            FireTime = DateTime.Now.AddMinutes(10) 
        };

        AndroidNotificationCenter.SendNotification(notification, "game_notifications");
    }

    public void ScheduleDailyRewardNotification()
    {
        var notification = new AndroidNotification
        {
            Title = "Recompensa diaria lista",
            Text = "¡Reclama tu recompensa diaria y sigue jugando!",
            FireTime = DateTime.Now.AddHours(24), 
            RepeatInterval = new TimeSpan(24, 0, 0) 
        };

        AndroidNotificationCenter.SendNotification(notification, "game_notifications");
    }

    public void ScheduleInactivityNotification()
    {
        var notification = new AndroidNotification
        {
            Title = "Hace tiempo que no juegas...",
            Text = "Vuelve al espacio y sigue destruyendo meteoritos.",
            FireTime = DateTime.Now.AddDays(3), 
        };

        AndroidNotificationCenter.SendNotification(notification, "game_notifications");
    }

    public void ScheduleMilestoneNotification()
    {
        var notification = new AndroidNotification
        {
            Title = "¡Nuevo hito alcanzado!",
            Text = "Destruiste 100 meteoritos. ¿Puedes ir por más?",
            FireTime = DateTime.Now.AddMinutes(5) 
        };

        AndroidNotificationCenter.SendNotification(notification, "game_notifications");
    }
    public void CancelAllNotifications()
    {
        AndroidNotificationCenter.CancelAllNotifications();
    }
}


