using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuHaoQuNa.Domain.Enum
{
    /// <summary>
    /// 电影还是电视剧
    /// </summary>
    public enum Family
    {
        电影 = 1,
        电视剧 = 2
    }

    /// <summary>
    /// 预览类型
    /// </summary>
    public enum PreviewType
    {
        预告片 = 1,
        花絮 = 2,
        片段 = 3
    }

    /// <summary>
    /// 排序方式
    /// </summary>
    public enum OrderBy
    {
        影评数量 = 1,
        想看人数 = 2,
        看过人数 = 3,
        在看人数 = 4,
        短评数量 = 5,
        评分人数 = 6,
        豆瓣评分 = 7,
        上映时间 = 8,
        更新时间 = 9
    }
}
