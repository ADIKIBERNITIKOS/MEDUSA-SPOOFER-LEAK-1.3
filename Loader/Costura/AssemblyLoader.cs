using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x02000025 RID: 37
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x0600014A RID: 330 RVA: 0x00002CBE File Offset: 0x00000EBE
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000B9D0 File Offset: 0x00009BD0
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000BA40 File Offset: 0x00009C40
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000BA74 File Offset: 0x00009C74
		private static Stream LoadStream(string fullName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullName.EndsWith(".compressed"))
			{
				Stream result;
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						result = memoryStream;
					}
				}
				return result;
			}
			return executingAssembly.GetManifestResourceStream(fullName);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000BB00 File Offset: 0x00009D00
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string fullName;
			if (resourceNames.TryGetValue(name, out fullName))
			{
				return AssemblyLoader.LoadStream(fullName);
			}
			return null;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000BB20 File Offset: 0x00009D20
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000BB48 File Offset: 0x00009D48
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] rawAssembly;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000BC08 File Offset: 0x00009E08
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
			if (assembly == null)
			{
				object obj2 = AssemblyLoader.nullCacheLock;
				lock (obj2)
				{
					AssemblyLoader.nullCache[e.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000BCE0 File Offset: 0x00009EE0
		// Note: this type is marked as 'beforefieldinit'.
		static AssemblyLoader()
		{
			AssemblyLoader.assemblyNames.Add("discordrpc", "costura.discordrpc.dll.compressed");
			AssemblyLoader.symbolNames.Add("discordrpc", "costura.discordrpc.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			AssemblyLoader.assemblyNames.Add("siticone.ui", "costura.siticone.ui.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.diagnostics.diagnosticsource", "costura.system.diagnostics.diagnosticsource.dll.compressed");
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000BD7C File Offset: 0x00009F7C
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x040000BD RID: 189
		private static object nullCacheLock = new object();

		// Token: 0x040000BE RID: 190
		private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		// Token: 0x040000BF RID: 191
		private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		// Token: 0x040000C0 RID: 192
		private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		// Token: 0x040000C1 RID: 193
		private static int isAttached;
	}
}
