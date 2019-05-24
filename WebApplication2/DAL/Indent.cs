using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.DAL
{
    public class Indent
    {
        public int Id { get; set; }//编号
        public string Name { get; set; }//姓名
		public string IdCard { get; set; }//身份证
		public string Trainno { get; set; }//车次
		public string Phone { get; set; }//手机号
		public string Startdate { get; set; }//发车日期
		public string Station { get; set; }//出发站
		public string Endstation { get; set; }//到达站
		public string Departuretime { get; set; }//开始时间
		public string ZuoWei { get; set; }//座位
		public string IndentState { get; set; }//订单状态
        public int Register_Id { get; set; }//用户id
    }
}