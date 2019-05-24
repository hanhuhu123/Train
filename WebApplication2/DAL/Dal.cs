using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DAL;
namespace WebApplication2.DAL
{
    public class Dal
    {

        //获取接口中的数据添加到数据库
        public int AddTrainCar(TrainCar tc)
        {
            string sql = string.Format("insert into TrainCar values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}')", tc.Startdate, tc.Trainno, tc.Station, tc.Endstation, tc.Departuretime, tc.Arrivaltime, tc.Costtime, tc.Pricesw, tc.Numsw, tc.Pricetd, tc.Numtd, tc.Pricerz, tc.Numyd, tc.Priceyz, tc.Numed, tc.Pricerz1, tc.Numrz, tc.Priceyz1, tc.Numyz, tc.Pricegr1, tc.Numgr, tc.Pricerw1, tc.Numrw, tc.Priceyw1, tc.Numyw, tc.Pricey2, tc.Numwz, tc.Numqt,tc.IndentState="未支付");

            var result = DBHelper.ExecuteNonQuery(sql);
            return result;
        }

        //显示查询
        public List<TrainCar>  GetTrainCar(string Trainno)
        {
            string sql = string.Format("select * from TrainCar where Trainno ='{0}'", Trainno);
            var table = DBHelper.GetDataTable(sql);
            var list = DBHelper.ConvertTableToList<List<TrainCar>>(table);
            return list;
        }

        //删除
        public int DelTrainCar(string Trainno)
        {
            string sql= string.Format("delete  from  TrainCar where Trainno ='{0}'", Trainno);
            var result = DBHelper.ExecuteNonQuery(sql);
            return result;
        }

        //购票
        public int AddIndent(Indent Ix)
        {
            string sql = string.Format("insert into Indent(Name,IdCard,Phone,Trainno,Startdate,Station,Endstation,Departuretime,ZuoWei,IndentState,Register_Id) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", Ix.Name, Ix.IdCard, Ix.Phone, Ix.Trainno, Ix.Startdate, Ix.Station, Ix.Endstation, Ix.Departuretime, Ix.ZuoWei, Ix.IndentState,Ix.Register_Id);
            var result = DBHelper.ExecuteNonQuery(sql);
            return result;
        }

		//显示订单
		public List<Indent> GetIndent(int id)
		{
			string str = "select * from Indent where Register_Id = " + id;  
            var tab = DBHelper.GetDataTable(str);
			var list = DBHelper.ConvertTableToList<List<Indent>>(tab);
			return list;
		}

		//查看订单
		public List<Indent> ChaKanIndent(int id)
		{
			string str = "select * from Indent where Id = " + id;
			var tab = DBHelper.GetDataTable(str);
			var list = DBHelper.ConvertTableToList<List<Indent>>(tab);
			return list;
		}

		//删除订单
		public int DelIndent(string ids)
		{
			string str = "delete from Indent where Id in (" + ids + ")";
			var n = DBHelper.ExecuteNonQuery(str);
			return n;
		}

		//退票
		public int UptIndent(int id)
		{
			string str = "update Indent set IndentState = '已退票' where Id = " + id;
            int n = DBHelper.ExecuteNonQuery(str);
			return n;
		}

	}
}