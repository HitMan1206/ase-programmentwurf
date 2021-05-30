using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _3_partygame_backend_domain.Services
{
    public class CredentialService
    {
        private static readonly Regex NAME_REGEX = new Regex("(?:[A-Z]|[a-z]|[0-9]|_){4,16}");
        private static readonly Regex EMAIL_REGEX = new Regex("(?s).*");
        private static readonly Regex PASSWORD_REGEX = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}#=+]).{8,}$");

        public CredentialService() { }

        public bool isNameValid(String username)
        {
            return NAME_REGEX.IsMatch(username);
        }

        public bool isEmailValid(String email)
        {
            return EMAIL_REGEX.IsMatch(email);
        }

        public bool isPasswordValid(String password)
        {
            return PASSWORD_REGEX.IsMatch(password);
        }

        public bool credentialsValid(String name, String email, String password)
        {
            return isNameValid(name) && isEmailValid(email) && isPasswordValid(password);
        }

        public bool credentialsValidOrNull(String name, String email, String password)
        {
            return (name == null || isNameValid(name)) && (email == null || isEmailValid(email)) && (password == null || isPasswordValid(password));
        }


    }
}
