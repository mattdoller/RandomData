using System;
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
			return String.Format("{0}.{1}.{2}.{3}",
	      NewRandom().Next(255),
	      NewRandom().Next(255),
	      NewRandom().Next(255),
	      NewRandom().Next(255)
			);
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
	}

	public enum UrlType
	{
		DomainOnly,
		DomainAndPath,
		DomainPathAndPage
	}
}