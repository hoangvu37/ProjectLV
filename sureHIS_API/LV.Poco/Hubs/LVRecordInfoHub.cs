using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LV.Poco;
using Microsoft.AspNet.SignalR;

namespace LV.Poco
{
    public delegate void RecordChangedEventHandler (RecordInfo rec);
    public class LVRecordInfoHub : Hub
    {

        public LVRecordInfoHub()
        {
        }

        public void RecordChanged(RecordInfo rec)
        {
            Clients.All.recordChanged(rec);
        }

         //Cập nhật
        public void Update(object obj)
        {
            Clients.All.update(obj);            
        }

        //Xóa
        public void Destroy(object obj)
        {
            Clients.All.destroy(obj);
        }

        //Tạo mới
        public void Create(object obj)
        {
            Clients.All.create(obj);
        }

    }
}