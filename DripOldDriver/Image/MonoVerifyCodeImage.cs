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
** 程序集			: DripOldDriver.Images
** 文件名			: MonoVerifyCodeImage.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2015-11-15
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2016-05-24
** ***********************************************************************

*********************************************************************************/
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using DripOldDriver.Web;

namespace DripOldDriver.Images
{
	/// <summary>图片验证码</summary>
	public class MonoVerifyCodeImage : IVerifyCode
	{
		private string VERIFY_CODE_KEY = "VerifyCode";
		private string VERIFY_CODE_TIMES = "VerifyCodeTimes";
		private static FontFamily[] fonts = {
			FontFamily.GenericMonospace,
			FontFamily.GenericSansSerif,
			FontFamily.GenericSerif
		};

		/// <summary>获取验证码图片信息</summary>
		/// <returns>验证码图片信息</returns>
		public VerifyCodeImageInfo GetVerifyCodeImageInfo()
		{
			var vcii = new VerifyCodeImageInfo();
			vcii.Text = this.GetVerifyCode(5);
			vcii.ImageWidth = WebGet.GetInt("w", 200);
			vcii.ImageHeight = WebGet.GetInt("h", 80);
			var tc = WebGet.GetString("tc");
			if(tc.IsNullOrEmpty_())
			{
				vcii.TextColor = Color.Empty;
				vcii.RandomTextColor = true;
			}
			else
			{
				vcii.TextColor = ColorTranslator.FromHtml(tc);
				vcii.RandomTextColor = WebGet.GetString("r").ToBool_();
			}
			var bc = WebGet.GetString("bc");
			vcii.BackgroundColor = bc.IsNullOrEmpty_() ? Color.White : ColorTranslator.FromHtml(bc);
			vcii.ImageFormat = ImageFormat.Png;
			this.CreateVerifyCodeImage(vcii);

			return vcii;
		}

		/// <summary>检测验证码是否正确</summary>
		/// <param name="code">要检测的验证码</param>
		/// <returns>指示验证码是否正确</returns>
		public bool CheckCode(string code)
		{
			if(code.IsNullOrEmpty_()) return false;
			var key = WebUtils.GetSession(VERIFY_CODE_KEY);
			if(key.IsNullOrEmpty_()) return false;
			WebUtils.DelSession(VERIFY_CODE_KEY);
			return key.Equals(code, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>创建验证码图片</summary>
		/// <param name="verifyCodeImageInfo">验证码图片信息</param>
		public void CreateVerifyCodeImage(VerifyCodeImageInfo verifyCodeImageInfo)
		{
			int textLength = verifyCodeImageInfo.Text.Length;
			if(textLength == 0 || verifyCodeImageInfo.ImageWidth == 0 || verifyCodeImageInfo.ImageHeight == 0) return;

			using(Bitmap img = new Bitmap(verifyCodeImageInfo.ImageWidth, verifyCodeImageInfo.ImageHeight, PixelFormat.Format32bppArgb))
			{
				using(GraphicsPath p = new GraphicsPath())
				{
					using(Graphics g = Graphics.FromImage(img))
					{
						g.SmoothingMode = SmoothingMode.AntiAlias;
						g.Clear(verifyCodeImageInfo.BackgroundColor);

						int charSize = (int)(Math.Min(verifyCodeImageInfo.ImageHeight, (int)(verifyCodeImageInfo.ImageWidth / textLength)) * 0.8);
						PointF charPoint = new PointF();
						int halfCharSize = (int)(charSize * 0.5f);
						int paddingHeight = (int)(verifyCodeImageInfo.ImageHeight * 0.8) - charSize;

						using(Matrix matrix = new Matrix())
						{
							using(Pen pen = new Pen(Color.Empty))
							{
								using(StringFormat format = new StringFormat())
								{
									format.Alignment = StringAlignment.Near;
									format.LineAlignment = StringAlignment.Near;
									FontFamily f;
									for(int i = 0; i < textLength; i++)
									{
										charPoint.X = (float)(i * charSize + Utils.Rand((int)(charSize * 0.2f), (int)(charSize * 0.8f)));
										charPoint.Y = (float)Utils.Rand(2, paddingHeight);

										p.Reset();
										float fs = charSize * Utils.Rand(80, 120) * 0.01f;
										f = GetFontFamily(verifyCodeImageInfo.Fonts);
										p.AddString(verifyCodeImageInfo.Text[i].ToString(), f, 0, fs, new Point(0, 0), format);

										matrix.Reset();
										matrix.RotateAt((float)Utils.Rand(-60, 60), new PointF(charPoint.X + halfCharSize, charPoint.Y + halfCharSize));
										matrix.Translate(charPoint.X, charPoint.Y);
										p.Transform(matrix);

										pen.Color = GetTextColor(verifyCodeImageInfo.RandomTextColor, verifyCodeImageInfo.TextColor);
										pen.Width = Utils.Rand(1, 2);
										g.DrawPath(pen, p);
										g.DrawBezier(pen,
											Utils.Rand(verifyCodeImageInfo.ImageWidth),
											Utils.Rand(verifyCodeImageInfo.ImageHeight),
											Utils.Rand(verifyCodeImageInfo.ImageWidth),
											Utils.Rand(verifyCodeImageInfo.ImageHeight),
											Utils.Rand(verifyCodeImageInfo.ImageWidth),
											Utils.Rand(verifyCodeImageInfo.ImageHeight),
											Utils.Rand(verifyCodeImageInfo.ImageWidth),
											Utils.Rand(verifyCodeImageInfo.ImageHeight));
									}
								}
								pen.Color = GetTextColor(verifyCodeImageInfo.RandomTextColor, verifyCodeImageInfo.TextColor);
								pen.Width = Utils.Rand(1, 2);
								g.DrawBezier(pen,
									Utils.Rand(verifyCodeImageInfo.ImageWidth),
									0,
									Utils.Rand(verifyCodeImageInfo.ImageWidth),
									Utils.Rand(verifyCodeImageInfo.ImageHeight),
									Utils.Rand(verifyCodeImageInfo.ImageWidth),
									Utils.Rand(verifyCodeImageInfo.ImageHeight),
									Utils.Rand(verifyCodeImageInfo.ImageWidth),
									verifyCodeImageInfo.ImageHeight);
								pen.Width = Utils.Rand(1, 2);
								pen.Color = GetTextColor(verifyCodeImageInfo.RandomTextColor, verifyCodeImageInfo.TextColor);
								g.DrawBezier(pen,
									0,
									Utils.Rand(verifyCodeImageInfo.ImageHeight),
									Utils.Rand(verifyCodeImageInfo.ImageWidth),
									Utils.Rand(verifyCodeImageInfo.ImageHeight),
									Utils.Rand(verifyCodeImageInfo.ImageWidth),
									Utils.Rand(verifyCodeImageInfo.ImageHeight),
									verifyCodeImageInfo.ImageWidth,
									Utils.Rand(verifyCodeImageInfo.ImageHeight));
							}
						}
					}
				}
				verifyCodeImageInfo.ImageData = img.Clone() as Image;
			}
		}

		private Color GetTextColor(bool randColor, Color defColor)
		{
			if(!randColor) return defColor;
			return Color.FromArgb(Utils.Rand(150), Utils.Rand(150), Utils.Rand(150));
		}

		private FontFamily GetFontFamily(FontFamily[] fonts)
		{
			var fs = fonts;
			if(fs.IsNullOrEmpty_())
				fs = MonoVerifyCodeImage.fonts;
			if(fs.Length == 1)
				return fs[0];
			return fs[Utils.Rand(fs.Length - 1)];
		}

		private string GetVerifyCode(int len)
		{
			var code = WebUtils.GetSession(VERIFY_CODE_KEY);
			var times = WebUtils.GetSession(VERIFY_CODE_TIMES).ToInt_() + 1;
			if(times == 1 || times > 5 || code.IsNullOrEmpty_() || code.Length != len)
			{
				times = 1;
				var str = new string[len];
				str[0] = Utils.Rand(1, 9).ToString();
				for(var i = 1; i < len; i++)
					str[i] = Utils.Rand(0, 9).ToString();
				code = str.Join_();
				WebUtils.SetSession(VERIFY_CODE_KEY, code);
			}
			WebUtils.SetSession(VERIFY_CODE_TIMES, times);
			return code;
		}
	}
}