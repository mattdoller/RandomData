using System;
using RandomData.Data;
using RandomData.Extensions;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomLocation : RandomCategoryBase
	{
		public RandomLocation(IRandomGenerator random) 
			: base(random)
		{
		}

		public string AddressLine1()
		{
			return String.Format(
				"{0} {1} {2}.",
				NumericString(3),
				NewRandom().PickFrom(Locations.StreetNames),
				NewRandom().PickFrom(Locations.StreetTypes)
			);
		}

		public string AddressLine2()
		{
			return String.Format(
				"{0}. {1}",
				NewRandom().PickFrom(Locations.AddressLine2Types),
				NumericString(3)
			);
		}

		public string City()
		{
			return NewRandom().PickFrom(Locations.Cities);
		}

		public string ZipCode()
		{
			return NumericString(5);
		}

		public string ZipCodePlusFour()
		{
			return String.Format("{0}-{1}", ZipCode(), NumericString(4));
		}

		public string PostalCode(PostalCodeFormat format = PostalCodeFormat.UnitedStatesZipCode)
		{
			switch (format)
			{
				case (PostalCodeFormat.UnitedStatesZipCode) :
					return ZipCode();
				case (PostalCodeFormat.UnitedStatesZipCodePlusFour) :
					return ZipCodePlusFour();
				case (PostalCodeFormat.Canada) :
					return PostalCodeCanada();
				case (PostalCodeFormat.UnitedKingdom) :
					return PostalCodeUnitedKingdom();
				default:
					throw new ArgumentException("Unrecognized PostalCodeFormat");
			}
		}

		public string State()
		{
			return NewRandom().PickFrom(Locations.StateAbbreviations);
		}

		public string StateName()
		{
			return NewRandom().PickFrom(Locations.States);
		}

		public string Country()
		{
			return NewRandom().PickFrom(Locations.Countries);
		}

		private string PostalCodeCanada()
		{
			return String.Format("{0}{1}{2} {3}{4}{5}", 
				RandomAlphaCharacter(),
				RandomNumericCharacter(),
				RandomAlphaCharacter(),
				RandomNumericCharacter(),
				RandomAlphaCharacter(),
				RandomNumericCharacter()
			);
		}

		private string PostalCodeUnitedKingdom()
		{
			return String.Format("{0} {1}",
				AlphanumericString(4),
				AlphanumericString(3)
			);
		}
	}

	public enum PostalCodeFormat
	{
		UnitedStatesZipCode,
		UnitedStatesZipCodePlusFour,
		Canada,
		UnitedKingdom
	}
}

