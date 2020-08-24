using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//Internet
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JoyaMovil.Models
{
    class Http
    {
        public async void post(string url, string content, Action<string> methodResponse=null, Action<string> methodError=null)  //Func<string, bool, bool> method
        {
            HttpClient client = new HttpClient();
            
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            try
            {
                var response = await client.PostAsync(url, byteContent).ConfigureAwait(false);
                var result = response.Content.ReadAsStringAsync().Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    if (methodResponse != null)
                        methodResponse(result.ToString());
                    
                }
                else if(methodError != null) {
                    methodError("Error response server estatus: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                methodError(ex.Message);
                if (methodError != null)
                    methodError("Service no found");
            }
            
        }
    }
}
