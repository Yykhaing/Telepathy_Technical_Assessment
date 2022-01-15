using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telepathy_Technical_Assessment.Task_1;
using Moq;
using System.Collections.Generic;

namespace Telepathy_Technical_Assessment_Tests.Task_1
{
    [TestClass]
    public class HotelRoomService_Tests
    {
        

        [TestInitialize]
        public void TestInitialize()
        {
           
        }



        [TestMethod]
        public void AssignRoom_Odd_Floor_Test()
        {
            HotelRoomService roomService;
            var rooms = new List<Room>();
            rooms.Add(new Room() { Floor = 1, Unit = 'A', Status = RoomStatus.Occupied });
            rooms.Add(new Room() { Floor = 1, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 1, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 1, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 1, Unit = 'E', Status = RoomStatus.Available });

            rooms.Add(new Room() { Floor = 2, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'E', Status = RoomStatus.Available });

            rooms.Add(new Room() { Floor = 3, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'E', Status = RoomStatus.Available });

            rooms.Add(new Room() { Floor = 4, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'E', Status = RoomStatus.Available });

            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetAllRooms()).Returns(rooms);

            roomService = new HotelRoomService(mockDS.Object);

            var result  = roomService.AssignRoom();
            var expectedResult = "1B";
            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void AssignRoom_Even_Floor_Test()
        {
            HotelRoomService roomService;
            var rooms = new List<Room>();
            rooms.Add(new Room() { Floor = 1, Unit = 'A', Status = RoomStatus.Occupied });
            rooms.Add(new Room() { Floor = 1, Unit = 'B', Status = RoomStatus.Occupied });
            rooms.Add(new Room() { Floor = 1, Unit = 'C', Status = RoomStatus.Occupied });
            rooms.Add(new Room() { Floor = 1, Unit = 'D', Status = RoomStatus.Occupied });
            rooms.Add(new Room() { Floor = 1, Unit = 'E', Status = RoomStatus.Occupied });

            rooms.Add(new Room() { Floor = 2, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'E', Status = RoomStatus.Occupied });

            rooms.Add(new Room() { Floor = 3, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'E', Status = RoomStatus.Available });

            rooms.Add(new Room() { Floor = 4, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'E', Status = RoomStatus.Available });

            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetAllRooms()).Returns(rooms);

            roomService = new HotelRoomService(mockDS.Object);

            var result = roomService.AssignRoom();
            var expectedResult = "2D";
            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void CheckOutRoom_True_Test()
        {
            HotelRoomService roomService;
            var room = new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Occupied };

            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetRoom("2B")).Returns(room);

            mockDS.Setup(m => m.UpdateRoom(room)).Returns(true);

            roomService = new HotelRoomService(mockDS.Object);

            var result = roomService.CheckOutRoom("2B");
            var expectedResult = true;

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void CheckOutRoom_False_Test()
        {
            HotelRoomService roomService;
            var room = new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Available };

            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetRoom("2B")).Returns(room);

            mockDS.Setup(m => m.UpdateRoom(room)).Returns(false);

            roomService = new HotelRoomService(mockDS.Object);

            var result = roomService.CheckOutRoom("2B");
            var expectedResult = false;

            Assert.AreEqual(expectedResult, result);
        }



        [TestMethod]
        public void CleanRoom_True_Test()
        {
            HotelRoomService roomService;
            var room = new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Vacant };

            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetRoom("2B")).Returns(room);

            mockDS.Setup(m => m.UpdateRoom(room)).Returns(true);

            roomService = new HotelRoomService(mockDS.Object);

            var result = roomService.CleanRoom("2B");
            var expectedResult = true;

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void CleanRoom_False_Test()
        {
            HotelRoomService roomService;
            var room = new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Available };

            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetRoom("2B")).Returns(room);

            mockDS.Setup(m => m.UpdateRoom(room)).Returns(false);

            roomService = new HotelRoomService(mockDS.Object);

            var result = roomService.CleanRoom("2B");
            var expectedResult = false;

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void RepairRoom_True_Test()
        {
            HotelRoomService roomService;
            var room = new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Repair };

            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetRoom("2B")).Returns(room);

            mockDS.Setup(m => m.UpdateRoom(room)).Returns(true);

            roomService = new HotelRoomService(mockDS.Object);

            var result = roomService.RepairRoom("2B");
            var expectedResult = true;

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void RepairRoom_False_Test()
        {
            HotelRoomService roomService;
            var room = new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Available };

            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetRoom("2B")).Returns(room);

            mockDS.Setup(m => m.UpdateRoom(room)).Returns(false);

            roomService = new HotelRoomService(mockDS.Object);

            var result = roomService.RepairRoom("2B");
            var expectedResult = false;

            Assert.AreEqual(expectedResult, result);
        }



        [TestMethod]
        public void GetAllAvailableRooms_Test()
        {
            HotelRoomService roomService;
            var rooms = new List<Room>();
            rooms.Add(new Room() { Floor = 1, Unit = 'A', Status = RoomStatus.Occupied });
            rooms.Add(new Room() { Floor = 1, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 1, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 1, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 1, Unit = 'E', Status = RoomStatus.Available });

            rooms.Add(new Room() { Floor = 2, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 2, Unit = 'E', Status = RoomStatus.Available });
                      
            rooms.Add(new Room() { Floor = 3, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 3, Unit = 'E', Status = RoomStatus.Available });

            rooms.Add(new Room() { Floor = 4, Unit = 'A', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'B', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'C', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'D', Status = RoomStatus.Available });
            rooms.Add(new Room() { Floor = 4, Unit = 'E', Status = RoomStatus.Available });


            Mock<IRoomDataStore> mockDS = new Mock<IRoomDataStore>();
            mockDS.Setup(m => m.GetAllRooms()).Returns(rooms);

            roomService = new HotelRoomService(mockDS.Object);

            var result = roomService.GetAllAvailableRooms();
            var expectedResultCount = 19;
            
            Assert.AreEqual(expectedResultCount, result.Count);
        }

    }
}
