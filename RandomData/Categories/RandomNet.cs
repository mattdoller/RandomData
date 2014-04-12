using System;
using System.Linq;
using System.Text;
using RandomData.Extensions;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomNet : RandomCategoryBase
	{
		public RandomNet(IRandomGenerator random) 
			: base(random)
		{
		}

		public string IPv4()
		{
			var ipv4 = new StringBuilder(NewRandom().Next(255).ToString());
			Repeat(() => ipv4.AppendFormat(".{0}", NewRandom().Next(255)), 3);
			return ipv4.ToString();
		}

		public string IPv6()
		{
			var ipv6 = new StringBuilder(HexadecimalString(4));
			Repeat(() => ipv6.AppendFormat(":{0}", HexadecimalString(4)), 7);
			return ipv6.ToString();
		}

		public string Url(UrlType urlType = UrlType.DomainOnly)
		{
			switch (urlType)
			{
				case (UrlType.DomainOnly) :
					return UrlForDomainOnly();
				case (UrlType.DomainAndPath) :
					return UrlForDomainAndPath();
				case (UrlType.DomainPathAndPage) :
					return UrlForDomainPathAndPage();
				default :
					throw new ArgumentException();
			}
		}

		private string UrlForDomainOnly()
		{
			var tlds = new[] {"com", "net", "org", "edu"};
			return String.Format("http://www.example.{0}", NewRandom().PickFrom(tlds));
		}

		private string UrlForDomainAndPath()
		{
			return String.Format("{0}/{1}", 
				UrlForDomainOnly(),
				AlphaString(6).ToLower()
			);
		}

		private string UrlForDomainPathAndPage()
		{
			return String.Format("{0}/{1}.html", 
				UrlForDomainAndPath(),
				AlphaString(6).ToLower()
			);
		}

		private void Repeat(Action action, int times)
		{
			for (var i = 0; i < times; i++)
			{
				action();
			}
		}
	}

	public enum UrlType
	{
		DomainOnly,
		DomainAndPath,
		DomainPathAndPage
	}
}