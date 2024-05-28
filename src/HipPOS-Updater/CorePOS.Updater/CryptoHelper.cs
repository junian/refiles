using System;
using System.Security.Cryptography;
using System.Text;

namespace CorePOS.Updater;

public class CryptoHelper
{
	public string Decrypt(string text, string iv)
	{
		AesCryptoServiceProvider obj = new AesCryptoServiceProvider
		{
			BlockSize = 128,
			KeySize = 256,
			IV = Convert.FromBase64String(iv),
			Key = Encoding.UTF8.GetBytes("CF182BBFC340D700ED097149464A8BE2"),
			Mode = CipherMode.CBC,
			Padding = PaddingMode.PKCS7
		};
		byte[] array = Convert.FromBase64String(text);
		using ICryptoTransform cryptoTransform = obj.CreateDecryptor();
		byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
		return Encoding.Unicode.GetString(bytes);
	}

	public CryptoHelper()
	{
		Class13.FLcy5UmzUUEfT();
		// base._002Ector();
	}
}
