using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DO;
using BL;
using BO;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //אתחול של רשימה קיימת אל קובץ XML
            List<int> list = new List<int>{1,2,3,4,5,6,7,8,9};
            FileStream file = new FileStream(@"..\..\..\bin\xml\XmlFile.xml", FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(file, list);
            file.Close();
            
            return;

        }
    }
}
