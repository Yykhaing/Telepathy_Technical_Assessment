using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telepathy_Technical_Assessment.Task_1
{
    public interface IRoomDataStore
    {
        public List<Room> GetAllRooms();

        public bool UpdateRoom(Room room);

        public Room GetRoom(string roomNo);

    }
}
