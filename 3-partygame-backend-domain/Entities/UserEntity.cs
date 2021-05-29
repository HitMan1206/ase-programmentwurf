using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities
{
    public class UserEntity
    {
        private readonly int id;
        private String email;
        private String name;
        private string password;
        private Status actualStatus;
        private bool hasHistory = false;


        public UserEntity(int id, String email, String name, string password)
        {
            if (id < 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            CredentialService credentialService = new CredentialService();
            if (!credentialService.isNameValid(name)) throw new ArgumentException("Name is invalid.");
            this.name = name;
            if (!credentialService.isEmailValid(email)) throw new ArgumentException("Email is invalid.");
            this.email = email;
            if (!credentialService.isPasswordValid(password)) throw new ArgumentException("Password is invalid.");
            this.password = password;
        }

        public int getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public String getPassword()
        {
            return password;
        }

        public String getEmail()
        {
            return email;
        }

        public Status ActualStatus
        {
            get { return actualStatus; }
            set { actualStatus = value; }
        }

        public bool HasHistory
        {
            get { return hasHistory; }
            set { hasHistory = value;}
        }

        public bool modify(String name, String email)
        {
            CredentialService credentialService = new CredentialService();
            if (credentialService.credentialsValidOrNull(name, email, null))
            {
                this.name = name;
                this.email = email;
                return true;
            }
            return false;
        }

        public UserEntity copy()
        {
            return new UserEntity(id, name, email, password);
        }

    }
}
