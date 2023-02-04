using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnicaFox.Core.Models
{
    public class AccomodationModel
    {
        public int AccomodationId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<RoomType> Rooms { get; set; }
        public List<Dictionary<RoomType, float>> PriceList { get; set; }

        public AccomodationModel()
        {

            PriceList = new List<Dictionary<RoomType, float>>
            {
                new Dictionary<RoomType, float>() {{RoomType.Single, 10 }},
                new Dictionary<RoomType, float>() {{RoomType.Double, 15 }},
                new Dictionary<RoomType, float>() {{RoomType.Suite, 25 }},
                new Dictionary<RoomType, float>() {{RoomType.Deluxe, 40 }}
            };
        }

    }

    public class PriceList
    {
        public float singlePrice { get; set; }
        public float doublePrice { get; set; }
        public float suitePrice { get; set; }
        public float deluxePrice { get; set; }

        public PriceList()
        {
            singlePrice= 10;
            doublePrice= 15;
            suitePrice= 25;
            deluxePrice= 40;

        }
    }
}
