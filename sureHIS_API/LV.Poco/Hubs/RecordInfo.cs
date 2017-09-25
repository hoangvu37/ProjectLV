 using System;
 using System.Collections.Generic;
 using System.Data;
 using System.ComponentModel;
 using System.Drawing;
 using System.Text;
using LV.Core.DAL.EntityFramework;

namespace LV.Poco
 {

     [Serializable]
     public enum ActionRec
     {
         None,
         Insert,
         Delete,
         Update,
         Enable,
         Disable
     }

	 [Serializable]
	 public class RecordInfo : ICloneable
 	 {
         public RecordInfo() {
             _ID = Guid.NewGuid();
             m_DateModify = DateTime.Now;
             m_TableName = "";
             _SessionID = "";
             m_UserLogin = "";

         }
         
         public RecordInfo(DBChangeTrackerInfo db, object keypair)
         {
             _ID = Guid.NewGuid();
             _SessionID = "";
             m_UserLogin = "";
             entityKey = keypair;
             m_DateModify = DateTime.Now;
             m_TableName = db.EntityKey.TblName;
             currentValues = db.Entity;
             state = db.State;
             m_Token = System.Web.HttpContext.Current.Request.Headers["Authorization"];
             if (db.ListRecordChanged != null)
                 listRecordChanged = new List<DbRecordChangedInfo>(db.ListRecordChanged);
         }

         private Guid _ID;
         public Guid ID { get { return _ID; } set { _ID = value; } }

         private string _SessionID = "";
         public string SessionID { get { return _SessionID; } set { _SessionID = value; } }
         
         object entityKey;
         public object EntityKey { get { return entityKey; } set { entityKey = value; } }

         object currentValues;
         public object CurrentValues { get { return currentValues; } set { currentValues = value; } }

         object originalValues;
         public object OriginalValues { get { return originalValues; } set { originalValues = value; } }

         List<DbRecordChangedInfo> listRecordChanged;
         public List<DbRecordChangedInfo> ListRecordChanged { get { return listRecordChanged; } set { listRecordChanged = value; } }

         string _Hostname = "", _IPAddress = "";
         public string HostName { get { return _Hostname; } set { _Hostname = value; } }
         public string IPAddress { get { return _IPAddress; } set { _IPAddress = value; } }

         private string m_UserLogin;
         public string UserLogin { set { m_UserLogin = value; } get { return m_UserLogin; } }


         private DateTime m_DateModify;
         public DateTime DateModify {  set {m_DateModify = value;} get {return m_DateModify;} }

         System.Data.Entity.EntityState state;
         public System.Data.Entity.EntityState State { get { return state; } set { state = value; } }

         private string m_TableName;
         public string TableName {  set {m_TableName = value;} get {return m_TableName;} }

        private string m_Token;
        public string Token { set { m_Token = value; } get { return m_Token; } }
        public override string ToString() {
			 return TableName;
		 }

         public object Clone()
         {
             return this.MemberwiseClone();
         }
     }


 }