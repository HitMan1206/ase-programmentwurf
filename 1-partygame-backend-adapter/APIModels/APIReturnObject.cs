using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels
{
    public class APIReturnObject
    {
        private bool success;
        private string message;

        public APIReturnObject(bool success, string message)
        {
            this.message = message;
            this.success = success;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
