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
** 文件名			: StandardMapper.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-07-16
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-08-15
** ***********************************************************************

*********************************************************************************/

using System;
using System.Reflection;

/// <summary>
/// Data 命名空间
/// </summary>
namespace DripOldDriver.Data
{
	/// <summary>
	/// 实现了 IMapper 接口的标准映射器
	/// </summary>
	public class StandardMapper : IMapper
	{
		/// <summary>
		/// 获取数据表信息
		/// </summary>
		/// <param name="pocoType">实体类型</param>
		/// <returns>数据表信息</returns>
		/// <remarks>This method must return a valid TableInfo.
		/// To create a TableInfo from a POCO's attributes, use TableInfo.FromPoco</remarks>
		public TableInfo GetTableInfo(Type pocoType)
		{
			return TableInfo.FromPoco(pocoType);
		}

		/// <summary>
		/// 获取数据表字段信息
		/// </summary>
		/// <param name="pocoProperty">实体属性信息</param>
		/// <returns>数据表字段信息</returns>
		/// <remarks>To create a ColumnInfo from a property's attributes, use PropertyInfo.FromProperty</remarks>
		public ColumnInfo GetColumnInfo(PropertyInfo pocoProperty)
		{
			return ColumnInfo.FromProperty(pocoProperty);
		}

		/// <summary>
		/// 获取将数据源值到实体属性值的转换器
		/// </summary>
		/// <param name="TargetProperty">目标实体属性信息</param>
		/// <param name="SourceType">数据源返回来的值的类型</param>
		/// <returns>数据源值到实体属性值的转换器</returns>
		public Func<object, object> GetFromDbConverter(PropertyInfo TargetProperty, Type SourceType)
		{
			return null;
		}

		/// <summary>
		/// 获取将实体属性值到数据源对应值的转换器
		/// </summary>
		/// <param name="SourceProperty">实体属性信息</param>
		/// <returns>实体属性值到数据源对应值的转换器</returns>
		/// <remarks>This conversion is only used for converting values from POCO's that are
		/// being Inserted or Updated.
		/// Conversion is not available for parameter values passed directly to queries.</remarks>
		public Func<object, object> GetToDbConverter(PropertyInfo SourceProperty)
		{
			return null;
		}
	}
}