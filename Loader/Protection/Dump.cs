using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Protection
{
	// Token: 0x02000007 RID: 7
	internal class Dump
	{
		// Token: 0x06000020 RID: 32 RVA: 0x0000212B File Offset: 0x0000032B
		public unsafe static void fuckyou(void* destination, void* source, uint byteCount)
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000212B File Offset: 0x0000032B
		public unsafe static void retard(void* startAddress, byte value, uint byteCount)
		{
		}

		// Token: 0x06000022 RID: 34
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, [MarshalAs(UnmanagedType.U4)] Dump.MemoryProtection flNewProtect, [MarshalAs(UnmanagedType.U4)] out Dump.MemoryProtection lpflOldProtect);

		// Token: 0x06000023 RID: 35 RVA: 0x0000354C File Offset: 0x0000174C
		public unsafe static void Initialize()
		{
			Module module = typeof(Dump).Module;
			byte* ptr = (byte*)((void*)Marshal.GetHINSTANCE(module));
			byte* ptr2 = ptr + 60;
			ptr2 = ptr + *(uint*)ptr2;
			ptr2 += 6;
			ushort num = *(ushort*)ptr2;
			ptr2 += 14;
			ushort num2 = *(ushort*)ptr2;
			ptr2 = ptr2 + 4 + num2;
			byte* ptr3 = stackalloc byte[(UIntPtr)11];
			if (module.FullyQualifiedName[0] != '<')
			{
				byte* ptr4 = ptr + *(uint*)(ptr2 - 16);
				Dump.MemoryProtection memoryProtection;
				if (*(uint*)(ptr2 - 120) != 0U)
				{
					byte* ptr5 = ptr + *(uint*)(ptr2 - 120);
					byte* ptr6 = ptr + *(uint*)ptr5;
					byte* ptr7 = ptr + *(uint*)(ptr5 + 12);
					byte* ptr8 = ptr + *(uint*)ptr6 + 2;
					Dump.VirtualProtect(new IntPtr((void*)ptr7), 11U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					*(int*)ptr3 = 1818522734;
					*(int*)(ptr3 + 4) = 1818504812;
					*(short*)(ptr3 + (IntPtr)4 * 2) = 108;
					ptr3[10] = 0;
					Dump.fuckyou((void*)ptr7, (void*)ptr3, 11U);
					Dump.VirtualProtect(new IntPtr((void*)ptr8), 11U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					*(int*)ptr3 = 1866691662;
					*(int*)(ptr3 + 4) = 1852404846;
					*(short*)(ptr3 + (IntPtr)4 * 2) = 25973;
					ptr3[10] = 0;
					Dump.fuckyou((void*)ptr8, (void*)ptr3, 11U);
				}
				for (int i = 0; i < (int)num; i++)
				{
					Dump.VirtualProtect(new IntPtr((void*)ptr2), 8U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					Dump.retard((void*)ptr2, 0, 8U);
					ptr2 += 40;
				}
				Dump.VirtualProtect(new IntPtr((void*)ptr4), 72U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
				byte* ptr9 = ptr + *(uint*)(ptr4 + 8);
				Dump.retard((void*)ptr4, 0, 16U);
				Dump.VirtualProtect(new IntPtr((void*)ptr9), 4U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
				*(int*)ptr9 = 0;
				ptr9 += 12;
				ptr9 += *(uint*)ptr9;
				ptr9 = (ptr9 + 7L & -4L);
				ptr9 += 2;
				ushort num3 = (ushort)(*ptr9);
				ptr9 += 2;
				int j = 0;
				IL_256:
				while (j < (int)num3)
				{
					Dump.VirtualProtect(new IntPtr((void*)ptr9), 8U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					ptr9 += 4;
					ptr9 += 4;
					int k = 0;
					while (k < 8)
					{
						Dump.VirtualProtect(new IntPtr((void*)ptr9), 4U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
						*ptr9 = 0;
						ptr9++;
						if (*ptr9 != 0)
						{
							*ptr9 = 0;
							ptr9++;
							if (*ptr9 != 0)
							{
								*ptr9 = 0;
								ptr9++;
								if (*ptr9 != 0)
								{
									*ptr9 = 0;
									ptr9++;
									k++;
									continue;
								}
								ptr9++;
							}
							else
							{
								ptr9 += 2;
							}
						}
						else
						{
							ptr9 += 3;
						}
						IL_250:
						j++;
						goto IL_256;
					}
					goto IL_250;
				}
				return;
			}
			uint num4 = *(uint*)(ptr2 - 16);
			uint num5 = *(uint*)(ptr2 - 120);
			uint[] array = new uint[(int)num];
			uint[] array2 = new uint[(int)num];
			uint[] array3 = new uint[(int)num];
			for (int l = 0; l < (int)num; l++)
			{
				Dump.MemoryProtection memoryProtection;
				Dump.VirtualProtect(new IntPtr((void*)ptr2), 8U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
				Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
				array[l] = *(uint*)(ptr2 + 12);
				array2[l] = *(uint*)(ptr2 + 8);
				array3[l] = *(uint*)(ptr2 + 20);
				ptr2 += 40;
			}
			if (num5 != 0U)
			{
				for (int m = 0; m < (int)num; m++)
				{
					if (array[m] <= num5 && num5 < array[m] + array2[m])
					{
						num5 = num5 - array[m] + array3[m];
						IL_31D:
						byte* ptr10 = ptr + num5;
						uint num6 = *(uint*)ptr10;
						for (int n = 0; n < (int)num; n++)
						{
							if (array[n] <= num6 && num6 < array[n] + array2[n])
							{
								num6 = num6 - array[n] + array3[n];
								IL_363:
								byte* ptr11 = ptr + num6;
								uint num7 = *(uint*)(ptr10 + 12);
								for (int num8 = 0; num8 < (int)num; num8++)
								{
									if (array[num8] <= num7 && num7 < array[num8] + array2[num8])
									{
										num7 = num7 - array[num8] + array3[num8];
										IL_3AC:
										uint num9 = *(uint*)ptr11 + 2U;
										for (int num10 = 0; num10 < (int)num; num10++)
										{
											if (array[num10] <= num9 && num9 < array[num10] + array2[num10])
											{
												num9 = num9 - array[num10] + array3[num10];
												IL_3ED:
												Dump.MemoryProtection memoryProtection;
												Dump.VirtualProtect(new IntPtr((void*)(ptr + num7)), 11U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
												*(int*)ptr3 = 1818522734;
												*(int*)(ptr3 + 4) = 1818504812;
												*(short*)(ptr3 + (IntPtr)4 * 2) = 108;
												ptr3[10] = 0;
												Dump.fuckyou((void*)(ptr + num7), (void*)ptr3, 11U);
												Dump.VirtualProtect(new IntPtr((void*)(ptr + num9)), 11U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
												*(int*)ptr3 = 1866691662;
												*(int*)(ptr3 + 4) = 1852404846;
												*(short*)(ptr3 + (IntPtr)4 * 2) = 25973;
												ptr3[10] = 0;
												Dump.fuckyou((void*)(ptr + num9), (void*)ptr3, 11U);
												goto IL_47E;
											}
										}
										goto IL_3ED;
									}
								}
								goto IL_3AC;
							}
						}
						goto IL_363;
					}
				}
				goto IL_31D;
			}
			IL_47E:
			for (int num11 = 0; num11 < (int)num; num11++)
			{
				if (array[num11] <= num4 && num4 < array[num11] + array2[num11])
				{
					num4 = num4 - array[num11] + array3[num11];
					IL_4B8:
					byte* ptr12 = ptr + num4;
					Dump.MemoryProtection memoryProtection;
					Dump.VirtualProtect(new IntPtr((void*)ptr12), 72U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					uint num12 = *(uint*)(ptr12 + 8);
					for (int num13 = 0; num13 < (int)num; num13++)
					{
						if (array[num13] <= num12 && num12 < array[num13] + array2[num13])
						{
							num12 = num12 - array[num13] + array3[num13];
							IL_513:
							Dump.retard((void*)ptr12, 0, 16U);
							byte* ptr13 = ptr + num12;
							Dump.VirtualProtect(new IntPtr((void*)ptr13), 4U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
							*(int*)ptr13 = 0;
							ptr13 += 12;
							ptr13 += *(uint*)ptr13;
							ptr13 = (ptr13 + 7L & -4L);
							ptr13 += 2;
							ushort num14 = (ushort)(*ptr13);
							ptr13 += 2;
							int num15 = 0;
							IL_612:
							while (num15 < (int)num14)
							{
								Dump.VirtualProtect(new IntPtr((void*)ptr13), 8U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
								ptr13 += 4;
								ptr13 += 4;
								int num16 = 0;
								while (num16 < 8)
								{
									Dump.VirtualProtect(new IntPtr((void*)ptr13), 4U, Dump.MemoryProtection.ExecuteReadWrite, out memoryProtection);
									*ptr13 = 0;
									ptr13++;
									if (*ptr13 != 0)
									{
										*ptr13 = 0;
										ptr13++;
										if (*ptr13 != 0)
										{
											*ptr13 = 0;
											ptr13++;
											if (*ptr13 != 0)
											{
												*ptr13 = 0;
												ptr13++;
												num16++;
												continue;
											}
											ptr13++;
										}
										else
										{
											ptr13 += 2;
										}
									}
									else
									{
										ptr13 += 3;
									}
									IL_60C:
									num15++;
									goto IL_612;
								}
								goto IL_60C;
							}
							return;
						}
					}
					goto IL_513;
				}
			}
			goto IL_4B8;
		}

		// Token: 0x02000008 RID: 8
		internal enum MemoryProtection
		{
			// Token: 0x0400000E RID: 14
			ExecuteReadWrite = 64
		}
	}
}
