using System;
using RandomData.Data;
using RandomData.Extensions;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomName : RandomCategoryBase
	{
		public RandomName(IRandomGenerator random) 
			: base(random)
		{
		}

		public string LastName()
		{
			return NewRandom().PickFrom(Names.LastNames);
		}

		public string FirstName()
		{
			return NewRandom().PickFrom(Names.FirstNames);
		}

		public string FirstNameMale()
		{
			return NewRandom().PickFrom(Names.FirstNamesMale);
		}

		public string FirstNameFemale()
		{
			return NewRandom().PickFrom(Names.FirstNamesFemale);
		}

		public string Initial()
		{
			var start = 'A';
			var initial = start + NewRandom().Next(25);
			return ((char) initial).ToString();
		}

		public string FullName(NameType nameType = NameType.FirstLast)
		{
			var gender = RandomGender();
			return FullNameForGender(nameType, gender);
		}

		public string FullNameMale(NameType nameType = NameType.FirstLast)
		{
			return FullNameForGender(nameType, Gender.Male);
		}

		public string FullNameFemale(NameType nameType = NameType.FirstLast)
		{
			return FullNameForGender(nameType, Gender.Female);
		}

		public string CompanyName()
		{
			throw new NotImplementedException();
		}

		private string FirstNameForGender(Gender gender)
		{
			return gender == Gender.Male ? FirstNameMale() : FirstNameFemale();
		}

		private string FullNameForGender(NameType nameType, Gender gender)
		{
			if (nameType == NameType.FirstLast)
			{
				return String.Format("{0} {1}", FirstNameForGender(gender), LastName());
			}
			
			if (nameType == NameType.FirstMiddleInitialLast)
			{
				return String.Format("{0} {1}. {2}", 
					FirstNameForGender(gender), Initial(), LastName()
				);
			}
			
			if (nameType == NameType.FirstMiddleLast)
			{
				return String.Format("{0} {1} {2}",
					FirstNameForGender(gender), FirstNameForGender(gender), LastName()
				);
			}
			throw new ArgumentException("nameType");
		}

		private Gender RandomGender()
		{
			var random = NewRandom().Next(1);
			return random == 0 ? Gender.Male : Gender.Female;
		}
	}

	public enum NameType
	{
		FirstLast,
		FirstMiddleLast,
		FirstMiddleInitialLast
	}

	public enum Gender
	{
		Male,
		Female
	}
}

