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
** 文件名			: IMapper.cs
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
/// Data 命名空间
/// </summary>
namespace DripOldDriver.Data
{
	/// <summary>
	/// 定义数据源到实体的映射接口
	/// </summary>
	/// <remarks>To use this functionality, instantiate a class that implements IMapper and then pass it to
	/// PetaPoco through the static method Mappers.Register()</remarks>
	public interface IMapper
	{
		/// <summary>
		/// 获取数据表信息
		/// </summary>
		/// <param name="pocoType">实体类型</param>
		/// <returns>数据表信息</returns>
		/// <remarks>This method must return a valid TableInfo.
		/// To create a TableInfo from a POCO's attributes, use TableInfo.FromPoco</remarks>
		TableInfo GetTableInfo(Type pocoType);

		/// <summary>
		/// 获取数据表字段信息
		/// </summary>
		/// <param name="pocoProperty">实体属性信息</param>
		/// <returns>数据表字段信息</returns>
		/// <remarks>To create a ColumnInfo from a property's attributes, use PropertyInfo.FromProperty</remarks>
		ColumnInfo GetColumnInfo(PropertyInfo pocoProperty);

		/// <summary>
		/// 获取将数据源值到实体属性值的转换器
		/// </summary>
		/// <param name="TargetProperty">目标实体属性信息</param>
		/// <param name="SourceType">数据源返回来的值的类型</param>
		/// <returns>数据源值到实体属性值的转换器</returns>
		Func<object, object> GetFromDbConverter(PropertyInfo TargetProperty, Type SourceType);

		/// <summary>
		/// 获取将实体属性值到数据源对应值的转换器
		/// </summary>
		/// <param name="SourceProperty">实体属性信息</param>
		/// <returns>实体属性值到数据源对应值的转换器</returns>
		/// <remarks>This conversion is only used for converting values from POCO's that are
		/// being Inserted or Updated.
		/// Conversion is not available for parameter values passed directly to queries.</remarks>
		Func<object, object> GetToDbConverter(PropertyInfo SourceProperty);
	}
}