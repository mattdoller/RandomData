using RandomData.Extensions;
using RandomData.Resources;

namespace RandomData.Data
{
	internal static class Locations
	{
		private static string[] _addressLine2Types;
		private static string[] _cities;
		private static string[] _countries;
		private static string[] _states;
		private static string[] _stateAbbreviations;
		private static string[] _streetNames;
		private static string[] _streetTypes;

		public static string[] AddressLine2Types
		{
			get
			{
				return _addressLine2Types ?? (_addressLine2Types = Strings.AddressLine2Types.SplitResource());
			}
		}

		public static string[] Cities
		{
			get { return _cities ?? (_cities = Strings.Cities.SplitResource()); }
		}

		public static string[] Countries
		{
			get { return _countries ?? (_countries = Strings.Countries.SplitResource()); }
		}

		public static string[] States
		{
			get { return _states ?? (_states = Strings.States.SplitResource()); }
		}

		public static string[] StateAbbreviations
		{
			get { return _stateAbbreviations ?? (_stateAbbreviations = Strings.StateAbbreviations.SplitResource()); }
		}

		public static string[] StreetNames
		{
			get { return _streetNames ?? (_streetNames = Strings.StreetNames.SplitResource()); }
		}

		public static string[] StreetTypes
		{
			get { return _streetTypes ?? (_streetTypes = Strings.StreetTypes.SplitResource()); }
		}
	}
}