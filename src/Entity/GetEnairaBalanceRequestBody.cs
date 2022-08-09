﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class GetEnairaBalanceRequestBody
    {
        public string user_email { get; set; }
        public string user_type { get; set; } = "USER";
        public string channel_code { get; set; } = "APISNG";
        public string user_token { get; set; }
    }
}
