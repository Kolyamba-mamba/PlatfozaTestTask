using System;

namespace PlatfozaTestTask.API.Models
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual int Amount { get; set; }
        public virtual Account Account { get; set; }
    }
}