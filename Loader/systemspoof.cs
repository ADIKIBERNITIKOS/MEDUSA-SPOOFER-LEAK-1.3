using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using KeyAuth;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using Siticone.UI.WinForms;

namespace Loader
{
	// Token: 0x0200001C RID: 28
	public partial class systemspoof : Form
	{
		// Token: 0x060000F1 RID: 241 RVA: 0x000027C0 File Offset: 0x000009C0
		public systemspoof()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00009504 File Offset: 0x00007704
		public static void ChangeSerialNumber(char volume, uint newSerial)
		{
			var source = new <>f__AnonymousType3<string, int, int>[]
			{
				new
				{
					Name = "FAT32",
					NameOffs = 82,
					SerialOffs = 67
				},
				new
				{
					Name = "FAT",
					NameOffs = 54,
					SerialOffs = 39
				},
				new
				{
					Name = "NTFS",
					NameOffs = 3,
					SerialOffs = 72
				}
			};
			using (systemspoof.Disk disk = new systemspoof.Disk(volume))
			{
				byte[] sector = new byte[512];
				disk.ReadSector(0U, sector);
				var <>f__AnonymousType = source.FirstOrDefault(f => systemspoof.Strncmp(f.Name, sector, f.NameOffs));
				if (<>f__AnonymousType == null)
				{
					throw new NotSupportedException("This file system is not supported");
				}
				uint num = newSerial;
				int i = 0;
				while (i < 4)
				{
					sector[<>f__AnonymousType.SerialOffs + i] = (byte)(num & 255U);
					i++;
					num >>= 8;
				}
				disk.WriteSector(0U, sector);
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000095F0 File Offset: 0x000077F0
		public static bool Strncmp(string str, byte[] data, int offset)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (data[i + offset] != (byte)str[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00009624 File Offset: 0x00007824
		public static string GenerateString(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "ABCDEF0123456789"[systemspoof.rand.Next("ABCDEF0123456789".Length)];
			}
			return new string(array);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000966C File Offset: 0x0000786C
		public static string RandomId(int length)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			string text2 = "";
			Random random = new Random();
			for (int i = 0; i < length; i++)
			{
				text2 += text[random.Next(text.Length)].ToString();
			}
			return text2;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000096BC File Offset: 0x000078BC
		public static string RandomMac()
		{
			string text = "ABCDEF0123456789";
			string text2 = "26AE";
			string text3 = "";
			Random random = new Random();
			text3 += text[random.Next(text.Length)].ToString();
			text3 += text2[random.Next(text2.Length)].ToString();
			for (int i = 0; i < 5; i++)
			{
				text3 += "-";
				text3 += text[random.Next(text.Length)].ToString();
				text3 += text[random.Next(text.Length)].ToString();
			}
			return text3;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00009788 File Offset: 0x00007988
		public static void Enable_LocalAreaConection(string adapterId, bool enable = true)
		{
			string str = "Ethernet";
			foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
			{
				if (networkInterface.Id == adapterId)
				{
					str = networkInterface.Name;
					IL_3D:
					string str2;
					if (enable)
					{
						str2 = "enable";
					}
					else
					{
						str2 = "disable";
					}
					ProcessStartInfo startInfo = new ProcessStartInfo("netsh", "interface set interface \"" + str + "\" " + str2);
					Process process = new Process();
					process.StartInfo = startInfo;
					process.Start();
					process.StartInfo.CreateNoWindow = true;
					process.WaitForExit();
					return;
				}
			}
			goto IL_3D;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00009824 File Offset: 0x00007A24
		public static bool x9WBy16uhpC0()
		{
			bool result = false;
			foreach (string text in Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}").GetSubKeyNames())
			{
				if (text != "Properties")
				{
					try
					{
						RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}\\" + text, true);
						if (registryKey.GetValue("BusType") != null)
						{
							registryKey.SetValue("NetworkAddress", systemspoof.RandomMac());
							string adapterId = registryKey.GetValue("NetCfgInstanceId").ToString();
							systemspoof.Enable_LocalAreaConection(adapterId, false);
							systemspoof.Enable_LocalAreaConection(adapterId, true);
						}
					}
					catch (SecurityException)
					{
						return true;
					}
				}
			}
			return result;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000098DC File Offset: 0x00007ADC
		public static void Bnc4fHNVZ7Hf()
		{
			foreach (string text in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi").GetSubKeyNames())
			{
				foreach (string text2 in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi\\" + text).GetSubKeyNames())
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string.Concat(new string[]
					{
						"HARDWARE\\DEVICEMAP\\Scsi\\",
						text,
						"\\",
						text2,
						"\\Target Id 0\\Logical Unit Id 0"
					}), true);
					if (registryKey != null && registryKey.GetValue("DeviceType").ToString() == "DiskPeripheral")
					{
						string text3 = systemspoof.RandomId(14);
						string text4 = systemspoof.RandomId(14);
						registryKey.SetValue("DeviceIdentifierPage", Encoding.UTF8.GetBytes(text4));
						registryKey.SetValue("Identifier", text3);
						registryKey.SetValue("InquiryData", Encoding.UTF8.GetBytes(text3));
						registryKey.SetValue("SerialNumber", text4);
					}
				}
			}
			foreach (string str in Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral").GetSubKeyNames())
			{
				Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral\\" + str, true).SetValue("Identifier", systemspoof.RandomId(8) + "-" + systemspoof.RandomId(8) + "-A");
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00009A6C File Offset: 0x00007C6C
		public static void CuzqxhGdB1ly()
		{
			string value = Guid.NewGuid().ToString();
			RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true).SetValue("MachineGuid", value);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00009AB4 File Offset: 0x00007CB4
		public static string GenerateDate(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "abcdef0123456789"[systemspoof.random.Next("abcdef0123456789".Length)];
			}
			return new string(array);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00009AFC File Offset: 0x00007CFC
		public static void e1VQVLbWdLng()
		{
			string value = systemspoof.GenerateDate(8);
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			registryKey.SetValue("InstallDate", value);
			registryKey.Close();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00009B3C File Offset: 0x00007D3C
		public static void luLKEfzx4M()
		{
			string value = string.Concat(new string[]
			{
				systemspoof.GenerateString(5),
				"-",
				systemspoof.GenerateString(5),
				"-",
				systemspoof.GenerateString(5),
				"-",
				systemspoof.GenerateString(5)
			});
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			registryKey.SetValue("ProductID", value);
			registryKey.Close();
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00009BBC File Offset: 0x00007DBC
		public static void cvxOUtsw4Z()
		{
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
			registryKey.SetValue("ComputerName", "MEDUSA-" + systemspoof.pcname);
			registryKey.Close();
			RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters", true);
			registryKey2.SetValue("NV Hostname", "MEDUSA-" + systemspoof.pcname);
			registryKey2.Close();
			RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters", true);
			registryKey3.SetValue("Hostname", "MEDUSA-" + systemspoof.pcname);
			registryKey3.Close();
			RegistryKey registryKey4 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", true);
			registryKey4.SetValue("ComputerName", "MEDUSA-" + systemspoof.pcname);
			registryKey4.Close();
			string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			using (RegistryKey registryKey5 = Registry.CurrentUser.OpenSubKey(name, true))
			{
				registryKey5.DeleteSubKeyTree("RegisteredOwner", false);
			}
			RegistryKey registryKey6 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			registryKey6.SetValue("RegisteredOwner", "MEDUSA-" + systemspoof.pcname);
			registryKey6.Close();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00009D24 File Offset: 0x00007F24
		public static void vsPHZ2U1uAah()
		{
			uint newSerial = uint.Parse(systemspoof.GenerateString(8), NumberStyles.HexNumber);
			systemspoof.ChangeSerialNumber('C', newSerial);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000027DA File Offset: 0x000009DA
		private void siticoneRoundedButton4_Click(object sender, EventArgs e)
		{
			systemspoof.x9WBy16uhpC0();
			MessageBox.Show("Spoofed MAC Adress", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000027F5 File Offset: 0x000009F5
		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
			systemspoof.Bnc4fHNVZ7Hf();
			MessageBox.Show("Spoofed Disk's", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000280F File Offset: 0x00000A0F
		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			systemspoof.vsPHZ2U1uAah();
			systemspoof.CuzqxhGdB1ly();
			MessageBox.Show("Spoofed HWID", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000282E File Offset: 0x00000A2E
		private void siticoneRoundedButton3_Click(object sender, EventArgs e)
		{
			systemspoof.e1VQVLbWdLng();
			MessageBox.Show("Spoofer Install Time", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00002848 File Offset: 0x00000A48
		private void siticoneRoundedButton5_Click(object sender, EventArgs e)
		{
			systemspoof.cvxOUtsw4Z();
			MessageBox.Show("Spoofed PC Name", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00002862 File Offset: 0x00000A62
		private void siticoneRoundedButton6_Click(object sender, EventArgs e)
		{
			systemspoof.luLKEfzx4M();
			MessageBox.Show("Spoofed Product ID", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000287C File Offset: 0x00000A7C
		private void siticoneRoundedButton8_Click(object sender, EventArgs e)
		{
			this.wqyWTF47t0JP();
			systemspoof.x9WBy16uhpC0();
			systemspoof.Bnc4fHNVZ7Hf();
			systemspoof.vsPHZ2U1uAah();
			systemspoof.CuzqxhGdB1ly();
			systemspoof.e1VQVLbWdLng();
			systemspoof.cvxOUtsw4Z();
			MessageBox.Show("Spoofed PC", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			this.ZylLF00l2wNH();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00009D4C File Offset: 0x00007F4C
		public void ZylLF00l2wNH()
		{
			DialogResult dialogResult = MessageBox.Show("Do you want to restart your PC?", "Medusa Spoofer", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				return;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00009D9C File Offset: 0x00007F9C
		public void bruhmoment()
		{
			string tempPath = Path.GetTempPath();
			if (Process.GetProcessesByName(this.uaregae + ".bat").Length == 0)
			{
				File.Delete(tempPath + this.uaregae + ".bat");
				return;
			}
			Thread.Sleep(5000);
			this.bruhmoment();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000028BC File Offset: 0x00000ABC
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[systemspoof.randoms.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000028F7 File Offset: 0x00000AF7
		public static string rndString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("0123456789", length)
			select s[systemspoof.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00009DF0 File Offset: 0x00007FF0
		private void siticoneRoundedButton9_Click(object sender, EventArgs e)
		{
			string tempPath = Path.GetTempPath();
			byte[] bytes = Login.KeyAuthApp.download("042447");
			File.WriteAllBytes(tempPath + this.uaregae + ".bat", bytes);
			Process.Start(tempPath + this.uaregae + ".bat");
			Thread.Sleep(2500);
			this.bruhmoment();
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00009E50 File Offset: 0x00008050
		private void siticoneRoundedButton7_Click(object sender, EventArgs e)
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
					Arguments = "/C net stop wuauserv && slmgr /ipk W269N-WFGWX-YVC9B-4J6C9-T83GX && slmgr /skms s8.uk.to && net start wuauserv"
				}
			}.Start();
			MessageBox.Show("Activated Windows", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00009EDC File Offset: 0x000080DC
		public void wqyWTF47t0JP()
		{
			byte[] bytes = Login.KeyAuthApp.download("853804");
			File.WriteAllBytes("C:\\Volumeid.exe", bytes);
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
					Arguments = string.Concat(new string[]
					{
						"/C cd C:/ && volumeid C: ",
						systemspoof.rndString(4),
						"-",
						systemspoof.rndString(4),
						" -nobanner"
					})
				}
			}.Start();
			if (File.Exists("C:\\Volumeid.exe"))
			{
				File.Delete("C:\\Volumeid.exe");
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00002932 File Offset: 0x00000B32
		public static string randstring(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
			select s[systemspoof.rndhwid.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00009FB8 File Offset: 0x000081B8
		public static void kt8t5gn6UldO()
		{
			systemspoof.IDgenerate = systemspoof.randstring(20);
			for (int i = 0; i < systemspoof.regkeyshwid.Length; i++)
			{
				systemspoof.XI0awLDj2UyO(i);
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00009FEC File Offset: 0x000081EC
		public static void XI0awLDj2UyO(int regKeyIndex)
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(systemspoof.regkeyshwid[regKeyIndex], true);
			if (registryKey == null)
			{
				return;
			}
			int num = 0;
			while (num < systemspoof.sOPIC9JSa8Gu.GetLength(1) && !(systemspoof.sOPIC9JSa8Gu[regKeyIndex, num] == "nop"))
			{
				registryKey.SetValue(systemspoof.sOPIC9JSa8Gu[regKeyIndex, num], systemspoof.IDgenerate);
				systemspoof.IDgenerate = systemspoof.randstring(20);
				num++;
			}
			registryKey.Close();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000296D File Offset: 0x00000B6D
		private void siticoneRoundedButton10_Click_1(object sender, EventArgs e)
		{
			this.wqyWTF47t0JP();
			MessageBox.Show("Spoofed Volume Serial Number", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000B2A0 File Offset: 0x000094A0
		// Note: this type is marked as 'beforefieldinit'.
		static systemspoof()
		{
			string[,] array = new string[6, 7];
			array[0, 0] = "SystemProductName";
			array[0, 1] = "Identifier";
			array[0, 2] = "Previous Update Revision";
			array[0, 3] = "ProcessorNameString";
			array[0, 4] = "VendorIdentifier";
			array[0, 5] = "Platform Specific Field1";
			array[0, 6] = "Component Information";
			array[1, 0] = "SerialNumber";
			array[1, 1] = "Identifier";
			array[1, 2] = "SystemManufacturer";
			array[1, 3] = "nop";
			array[1, 4] = "nop";
			array[1, 5] = "nop";
			array[1, 6] = "nop";
			array[2, 0] = "ComputerHardwareId";
			array[2, 1] = "ComputerHardwareIds";
			array[2, 2] = "BIOSVendor";
			array[2, 3] = "ProductId";
			array[2, 4] = "ProcessorNameString";
			array[2, 5] = "BIOSReleaseDate";
			array[2, 6] = "nop";
			array[3, 0] = "ProductId";
			array[3, 1] = "InstallDate";
			array[3, 2] = "InstallTime";
			array[3, 3] = "nop";
			array[3, 4] = "nop";
			array[3, 5] = "nop";
			array[3, 6] = "nop";
			array[4, 0] = "SusClientId";
			array[4, 1] = "nop";
			array[4, 2] = "nop";
			array[4, 3] = "nop";
			array[4, 4] = "nop";
			array[4, 5] = "nop";
			array[4, 6] = "nop";
			array[5, 0] = "BaseBoardManufacturer";
			array[5, 1] = "BaseBoardProduct";
			array[5, 2] = "BIOSVersion";
			array[5, 3] = "nop";
			array[5, 4] = "SystemManufacturer";
			array[5, 5] = "SystemProductName";
			array[5, 6] = "nop";
			systemspoof.sOPIC9JSa8Gu = array;
		}

		// Token: 0x0400008E RID: 142
		public static Random rand = new Random();

		// Token: 0x0400008F RID: 143
		public const string Alphabet = "ABCDEF0123456789";

		// Token: 0x04000090 RID: 144
		public static Random random = new Random();

		// Token: 0x04000091 RID: 145
		public const string Alphabet1 = "abcdef0123456789";

		// Token: 0x04000092 RID: 146
		public static Random randoms = new Random();

		// Token: 0x04000093 RID: 147
		private static string pcname = systemspoof.rndString(4);

		// Token: 0x04000094 RID: 148
		private string uaregae = systemspoof.RandomString(5);

		// Token: 0x04000095 RID: 149
		public static string IDgenerate;

		// Token: 0x04000096 RID: 150
		public static Random rndhwid = new Random();

		// Token: 0x04000097 RID: 151
		public static string[] regkeyshwid = new string[]
		{
			"HARDWARE\\Description\\System\\CentralProcessor\\0",
			"HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0",
			"SYSTEM\\CurrentControlSet\\Control\\SystemInformation",
			"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",
			"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate",
			"HARDWARE\\DESCRIPTION\\System\\BIOS"
		};

		// Token: 0x04000098 RID: 152
		public static string[,] sOPIC9JSa8Gu;

		// Token: 0x0200001D RID: 29
		private class Disk : IDisposable
		{
			// Token: 0x06000115 RID: 277 RVA: 0x0000B54C File Offset: 0x0000974C
			public Disk(char volume)
			{
				IntPtr preexistingHandle = systemspoof.Disk.CreateFile(string.Format("\\\\.\\{0}:", volume), FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
				this.handle = new SafeFileHandle(preexistingHandle, true);
				if (this.handle.IsInvalid)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
			}

			// Token: 0x06000116 RID: 278 RVA: 0x0000B5A8 File Offset: 0x000097A8
			public void ReadSector(uint sector, byte[] buffer)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (systemspoof.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, systemspoof.Disk.EMoveMethod.Begin) == 4294967295U)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				uint num;
				if (!systemspoof.Disk.ReadFile(this.handle, buffer, buffer.Length, out num, IntPtr.Zero))
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				if ((ulong)num != (ulong)((long)buffer.Length))
				{
					throw new IOException();
				}
			}

			// Token: 0x06000117 RID: 279 RVA: 0x0000B614 File Offset: 0x00009814
			public void WriteSector(uint sector, byte[] buffer)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (systemspoof.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, systemspoof.Disk.EMoveMethod.Begin) == 4294967295U)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				uint num;
				if (!systemspoof.Disk.WriteFile(this.handle, buffer, buffer.Length, out num, IntPtr.Zero))
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				if ((ulong)num != (ulong)((long)buffer.Length))
				{
					throw new IOException();
				}
			}

			// Token: 0x06000118 RID: 280 RVA: 0x000029A7 File Offset: 0x00000BA7
			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}

			// Token: 0x06000119 RID: 281 RVA: 0x000029B6 File Offset: 0x00000BB6
			protected virtual void Dispose(bool disposing)
			{
				if (disposing && this.handle != null)
				{
					this.handle.Dispose();
				}
			}

			// Token: 0x0600011A RID: 282
			[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			public static extern IntPtr CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, int flags, IntPtr template);

			// Token: 0x0600011B RID: 283
			[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern uint SetFilePointer([In] SafeFileHandle hFile, [In] uint lDistanceToMove, [In] IntPtr lpDistanceToMoveHigh, [In] systemspoof.Disk.EMoveMethod dwMoveMethod);

			// Token: 0x0600011C RID: 284
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern bool ReadFile(SafeFileHandle hFile, [Out] byte[] lpBuffer, int nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

			// Token: 0x0600011D RID: 285
			[DllImport("kernel32.dll")]
			private static extern bool WriteFile(SafeFileHandle hFile, [In] byte[] lpBuffer, int nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] IntPtr lpOverlapped);

			// Token: 0x040000AB RID: 171
			private SafeFileHandle handle;

			// Token: 0x040000AC RID: 172
			private const uint INVALID_SET_FILE_POINTER = 4294967295U;

			// Token: 0x0200001E RID: 30
			private enum EMoveMethod : uint
			{
				// Token: 0x040000AE RID: 174
				Begin,
				// Token: 0x040000AF RID: 175
				Current,
				// Token: 0x040000B0 RID: 176
				End
			}
		}
	}
}
