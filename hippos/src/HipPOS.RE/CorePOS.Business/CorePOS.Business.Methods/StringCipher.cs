using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CorePOS.Business.Methods;

public static class StringCipher
{
	private static Random random_0;

	public static string Encrypt(string plainText, string passPhrase)
	{
		try
		{
			byte[] array = smethod_0();
			byte[] array2 = smethod_0();
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, array, 1000);
			byte[] bytes2 = rfc2898DeriveBytes.GetBytes(32);
			using RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.BlockSize = 256;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			using ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, array2);
			using MemoryStream memoryStream = new MemoryStream();
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = array.Concat(array2).ToArray().Concat(memoryStream.ToArray())
				.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(inArray);
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			return "false";
		}
	}

	public static string Decrypt(string cipherText, string passPhrase)
	{
		try
		{
			byte[] array = Convert.FromBase64String(cipherText);
			byte[] salt = array.Take(32).ToArray();
			byte[] rgbIV = array.Skip(32).Take(32).ToArray();
			byte[] array2 = array.Skip(64).Take(array.Length - 64).ToArray();
			using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, salt, 1000);
			byte[] bytes = rfc2898DeriveBytes.GetBytes(32);
			using RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.BlockSize = 256;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			using ICryptoTransform transform = rijndaelManaged.CreateDecryptor(bytes, rgbIV);
			using MemoryStream memoryStream = new MemoryStream(array2);
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			byte[] array3 = new byte[array2.Length];
			int count = cryptoStream.Read(array3, 0, array3.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(array3, 0, count);
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			return "false";
		}
	}

	private static byte[] smethod_0()
	{
		byte[] array = new byte[32];
		using RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
		rNGCryptoServiceProvider.GetBytes(array);
		return array;
	}

	public static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[random_0.Next(s.Length)]).ToArray());
	}

	static StringCipher()
	{
		Class2.oOsq41PzvTVMr();
		random_0 = new Random();
	}
}
