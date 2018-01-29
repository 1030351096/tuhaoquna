using Amib.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuHaoQuNa.Core.AsynBackground
{
    /// <summary>
    /// 异步线程池
    /// </summary>
    public class AsynBackground
    {
        #region 单件模式
        private static readonly object SyncObject = new object();
        private static AsynBackground _singleton;
        /// <summary>
        /// 单件对象
        /// </summary>
        public static AsynBackground Instance
        {
            get
            {
                if (null == _singleton)
                {
                    lock (SyncObject)
                    {
                        _singleton = new AsynBackground();
                    }
                }
                return _singleton;
            }
        }

        #endregion

        #region 线程方面的变量和对象
        /// <summary>
        /// 线程空闲超时时间（单位：秒）
        /// </summary>
        private int _idleTimeout = 60;
        /// <summary>
        /// 最大线程数
        /// </summary>
        private int _maxWorkerThreads = 100;
        /// <summary>
        /// 最小线程数
        /// </summary>
        private int _minWorkerThreads = 0;
        /// <summary>
        /// 主线程池对象
        /// </summary>
        private SmartThreadPool _smartThreadPool = null;
        private IWorkItemsGroup _workItemsGroup = null;
        #endregion

        #region 启动业务
        /// <summary>
        /// 后台消息业务处理对象启动
        /// </summary>
        /// <returns></returns>
        public bool InitServer()
        {
            try
            {
                //获取线程空闲超时时间（单位：秒）、最大线程数
                _idleTimeout = 10;
                _maxWorkerThreads = 10;
            }
            catch (Exception ex)
            {

                //写日志（预留），不退出

            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                STPStartInfo stpStartInfo = new STPStartInfo();
                stpStartInfo.IdleTimeout = _idleTimeout * 2000;
                stpStartInfo.MaxWorkerThreads = _maxWorkerThreads;
                stpStartInfo.MinWorkerThreads = _minWorkerThreads;
                stpStartInfo.PerformanceCounterInstanceName = "Pool";
                _smartThreadPool = new SmartThreadPool(stpStartInfo);
                _workItemsGroup = _smartThreadPool;
                //线程池启动成功，写日志（预留）
                return true;
            }
            catch (Exception ex)
            {
                //Helper.Log.SaveException("Exception", ex);
                //写日志（预留）

                return false;
            }
        }
        #endregion

        #region 对外统一业务调用接口
        /// <summary>
        /// 后台业务处理推送统一调用接口
        /// 未持久化，可能出现丢失
        /// </summary>
        /// <param name="func">委托方法</param>
        /// <param name="workItemPriority">任务等级，默认的是正常</param>
        public void Push(Amib.Threading.Action func, WorkItemPriority workItemPriority = WorkItemPriority.Normal)
        {
            _workItemsGroup.QueueWorkItem(func, workItemPriority);

        }

        #endregion
    }
}
