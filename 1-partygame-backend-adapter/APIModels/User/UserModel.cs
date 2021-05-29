using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.User
{
    public class UserModel
    {
        private long id;
        private string email;
        private string username;
        private string password;
        private Userstatus actualStatus;

        public UserModel(long id, string email, string username, string password, Userstatus actualStatus)
        {
            this.id = id;
            this.email = email;
            this.username = username;
            this.password = password;
            this.actualStatus = actualStatus;
        }

        public long Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Userstatus ActualStatus { get; set; }
    }
}
