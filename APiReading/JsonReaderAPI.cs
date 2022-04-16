using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiReading
{

    public abstract class JsonReaderAPi
    {

        protected string JsonQuary = "";

        protected readonly string APIKey;

        public JsonReaderAPi(string ApiKey)
        {
            APIKey = ApiKey;
        }

        protected abstract void AddDefaultParameters();


        public virtual void AddParameter(string parameterName, object parameterValue)
        {
            JsonQuary += $"{parameterName}={parameterValue}&";
        }

        public virtual void AddQuary(string Quary)
        {
            JsonQuary += Quary + "?";
        }

        public static async Task<T> GetJsonRead<T>(string JsonQuary, IJsonDeserializer<T> jsonDeserializer = null)
        {
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

                
                //return final variable
                return jsonDeserializer == null ? JsonConvert.DeserializeObject<T>(Json) : jsonDeserializer.Deserialize(Json);
            }
            catch
            {
                Console.WriteLine("Something Went Wrong.. Please Try Again.");
                return default;
            }
        }

        public async Task<T> ReadJson<T>(IJsonDeserializer<T> jsonDeserializer = null)
        {
            AddDefaultParameters();

            T returnValue = await GetJsonRead(JsonQuary, jsonDeserializer);
            
            //reset the json for next call
            JsonQuary = "";

            return returnValue;
        }
    }
}
