using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Model12
    {
        public string status { get; set; }
        public string msg { get; set; }
        public _M3 result { get; set; }
    }

    public class _M3
    {
        public string date { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public List<_M4> list { get; set; }
    }
    public class _M4
    {
        /// <summary>
        /// 车号
        /// </summary>
        public string trainno { get; set; } //车次
        public string station { get; set; }  //出发站
        public string endstation { get; set; } //到达站
        public string departuretime { get; set; } //开始时间
        public string arrivaltime { get; set; }  //结束时间
        public int day { get; set; } //历时
        public string costtime { get; set; }// 总耗时
        public string startdate { get; set; }//出发日期

        //商务
        public string pricesw { get; set; }
        public string numsw { get; set; }

        //特等
        public string pricetd { get; set; }
        public string numtd { get; set; }

        //一等座
        public string pricerz { get; set; }
        public string numyd { get; set; }


        //二等座
        public string priceyz { get; set; }
        public string numed { get; set; }


        //软座数量
        public string pricerz1 { get; set; }
        public string numrz { get; set; }


        //硬座数量
        public string priceyz1 { get; set; }
        public string numyz { get; set; }


        //高级软卧数量
        public string pricegr1 { get; set; }
        public string numgr { get; set; }


        //软卧数量
        public string pricerw1 { get; set; }
        public string numrw { get; set; }


        //硬卧数量
        public string priceyw1 { get; set; }
        public string numyw { get; set; }


        //无座数量
        public string pricey2 { get; set; }
        public string numwz { get; set; }

        //其他数量
        public string numqt { get; set; }

    }
}