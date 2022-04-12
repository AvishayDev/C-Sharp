using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiReading
{

    public class JsonReaderAPi
    {

        protected string JsonQuary = "";

        protected readonly string APIKey;

        public JsonReaderAPi(string ApiKey)
        {
            APIKey = ApiKey;
        }

        protected virtual void AddDefaultParameters() { }


        public virtual void AddParameter(string parameterName, object parameterValue)
        {
            JsonQuary += $"{parameterName}={parameterValue}&";
        }

        public virtual void AddQuary(string Quary)
        {
            JsonQuary += Quary + "?";
        }

        public async Task<T> ReadJson<T>(string JsonQuary = "", IJsonDeserializer<T> jsonDeserialize = null)
        {
           if (JsonQuary != "")
                this.JsonQuary = JsonQuary;
            else
                AddDefaultParameters();


            try
            {
               // ask for Json
                string Json = "";
                bool success = false;

                await Task.Run(() =>
                {
                    Parallel.Invoke(() =>
                    {
                        // for no internet connection
                        // or bad Json quary
                        Thread.Sleep(5000);
                        if (!success)
                            throw new Exception();
                    }, async () =>
                    {
                        Json = await ApiClient.HttpClient.GetStringAsync(JsonQuary);
                        success = true;
                    });
                });

                //reset the json for next call
                this.JsonQuary = "";

                //return final variable
                return jsonDeserialize == null ? JsonConvert.DeserializeObject<T>(Json) : jsonDeserialize.Deserialize(Json);
            }
            catch
            {
                Console.WriteLine("Something Went Wrong.. Please Try Again.");
                return default;
            }          
            
    }
}
