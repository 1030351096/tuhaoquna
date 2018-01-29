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
** 程序集			: DripOldDriver.Data.Internal
** 文件名			: EnumMapper.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-08-15
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-08-15
** ***********************************************************************

*********************************************************************************/

using System;
using System.Collections.Generic;

/// <summary>
/// Internal 命名空间
/// </summary>
namespace DripOldDriver.Data.Internal
{
	internal static class EnumMapper
	{
		public static object EnumFromString(Type enumType, string value)
		{
			Dictionary<string, object> map = _types.Get(enumType, () =>
			{
				var values = Enum.GetValues(enumType);

				var newmap = new Dictionary<string, object>(values.Length, StringComparer.InvariantCultureIgnoreCase);

				foreach(var v in values)
				{
					newmap.Add(v.ToString(), v);
				}

				return newmap;
			});


			return map[value];
		}

		static Cache<Type, Dictionary<string, object>> _types = new Cache<Type, Dictionary<string, object>>();
	}
}
