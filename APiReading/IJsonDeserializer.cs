using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Classes.APiReading
{
    public interface IJsonDeserializer<T>
    {
        T Deserialize(string Json);
    }
}
