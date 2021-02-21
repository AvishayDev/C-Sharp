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
            //  TimeSpan a = TimeSpan.Zero;
            //  a.Subtract(new TimeSpan(1, 1, 1));

            //IBL Bl = BL.FactoryBL.GetBlInstance();

            List<DO.Bus> list = DS.DataSource.Busses;
            FileStream file = new FileStream(@"..\..\..\bin\xml\BusXml.xml", FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(file, list);
            file.Close();

            List<DO.User> list1 = DS.DataSource.Users;
            file = new FileStream(@"..\..\..\bin\xml\UserXml.xml", FileMode.Create);
            x = new XmlSerializer(list1.GetType());
            x.Serialize(file, list1);
            file.Close();

            List<DO.Trip> list2 = DS.DataSource.Trips;
            file = new FileStream(@"..\..\..\bin\xml\TripXml.xml", FileMode.Create);
            x = new XmlSerializer(list2.GetType());
            x.Serialize(file, list2);
            file.Close();

            List<DO.Station> list3 = DS.DataSource.Stations;
            file = new FileStream(@"..\..\..\bin\xml\StationXml.xml", FileMode.Create);
            x = new XmlSerializer(list3.GetType());
            x.Serialize(file, list3);
            file.Close();

            List<DO.Line> list4 = DS.DataSource.Lines;
            file = new FileStream(@"..\..\..\bin\xml\LineXml.xml", FileMode.Create);
            x = new XmlSerializer(list4.GetType());
            x.Serialize(file, list4);
            file.Close();

            List<DO.LineStation> list5 = DS.DataSource.LineStations;
            file = new FileStream(@"..\..\..\bin\xml\LineStationXml.xml", FileMode.Create);
            x = new XmlSerializer(list5.GetType());
            x.Serialize(file, list5);
            file.Close();
           
          
            List<DO.AdjacentStations> list6 = DS.DataSource.AdjacentStationses;
            file = new FileStream(@"..\..\..\bin\xml\AdjacentStationsXml.xml", FileMode.Create);
            x = new XmlSerializer(list6.GetType());
            x.Serialize(file, list6);
            file.Close();
            
            

            List<DO.BusOnTrip> list7 = DS.DataSource.BussesOnTrip;
            file = new FileStream(@"..\..\..\bin\xml\BusOnTripXml.xml", FileMode.Create);
            x = new XmlSerializer(list7.GetType());
            x.Serialize(file, list7);
            file.Close();

            List<DO.LineTrip> list8 = DS.DataSource.LineTrips;
            file = new FileStream(@"..\..\..\bin\xml\LineTripXml.xml", FileMode.Create);
            x = new XmlSerializer(list8.GetType());
            x.Serialize(file, list8);
            file.Close();

            return;

        }
    }
}
