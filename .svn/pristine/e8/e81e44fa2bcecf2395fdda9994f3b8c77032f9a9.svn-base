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
** 文件名			: Page.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-07-08
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-07-08
** ***********************************************************************

*********************************************************************************/

using System.Collections.Generic;

/// <summary>
/// Data 命名空间
/// </summary>
namespace DripOldDriver.Data
{
	/// <summary>
	/// 分页数据
	/// </summary>
	/// <typeparam name="T">实体类型</typeparam>
	public class Page<T>
	{
		/// <summary>
		/// 获取或设置当前页码
		/// </summary>
		/// <value>当前页码</value>
		public long CurrentPage
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置总页数
		/// </summary>
		/// <value>总页数</value>
		public long TotalPages
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置总记录数
		/// </summary>
		/// <value>总记录数</value>
		public long TotalItems
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置每页记录数
		/// </summary>
		/// <value>每页记录数</value>
		public long ItemsPerPage
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置当前页记录列表
		/// </summary>
		/// <value>当前页记录列表</value>
		public List<T> Items
		{
			get;
			set;
		}

		/// <summary>
		/// 获取或设置其它相关数据
		/// </summary>
		/// <value>其它相关数据</value>
		public object Context
		{
			get;
			set;
		}
	}
}