using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace KeyAuth
{
	// Token: 0x02000018 RID: 24
	internal static class Program
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00007D6C File Offset: 0x00005F6C
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
				{
					MessageBox.Show("You must run this application as administrator.");
					Application.Exit();
				}
				Application.Run(new Login());
			}
			catch (Exception)
			{
			}
		}
	}
}
