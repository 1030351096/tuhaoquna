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
** 程序集			: DripOldDriver.Data
** 文件名			: PocoColumn.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-07-08
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-07-08
** ***********************************************************************

*********************************************************************************/

using System;
using System.Reflection;

/// <summary>
/// Internal 命名空间
/// </summary>
namespace DripOldDriver.Data.Internal
{
	internal class PocoColumn
	{
		public string ColumnName;
		public PropertyInfo PropertyInfo;
		public bool ResultColumn;
		public bool ForceToUtc;
		public virtual void SetValue(object target, object val) { PropertyInfo.FastSetValue(target, val); }
		public virtual object GetValue(object target) { return PropertyInfo.FastGetValue(target); }
		public virtual object ChangeType(object val) { return Convert.ChangeType(val, PropertyInfo.PropertyType); }
	}
}