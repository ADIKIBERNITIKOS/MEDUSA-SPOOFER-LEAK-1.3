using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace KeyAuth
{
	// Token: 0x0200000A RID: 10
	public class api
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00003DF0 File Offset: 0x00001FF0
		public api(string name, string ownerid, string secret, string version)
		{
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003E54 File Offset: 0x00002054
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			if (text2 == "KeyAuth_Invalid")
			{
				api.error("You are on an old version of Medusa Spoofer. Please update to the latest version.");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
				return;
			}
			if (response_structure.message == "invalidver")
			{
				this.app_data.downloadLink = response_structure.download;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002193 File Offset: 0x00000393
		public static bool IsDebugRelease
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002196 File Offset: 0x00000396
		public void Checkinit()
		{
			if (!this.initzalized)
			{
				if (api.IsDebugRelease)
				{
					api.error("Medusa Spoofer Down!");
					return;
				}
				api.error("Please initialize first");
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003FD8 File Offset: 0x000021D8
		public void register(string username, string pass, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004134 File Offset: 0x00002334
		public void gamwtospitisou(string username, string pass)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004278 File Offset: 0x00002478
		public void upgrade(string username, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004398 File Offset: 0x00002598
		public void license(string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000044C4 File Offset: 0x000026C4
		public void check()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000459C File Offset: 0x0000279C
		public void setvar(string var, string data)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data2);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000046A4 File Offset: 0x000028A4
		public string getvar(string var)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000047A4 File Offset: 0x000029A4
		public void ban()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000487C File Offset: 0x00002A7C
		public string var(string varid)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.message;
			}
			return null;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000498C File Offset: 0x00002B8C
		public List<api.msg> chatget(string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.messages;
			}
			return null;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004A8C File Offset: 0x00002C8C
		public bool chatsend(string msg, string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004BA0 File Offset: 0x00002DA0
		public bool checkblack()
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004CAC File Offset: 0x00002EAC
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004DF4 File Offset: 0x00002FF4
		public byte[] download(string fileid)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return encryption.str_to_byte_arr(response_structure.contents);
			}
			return null;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004EF8 File Offset: 0x000030F8
		public void log(string message)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			api.req(nameValueCollection);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004FE0 File Offset: 0x000031E0
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005050 File Offset: 0x00003250
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"title Project Medusa && echo " + message + " && pause\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Thread.Sleep(5000);
			Environment.Exit(0);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000050AC File Offset: 0x000032AC
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005148 File Offset: 0x00003348
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000051AC File Offset: 0x000033AC
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005220 File Offset: 0x00003420
		public string expirydaysleft()
		{
			this.Checkinit();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(this.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			return Convert.ToString(timeSpan.Days.ToString() + " Days " + timeSpan.Hours.ToString() + " Hours Left");
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000021BC File Offset: 0x000003BC
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x0400000F RID: 15
		public string name;

		// Token: 0x04000010 RID: 16
		public string ownerid;

		// Token: 0x04000011 RID: 17
		public string secret;

		// Token: 0x04000012 RID: 18
		public string version;

		// Token: 0x04000013 RID: 19
		private string sessionid;

		// Token: 0x04000014 RID: 20
		private string enckey;

		// Token: 0x04000015 RID: 21
		private bool initzalized;

		// Token: 0x04000016 RID: 22
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x04000017 RID: 23
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x04000018 RID: 24
		public api.response_class response = new api.response_class();

		// Token: 0x04000019 RID: 25
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x0200000B RID: 11
		[DataContract]
		private class response_structure
		{
			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000048 RID: 72 RVA: 0x000021E0 File Offset: 0x000003E0
			// (set) Token: 0x06000049 RID: 73 RVA: 0x000021E8 File Offset: 0x000003E8
			[DataMember]
			public bool success { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x0600004A RID: 74 RVA: 0x000021F1 File Offset: 0x000003F1
			// (set) Token: 0x0600004B RID: 75 RVA: 0x000021F9 File Offset: 0x000003F9
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x0600004C RID: 76 RVA: 0x00002202 File Offset: 0x00000402
			// (set) Token: 0x0600004D RID: 77 RVA: 0x0000220A File Offset: 0x0000040A
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x0600004E RID: 78 RVA: 0x00002213 File Offset: 0x00000413
			// (set) Token: 0x0600004F RID: 79 RVA: 0x0000221B File Offset: 0x0000041B
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000050 RID: 80 RVA: 0x00002224 File Offset: 0x00000424
			// (set) Token: 0x06000051 RID: 81 RVA: 0x0000222C File Offset: 0x0000042C
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000052 RID: 82 RVA: 0x00002235 File Offset: 0x00000435
			// (set) Token: 0x06000053 RID: 83 RVA: 0x0000223D File Offset: 0x0000043D
			[DataMember]
			public string download { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000054 RID: 84 RVA: 0x00002246 File Offset: 0x00000446
			// (set) Token: 0x06000055 RID: 85 RVA: 0x0000224E File Offset: 0x0000044E
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000056 RID: 86 RVA: 0x00002257 File Offset: 0x00000457
			// (set) Token: 0x06000057 RID: 87 RVA: 0x0000225F File Offset: 0x0000045F
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000058 RID: 88 RVA: 0x00002268 File Offset: 0x00000468
			// (set) Token: 0x06000059 RID: 89 RVA: 0x00002270 File Offset: 0x00000470
			[DataMember]
			public List<api.msg> messages { get; set; }
		}

		// Token: 0x0200000C RID: 12
		public class msg
		{
			// Token: 0x17000017 RID: 23
			// (get) Token: 0x0600005B RID: 91 RVA: 0x00002279 File Offset: 0x00000479
			// (set) Token: 0x0600005C RID: 92 RVA: 0x00002281 File Offset: 0x00000481
			public string message { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600005D RID: 93 RVA: 0x0000228A File Offset: 0x0000048A
			// (set) Token: 0x0600005E RID: 94 RVA: 0x00002292 File Offset: 0x00000492
			public string author { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600005F RID: 95 RVA: 0x0000229B File Offset: 0x0000049B
			// (set) Token: 0x06000060 RID: 96 RVA: 0x000022A3 File Offset: 0x000004A3
			public string timestamp { get; set; }
		}

		// Token: 0x0200000D RID: 13
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000062 RID: 98 RVA: 0x000022AC File Offset: 0x000004AC
			// (set) Token: 0x06000063 RID: 99 RVA: 0x000022B4 File Offset: 0x000004B4
			[DataMember]
			public string username { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000064 RID: 100 RVA: 0x000022BD File Offset: 0x000004BD
			// (set) Token: 0x06000065 RID: 101 RVA: 0x000022C5 File Offset: 0x000004C5
			[DataMember]
			public string ip { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000066 RID: 102 RVA: 0x000022CE File Offset: 0x000004CE
			// (set) Token: 0x06000067 RID: 103 RVA: 0x000022D6 File Offset: 0x000004D6
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000068 RID: 104 RVA: 0x000022DF File Offset: 0x000004DF
			// (set) Token: 0x06000069 RID: 105 RVA: 0x000022E7 File Offset: 0x000004E7
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x0600006A RID: 106 RVA: 0x000022F0 File Offset: 0x000004F0
			// (set) Token: 0x0600006B RID: 107 RVA: 0x000022F8 File Offset: 0x000004F8
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600006C RID: 108 RVA: 0x00002301 File Offset: 0x00000501
			// (set) Token: 0x0600006D RID: 109 RVA: 0x00002309 File Offset: 0x00000509
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200000E RID: 14
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600006F RID: 111 RVA: 0x00002312 File Offset: 0x00000512
			// (set) Token: 0x06000070 RID: 112 RVA: 0x0000231A File Offset: 0x0000051A
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000071 RID: 113 RVA: 0x00002323 File Offset: 0x00000523
			// (set) Token: 0x06000072 RID: 114 RVA: 0x0000232B File Offset: 0x0000052B
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000073 RID: 115 RVA: 0x00002334 File Offset: 0x00000534
			// (set) Token: 0x06000074 RID: 116 RVA: 0x0000233C File Offset: 0x0000053C
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000075 RID: 117 RVA: 0x00002345 File Offset: 0x00000545
			// (set) Token: 0x06000076 RID: 118 RVA: 0x0000234D File Offset: 0x0000054D
			[DataMember]
			public string version { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000077 RID: 119 RVA: 0x00002356 File Offset: 0x00000556
			// (set) Token: 0x06000078 RID: 120 RVA: 0x0000235E File Offset: 0x0000055E
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000079 RID: 121 RVA: 0x00002367 File Offset: 0x00000567
			// (set) Token: 0x0600007A RID: 122 RVA: 0x0000236F File Offset: 0x0000056F
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x0200000F RID: 15
		public class app_data_class
		{
			// Token: 0x17000026 RID: 38
			// (get) Token: 0x0600007C RID: 124 RVA: 0x00002378 File Offset: 0x00000578
			// (set) Token: 0x0600007D RID: 125 RVA: 0x00002380 File Offset: 0x00000580
			public string numUsers { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x0600007E RID: 126 RVA: 0x00002389 File Offset: 0x00000589
			// (set) Token: 0x0600007F RID: 127 RVA: 0x00002391 File Offset: 0x00000591
			public string numOnlineUsers { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000080 RID: 128 RVA: 0x0000239A File Offset: 0x0000059A
			// (set) Token: 0x06000081 RID: 129 RVA: 0x000023A2 File Offset: 0x000005A2
			public string numKeys { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000082 RID: 130 RVA: 0x000023AB File Offset: 0x000005AB
			// (set) Token: 0x06000083 RID: 131 RVA: 0x000023B3 File Offset: 0x000005B3
			public string version { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000084 RID: 132 RVA: 0x000023BC File Offset: 0x000005BC
			// (set) Token: 0x06000085 RID: 133 RVA: 0x000023C4 File Offset: 0x000005C4
			public string customerPanelLink { get; set; }

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000086 RID: 134 RVA: 0x000023CD File Offset: 0x000005CD
			// (set) Token: 0x06000087 RID: 135 RVA: 0x000023D5 File Offset: 0x000005D5
			public string downloadLink { get; set; }
		}

		// Token: 0x02000010 RID: 16
		public class user_data_class
		{
			// Token: 0x1700002C RID: 44
			// (get) Token: 0x06000089 RID: 137 RVA: 0x000023DE File Offset: 0x000005DE
			// (set) Token: 0x0600008A RID: 138 RVA: 0x000023E6 File Offset: 0x000005E6
			public string username { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x0600008B RID: 139 RVA: 0x000023EF File Offset: 0x000005EF
			// (set) Token: 0x0600008C RID: 140 RVA: 0x000023F7 File Offset: 0x000005F7
			public string ip { get; set; }

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x0600008D RID: 141 RVA: 0x00002400 File Offset: 0x00000600
			// (set) Token: 0x0600008E RID: 142 RVA: 0x00002408 File Offset: 0x00000608
			public string hwid { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x0600008F RID: 143 RVA: 0x00002411 File Offset: 0x00000611
			// (set) Token: 0x06000090 RID: 144 RVA: 0x00002419 File Offset: 0x00000619
			public string createdate { get; set; }

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x06000091 RID: 145 RVA: 0x00002422 File Offset: 0x00000622
			// (set) Token: 0x06000092 RID: 146 RVA: 0x0000242A File Offset: 0x0000062A
			public string lastlogin { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x06000093 RID: 147 RVA: 0x00002433 File Offset: 0x00000633
			// (set) Token: 0x06000094 RID: 148 RVA: 0x0000243B File Offset: 0x0000063B
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000011 RID: 17
		public class Data
		{
			// Token: 0x17000032 RID: 50
			// (get) Token: 0x06000096 RID: 150 RVA: 0x00002444 File Offset: 0x00000644
			// (set) Token: 0x06000097 RID: 151 RVA: 0x0000244C File Offset: 0x0000064C
			public string subscription { get; set; }

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x06000098 RID: 152 RVA: 0x00002455 File Offset: 0x00000655
			// (set) Token: 0x06000099 RID: 153 RVA: 0x0000245D File Offset: 0x0000065D
			public string expiry { get; set; }

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x0600009A RID: 154 RVA: 0x00002466 File Offset: 0x00000666
			// (set) Token: 0x0600009B RID: 155 RVA: 0x0000246E File Offset: 0x0000066E
			public string timeleft { get; set; }
		}

		// Token: 0x02000012 RID: 18
		public class response_class
		{
			// Token: 0x17000035 RID: 53
			// (get) Token: 0x0600009D RID: 157 RVA: 0x00002477 File Offset: 0x00000677
			// (set) Token: 0x0600009E RID: 158 RVA: 0x0000247F File Offset: 0x0000067F
			public bool success { get; set; }

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x0600009F RID: 159 RVA: 0x00002488 File Offset: 0x00000688
			// (set) Token: 0x060000A0 RID: 160 RVA: 0x00002490 File Offset: 0x00000690
			public string message { get; set; }
		}
	}
}
