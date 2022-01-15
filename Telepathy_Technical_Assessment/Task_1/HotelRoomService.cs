using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telepathy_Technical_Assessment.Task_1
{
    public class HotelRoomService
    {
        IRoomDataStore DS;

        public HotelRoomService(IRoomDataStore iRoomDataStore)
        {
            DS = iRoomDataStore;
        }

        public string AssignRoom()
        {            
            
            string roomNo = string.Empty;
            
            //get all available rooms
            var availableRooms = DS.GetAllRooms().FindAll(i => i.Status == RoomStatus.Available);

            if (availableRooms.Count > 0)
            {
                Room assignedRoom = null;
                //find nearest available room
                for (int i = 1; i <= availableRooms.Max(m => m.Floor); i++)
                {
                    if (i % 2 != 0)
                        assignedRoom = availableRooms.Where(w => w.Floor == i).OrderBy(o => o.Unit).FirstOrDefault();
                    else
                        assignedRoom = availableRooms.Where(w => w.Floor == i).OrderByDescending(o => o.Unit).FirstOrDefault();
                    
                    if (assignedRoom != null) break;
                }

                assignedRoom.Status = RoomStatus.Occupied;
                DS.UpdateRoom(assignedRoom);

                roomNo = assignedRoom.Floor.ToString() + assignedRoom.Unit;
            }
            
            return roomNo;
        }

        public bool CheckOutRoom(string roomNo)
        {
            var result = false;
            var room = DS.GetRoom(roomNo);
            if (room.Status == RoomStatus.Occupied)
            {
                room.Status = RoomStatus.Vacant;
                DS.UpdateRoom(room);
                result = true;
            }
            return result;
        }

        public bool CleanRoom(string roomNo)
        {
            var result = false;
            var room = DS.GetRoom(roomNo);
            if (room.Status == RoomStatus.Vacant)
            {
                room.Status = RoomStatus.Available;
                DS.UpdateRoom(room);
                result = true;
            }
            return result;
        }

        public bool RepairRoom(string roomNo)
        {
            var result = false;
            var room = DS.GetRoom(roomNo);
            if (room.Status == RoomStatus.Repair)
            {
                room.Status = RoomStatus.Vacant;
                DS.UpdateRoom(room);
                result = true;
            }
            return result;
        }

        public List<Room> GetAllAvailableRooms()
        {
            return DS.GetAllRooms().FindAll(i => i.Status == RoomStatus.Available);
        }

       
    }
}
