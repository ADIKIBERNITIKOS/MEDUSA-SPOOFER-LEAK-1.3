using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using KeyAuth;
using Siticone.UI.WinForms;

namespace Loader
{
	// Token: 0x02000019 RID: 25
	public partial class dashboard : Form
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x000026C8 File Offset: 0x000008C8
		public dashboard()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00007DD4 File Offset: 0x00005FD4
		public static DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			result = result.AddSeconds((double)unixtime).ToLocalTime();
			return result;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00007E08 File Offset: 0x00006008
		private void dashboard_Load(object sender, EventArgs e)
		{
			this.key.Text = "Username: " + Login.KeyAuthApp.user_data.username;
			this.subscription.Text = "Subscription: " + Login.KeyAuthApp.user_data.subscriptions[0].subscription;
			this.expiry.Text = "Expiry: LifeTime";
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000026D6 File Offset: 0x000008D6
		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/projectmedusa");
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000026E3 File Offset: 0x000008E3
		private void siticoneRoundedButton3_Click(object sender, EventArgs e)
		{
			Process.Start("https://shoppy.gg/@Spinayy");
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000026F0 File Offset: 0x000008F0
		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCwJtkXgmuCB7nNnPe0t52LA");
		}
	}
}
