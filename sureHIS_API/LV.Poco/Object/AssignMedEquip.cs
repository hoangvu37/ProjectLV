/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AssignMedEquip.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class AssignMedEquip : BaseEntity, ICloneable	{
		public AssignMedEquip()
		{
			this.AMedEquipID = 0;
			this.RoomID = 0;
			this.EquipMDSrcrID = 0;
            this.FromDate = DateTime.Now;
            this.ToDate = DateTime.Now;
            this.V_UsageStatus = null;
            this.V_ReqServices = null;
            this.RecomUses = null;
            this.SupSerDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AMedEquipID", AMedEquipID); } }


		private long _AMedEquipID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AMedEquipID { get { return _AMedEquipID; } set {_AMedEquipID = value; } }

		private long _RoomID;
		[LVRequired]
        public long RoomID { get { return _RoomID; } set {_RoomID = value; } }

		private long _EquipMDSrcrID;
		[LVRequired]
        public long EquipMDSrcrID { get { return _EquipMDSrcrID; } set {_EquipMDSrcrID = value; } }

		private DateTime? _FromDate;
        public DateTime? FromDate { get { return _FromDate; } set {_FromDate = value; } }

		private DateTime? _ToDate;
        public DateTime? ToDate { get { return _ToDate; } set {_ToDate = value; } }

		private long? _V_UsageStatus;
        public long? V_UsageStatus { get { return _V_UsageStatus; } set {_V_UsageStatus = value; } }

		private long? _V_ReqServices;
        public long? V_ReqServices { get { return _V_ReqServices; } set {_V_ReqServices = value; } }

		private string _RecomUses;
        [LVMaxLength(4000)]
        public string RecomUses { get { return _RecomUses; } set {_RecomUses = value; } }

		private string _SupSerDesc;
        [LVMaxLength(2048)]
        public string SupSerDesc { get { return _SupSerDesc; } set {_SupSerDesc = value; } }

		/// <summary>
/// Ref Key: FK_AssignMedEquip_MedicalEquimentsResources
/// <summary>
/// <summary>
/// Ref Key: FK_AssignMedEquip_RoomAllocation
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
    public class KeyedAssignMedEquip : KeyedCollection<KeyValuePair<string, long>, AssignMedEquip>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAssignMedEquip() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AssignMedEquip item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AMedEquipID) { return new KeyValuePair<string, long>("AMedEquipID", k_AMedEquipID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AssignMedEquip item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AssignMedEquip item)
        {
            AssignMedEquip orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AssignMedEquip item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AssignMedEquip item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AssignMedEquip GetObjectByKey(long k_AMedEquipID) 
		{
            if (this.Contains(GetKey(k_AMedEquipID)) == false) return null;
            AssignMedEquip ob = this[GetKey(k_AMedEquipID)];
            return (AssignMedEquip)ob;
        }

		public AssignMedEquip GetObjectByKey(long k_AMedEquipID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AMedEquipID)) == false) {
				AssignMedEquip ob = repository.GetQuery<AssignMedEquip>().FirstOrDefault(o => o.AMedEquipID == k_AMedEquipID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AssignMedEquip obj = this[GetKey(k_AMedEquipID)];
            return (AssignMedEquip)obj;
        }

		public AssignMedEquip GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AssignMedEquip ob = this[keypair];
            return (AssignMedEquip)ob;
        }

        public AssignMedEquip GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AssignMedEquip ob = this[GetKey(keypair)];
            return (AssignMedEquip)ob;
        }

		bool _LoadAll = false;
        public List<AssignMedEquip> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AssignMedEquip>().ToList();
			foreach (AssignMedEquip item in list) {
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

        ~KeyedAssignMedEquip()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
