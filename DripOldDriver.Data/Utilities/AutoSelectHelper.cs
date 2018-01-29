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
** 文件名			: AutoSelectHelper.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-08-13
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-08-15
** ***********************************************************************

*********************************************************************************/

using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// Internal 命名空间
/// </summary>
namespace DripOldDriver.Data.Internal
{
	static class AutoSelectHelper
	{
		public static string AddSelectClause<T>(DatabaseType DatabaseType, string sql)
		{
			if(sql.StartsWith(";"))
				return sql.Substring(1);

			if(!rxSelect.IsMatch(sql))
			{
				var pd = PocoData.ForType(typeof(T));
				var tableName = DatabaseType.EscapeTableName(pd.TableInfo.TableName);
				string cols = pd.Columns.Count != 0 ? string.Join(", ", (from c in pd.QueryColumns select tableName + "." + DatabaseType.EscapeSqlIdentifier(c)).ToArray()) : "NULL";
				if(!rxFrom.IsMatch(sql))
					sql = string.Format("SELECT {0} FROM {1} {2}", cols, tableName, sql);
				else
					sql = string.Format("SELECT {0} {1}", cols, sql);
			}
			return sql;
		}

		static Regex rxSelect = new Regex(@"\A\s*(SELECT|EXECUTE|CALL)\s", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);
		static Regex rxFrom = new Regex(@"\A\s*FROM\s", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);
	}
}
