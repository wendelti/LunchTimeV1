using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DAL
{
    public class Base
    {

        public string servico;

        protected string Salvar<T>(T registro)
        {

            string result;
            string json = JsonConvert.SerializeObject(registro);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://wtcsistemas.com.br/db/index.php/webapp/Add/" + this.servico);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = json.Length;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    //Debug.WriteLine("R : " + result);
                }
            }


            return result;
        }


        protected List<T> Get<T>()
        {
            string result = new WebClient().DownloadString("http://wtcsistemas.com.br/db/index.php/webapp/Get/" + this.servico);
            List<T> ul = JsonConvert.DeserializeObject<List<T>>(result);
            return ul;
        }

        protected bool Delete(int ID)
        {
            string result = new WebClient().DownloadString(string.Format("http://wtcsistemas.com.br/db/index.php/webapp/Get/{0}/{1}", this.servico, ID));
            return true;
        }

    }
}
