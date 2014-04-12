using System;
using RandomData.Categories;
using RandomData.Generators;

namespace RandomData
{
	public static class Randomized
	{
		private static readonly Lazy<RandomBoolean> _booleans =
			new Lazy<RandomBoolean>(() => new RandomBoolean(NewRandom()));

		private static readonly Lazy<RandomContact> _contacts =
			new Lazy<RandomContact>(() => new RandomContact(NewRandom()));

		private static readonly Lazy<RandomDate> _dates =
			new Lazy<RandomDate>(() => new RandomDate(NewRandom()));

		private static readonly Lazy<RandomLocation> _locations =
			new Lazy<RandomLocation>(() => new RandomLocation(NewRandom()));

		private static readonly Lazy<RandomName> _names =
			new Lazy<RandomName>(() => new RandomName(NewRandom()));

		private static readonly Lazy<RandomNet> _net =
			new Lazy<RandomNet>(() => new RandomNet(NewRandom()));

		private static readonly Lazy<RandomText> _text =
			new Lazy<RandomText>(() => new RandomText(NewRandom()));

		private static IRandomGenerator NewRandom()
		{
			return new SystemRandom();
		}

		public static RandomBoolean Booleans 
		{
			get { return _booleans.Value; }
		}

		public static RandomContact Contacts
		{
			get { return _contacts.Value; }
		}

		public static RandomDate Dates
		{
			get { return _dates.Value; }
		}

		public static RandomLocation Locations
		{
			get { return _locations.Value; }
		}

		public static RandomName Names
		{
			get { return _names.Value; }
		}

		public static RandomNet Net
		{
			get { return _net.Value; }
		}

		public static RandomText Text
		{
			get { return _text.Value; }
		}
	}
}
