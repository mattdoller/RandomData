using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace RandomData
{
	public static class Names
	{
		private const string FIRST_NAMES_MALE = @"ADAM ANTHONY ARTHUR BRIAN CHARLES CHRISTOPHER DANIEL DAVID DONALD EDGAR EDWARD EDWIN GEORGE HAROLD HERBERT HUGH JAMES JASON JOHN JOSEPH KENNETH KEVIN MARCUS MARK MATTHEW MICHAEL PAUL PHILIP RICHARD ROBERT ROGER RONALD SIMON STEVEN TERRY THOMAS WILLIAM";
		private const string FIRST_NAMES_FEMALE = @"ALISON ANN ANNA ANNE BARBARA BETTY BERYL CAROL CHARLOTTE CHERYL DEBORAH DIANA DONNA DOROTHY ELIZABETH EVE FELICITY FIONA HELEN HELENA JENNIFER JESSICA JUDITH KAREN KIMBERLY LAURA LINDA LISA LUCY MARGARET MARIA MARY MICHELLE NANCY PATRICIA POLLY ROBYN RUTH SANDRA SARAH SHARON SUSAN TABITHA URSULA VICTORIA WENDY";
		private const string LAST_NAMES = @"ABEL ANDERSON ANDREWS ANTHONY BAKER BROWN BURROWS CLARK CLARKE CLARKSON DAVIDSON DAVIES DAVIS DENT EDWARDS GARCIA GRANT HALL HARRIS HARRISON JACKSON JEFFRIES JEFFERSON JOHNSON JONES KIRBY KIRK LAKE LEE LEWIS MARTIN MARTINEZ MAJOR MILLER MOORE OATES PETERS PETERSON ROBERTSON ROBINSON RODRIGUEZ SMITH SMYTHE STEVENS TAYLOR THATCHER THOMAS THOMPSON WALKER WASHINGTON WHITE WILLIAMS WILSON YORKE";
		private const string INCORPORATION_TYPES = @"LLC Inc Inc. Ltd. LP LLP Corp. PLLC";
		private const string COMPANY_TYPES = @"Clothier Publishing Computing Consulting Engineering Industries Marketing Manufacturing";

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
				return _firstNames ?? 
					(_firstNames = FirstNamesMale.Concat(FirstNamesFemale).ToArray()); 
			}
		}

		public static string[] FirstNamesMale
		{
			get 
			{ 
				return _firstNamesMale ?? 
					(_firstNamesMale = StringsToArray(FIRST_NAMES_MALE).Select(Titleize).ToArray()); 
			}
		}

		public static string[] FirstNamesFemale
		{
			get 
			{ 
				return _firstNamesFemale ?? 
					(_firstNamesFemale = StringsToArray(FIRST_NAMES_FEMALE).Select(Titleize).ToArray()); 
			}
		}

		public static string[] LastNames
		{
			get { return _lastNames ?? (_lastNames = StringsToArray(LAST_NAMES)); }
		}

		public static string[] IncorporationTypes
		{
			get { return _incorporationTypes ?? (_incorporationTypes = StringsToArray(INCORPORATION_TYPES)); }
		}

		public static string[] CompanyTypes
		{
			get { return _companyTypes ?? (_companyTypes = StringsToArray(COMPANY_TYPES)); }
		}

		private static string[] StringsToArray(params string[] strings)
		{
			var combined = new StringBuilder();
			var separator = "";
			foreach (var item in strings)
			{
				combined.Append(item).Append(" ");
			}
			return combined.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		}

		private static string Titleize(string s)
		{
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
			TextInfo textInfo = cultureInfo.TextInfo;
			return textInfo.ToTitleCase(s);
		}
	}
}
