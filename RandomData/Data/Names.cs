using System.Linq;
using RandomData.Extensions;
using RandomData.Resources;

namespace RandomData.Data
{
	internal static class Names
	{
		private static string[] _firstNames;
		private static string[] _firstNamesMale;
		private static string[] _firstNamesFemale;
		private static string[] _lastNames;
		private static string[] _incorporationTypes;
		private static string[] _companyTypes;

		public static string[] FirstNames
		{
			get 
			{ 
				return _firstNames ?? (_firstNames = FirstNamesMale.Concat(FirstNamesFemale).ToArray()); 
			}
		}

		public static string[] FirstNamesMale
		{
			get 
			{ 
				return _firstNamesMale ?? (_firstNamesMale = Strings.FirstNamesMale.SplitResource()); 
			}
		}

		public static string[] FirstNamesFemale
		{
			get 
			{ 
				return _firstNamesFemale ?? (_firstNamesFemale = Strings.FirstNamesFemale.SplitResource()); 
			}
		}

		public static string[] LastNames
		{
			get
			{
				return _lastNames ?? (_lastNames = Strings.LastNames.SplitResource());
			}
		}

		public static string[] IncorporationTypes
		{
			get
			{
				return _incorporationTypes ?? (_incorporationTypes = Strings.IncorporationTypes.SplitResource());
			}
		}

		public static string[] CompanyTypes
		{
			get
			{
				return _companyTypes ?? (_companyTypes = Strings.CompanyTypes.SplitResource());
			}
		}
	}
}
