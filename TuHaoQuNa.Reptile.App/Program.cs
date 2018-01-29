using DripOldDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuHaoQuNa.Reptile;

namespace TuHaoQuNa.Reptile.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1、采集GaoQing电影数据");
            Console.WriteLine("2、采集GaoQing电视剧数据");
            Console.WriteLine("3、采集爱奇艺电影数据,并采集播放地址");
            Console.WriteLine("4、采集爱奇艺电视剧数据,并采集播放地址");
            Console.WriteLine("5、采集优酷电影数据,并采集播放地址");
            Console.WriteLine("6、采集优酷电视剧数据,并采集播放地址");
            Console.WriteLine("7、采集腾讯电影数据,并采集播放地址");
            Console.WriteLine("8、采集腾讯电视剧数据,并采集播放地址");

            Console.WriteLine("请输入对应的编号:");
            string code = Console.ReadLine();

            switch (code)
            {
                case "1":
                    采集GaoQing电影数据();
                    break;
                case "2":
                    采集GaoQing电视剧数据();
                    break;
                case "3":
                    采集爱奇艺电影数据();
                    break;
                case "4":
                    采集爱奇艺电视剧数据();
                    break;
                case "5":
                    采集优酷电影数据();
                    break;
                case "6":
                    采集优酷电视剧数据();
                    break;
                case "7":
                    采集腾讯电影数据();
                    break;
                case "8":
                    采集腾讯电视剧数据();
                    break;
                default:
                    Console.WriteLine("啥都没选...");
                    break;
            }

            Console.ReadLine();
        }

        static void 采集GaoQing电影数据()
        {
            //while (true)
            //{
                Console.WriteLine("开始采集GaoQing电影数据...");
                new GaoQingCollection().CollectionMovies(TuHaoQuNa.Domain.Enum.Family.电影);
                Console.WriteLine("采集结束...");
                //Console.WriteLine("休息一个小时后继续...");
                //System.Threading.Thread.Sleep(1000*60*60);
            //}
        }

        static void 采集GaoQing电视剧数据()
        {
            //while (true)
            //{
                Console.WriteLine("开始采集GaoQing电视剧数据...");
                new GaoQingCollection().CollectionMovies(TuHaoQuNa.Domain.Enum.Family.电视剧);
                Console.WriteLine("采集结束...");
            //    Console.WriteLine("休息一个小时后继续...");
            //    System.Threading.Thread.Sleep(1000 * 60 * 60);
            //}
        }

        static void 采集爱奇艺电影数据()
        {
            //while (true)
            //{
                Console.WriteLine("开始采集爱奇艺电影数据...");
                new iQiYiCollection().CollectionMovies(TuHaoQuNa.Domain.Enum.Family.电影);
                Console.WriteLine("采集结束...");
            //    Console.WriteLine("休息一个小时后继续...");
            //    System.Threading.Thread.Sleep(1000 * 60 * 60);
            //}
        }

        static void 采集爱奇艺电视剧数据()
        {
            //while (true)
            //{
                Console.WriteLine("开始采集爱奇艺电视剧数据...");
                new iQiYiCollection().CollectionMovies(TuHaoQuNa.Domain.Enum.Family.电视剧);
                Console.WriteLine("采集结束...");
            //    Console.WriteLine("休息一个小时后继续...");
            //    System.Threading.Thread.Sleep(1000 * 60 * 60);
            //}
        }

        static void 采集优酷电影数据()
        {
            //while (true)
            //{
                Console.WriteLine("开始采集优酷电影数据...");
                new YouKuCollection().CollectionMovies(Domain.Enum.Family.电影);
                Console.WriteLine("采集结束...");
            //    Console.WriteLine("休息一个小时后继续...");
            //    System.Threading.Thread.Sleep(1000 * 60 * 60);
            //}
        }

        static void 采集优酷电视剧数据()
        {
            //while (true)
            //{
                Console.WriteLine("开始采集优酷电视剧数据...");
                new YouKuCollection().CollectionMovies(Domain.Enum.Family.电视剧);
                Console.WriteLine("采集结束...");
            //    Console.WriteLine("休息一个小时后继续...");
            //    System.Threading.Thread.Sleep(1000 * 60 * 60);
            //}
        }

        static void 采集腾讯电影数据()
        {
            //while (true)
            //{
                Console.WriteLine("开始采集腾讯电影数据...");
                new QQCollection().CollectionMovies(Domain.Enum.Family.电影);
                Console.WriteLine("采集结束...");
            //    Console.WriteLine("休息一个小时后继续...");
            //    System.Threading.Thread.Sleep(1000 * 60 * 60);
            //}
        }

        static void 采集腾讯电视剧数据()
        {
            //while (true)
            //{
                Console.WriteLine("开始采集腾讯电视剧数据...");
                new QQCollection().CollectionMovies(Domain.Enum.Family.电视剧);
                Console.WriteLine("采集结束...");
            //    Console.WriteLine("休息一个小时后继续...");
            //    System.Threading.Thread.Sleep(1000 * 60 * 60);
            //}
        }
    }
}
