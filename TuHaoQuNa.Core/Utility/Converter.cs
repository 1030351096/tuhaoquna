using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TuHaoQuNa.Core.Utility
{
    /// <summary>
    /// 各种值类型转换
    /// </summary>d
    public static class Converter
    {
        /// <summary>
        /// 小数转整数，类似四舍五入
        /// </summary>
        /// <param name="value">小数</param>
        /// <returns>整数</returns>
        public static int ToInt(this decimal value)
        {
            var decimalNum = value - (int)value;
            if (decimalNum >= 0.5m)
                return ((int)value) + 1;
            else
                return (int)value;
        }

        /// <summary>
        /// double转整数，类似四舍五入
        /// </summary>
        /// <param name="value">double</param>
        /// <returns>整数</returns>
        public static int ToInt(this double value)
        {
            return ((decimal)value).ToInt();
        }

        /// <summary>
        /// 将对象转换为Int32类型,转换失败返回0
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str, int defValue)
        {
            Int32.TryParse(str, out defValue);
            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型,转换失败返回0
        /// </summary>
        /// <param name="obj">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object obj)
        {
            return ObjectToInt(obj, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="obj">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object obj, int defValue)
        {
            if (obj == null) return defValue;
            Int32.TryParse(obj.ToString(), out defValue);
            return defValue;
        }

        /// <summary>
        /// 将时间精确到哪个级别
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="cutTicks"></param>
        /// <returns></returns>
        public static DateTime CutOff(this DateTime dateTime, long cutTicks = TimeSpan.TicksPerSecond)
        {
            return new DateTime(dateTime.Ticks - (dateTime.Ticks % cutTicks), dateTime.Kind);
        }

        /// <summary>
        /// 把时间转换成字符串如：2013-08-02
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns></returns>
        public static string ToCnDataString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 把带[/]或空格的日期转换为带[-]的日期
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCnDateString(this string str)
        {
            if (str != null && str.Length > 4)
            {
                if (str.IndexOf('-') == -1)
                {
                    string[] strs = null;
                    if (str.IndexOf('/') == 4)
                        strs = str.Split('/');
                    if (str.IndexOf(' ') == 4)
                        strs = str.Split('/');
                    if (strs != null)
                    {
                        if (strs.Length == 2)
                            str = strs[0] + "-" + (strs[1] != "" ? strs[1].PadLeft(2, '0') : "");
                        else if (strs.Length == 3)
                            str = strs[0] + "-" + (strs[1] != "" ? strs[1].PadLeft(2, '0') : "") + "-" + (strs[2] != "" ? strs[2].PadLeft(2, '0') : "");
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 把时间转换成字符串如：2013-08-02
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns></returns>
        public static string ToCnDataString(this DateTime? dateTime)
        {
            return dateTime == null ? string.Empty : dateTime.Value.ToCnDataString();
        }

        /// <summary>
        /// 小数转成价格，如3.123123会转成3.12
        /// </summary>
        /// <param name="price"></param>
        /// <param name="format">小数位数格式</param>
        /// <returns></returns>
        public static string ToPrice(this decimal price, string format = "0.00")
        {
            return price.ToString(format);
        }

        /// <summary>
        /// 价格区间，会转成如 200-300
        /// </summary>
        /// <param name="fromPrice"></param>
        /// <param name="toPrice"></param>
        /// <returns></returns>
        public static string ToShortPriceRange(this decimal fromPrice, decimal toPrice)
        {
            if (fromPrice == toPrice)
                return fromPrice.ToShortPrice();
            else
                return string.Format("{0}-{1}", fromPrice.ToShortPrice(), toPrice.ToShortPrice());
        }

        /// <summary>
        /// 转成价格，如200.45将转成200.00
        /// </summary>
        /// <param name="price"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static string ToShortPrice(this decimal price, int decimalPlaces = 0)
        {
            return price.ToString("f" + decimalPlaces);
        }
        
        /// <summary>
        /// 转成价格，如"¥200.00"
        /// </summary>
        /// <param name="price"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToCnPrice(this decimal price, string format = "0.00")
        {
            return string.Format("&yen;{0}", price.ToString(format));
        }

        /// <summary>
        /// 人名字只留姓，后面用*填充
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static string ToStar(this string s, int start = 1)
        {
            var sb = new StringBuilder();
            if (String.IsNullOrWhiteSpace(s))
            {
                return "*";
            }
            var firstLetter = s[0];
            var firstIsLetter = 65 < firstLetter && firstLetter < 122;
            if (firstIsLetter)
            {
                var array = s.Split(' ');
                if (array.Length > 1 && array[0].Length <= 10)
                {
                    sb.Append(array[0]);
                    if (!String.IsNullOrWhiteSpace(array[1]))
                    {
                        sb.Append(" ");
                        sb.Append(array[1].Substring(0, 1).ToUpper());
                    }
                    else
                        sb.Append("*");
                }
                else
                {
                    var head = array[0];
                    if (head.Length > 10)
                        head = s.Substring(0, 10);
                    sb.Append(head);
                    sb.Append("*");
                }
            }
            else
            {
                var head = s.Substring(0, start);
                sb.Append(head);
                sb.Append("**");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 小数转评分，如3.6转成4，3.3转成3.5，3转成3
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static double ToScore(this double score)
        {
            var decimalNum = score - (int)score;
            if (0 < decimalNum && decimalNum <= 0.5)
                return ((int)score) + 0.5;
            else if (0 < decimalNum && decimalNum > 0.5)
                return ((int)score) + 1;

            return score;
        }

        /// <summary>
        /// 价钱区间转Tuple，如200-300转成Tuple<200, 300>
        /// </summary>
        /// <param name="priceParam"></param>
        /// <returns></returns>
        public static Tuple<int, int> ToPriceRange(this string priceParam)
        {
            if (priceParam.Contains("-"))
            {
                var rangeArray = priceParam.Split('-');
                if (rangeArray.Length == 2)
                {
                    var priceRange = new Tuple<int, int>(rangeArray[0].ToInt(), rangeArray[1].ToInt());
                    return priceRange;
                }
            }

            return new Tuple<int, int>(0, 0);
        }

        /// <summary>
        /// 日期转当前天，跟今天比，如转成“今天”，“昨天”，不符和就转成如“2012-08-02”
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToDay(this DateTime date)
        {
            string s = "";
            var now = DateTime.Now.Day;
            if (now == date.Day)
            {
                s = "今天";
            }
            else if (now - date.Day == 1)
            {
                s = "昨天";
            }
            else
            {
                s = date.ToString("yyyy-MM-dd");
            }
            return s;
        }

        /// <summary>
        /// 日期转星期几，如"星期日", "星期一"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToWeek(this string date)
        {
            var dayOfWeek = Convert.ToInt32(date.ToDateTime().DayOfWeek);

            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return weekdays[dayOfWeek];
        }

        #region Convert string type to other types
        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static int ToInt(this string s, int defalut = 0)
        {
            int result = defalut;
            if (int.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static bool ToBool(this string s, bool defalut = false)
        {
            bool result = defalut;
            if (bool.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static double ToDouble(this string s, double defalut = 0)
        {
            double result = defalut;
            if (double.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s, decimal defalut = 0)
        {
            decimal result = defalut;
            if (decimal.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转float
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static float ToFloat(this string s, float defalut = 0)
        {
            float result = defalut;
            if (float.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转GUID
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string s)
        {
            Guid result = Guid.Empty;
            if (Guid.TryParse(s, out result))
                return result;
            else
                return Guid.Empty;
        }

        /// <summary>
        /// 字符串转日期
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s, DateTime defalut = new DateTime())
        {
            DateTime result = defalut;
            if (DateTime.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 日期转当前天，跟今天比，如转成“今天”，“昨天”，不符和就转成如“2012-8-2”
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToDate(DateTime date, string format = "yyyy-MM-dd")
        {
            string s = "";
            var now = DateTime.Now.Day;
            if (now == date.Day)
            {
                s = "今天";
            }
            else if (now - date.Day == 1)
            {
                s = "昨天";
            }
            else if (now - date.Day == 2)
            {
                s = "前天";
            }
            else
            {
                s = date.ToString(format);
            }
            return s;
        }

        public static string ToDateTime(DateTime date, string format = "yyyy-MM-dd HH:mm")
        {
            string s = "";
            var now = DateTime.Now;
            if (now.Day == date.Day && now.Hour == date.Hour)
            {
                s = "刚刚";
            }
            else if (now.Day == date.Day && now.Hour - date.Hour >= 1)
            {
                s = string.Format("{0}小时前", now.Hour - date.Hour);
            }
            else if (now.Day == date.Day)
            {
                s = "今天";
            }
            else if (now.Day - date.Day == 1)
            {
                s = "昨天";
            }
            else if (now.Day - date.Day == 2)
            {
                s = "前天";
            }
            else
            {
                s = date.ToString(format);
            }
            return s;
        }

        /// <summary>
        /// 字符串转Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string s) where T : struct
        {
            T result = default(T);
            Enum.TryParse<T>(s, true, out result);
            return result;
        }

        public static object ChangeType(this object value, Type conversionType, bool changeEnum = false)
        {
            if (value == null) return null;
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }

            if (changeEnum)
            {
                if (conversionType.IsEnum)
                {
                    int e = 0;
                    if (int.TryParse(value.ToString(), out e))
                    {
                        string name = Enum.GetName(conversionType, e);
                        if (!string.IsNullOrEmpty(name))
                            return Enum.Parse(conversionType, name);
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }

            if (conversionType == typeof(Int32) && value.ToString() == "")
                value = 0;

            return Convert.ChangeType(value, conversionType);
        }
        #endregion

        //天干
        private static string[] TianGan = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

        //地支
        private static string[] DiZhi = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        //十二生肖
        private static string[] ShengXiao = { "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

        //农历日期
        private static string[] DayName =   {"*","初一","初二","初三","初四","初五",
             "初六","初七","初八","初九","初十",
             "十一","十二","十三","十四","十五",
             "十六","十七","十八","十九","二十",
             "廿一","廿二","廿三","廿四","廿五",
             "廿六","廿七","廿八","廿九","三十"};

        //农历月份
        private static string[] MonthName = { "*", "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };

        //公历月计数天
        private static int[] MonthAdd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        //农历数据
        private static int[] LunarData = {2635,333387,1701,1748,267701,694,2391,133423,1175,396438
            ,3402,3749,331177,1453,694,201326,2350,465197,3221,3402
            ,400202,2901,1386,267611,605,2349,137515,2709,464533,1738
            ,2901,330421,1242,2651,199255,1323,529706,3733,1706,398762
            ,2741,1206,267438,2647,1318,204070,3477,461653,1386,2413
            ,330077,1197,2637,268877,3365,531109,2900,2922,398042,2395
            ,1179,267415,2635,661067,1701,1748,398772,2742,2391,330031
            ,1175,1611,200010,3749,527717,1452,2742,332397,2350,3222
            ,268949,3402,3493,133973,1386,464219,605,2349,334123,2709
            ,2890,267946,2773,592565,1210,2651,395863,1323,2707,265877};
        /// <summary>
        /// 获取对应日期的农历
        /// </summary>
        /// <param name="dtDay">公历日期</param>
        /// <returns></returns>
        public static DateTime ToLunarCalendar(DateTime dtDay)
        {
            string sYear = dtDay.Year.ToString();
            string sMonth = dtDay.Month.ToString();
            string sDay = dtDay.Day.ToString();
            int year;
            int month;
            int day;
            try
            {
                year = int.Parse(sYear);
                month = int.Parse(sMonth);
                day = int.Parse(sDay);
            }
            catch
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
                day = DateTime.Now.Day;
            }

            int nTheDate;
            int nIsEnd;
            int k, m, n, nBit, i;
            string calendar = string.Empty;
            //计算到初始时间1921年2月8日的天数：1921-2-8(正月初一)
            nTheDate = (year - 1921) * 365 + (year - 1921) / 4 + day + MonthAdd[month - 1] - 38;
            if ((year % 4 == 0) && (month > 2))
                nTheDate += 1;
            //计算天干，地支，月，日
            nIsEnd = 0;
            m = 0;
            k = 0;
            n = 0;
            while (nIsEnd != 1)
            {
                if (LunarData[m] < 4095)
                    k = 11;
                else
                    k = 12;
                n = k;
                while (n >= 0)
                {
                    //获取LunarData[m]的第n个二进制位的值
                    nBit = LunarData[m];
                    for (i = 1; i < n + 1; i++)
                        nBit = nBit / 2;
                    nBit = nBit % 2;
                    if (nTheDate <= (29 + nBit))
                    {
                        nIsEnd = 1;
                        break;
                    }
                    nTheDate = nTheDate - 29 - nBit;
                    n = n - 1;
                }
                if (nIsEnd == 1)
                    break;
                m = m + 1;
            }
            year = 1921 + m;
            month = k - n + 1;
            day = nTheDate;
            return DateTime.Parse(year + "-" + month + "-" + day);
        }
    }
}