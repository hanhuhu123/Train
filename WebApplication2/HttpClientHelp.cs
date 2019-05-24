using System;
using System.Net.Http;
namespace WebApplication2
{
    public class HttpClientHelp
    {
        // 定义个私有字段
        private HttpClient client;

        public HttpClientHelp(string ba)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ba);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        // 添加
        public string Get(string url)
        {
            // 初始化
            string result = "";
            //信息不是实例化  
            //信息要有方法
            HttpResponseMessage msg = client.GetAsync(url).Result;
            if (msg.IsSuccessStatusCode)
            {
                result = msg.Content.ReadAsStringAsync().Result;   
            }
            return result;
        }
        //添加
        public string Post(string url, string data)
        {
            string result = "";
            // 设置头信息 
            HttpContent content = new StringContent(data);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage msg = client.PostAsync(url, content).Result;
            if (msg.IsSuccessStatusCode)
            {
                result = msg.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
        // 删除
        public string   Delete(string url)
        {
            // 初始化
            string result = "";
            //信息不是实例化  
            //信息要有方法
            HttpResponseMessage msg = client.DeleteAsync(url).Result;
            if (msg.IsSuccessStatusCode)
            {
                result = msg.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
        //修改
        public string Put(string url, string data)
        {
            string result = "";
            // 设置头信息 
            HttpContent content = new StringContent(data);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage msg = client.PutAsync(url, content).Result;
            if (msg.IsSuccessStatusCode)
            {
                result = msg.Content.ReadAsStringAsync().Result;
            }
            return result;
        }


    }
}