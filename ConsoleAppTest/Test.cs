using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DripOldDriver;
using DripOldDriver.Data;
using TuHaoQuNa.Domain.Entity;

namespace ConsoleAppTest
{
    public class Test : BaseDal //继承下我封装的BaseDal
    {


        public void InsertMovie()
        {
            //db.Insert()   一样的用法
            //db.Query<>    这些全部都是一样的用法
            db.Insert(new Category_Repository() { Name="动作片", FID = 1 });
            db.Insert("Category", "ID", true, new Category_Repository() { Name = "纪录片", FID = 2 });
            
        }

    }
}
