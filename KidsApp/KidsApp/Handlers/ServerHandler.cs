using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KidsApp.Handlers
{
    internal class ServerHandler
    {

        /// <summary>
        /// Method used to post an object to the Web API 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="apiPath"></param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(object obj, Action<HttpResponseMessage> errorMethod, string apiPath = "KidsAppAPI/api/Login") where T : class
        {
            try
            {
                if (obj != null)
                {
                    HttpClient client = new HttpClient()
                    {
                        //IP address for the emulator
                        BaseAddress = new System.Uri("http://169.254.80.80:80/")
                        //IP address for the phone if the device is connected to the computer and used for testing
                        //BaseAddress = new System.Uri("")
                    };

                    string x = client.BaseAddress.ToString();

                    string content = JsonConvert.SerializeObject(obj);
                    HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, apiPath)
                    {
                        Content = new StringContent(content, Encoding.UTF8, "application/json")
                    };

                    HttpResponseMessage response = await client.SendAsync(msg);

                    if (response.IsSuccessStatusCode)
                    {
                        string val = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(val);
                    }
                    else
                    {
                        errorMethod.Invoke(response);
                        return default(T);
                    }
                }
                else
                {
                    errorMethod.Invoke(null);
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                errorMethod.Invoke(null);
                Console.Write(ex);
                return default(T);

            }
        }

        public static async Task<HttpResponseMessage> UploadImageAsync(Stream image, string fileName, string apiPath = "KidsAppAPI/api/AddWord")
        {
            try
            {
                HttpContent fileStreamContent = new StreamContent(image);
                fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "file", FileName = fileName };
                fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                using (HttpClient client = new HttpClient())
                {
                    using (MultipartFormDataContent formData = new MultipartFormDataContent())
                    {
                        formData.Add(fileStreamContent);
                        HttpResponseMessage response = await client.PostAsync(new Uri("http://192.168.137.1:80/" + apiPath), formData);
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static async Task<T> GetAsync<T>(object obj, Action<HttpResponseMessage> errorMethod, string apiPath = "KidsAppAPI/api/ResearcherUser") where T : class
        {
            try
            {
                if (obj != null)
                {
                    HttpClient client = new HttpClient()
                    {
                        //IP address for the emulator
                        //BaseAddress = new System.Uri("http://169.254.80.80:80/")
                        //IP address for the phone
                        BaseAddress = new System.Uri("http://192.168.137.1:80/")
                    };

                    string x = client.BaseAddress.ToString();

                    string content = JsonConvert.SerializeObject(obj);
                    HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, apiPath)
                    {
                        Content = new StringContent(content, Encoding.UTF8, "application/json")
                    };

                    HttpResponseMessage response = await client.SendAsync(msg);

                    if (response.IsSuccessStatusCode)
                    {
                        string val = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(val);
                    }
                    else
                    {
                        errorMethod.Invoke(response);
                        return default(T);
                    }
                }
                else
                {
                    errorMethod.Invoke(null);
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                errorMethod.Invoke(null);
                Console.Write(ex);
                return default(T);

            }
        }

    }

}
