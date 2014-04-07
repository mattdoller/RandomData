using System;
using System.Net;
using System.Text;

namespace RandomData
{
	public class RandomNet : RandomCategoryBase
	{
		public RandomNet()
			: base()
		{
		}

		public RandomNet(int seed)
			: base(seed)
		{
		}

		public string IPv4()
		{
			return String.Format("{0}.{1}.{2}.{3}",
	      NewRandom().Next(255),
	      NewRandom().Next(255),
	      NewRandom().Next(255),
	      NewRandom().Next(255)
			);
		}

		public string Url()
		{
			throw new NotImplementedException();
		}
	}
}

