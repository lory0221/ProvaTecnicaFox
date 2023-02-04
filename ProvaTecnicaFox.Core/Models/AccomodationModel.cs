using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnicaFox.Core.Models
{
    public class AccomodationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<RoomModel> Rooms { get; set; }
        public PriceModel PriceList { get; set; }
    }


}
