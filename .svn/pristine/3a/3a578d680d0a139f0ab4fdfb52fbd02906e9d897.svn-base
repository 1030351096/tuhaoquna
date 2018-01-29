using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TuHaoQuNa.Domain.Enum;

namespace TuHaoQuNa.WebApi.Models.Input
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParamsDto
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        [Range(1,100)]
        public int pageSize { get; set; }
    }

    /// <summary>
    /// 获取影片列表参数
    /// </summary>
    public class PageFilmParamsDto : PageParamsDto
    {
        /// <summary>
        /// 排序
        /// </summary>
        [Range(1,9)]
        public OrderBy orderby { get; set; }

        /// <summary>
        /// 电影还是电视剧
        /// </summary>
        [Range(1,2)]
        public Family family { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string genre { get; set; }

        /// <summary>
        /// 制片国家
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string year { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string state { get; set; }
    }

    /// <summary>
    /// 预览参数
    /// </summary>
    public class PreviewParamsDto
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Required]
        public string doubanID { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Range(1, 3)]
        public PreviewType previewtype { get; set; }
    }

    /// <summary>
    /// 资源参数
    /// </summary>
    public class ResourceQuantityParamsDto
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Required]
        public string doubanID { get; set; }
    }
}