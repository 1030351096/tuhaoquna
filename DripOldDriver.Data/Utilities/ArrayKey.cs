﻿/********************************************************************************
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
** 文件名			: ArrayKey.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-08-13
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-08-15
** ***********************************************************************

*********************************************************************************/


/// <summary>
/// Internal 命名空间
/// </summary>
namespace DripOldDriver.Data.Internal
{
	internal class ArrayKey<T>
	{
		public ArrayKey(T[] keys)
		{
			// Store the keys
			_keys = keys;

			// Calculate the hashcode
			_hashCode = 17;
			foreach(var k in keys)
			{
				_hashCode = _hashCode * 23 + (k == null ? 0 : k.GetHashCode());
			}
		}

		T[] _keys;
		int _hashCode;

		bool Equals(ArrayKey<T> other)
		{
			if(other == null)
				return false;

			if(other._hashCode != _hashCode)
				return false;

			if(other._keys.Length != _keys.Length)
				return false;

			for(int i = 0; i < _keys.Length; i++)
			{
				if(!object.Equals(_keys[i], other._keys[i]))
					return false;
			}

			return true;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ArrayKey<T>);
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}
	}
}