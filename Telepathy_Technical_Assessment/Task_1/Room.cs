using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telepathy_Technical_Assessment.Task_1
{
    class Room
    {
        public int RoomId { get; set; }
        public RoomStatus Status { get; set; }

    }

    enum RoomStatus 
    { 
        Available,
        Occupied,
        Vacant,
        Repair
    }
}
