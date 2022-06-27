using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;
using Loader;
using Loader.Properties;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;

namespace KeyAuth
{
	// Token: 0x02000015 RID: 21
	public partial class Main : Form
	{
		// Token: 0x060000AE RID: 174
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060000AF RID: 175 RVA: 0x000024E0 File Offset: 0x000006E0
		public Main()
		{
			this.InitializeComponent();
			this.Initialize();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		}

		// Token: 0x060000B0 RID: 176
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x060000B1 RID: 177
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060000B2 RID: 178 RVA: 0x00002175 File Offset: 0x00000375
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000564C File Offset: 0x0000384C
		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			dashboard dashboard = new dashboard
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			dashboard.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(dashboard);
			dashboard.Show();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000056A4 File Offset: 0x000038A4
		private void timer1_Tick(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			this.time.Text = string.Format("Medusa Spoofer || {0}/{1}/{2} {3}:{4}:{5}", new object[]
			{
				now.Day,
				now.Month,
				now.Year,
				now.Hour,
				now.Minute,
				now.Second
			});
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000572C File Offset: 0x0000392C
		private void siticoneRoundedButton4_Click(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			game game = new game
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			game.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(game);
			game.Show();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000564C File Offset: 0x0000384C
		private void Main_Load(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			dashboard dashboard = new dashboard
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			dashboard.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(dashboard);
			dashboard.Show();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00005784 File Offset: 0x00003984
		private void siticoneRoundedButton5_Click(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			systemspoof systemspoof = new systemspoof
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			systemspoof.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(systemspoof);
			systemspoof.Show();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000251D File Offset: 0x0000071D
		private void siticonePanel4_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000057DC File Offset: 0x000039DC
		private void Initialize()
		{
			this.client = new DiscordRpcClient("931208326262448129");
			this.client.Logger = new ConsoleLogger
			{
				Level = 3
			};
			this.client.Initialize();
			this.client.SetPresence(new RichPresence
			{
				Details = "Using The Best Spoofer",
				State = "discord.gg/projectmedusa",
				Timestamps = new Timestamps
				{
					Start = new DateTime?(DateTime.UtcNow)
				},
				Assets = new Assets
				{
					LargeImageKey = "medusa",
					LargeImageText = "What are you looking at?",
					SmallImageKey = "logo"
				}
			});
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00002545 File Offset: 0x00000745
		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=xvFZjo5PgG0");
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00005784 File Offset: 0x00003984
		private void siticoneRoundedButton1_Click_1(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			systemspoof systemspoof = new systemspoof
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			systemspoof.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(systemspoof);
			systemspoof.Show();
		}

		// Token: 0x04000045 RID: 69
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000046 RID: 70
		public const int HT_CAPTION = 2;

		// Token: 0x04000047 RID: 71
		private DiscordRpcClient client;
	}
}
