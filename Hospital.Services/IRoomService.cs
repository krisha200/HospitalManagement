using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IRoomService
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);

        RoomViewModel GetRoomById(int RoomId);

        void UpdateRoom(RoomViewModel room);
        void InsertRoom(RoomViewModel room);
        void DeleteRoom(int id);
    }
}
