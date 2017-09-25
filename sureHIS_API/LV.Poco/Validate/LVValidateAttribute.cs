using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LV.Poco.Validate
{
    public class LVRequiredAttribute : RequiredAttribute
    {
        public LVRequiredAttribute()
        {
            ErrorMessage = "MsgRequired";
        }

    }

    public class LVMaxLengthAttribute : MaxLengthAttribute
    {
        public LVMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessage = "MsgMaxLength";
        }

    }

    public class LVRegularExpressionAttribute : RegularExpressionAttribute
    {
        public LVRegularExpressionAttribute(string pattern):base(pattern)
        {
            ErrorMessage = "MsgRegularExpression";
        }

    }
}
