using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Clientes.Bussines
{
	public class ValidarNumerico : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			string strValue = value as string;
			bool isNumeric = false;
			if (!string.IsNullOrEmpty(strValue))
			{
				decimal n;
				isNumeric = decimal.TryParse(strValue, out n);
			}
			return isNumeric;
		}

	}

	public class ValidaFechaFormato : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			string strValue = value as string;
			bool valido = false;
			try
			{
				if (DateTime.TryParseExact(strValue, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
				{
					valido = true;
				}
			}
			catch (Exception)
			{
			}
			return valido;
		}

	}
}
