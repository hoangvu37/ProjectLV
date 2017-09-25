/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : OperationSchedule.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class OperationSchedule : BaseEntity, ICloneable	{
		public OperationSchedule()
		{
			this.OpSkedID = 0;
            this.OpSkedDesc = null;
            this.AppliedDate = DateTime.Now;
            this.NoEffect = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("OpSkedID", OpSkedID); } }


		private long _OpSkedID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long OpSkedID { get { return _OpSkedID; } set {_OpSkedID = value; } }

		private string _OpSkedCode;
		[LVRequired]
        [LVMaxLength(20)]
        public string OpSkedCode { get { return _OpSkedCode; } set {_OpSkedCode = value; } }

		private string _OpSkedTitle;
		[LVRequired]
        [LVMaxLength(64)]
        public string OpSkedTitle { get { return _OpSkedTitle; } set {_OpSkedTitle = value; } }

		private string _OpSkedDesc;
        [LVMaxLength(128)]
        public string OpSkedDesc { get { return _OpSkedDesc; } set {_OpSkedDesc = value; } }

		private string _YearNumber;
		[LVRequired]
        [LVMaxLength(4)]
        public string YearNumber { get { return _YearNumber; } set {_YearNumber = value; } }

		private DateTime? _AppliedDate;
        public DateTime? AppliedDate { get { return _AppliedDate; } set {_AppliedDate = value; } }

		private bool? _NoEffect;
        public bool? NoEffect { get { return _NoEffect; } set {_NoEffect = value; } }

		/// <summary>
/// Ref Key: FK_AssignmentSchedule_OperationSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_Operations_OperationSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_OpSkedDistibution_OperationSchedule
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
    public class KeyedOperationSchedule : KeyedCollection<KeyValuePair<string, long>, OperationSchedule>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedOperationSchedule() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(OperationSchedule item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_OpSkedID) { return new KeyValuePair<string, long>("OpSkedID", k_OpSkedID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(OperationSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, OperationSchedule item)
        {
            OperationSchedule orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(OperationSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(OperationSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public OperationSchedule GetObjectByKey(long k_OpSkedID) 
		{
            if (this.Contains(GetKey(k_OpSkedID)) == false) return null;
            OperationSchedule ob = this[GetKey(k_OpSkedID)];
            return (OperationSchedule)ob;
        }

		public OperationSchedule GetObjectByKey(long k_OpSkedID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_OpSkedID)) == false) {
				OperationSchedule ob = repository.GetQuery<OperationSchedule>().FirstOrDefault(o => o.OpSkedID == k_OpSkedID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            OperationSchedule obj = this[GetKey(k_OpSkedID)];
            return (OperationSchedule)obj;
        }

		public OperationSchedule GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            OperationSchedule ob = this[keypair];
            return (OperationSchedule)ob;
        }

        public OperationSchedule GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            OperationSchedule ob = this[GetKey(keypair)];
            return (OperationSchedule)ob;
        }

		bool _LoadAll = false;
        public List<OperationSchedule> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<OperationSchedule>().ToList();
			foreach (OperationSchedule item in list) {
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

        ~KeyedOperationSchedule()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
