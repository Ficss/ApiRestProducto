using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    public class RestHelper
    {
        private static readonly string baseURL = "https://localhost:44332/api/";
        public static async Task<string> GetAll(string controller)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + controller))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }


            }
            return string.Empty;
        }

        public static async Task<string> GetId(string controller, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + controller + "/"+ id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }


            }
            return string.Empty;
        }

        public static async Task<string> Post(string controller, string name)
        {
            var inputData = new Dictionary<string,string>
            {
                {"nombre", name }
            };
            var input = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(baseURL + controller, input ))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }


            }
            return string.Empty;
        }
    }

}
