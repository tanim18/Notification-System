using Dapper;
using NotificationSystemMVC.Common;
using NotificationSystemMVC.IServices;
using NotificationSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystemMVC.Services
{
    public class NotificationRepo : INotification
    {
        List<Notification> _oNotifications = new List<Notification>();
        public List<Notification> GetNotifications(int nToUserId, bool bIsGetOnlyUnread)
        {
            _oNotifications = new List<Notification>();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                var oNotis = con.Query<Notification>("select * from View_Notification where ToUserId=" + nToUserId).ToList();
                if (oNotis != null && oNotis.Count > 0)
                {
                    _oNotifications = oNotis;
                }
                return _oNotifications;
            }
        }
    }
}
