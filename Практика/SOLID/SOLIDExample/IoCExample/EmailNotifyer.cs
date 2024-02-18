using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample
{
    public class EmailNotifyer : INotifyer
    {
        private readonly string _email;
        public EmailNotifyer(string email)
        {
            _email = email;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{message} send on email: {_email}");
        }
    }
}
