using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuHaoQuNa.WebApi.Models.Output
{
    /// <summary>
    /// 输出参数
    /// </summary>
    public class OutputParameter
    {
        /// <summary>
        /// 影片
        /// </summary>
        public class Film
        {
            /// <summary>
            /// DouBanID
            /// </summary>  
            public string DouBanID { get; set; }
            /// <summary>
            /// 名称
            /// </summary>  
            public string Name { get; set; }
            /// <summary>
            /// 评分
            /// </summary>  
            public decimal? Score { get; set; }
            /// <summary>
            /// 简介
            /// </summary>  
            public string Describe { get; set; }
            /// <summary>
            /// 1电影,2电视剧
            /// </summary>  
            public int Family { get; set; }
            /// <summary>
            /// 封面
            /// </summary>  
            public string Poster { get; set; }
            /// <summary>
            /// 年份
            /// </summary>  
            public int? Year { get; set; }
        }

        /// <summary>
        /// 预告
        /// </summary>
        public class MoviePreview
        {
            /// <summary>
            /// 标题
            /// </summary>  
            public string Title { get; set; }
            /// <summary>
            /// 图片
            /// </summary>  
            public string Photo { get; set; }
            /// <summary>
            /// 视频
            /// </summary>  
            public string Video { get; set; }
        }
    }
}