﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class GetCustomerDetailsRequestBody
    {
        public string bvn { get; set; }
        public string channel_code { get; set; }
    }
}
