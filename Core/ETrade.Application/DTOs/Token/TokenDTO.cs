﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.DTOs.Token
{
	public class TokenDTO
	{
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
