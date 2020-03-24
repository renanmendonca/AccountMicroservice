using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Application.Common
{
    public class EmailDto
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}
