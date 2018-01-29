/********************************************************************************
**
**　　　　　　　　┏┓　　　┏┓+ +
**　　　　　　　┏┛┻━━━┛┻┓ + +
**　　　　　　　┃　　　　　　　┃ 　
**　　　　　　　┃　　　━　　　┃ ++ + + +
**　　　　　　 ████━████ ┃+
**　　　　　　　┃　　　　　　　┃ +
**　　　　　　　┃　　　┻　　　┃
**　　　　　　　┃　　　　　　　┃ + +
**　　　　　　　┗━┓　　　┏━┛
**　　　　　　　　　┃　　　┃　　　　　　　　　　　
**　　　　　　　　　┃　　　┃ + + + +
**　　　　　　　　　┃　　　┃　　　　Code is far away from bug with the animal protecting　　　　　　　
**　　　　　　　　　┃　　　┃ + 　　　　神兽保佑,代码无bug　　
**　　　　　　　　　┃　　　┃
**　　　　　　　　　┃　　　┃　　+　　　　　　　　　
**　　　　　　　　　┃　 　　┗━━━┓ + +
**　　　　　　　　　┃ 　　　　　　　┣┓
**　　　　　　　　　┃ 　　　　　　　┏┛
**　　　　　　　　　┗┓┓┏━┳┓┏┛ + + + +
**　　　　　　　　　　┃┫┫　┃┫┫
**　　　　　　　　　　┗┻┛　┗┻┛+ + + +
**

** ***********************************************************************
** 程序集			: DripOldDriver.FastJson
** 文件名			: Cache.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2015-08-03
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2015-08-03
** ***********************************************************************

*********************************************************************************/
using System;
using System.Collections.Generic;

namespace DripOldDriver.FastJson
{
	internal sealed class Cache
	{
		public readonly static Cache Instance = new Cache();

		private Cache()
		{
			if(AC == null) AC = new Dict<string, Dictionary<string, JsonAccessor>>(StringComparer.OrdinalIgnoreCase);
		}

		private static Dict<string, Dictionary<string, JsonAccessor>> AC;
		internal Dictionary<string, JsonAccessor> GetJsonAccessors(Type type)
		{
			var typeName = type.FullName;
			return AC.Get(typeName, () =>
			{
				var ls = type.FastGetAccessors();
				var jas = new Dictionary<string, JsonAccessor>(ls.Count, StringComparer.OrdinalIgnoreCase);
				foreach(var a in ls.Values)
					jas.Add(a.Name, GetJsonAccessor(a));
				return jas;
			});
		}

		private JsonAccessor GetJsonAccessor(Accessor a)
		{
			var ja = new JsonAccessor
			{
				Name = a.Name,
				Member = a.Member,
				DataType = a.DataType,
				AccessorType = a.AccessorType,
				CanRade = a.CanRade,
				CanWrite = a.CanWrite,
				IsVirtual = a.IsVirtual
			};
			var t = ja.DataType;
			ja.IsDictionary = t.Name.Contains("Dictionary");
			if(ja.IsDictionary)
				ja.GenericTypes = t.GetGenericArguments();
			ja.IsValueType = t.IsValueType;
			ja.IsGenericType = t.IsGenericType;
			ja.IsArray = t.IsArray;
			if(ja.IsArray)
				ja.ElementType = t.GetElementType();
			if(ja.IsGenericType)
				ja.ElementType = t.GetGenericArguments()[0];
			ja.IsByteArray = t == typeof(byte[]);
			ja.IsGuid = t == typeof(Guid) || t == typeof(Guid?);
			ja.IsHashtable = t == typeof(System.Collections.Hashtable);
			ja.IsDataSet = t == typeof(System.Data.DataSet);
			ja.IsDataTable = t == typeof(System.Data.DataTable);
			ja.IsEnum = t.IsEnum;
			ja.IsDateTime = t == typeof(DateTime) || t == typeof(DateTime?);
			ja.IsInt = t == typeof(int) || t == typeof(int?);
			ja.IsLong = t == typeof(long) || t == typeof(long?);
			ja.IsString = t == typeof(string);
			ja.IsBool = t == typeof(bool) || t == typeof(bool?);
			ja.IsClass = t.IsClass;
			if(ja.IsDictionary && ja.GenericTypes.Length > 0 && ja.GenericTypes[0] == typeof(string))
				ja.IsStringDictionary = true;
			if(t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
				ja.ConversionType = t.GetGenericArguments()[0];
			else
				ja.ConversionType = t;

			return ja;
		}
	}
}