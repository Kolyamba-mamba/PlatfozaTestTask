using System;

namespace PlatfozaTestTask.API.Models.DTO
{
    public class CreateUserDTO
    {
        public string Name { get; set;}
        public DateTime BirthDate { get; set; }
        public int Amount { get; set; }
        public Guid Account_Id { get; set; } 
    }
}