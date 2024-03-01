using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONExample.model
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public Company? Company { get; set; }

        public override string ToString()
        {
            return
                $"User:\nId: {Id}\nName: {Name}\nUsername: {Username}\nEmail: {Email}\nAddress: {Address}\nPhone: {Phone}\nWebsite: {Website}\nCompany: {Company}";
        }
    }
}