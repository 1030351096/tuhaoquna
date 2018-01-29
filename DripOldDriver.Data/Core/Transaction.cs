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
** 文件名			: Transaction.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-07-16
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
	/// 事务接口
	/// </summary>
	public interface ITransaction : IDisposable
	{
		/// <summary>
		/// 完成事务
		/// </summary>
		void Complete();
	}

	/// <summary>
	/// 事务
	/// </summary>
	public class Transaction : ITransaction
	{
		/// <summary>
		/// 初始化一个新 <see cref="Transaction" /> 实例。
		/// </summary>
		/// <param name="db">要开始事务的数据源实例</param>
		public Transaction(Database db)
		{
			_db = db;
			_db.BeginTransaction();
		}

		/// <summary>
		/// 完成事务
		/// </summary>
		public void Complete()
		{
			_db.CompleteTransaction();
			_db = null;
		}

		/// <summary>
		/// 释放事务
		/// </summary>
		public void Dispose()
		{
			if(_db != null)
				_db.AbortTransaction();
		}

		Database _db;
	}
}