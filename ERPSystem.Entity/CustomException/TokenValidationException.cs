using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.CustomException
{
    public class TokenValidationException:Exception
    {
        public TokenValidationException(List<string> messageList)
        {
            this.Data["TokenValidationMessage"] = messageList;
        }
    }
}
