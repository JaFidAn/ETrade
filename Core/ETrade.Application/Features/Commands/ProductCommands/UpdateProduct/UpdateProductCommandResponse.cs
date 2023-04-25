﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Commands.ProductCommands.UpdateProduct
{
	public class UpdateProductCommandResponse
	{
        public string Id { get; set; }
        public string Name { get; set; }
		public int Stock { get; set; }
		public float Price { get; set; }
	}
}
