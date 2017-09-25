/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EquipHistory.cs         
 * Created by           : Auto - 09/11/2017 15:19:58                     
 * Last modify          : Auto - 09/11/2017 15:19:58                     
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
	public partial class EquipHistory : BaseEntity, ICloneable	{
		public EquipHistory()
		{
			this.EquipMDSrcrID = 0;
			this.EquipHisItemID = 0;
			this.V_ExamRegStatus = 0;
            this.ReasonOrNotes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EquipHisItemID", EquipHisItemID); } }


		private long? _EquipMDSrcrID;
        public long? EquipMDSrcrID { get { return _EquipMDSrcrID; } set {_EquipMDSrcrID = value; } }

		private long _EquipHisItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EquipHisItemID { get { return _EquipHisItemID; } set {_EquipHisItemID = value; } }

		private long _V_ExamRegStatus;
		[LVRequired]
        public long V_ExamRegStatus { get { return _V_ExamRegStatus; } set {_V_ExamRegStatus = value; } }

		private string _ReasonOrNotes;
        [LVMaxLength(1024)]
        public string ReasonOrNotes { get { return _ReasonOrNotes; } set {_ReasonOrNotes = value; } }

		/// <summary>
/// Ref Key: FK_EquipHistory_MedicalEquimentsResources
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
    public class KeyedEquipHistory : KeyedCollection<KeyValuePair<string, long>, EquipHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEquipHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(EquipHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EquipHisItemID) { return new KeyValuePair<string, long>("EquipHisItemID", k_EquipHisItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(EquipHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, EquipHistory item)
        {
            EquipHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(EquipHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(EquipHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public EquipHistory GetObjectByKey(long k_EquipHisItemID) 
		{
            if (this.Contains(GetKey(k_EquipHisItemID)) == false) return null;
            EquipHistory ob = this[GetKey(k_EquipHisItemID)];
            return (EquipHistory)ob;
        }

		public EquipHistory GetObjectByKey(long k_EquipHisItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EquipHisItemID)) == false) {
				EquipHistory ob = repository.GetQuery<EquipHistory>().FirstOrDefault(o => o.EquipHisItemID == k_EquipHisItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            EquipHistory obj = this[GetKey(k_EquipHisItemID)];
            return (EquipHistory)obj;
        }

		public EquipHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            EquipHistory ob = this[keypair];
            return (EquipHistory)ob;
        }

        public EquipHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            EquipHistory ob = this[GetKey(keypair)];
            return (EquipHistory)ob;
        }

		bool _LoadAll = false;
        public List<EquipHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<EquipHistory>().ToList();
			foreach (EquipHistory item in list) {
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

        ~KeyedEquipHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
