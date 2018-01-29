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
** 程序集			: DripOldDriver
** 文件名			: PositionType.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2015-08-03
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2015-08-03
** ***********************************************************************

*********************************************************************************/
using System.ComponentModel;

namespace DripOldDriver
{
	/// <summary>表示方位类型</summary>
	public enum PositionType
	{
		/// <summary>左上</summary>
		[Description("左上")]
		TopLeft,
		/// <summary>上</summary>
		[Description("上")]
		Top,
		/// <summary>右上</summary>
		[Description("右上")]
		TopRight,
		/// <summary>左</summary>
		[Description("左")]
		Left,
		/// <summary>中间</summary>
		[Description("中间")]
		Center,
		/// <summary>右</summary>
		[Description("右")]
		Right,
		/// <summary>左下</summary>
		[Description("左下")]
		BottomLeft,
		/// <summary>下</summary>
		[Description("下")]
		Bottom,
		/// <summary>右下</summary>
		[Description("右下")]
		BottomRight
	}
}