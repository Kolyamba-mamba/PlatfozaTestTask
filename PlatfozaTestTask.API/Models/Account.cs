using System;

namespace PlatfozaTestTask.API.Models
{
    public class Account
    {
        public virtual Guid Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
    }
}