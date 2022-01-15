using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telepathy_Technical_Assessment.Task_1
{
    public class Room
    {
        public int Id { get; set; }

        public int Floor { get; set; }

        public char Unit { get; set; }

        public RoomStatus Status { get; set; }


    }

    public enum RoomStatus 
    { 
        Available,
        Occupied,
        Vacant,
        Repair
    }
}
