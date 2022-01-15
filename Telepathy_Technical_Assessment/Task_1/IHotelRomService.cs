using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telepathy_Technical_Assessment.Task_1
{
    interface IHotelRomService
    {
        int AssignRoom();

        bool CheckOutRoom(int RoomId);

        bool CleanRoom(int RoomId);

        bool RepairRoom(int RoomId);

        bool GetAllAvailableRooms();

    }
}
