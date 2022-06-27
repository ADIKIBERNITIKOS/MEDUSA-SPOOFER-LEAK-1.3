using System;
using System.Diagnostics;
using System.Threading;

namespace Protection
{
	// Token: 0x02000009 RID: 9
	internal class ProcessCheck
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002135 File Offset: 0x00000335
		public static void Initialize()
		{
			new Thread(new ThreadStart(ProcessCheck.check)).Start();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000214D File Offset: 0x0000034D
		public static void check()
		{
			if (ProcessCheck.IsSandboxie())
			{
				ProcessCheck.msg();
			}
			if (ProcessCheck.IsDebugger())
			{
				ProcessCheck.msg();
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002167 File Offset: 0x00000367
		internal static bool IsSandboxie()
		{
			return ProcessCheck.IsDetected();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000216E File Offset: 0x0000036E
		internal static bool IsDebugger()
		{
			return ProcessCheck.Run();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002175 File Offset: 0x00000375
		internal static void msg()
		{
			Environment.Exit(0);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003B74 File Offset: 0x00001D74
		private static IntPtr GetModuleHandle(string libName)
		{
			foreach (object obj in Process.GetCurrentProcess().Modules)
			{
				ProcessModule processModule = (ProcessModule)obj;
				if (processModule.ModuleName.ToLower().Contains(libName.ToLower()))
				{
					return processModule.BaseAddress;
				}
			}
			return IntPtr.Zero;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000217D File Offset: 0x0000037D
		internal static bool IsDetected()
		{
			return ProcessCheck.GetModuleHandle("SbieDll.dll") != IntPtr.Zero;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003BF4 File Offset: 0x00001DF4
		internal static bool Run()
		{
			bool result = false;
			if (!Debugger.IsAttached && !Debugger.IsLogging())
			{
				string[] array = new string[]
				{
					"dnspy",
					"codecracker",
					"x32dbg",
					"x64dbg",
					"ollydbg",
					"ida",
					"charles",
					"simpleassembly",
					"peek",
					"httpanalyzer",
					"httpdebug",
					"fiddler",
					"wireshark",
					"dbx",
					"mdbg",
					"gdb",
					"windbg",
					"dbgclr",
					"kdb",
					"kgdb",
					"mdb",
					"processhacker",
					"scylla_x86",
					"scylla_x64",
					"scylla",
					"idau64",
					"idau",
					"idaq",
					"idaq64",
					"idaw",
					"idaw64",
					"idag",
					"idag64",
					"ida64",
					"ida",
					"ImportREC",
					"IMMUNITYDEBUGGER",
					"MegaDumper",
					"CodeBrowser",
					"reshacker",
					"cheat engine"
				};
				foreach (Process process in Process.GetProcesses())
				{
					if (process != Process.GetCurrentProcess())
					{
						for (int j = 0; j < array.Length; j++)
						{
							if (process.ProcessName.ToLower().Contains(array[j]))
							{
								result = true;
							}
							if (process.MainWindowTitle.ToLower().Contains(array[j]))
							{
								result = true;
							}
						}
					}
				}
			}
			return result;
		}
	}
}
