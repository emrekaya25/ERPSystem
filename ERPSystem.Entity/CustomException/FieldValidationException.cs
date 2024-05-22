﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.CustomException
{
    public class FieldValidationException:Exception
    {
        public FieldValidationException(List<string> messageList)
        {
            this.Data["FieldValidationMessage"] = messageList;
        }
    }
}
