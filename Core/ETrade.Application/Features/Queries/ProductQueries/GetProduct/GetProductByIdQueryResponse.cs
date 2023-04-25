﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Queries.ProductQueries.GetProduct
{
	public class GetProductByIdQueryResponse
	{
		public string Name { get; set; }
		public int Stock { get; set; }
		public float Price { get; set; }
        public DateTime CreatedDate { get; set; }
		public DateTime UpdateddDate { get; set; }
	}
}
