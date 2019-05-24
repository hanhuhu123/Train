using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using Newtonsoft.Json;
using WebApplication2.DAL;

// 短信插件
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {

        Dal dal = new Dal();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        //火车票显示页面
        public ActionResult Train(string start = "上海", string end = "北京", string date = "2019-06-10", string ids = null)
        {
            var classjson = HttpClientHelperh.Sender("Get", "/train/ticket/?appkey=b9a892e2d4da69ab&start=" + start + "&end=" + end + "&date=" + date, null);
            Model12 table = JsonConvert.DeserializeObject<Model12>(classjson);
            string[] str = new string[10];
            var srt = str;
            if (!string.IsNullOrEmpty(ids))
            {
                var list = table.result.list.Where(m => m.trainno.Contains(ids)).ToList();
                table.result.list = list;
                return View(table);
            }
            else
            {
                return View(table);
            }
        }
        //温馨服务
        HttpClientHelp he = new HttpClientHelp("https://api.jisuapi.com/iqa/query");
        public ActionResult Fuwu()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetRoom(string question)
        {
            var result = he.Get("?appkey=91e3c4c10e322f9f&question=" + question);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AuthorizFilter]
        //预定票务信息（客人）
        public ActionResult AddTicket(string Trainno)
        {
            var d = dal.GetTrainCar(Trainno);
            return View(d);
        }

        //火车列车的信息
        [HttpPost]
        public int AddTrainCar(TrainCar tc)
        {
            return dal.AddTrainCar(tc);
        }

        //删除
        public int DelTrainCar(string Trainno)
        {
            return dal.DelTrainCar(Trainno);
        }

        //购票
        
        [HttpPost]
        public int AddIndent(Indent Ix)
        {
            return dal.AddIndent(Ix);
        }

        /// <summary>
        /// 显示订单
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowIndent()
        {
            var id = Convert.ToInt32(Session["id"]);
            var list = dal.GetIndent(id);
            return View(list);
        }

        /// <summary>
        /// 查看订单
        /// </summary>
        public ActionResult ChaKanIndent(int id)
        {
            var list = dal.ChaKanIndent(id);
            return View(list);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <returns></returns>
        public int DelIndent(string ids)
        {
            var n = dal.DelIndent(ids);
            return n;
        }

        //退票
        public int UptIndent(int id)
        {
            var n = dal.UptIndent(id);
            return n;
        }

        //提示退票注意事项
        public ActionResult DelTicket(string id)
        {
            return View();
        }
        
        public ActionResult MainIndex()
        {
            return View();
        }
        // GET: Default
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public void Login(string name, string pwd)
        {
            string i = HttpClientHelper.Sender("get", "api/Default/Login?name=" + name + "&pwd=" + pwd, null);
            List<Register> list = JsonConvert.DeserializeObject<List<Register>>(i);
            if (list.Count() > 0)
            {
                Response.Write("<script>alert('登陆成功');location.href='/Default/Index';</script>");

                Session["name"] = list.FirstOrDefault().Uname;
                Session["id"] = list.FirstOrDefault().Id;
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误');</script>");
            }

        }
        public ActionResult ForgetPwd()
        {
            return View();
        }
        public ActionResult UptPwd()
        {
            return View();
        }
        // 随机获取验证码  6位数字
        public string YanZheng(int num)
        {
            string str = "";
            Random random = new Random();
            str = random.Next(100000, 1000000).ToString();
            return str;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public string SendMsM(string phone = null)
        {
            string code = YanZheng(6);
            Session["yanzheng"] = code;
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "LTAIb5CqZhlpFDjU", "rFp8cdI9lSZE8kJ137uwzwfNUgtF53");
            //IClientProfile profile = DefaultProfile.GetProfile("default", "<accessKeyId>", "<accessSecret>");
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", phone);
            request.AddQueryParameters("SignName", "放心游");
            request.AddQueryParameters("TemplateCode", "SMS_165380814");
            request.AddQueryParameters("TemplateParam", "{\"code\":\"" + code + "\"}");
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
                //return System.Text.Encoding.Default.GetString(response.HttpResponse.Content);
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        // 比较手机验证码
        public int Compto(int num = 0)
        {
            var code = Convert.ToInt32(Session["yanzheng"]);
            if (num == code)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //邮箱验证
        public string EmialYzm(string email)
        {
            string EYzm = MyEMHelper.CreateRadom();
            MyEMHelper.MyEM(email, EYzm);
            return EYzm;
        }


        //支付
        public string Payment(Indent Ix)
        {
            DefaultAopClient client = new DefaultAopClient(BuyConfig.gatewayUrl, BuyConfig.app_id, BuyConfig.private_key, "json", "1.0", BuyConfig.sign_type, BuyConfig.alipay_public_key, BuyConfig.charset, false);

            // 外部订单号，商户网站订单系统中唯一的订单号
            string out_trade_no = DateTime.Now.ToString();

            // 订单名称
            string subject = Ix.Trainno;

            // 付款金额
            int num1 = Ix.ZuoWei.IndexOf('(')+1; 
            int num2 = Ix.ZuoWei.IndexOf('元');
            var price = Ix.ZuoWei.Substring(num1, num2 - num1);
            string total_amout = price.Trim();

            // 商品描述
            string body = DateTime.Now.ToString()+"创建";

            // 组装业务参数model
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();
            model.Body = body;
            model.Subject = subject;
            model.TotalAmount = total_amout;
            model.OutTradeNo = out_trade_no;
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";

            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            // 设置同步回调地址
            request.SetReturnUrl("https://localhost:44338/Default/ShowIndent");
            // 设置异步通知接收地址
            //request.SetNotifyUrl("https://localhost:44338/Default/ShowIndent");
            // 将业务model载入到request
            request.SetBizModel(model);

            AlipayTradePagePayResponse response = null;
            try
            {
                response = client.pageExecute(request, null, "post");
                return (response.Body);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}