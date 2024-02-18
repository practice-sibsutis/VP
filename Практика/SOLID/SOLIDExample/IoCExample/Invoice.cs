using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample
{
    public class Invoice
    {
        private int _totalAmount;
        private DateTime _date;
        private INotifyer _notifyer;
        private ILogger _logger;

        public Invoice(INotifyer notifyer, ILogger logger)
        {
            _notifyer = notifyer;
            _logger = logger;
        }

       /* public ILogger Logger
        {
            get => _logger;
            set
            {
                _logger = value;
            }
        }*/

        public int TotalAmount
        {
            get => _totalAmount;
            set
            {
                if (value > 0)
                {
                    _totalAmount = value;
                    _logger.Info($"TotalAmount = {_totalAmount}");
                }
                else
                {
                    _logger.Error("TotalAmount <= 0");
                }
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                
                if (_date.Date.CompareTo(DateTime.Now) > 0)
                {
                    _logger.Warning($"New date = {_date}");
                }
                else
                {
                    _logger.Info($"New date = {_date}");
                }
            }
        }

        /*public ILogger Logger
        {
            set
            {
                _logger = value;
            }
            get => _logger;
        }*/

        public void AddInvoice()
        {
            Console.WriteLine($"Add invoice {TotalAmount} {Date}");
            _logger.Info($"Add invoice {TotalAmount} {Date}");
            _notifyer.Send($"Add invoice {TotalAmount} {Date}");
        }

        public void DeleteInvoice()
        {
            Console.WriteLine($"Delete invoice {TotalAmount} {Date}");
            _logger.Info($"Delete invoice {TotalAmount} {Date}");
            _notifyer.Send($"Delete invoice {TotalAmount} {Date}");
        }
    }
}
