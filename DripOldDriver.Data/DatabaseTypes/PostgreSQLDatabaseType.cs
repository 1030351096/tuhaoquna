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
** 程序集			: DripOldDriver.Data.DatabaseTypes
** 文件名			: PostgreSQLDatabaseType.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-08-13
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-08-15
** ***********************************************************************

*********************************************************************************/

using DripOldDriver.Data.Internal;

/// <summary>
/// DatabaseTypes 命名空间
/// </summary>
namespace DripOldDriver.Data.DatabaseTypes
{
	/// <summary>
	/// PostgreSQL 数据源
	/// </summary>
	class PostgreSQLDatabaseType : DatabaseType
	{
		/// <summary>
		/// 将 C# 数据类型转换为相应数据源的数据类型
		/// </summary>
		/// <param name="value">要转换的值</param>
		/// <returns>转换后的值</returns>
		public override object MapParameterValue(object value)
		{
			// Don't map bools to ints in PostgreSQL
			if(value.GetType() == typeof(bool))
				return value;

			return base.MapParameterValue(value);
		}

		/// <summary>
		/// 转码标识符
		/// </summary>
		/// <param name="str">要转码的表名或列名</param>
		/// <returns>转码后的表名或列名</returns>
		public override string EscapeSqlIdentifier(string str)
		{
			if(str[0] == '"' && str[str.Length - 1] == '"') return str;

			return string.Format("\"{0}\"", str);
		}

		/// <summary>
		/// 执行插入操作
		/// </summary>
		/// <param name="db">数据库对象</param>
		/// <param name="cmd">要执行插入的命令</param>
		/// <param name="PrimaryKeyName">主键名</param>
		/// <returns>插入后的主键值</returns>
		public override object ExecuteInsert(Database db, System.Data.IDbCommand cmd, string PrimaryKeyName)
		{
			if(PrimaryKeyName != null)
			{
				cmd.CommandText += string.Format("returning {0} as NewID", EscapeSqlIdentifier(PrimaryKeyName));
				return db.ExecuteScalarHelper(cmd);
			}
			else
			{
				db.ExecuteNonQueryHelper(cmd);
				return -1;
			}
		}
	}
}