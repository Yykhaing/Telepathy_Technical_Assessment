using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telepathy_Technical_Assessment.Task_1;

namespace Telepathy_Technical_Assessment_Tests.Task_1
{
    public class MockRoomDataStore:IRoomDataStore
    {
        private List<Room> Rooms { get; set; }

        public MockRoomDataStore()
        {
            for (int i = 1; i <= 4; i++)
            {
                Rooms.Add(new Room() { Floor = i, Unit = 'A', Status= RoomStatus.Available });
                Rooms.Add(new Room() { Floor = i, Unit = 'B', Status = RoomStatus.Available });
                Rooms.Add(new Room() { Floor = i, Unit = 'C', Status = RoomStatus.Available });
                Rooms.Add(new Room() { Floor = i, Unit = 'D', Status = RoomStatus.Available });
                Rooms.Add(new Room() { Floor = i, Unit = 'E', Status = RoomStatus.Available });
            }
        }

        public List<Room> GetAllRooms()
        {
            return Rooms;
        }


        public bool UpdateRoom(Room room)
        {
            var roomToupdate = Rooms.Find(i => i.Id == room.Id);
            roomToupdate = room;
            return true;
        }

        public Room GetRoom(string roomNo)
        {
            Room room = null;

            char[] roomNoArray= roomNo.ToArray();
            if (roomNoArray.Length > 0)
            {
                room = Rooms.Find(i => i.Floor == Convert.ToInt32(roomNoArray[0]) && i.Unit == roomNoArray[1]);
            }
            return room;
        }
    }
}
