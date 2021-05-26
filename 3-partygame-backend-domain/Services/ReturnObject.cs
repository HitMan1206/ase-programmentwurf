using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Services
{
    public class ReturnObject
    {
        private readonly bool success;
        private readonly String message;

        public ReturnObject(bool success, String message)
        {
            this.success = success;
            this.message = message;
        }

        public String getMessage()
        {
            return message;
        }

        public bool isSuccess()
        {
            return success;
        }
    }
}
