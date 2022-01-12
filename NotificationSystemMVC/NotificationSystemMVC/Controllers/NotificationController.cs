using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationSystemMVC.IServices;
using NotificationSystemMVC.Models;

namespace NotificationSystemMVC.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotification _notification = null;
        List<Notification> _oNotificationList = new List<Notification>();
        public NotificationController(INotification notification)
        {
            _notification = notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetNotifications(bool bIsGetOnlyUnread = false)
        {
            int nToUserId = 3;
            _oNotificationList = new List<Notification>();
            _oNotificationList = _notification.GetNotifications(nToUserId, bIsGetOnlyUnread);
            return Json(_oNotificationList);
        }
    }
}
