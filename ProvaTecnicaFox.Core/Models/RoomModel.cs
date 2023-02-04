using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnicaFox.Core.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public RoomType Type { get; set; }
        public int AccomodationId { get; set; }
        public AccomodationModel Accomodation { get; set; }
    }


    public enum RoomType
    {
        Single,
        Double,
        Suite,
        Deluxe
    }
}

