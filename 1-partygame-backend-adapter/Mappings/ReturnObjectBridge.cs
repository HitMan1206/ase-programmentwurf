using _1_partygame_backend_adapter.APIModels;
using _3_partygame_backend_domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Mappings
{
    public class ReturnObjectBridge
    {
        public ReturnObjectBridge()
        {

        }

        public APIReturnObject mapToAPIReturnObjectFrom(ReturnObject returnObject)
        {
            return new APIReturnObject(returnObject.isSuccess(), returnObject.getMessage());
        }
    }
}
