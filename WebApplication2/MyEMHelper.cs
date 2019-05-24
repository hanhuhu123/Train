using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace WebApplication2
{
    public static class MyEMHelper
    {
        public static string CreateRadom()//验证码生成
        {
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < 4; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;

        }
        public static void MyEM(string UserEmail,string Yzm)
        {
            MailMessage mailMessage = new MailMessage();
            //实例化邮件信息类
            mailMessage.From = new MailAddress("1981056174@qq.com");
            mailMessage.To.Add(new MailAddress(UserEmail));
            //写入收件人地址
            mailMessage.Subject = "尊敬的客户您好!";
            //邮件标题
            //验证码
            mailMessage.Body = "欢迎使用放心游，您的验证码是：" + Yzm;
            //主内容
            SmtpClient smtp = new SmtpClient();
            //安全集合
            smtp.Host = "smtp.qq.com";
            //使用邮箱格式 QQ邮箱
            smtp.EnableSsl = true;
            //加密是否开启
            smtp.UseDefaultCredentials = false;
            //是否和请求一起发送
            smtp.Credentials = new NetworkCredential("1981056174@qq.com", "rwmrrctqkxtkfbbd");
            smtp.Send(mailMessage);
            smtp.Dispose();
        }
    }
}
