using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MorganSkilly
{
	// Token: 0x02000022 RID: 34
	internal class EasyDiscordIntegration
	{
		// Token: 0x0600013A RID: 314 RVA: 0x0000B680 File Offset: 0x00009880
		public static string SendFile(string mssgBody, string filename, string fileformat, string filepath, string application, string userName, string webhook)
		{
			FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("filename", filename);
			dictionary.Add("fileformat", fileformat);
			dictionary.Add("file", new EasyDiscordIntegration.FormUpload.FileParameter(array, filename, application));
			dictionary.Add("username", userName);
			dictionary.Add("content", mssgBody);
			HttpWebResponse httpWebResponse = EasyDiscordIntegration.FormUpload.MultipartFormDataPost(webhook, EasyDiscordIntegration.defaultUserAgent, dictionary);
			string result = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
			httpWebResponse.Close();
			Console.WriteLine("Discord: file success");
			return result;
		}

		// Token: 0x040000B8 RID: 184
		private static string defaultUserAgent = "PATCHED";

		// Token: 0x02000023 RID: 35
		public static class FormUpload
		{
			// Token: 0x0600013D RID: 317 RVA: 0x0000B72C File Offset: 0x0000992C
			public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, Dictionary<string, object> postParameters)
			{
				string text = string.Format("----------{0:N}", Guid.NewGuid());
				string contentType = "multipart/form-data; boundary=" + text;
				byte[] multipartFormData = EasyDiscordIntegration.FormUpload.GetMultipartFormData(postParameters, text);
				return EasyDiscordIntegration.FormUpload.PostForm(postUrl, userAgent, contentType, multipartFormData);
			}

			// Token: 0x0600013E RID: 318 RVA: 0x0000B76C File Offset: 0x0000996C
			private static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, byte[] formData)
			{
				HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
				if (httpWebRequest == null)
				{
					Console.WriteLine("request is not a http request");
					throw new NullReferenceException("request is not a http request");
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = contentType;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.CookieContainer = new CookieContainer();
				httpWebRequest.ContentLength = (long)formData.Length;
				using (Stream requestStream = httpWebRequest.GetRequestStream())
				{
					requestStream.Write(formData, 0, formData.Length);
					requestStream.Close();
				}
				return httpWebRequest.GetResponse() as HttpWebResponse;
			}

			// Token: 0x0600013F RID: 319 RVA: 0x0000B80C File Offset: 0x00009A0C
			private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
			{
				Stream stream = new MemoryStream();
				bool flag = false;
				foreach (KeyValuePair<string, object> keyValuePair in postParameters)
				{
					if (flag)
					{
						stream.Write(EasyDiscordIntegration.FormUpload.encoding.GetBytes("\r\n"), 0, EasyDiscordIntegration.FormUpload.encoding.GetByteCount("\r\n"));
					}
					flag = true;
					if (keyValuePair.Value is EasyDiscordIntegration.FormUpload.FileParameter)
					{
						EasyDiscordIntegration.FormUpload.FileParameter fileParameter = (EasyDiscordIntegration.FormUpload.FileParameter)keyValuePair.Value;
						string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n", new object[]
						{
							boundary,
							keyValuePair.Key,
							fileParameter.FileName ?? keyValuePair.Key,
							fileParameter.ContentType ?? "application/octet-stream"
						});
						stream.Write(EasyDiscordIntegration.FormUpload.encoding.GetBytes(s), 0, EasyDiscordIntegration.FormUpload.encoding.GetByteCount(s));
						stream.Write(fileParameter.File, 0, fileParameter.File.Length);
					}
					else
					{
						string s2 = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}", boundary, keyValuePair.Key, keyValuePair.Value);
						stream.Write(EasyDiscordIntegration.FormUpload.encoding.GetBytes(s2), 0, EasyDiscordIntegration.FormUpload.encoding.GetByteCount(s2));
					}
				}
				string s3 = "\r\n--" + boundary + "--\r\n";
				stream.Write(EasyDiscordIntegration.FormUpload.encoding.GetBytes(s3), 0, EasyDiscordIntegration.FormUpload.encoding.GetByteCount(s3));
				stream.Position = 0L;
				byte[] array = new byte[stream.Length];
				stream.Read(array, 0, array.Length);
				stream.Close();
				return array;
			}

			// Token: 0x040000B9 RID: 185
			private static readonly Encoding encoding = Encoding.UTF8;

			// Token: 0x02000024 RID: 36
			public class FileParameter
			{
				// Token: 0x1700004C RID: 76
				// (get) Token: 0x06000141 RID: 321 RVA: 0x00002C59 File Offset: 0x00000E59
				// (set) Token: 0x06000142 RID: 322 RVA: 0x00002C61 File Offset: 0x00000E61
				public byte[] File { get; set; }

				// Token: 0x1700004D RID: 77
				// (get) Token: 0x06000143 RID: 323 RVA: 0x00002C6A File Offset: 0x00000E6A
				// (set) Token: 0x06000144 RID: 324 RVA: 0x00002C72 File Offset: 0x00000E72
				public string FileName { get; set; }

				// Token: 0x1700004E RID: 78
				// (get) Token: 0x06000145 RID: 325 RVA: 0x00002C7B File Offset: 0x00000E7B
				// (set) Token: 0x06000146 RID: 326 RVA: 0x00002C83 File Offset: 0x00000E83
				public string ContentType { get; set; }

				// Token: 0x06000147 RID: 327 RVA: 0x00002C8C File Offset: 0x00000E8C
				public FileParameter(byte[] file) : this(file, null)
				{
				}

				// Token: 0x06000148 RID: 328 RVA: 0x00002C96 File Offset: 0x00000E96
				public FileParameter(byte[] file, string filename) : this(file, filename, null)
				{
				}

				// Token: 0x06000149 RID: 329 RVA: 0x00002CA1 File Offset: 0x00000EA1
				public FileParameter(byte[] file, string filename, string contenttype)
				{
					this.File = file;
					this.FileName = filename;
					this.ContentType = contenttype;
				}
			}
		}
	}
}
