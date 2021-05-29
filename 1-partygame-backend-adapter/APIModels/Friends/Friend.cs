using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Friends
{
    public class Friend
    {

        private User.UserModel other;
        private User.UserModel me;

        public Friend(User.UserModel other, User.UserModel me)
        {
            this.other = other;
            this.me = me;
        }

        public User.UserModel Other { get; set; }

        public User.UserModel Me { get; set; }
    }
}
