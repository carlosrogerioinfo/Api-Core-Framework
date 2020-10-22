using FluentValidator;
using InVivo.Domain.Enums;
using InVivo.Shared.Entities;
using InVivo.Shared.Library;
using System;
using System.Text;

namespace InVivo.Domain.Entities
{
    public class User: Entity
    {

        //Constructors
        protected User() { } //EntityFramework needs empty constructor, for prevents corruptive, we sign constructor protected

        public User(string username, string password, string confirmPassword, string email)
        {
            Username = username;
            Password = SharedStringLibrary.EncryptPassword(password);
            Email = email;
            Active = false;
            Verified = false;
            LastLoginDate = DateTime.Now;
            Role = EUserRoleType.User;
            VerificationCode = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 5).ToUpper();
            ActivationCode = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 5).ToUpper();
            AuthorizationCode = string.Empty;
            LastAuthorizationCodeRequest = DateTime.Now.AddMinutes(5);

            new ValidationContract<User>(this)
                .AreEquals(x => x.Password, SharedStringLibrary.EncryptPassword(confirmPassword), "As senhas não coincidem");
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }

        public bool Verified { get; private set; }
        public DateTime LastLoginDate { get; private set; }
        public EUserRoleType Role { get; private set; }
        public string VerificationCode { get; private set; }
        public string ActivationCode { get; private set; }
        public string AuthorizationCode { get; private set; }
        public DateTime LastAuthorizationCodeRequest { get; private set; }


        public bool Authenticate(string email, string password)
        {
            if (Email.Equals(email) && Password.Equals(SharedStringLibrary.EncryptPassword(password)))
                return true;

            AddNotification("User", "Usuário ou senha inválidos");
            return false;
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void MakeToAdmin()
        {
            Role = EUserRoleType.Admin;
        }

        public string GenerateAutorizationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
        }

    }
}
