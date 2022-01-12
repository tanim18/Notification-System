using NotificationSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystemMVC.IServices
{
    public interface INotification
    {
        List<Notification> GetNotifications(int nToUserId, bool bIsGetOnlyUnread);
    }
}
