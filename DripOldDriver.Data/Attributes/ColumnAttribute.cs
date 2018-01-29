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
** 文件名			: ColumnAttribute.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-07-08
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-08-15
** ***********************************************************************

*********************************************************************************/

using System;

/// <summary>
/// Data 命名空间
/// </summary>
namespace DripOldDriver.Data
{
	/// <summary>
	/// 表示此属性为数据表字段，并可以另指定字段名称
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class ColumnAttribute : Attribute
	{
		/// <summary>
		/// 初始化一个新 <see cref="ColumnAttribute" /> 实例。
		/// </summary>
		public ColumnAttribute()
		{
			ForceToUtc = false;
		}

		/// <summary>
		/// 初始化一个新 <see cref="ColumnAttribute" /> 实例。
		/// </summary>
		/// <param name="Name">数据表字段名称</param>
		public ColumnAttribute(string Name)
		{
			this.Name = Name;
			ForceToUtc = false;
		}

		/// <summary>
		/// 获取或设置数据表字段名称
		/// </summary>
		/// <value>数据表字段名称</value>
		public string Name { get; set; }

		/// <summary>
		/// 获取或设置一个值，该值指示是否将时间转换为 UTC
		/// </summary>
		/// <value>如果要转换为 UTC，则该值为 <c>true</c>；否则为 <c>false</c>。</value>
		public bool ForceToUtc { get; set; }
	}
}