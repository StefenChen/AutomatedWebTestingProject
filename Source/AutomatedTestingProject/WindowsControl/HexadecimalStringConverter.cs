using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsControl
{
	public static class HexadecimalStringConverter
	{
		/// <summary>
		/// Converts string which represents a byte array in hexadecimal format to the byte array.
		/// </summary>
		/// <param name="source">Hexadecimal string</param>
		/// <returns>Original byte array</returns>
		public static byte[] ToBytes(string source)
		{
			if (string.IsNullOrWhiteSpace(source))
				return null;

			var buff = new byte[source.Length / 2];

			for (int i = 0; i < buff.Length; i++)
			{
				try
				{
					buff[i] = Convert.ToByte(source.Substring(i * 2, 2), 16);
				}
				catch (FormatException)
				{
					break;
				}
			}
			return buff;
		}

		/// <summary>
		/// Converts a byte array to string which represents the byte array in hexadecimal format.
		/// </summary>
		/// <param name="source">Original byte array</param>
		/// <returns>Hexadecimal string</returns>
		public static string ToHexadecimalString(byte[] source) =>
			BitConverter.ToString(source).Replace("-", "");

		public static string ToHexadecimalString(string source) =>
			ToHexadecimalString(Encoding.UTF8.GetBytes(source));
	}
}
