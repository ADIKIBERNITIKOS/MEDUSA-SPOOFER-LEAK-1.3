using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000014 RID: 20
	public class json_wrapper
	{
		// Token: 0x060000AA RID: 170 RVA: 0x000024B5 File Offset: 0x000006B5
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000055B4 File Offset: 0x000037B4
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			if (!json_wrapper.is_serializable(type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005604 File Offset: 0x00003804
		public object string_to_object(string json)
		{
			object result;
			using (MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(json)))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000024D2 File Offset: 0x000006D2
		public T string_to_generic<T>(string json)
		{
			return (!!0)((object)this.string_to_object(json));
		}

		// Token: 0x04000043 RID: 67
		private DataContractJsonSerializer serializer;

		// Token: 0x04000044 RID: 68
		private object current_object;
	}
}
