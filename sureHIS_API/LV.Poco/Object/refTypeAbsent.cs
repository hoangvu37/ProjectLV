/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refTypeAbsent.cs         
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
	public partial class refTypeAbsent : BaseEntity, ICloneable	{
		public refTypeAbsent()
		{
            this.IsNotEffect = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, byte> Key { get { return new KeyValuePair<string, byte>("TAbsID", TAbsID); } }


		private byte _TAbsID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public byte TAbsID { get { return _TAbsID; } set {_TAbsID = value; } }

		private string _TAbsCode;
		[LVRequired]
        [LVMaxLength(5)]
        public string TAbsCode { get { return _TAbsCode; } set {_TAbsCode = value; } }

		private string _TAbsDesc;
        [LVMaxLength(512)]
        public string TAbsDesc { get { return _TAbsDesc; } set {_TAbsDesc = value; } }

		private bool? _IsNotEffect;
        public bool? IsNotEffect { get { return _IsNotEffect; } set {_IsNotEffect = value; } }

		/// <summary>
/// Ref Key: FK_EmployeeAnnualLeave_refTypeAbsent
/// <summary>
/// <summary>
/// Ref Key: FK_EmployeeLeaveTaken_refTypeAbsent
/// <summary>
/// <summary>
/// Ref Key: FK_EmpWorkSchedule_refTypeAbsent
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
    public class KeyedrefTypeAbsent : KeyedCollection<KeyValuePair<string, byte>, refTypeAbsent>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefTypeAbsent() : base() { }

        protected override KeyValuePair<string, byte> GetKeyForItem(refTypeAbsent item)
        {
            return item.Key;
        }

        public KeyValuePair<string, byte> GetKey(byte k_TAbsID) { return new KeyValuePair<string, byte>("TAbsID", k_TAbsID); }

        public KeyValuePair<string, byte> GetKey(object keypair) { try { return (KeyValuePair<string, byte>)keypair; } catch { return new KeyValuePair<string, byte>(); } }
        #endregion

        #region Method
        public bool AddObject(refTypeAbsent item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, byte> keypair, refTypeAbsent item)
        {
            refTypeAbsent orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refTypeAbsent item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refTypeAbsent item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refTypeAbsent GetObjectByKey(byte k_TAbsID) 
		{
            if (this.Contains(GetKey(k_TAbsID)) == false) return null;
            refTypeAbsent ob = this[GetKey(k_TAbsID)];
            return (refTypeAbsent)ob;
        }

		public refTypeAbsent GetObjectByKey(byte k_TAbsID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_TAbsID)) == false) {
				refTypeAbsent ob = repository.GetQuery<refTypeAbsent>().FirstOrDefault(o => o.TAbsID == k_TAbsID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refTypeAbsent obj = this[GetKey(k_TAbsID)];
            return (refTypeAbsent)obj;
        }

		public refTypeAbsent GetObjectByKey(KeyValuePair<string, byte> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refTypeAbsent ob = this[keypair];
            return (refTypeAbsent)ob;
        }

        public refTypeAbsent GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refTypeAbsent ob = this[GetKey(keypair)];
            return (refTypeAbsent)ob;
        }

		bool _LoadAll = false;
        public List<refTypeAbsent> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refTypeAbsent>().ToList();
			foreach (refTypeAbsent item in list) {
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

        ~KeyedrefTypeAbsent()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
