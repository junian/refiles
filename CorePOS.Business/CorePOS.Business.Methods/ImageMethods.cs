using System;
using System.IO;
using System.Net;
using System.Text;

namespace CorePOS.Business.Methods;

public class ImageMethods
{
	public string ConvertImageURLToBase64(string url)
	{
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array = method_0(url);
		if (array == null)
		{
			return "NoImage";
		}
		stringBuilder.Append(Convert.ToBase64String(array, 0, array.Length));
		return stringBuilder.ToString();
	}

	private byte[] method_0(string string_0)
	{
		Stream stream = null;
		try
		{
			new WebProxy();
			HttpWebResponse httpWebResponse = (HttpWebResponse)((HttpWebRequest)WebRequest.Create(string_0)).GetResponse();
			stream = httpWebResponse.GetResponseStream();
			byte[] result;
			using (BinaryReader binaryReader = new BinaryReader(stream))
			{
				int count = (int)httpWebResponse.ContentLength;
				result = binaryReader.ReadBytes(count);
				binaryReader.Close();
			}
			stream.Close();
			httpWebResponse.Close();
			return result;
		}
		catch
		{
			return null;
		}
	}

	public ImageMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
