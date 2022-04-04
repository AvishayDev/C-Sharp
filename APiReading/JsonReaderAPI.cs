using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Classes;

namespace WindowsProject.Classes.APiReading
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

            if (!CanRead())
                return default;


            // TODO: add cancel option after 10 sec
            // TODO: try-catch for all and delete "CanRead"

            // ask for Json
            var Json = await ApiClient.HttpClient.GetStringAsync(this.JsonQuary);

            //reset the json for next call
            this.JsonQuary = "";

            //return final variable
            return jsonDeserialize == null ? JsonConvert.DeserializeObject<T>(Json) : jsonDeserialize.Deserialize(Json);
        }

        

        private bool CanRead()
        {
            return JsonQuary.Contains("https://") || JsonQuary.Contains("http://");
        }

    }
}
