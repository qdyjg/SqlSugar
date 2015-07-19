﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SyntacticSugar;
using SqlSugar;
using Dapper;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace WebTest.lambda
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PerformanceTest pt = new PerformanceTest();
            pt.SetCount(1);//设置循环次数

            pt.Execute(i =>
            {
                ResolveExpress r = new ResolveExpress();
                Expression<Func<Models.InsertTest, bool>> func = x => x.v1.StartsWith("a");
                r.ResolveExpression(func);
                var x2 = 1;

            }, m => { }, "resove");

            pt.Execute(i =>
            {
               // var x = SqlSugarTool.GetWhereByExpression<Models.InsertTest>(it => it.id == i);

            }, m => { }, "sqltool");



            //输出测试页面
            GridView gv = new GridView();
            gv.DataSource = pt.GetChartSource();
            gv.DataBind();
            Form.Controls.Add(gv);
        }
    }
}