using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class Blab : IEntity
    {
        public Blab()
        {
            this.User = new User();
            this.Message = "";
            this.DTTM = DateTime.Now;
            this.Id = Guid.NewGuid();
        }
        public Blab(string Message)
        {
            this.User = new User();
            this.Message = Message;
            this.DTTM = DateTime.Now;
            this.Id = Guid.NewGuid();
        }
        public Blab(User user)
        {
            this.User = user;
            this.Message = "";
            this.DTTM = DateTime.Now;
            this.Id = Guid.NewGuid();
        }
        public Blab(string Message, User user)
        {
            this.User = user;
            this.Message = Message;
            this.DTTM = DateTime.Now;
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime DTTM { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
        public bool IsValid()
        {
            // Add code to validate class data.
            return true;
        }
    }
}