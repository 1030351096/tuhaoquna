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
** 文件名			: TableNameAttribute.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-07-08
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-07-08
** ***********************************************************************

*********************************************************************************/

using System;

/// <summary>
/// Data 命名空间
/// </summary>
namespace DripOldDriver.Data
{
	/// <summary>
	/// 指定数据表名称
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class TableNameAttribute : Attribute
	{
		/// <summary>
		/// 初始化一个新 <see cref="TableNameAttribute" /> 实例。
		/// </summary>
		/// <param name="tableName">数据表名称</param>
		public TableNameAttribute(string tableName)
		{
			Value = tableName;
		}

		/// <summary>
		/// 获取数据表名称
		/// </summary>
		/// <value>数据表名称</value>
		public string Value { get; private set; }
	}
}