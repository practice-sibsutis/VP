using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample
{
    public class TelegramNotifyer : INotifyer
    {
        private string phoneNumber;
        public TelegramNotifyer(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{message}");
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}
