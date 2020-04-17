using System;
using System.Net.Mail;
using BlabberApp.Domain.Interfaces;
namespace BlabberApp.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id {get; set;}
        public System.DateTime RegisterDTTM { get; set; }
        public System.DateTime LastLoginDTTM { get; set; }
        public string Email { get; private set; }

        public User()
        {
            this.Id = Guid.NewGuid();
        }

        public User(string email)
        {
            this.Id = Guid.NewGuid();
            this.ChangeEmail(email); 
        }

        public void ChangeEmail(string email)
        {
            this.Email = email;
        }
        public bool IsValid()
        {
            if (this.Email == null){
                return false;
            } else{
                return true;
            }
            
        }
    }
}