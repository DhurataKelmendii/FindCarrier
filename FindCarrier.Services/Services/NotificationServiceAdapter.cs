using FindCarrier.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Services.Services
{
    // Notification Service Adapter
    public class NotificationServiceAdapter : INotificationService
    {
        public void NotifyApplicationStatus(string studentName, string universityName, string applicationStatus)
        {
            Console.WriteLine($"Notification: Application status for {studentName} at {universityName}: {applicationStatus}");
        }
    }

}
