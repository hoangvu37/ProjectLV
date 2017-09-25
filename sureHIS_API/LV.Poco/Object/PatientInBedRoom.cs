/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientInBedRoom.cs         
 * Created by           : Auto - 09/11/2017 15:20:02                     
 * Last modify          : Auto - 09/11/2017 15:20:02                     
 * Version              : 1.0                                  
 * ============================================================
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using LV.Poco.Validate;

namespace LV.Poco
{
	[Serializable]
	public partial class PatientInBedRoom : BaseEntity, ICloneable	{
		public PatientInBedRoom()
		{
			this.PtInBdRmID = 0;
			this.PtID = 0;
			this.PtBdRmID = 0;
            this.DateStayFrom = DateTime.Now;
            this.DateStayTo = DateTime.Now;
			this.V_HosBedInfoStatus = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtInBdRmID", PtInBdRmID); } }


		private long _PtInBdRmID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtInBdRmID { get { return _PtInBdRmID; } set {_PtInBdRmID = value; } }

		private long _PtID;
		[LVRequired]
        public long PtID { get { return _PtID; } set {_PtID = value; } }

		private long _PtBdRmID;
		[LVRequired]
        public long PtBdRmID { get { return _PtBdRmID; } set {_PtBdRmID = value; } }

		private DateTime _DateStayFrom;
		[LVRequired]
        public DateTime DateStayFrom { get { return _DateStayFrom; } set {_DateStayFrom = value; } }

		private DateTime? _DateStayTo;
        public DateTime? DateStayTo { get { return _DateStayTo; } set {_DateStayTo = value; } }

		private string _PPW;
		[LVRequired]
        public string PPW { get { return _PPW; } set {_PPW = value; } }

		private long? _V_HosBedInfoStatus;
        public long? V_HosBedInfoStatus { get { return _V_HosBedInfoStatus; } set {_V_HosBedInfoStatus = value; } }

		/// <summary>
/// Ref Key: FK_PatientInBedRoom_BedInRoom
/// <summary>


        #endregion

		#region ICloneable Members
        public object Clone()
        {
            return this.MemberwiseClone(); 
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

	}

	[Serializable]
    public class KeyedPatientInBedRoom : KeyedCollection<KeyValuePair<string, long>, PatientInBedRoom>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientInBedRoom() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientInBedRoom item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtInBdRmID) { return new KeyValuePair<string, long>("PtInBdRmID", k_PtInBdRmID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientInBedRoom item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientInBedRoom item)
        {
            PatientInBedRoom orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientInBedRoom item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientInBedRoom item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientInBedRoom GetObjectByKey(long k_PtInBdRmID) 
		{
            if (this.Contains(GetKey(k_PtInBdRmID)) == false) return null;
            PatientInBedRoom ob = this[GetKey(k_PtInBdRmID)];
            return (PatientInBedRoom)ob;
        }

		public PatientInBedRoom GetObjectByKey(long k_PtInBdRmID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtInBdRmID)) == false) {
				PatientInBedRoom ob = repository.GetQuery<PatientInBedRoom>().FirstOrDefault(o => o.PtInBdRmID == k_PtInBdRmID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientInBedRoom obj = this[GetKey(k_PtInBdRmID)];
            return (PatientInBedRoom)obj;
        }

		public PatientInBedRoom GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientInBedRoom ob = this[keypair];
            return (PatientInBedRoom)ob;
        }

        public PatientInBedRoom GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientInBedRoom ob = this[GetKey(keypair)];
            return (PatientInBedRoom)ob;
        }

		bool _LoadAll = false;
        public List<PatientInBedRoom> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientInBedRoom>().ToList();
			foreach (PatientInBedRoom item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
				
        #endregion

        #region Implement interface
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        // Protected implementation of Dispose pattern.
        bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing) {}

            // Free any unmanaged objects here.
            disposed = true;
        }

        ~KeyedPatientInBedRoom()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
