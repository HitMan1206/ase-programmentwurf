using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _3_partygame_backend_domain.Services
{
    public class CredentialService
    {

        String a = "\\";

        private static readonly Regex NAME_REGEX = new Regex("(?:[A-Z]|[a-z]|[0-9]|_){4,16}");
        private static readonly Regex EMAIL_REGEX = new Regex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\e.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\x01 -\x08\x0b\x0c\x0e -\x1f\x21\x23 -\x5b\x5d -\x7f] |\\[\x01 -\x09\x0b\x0c\x0e -\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\e.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\e[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\e.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\\e])");
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
