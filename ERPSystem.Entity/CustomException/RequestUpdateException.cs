using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.CustomException
{
	public class RequestUpdateException:Exception
	{
        public RequestUpdateException(List<string> message)
        {
            this.Data["RequestUpdateErrors"] = message;
        }
    }
}
