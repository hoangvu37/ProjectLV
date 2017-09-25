/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DrAdviceTmp.cs         
 * Created by           : Auto - 09/11/2017 15:19:55                     
 * Last modify          : Auto - 09/11/2017 15:19:55                     
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
	public partial class DrAdviceTmp : BaseEntity, ICloneable	{
		public DrAdviceTmp()
		{
			this.DrAdvTmpID = 0;
			this.DrID = 0;
			this.V_HCCnslTopic = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DrAdvTmpID", DrAdvTmpID); } }


		private long _DrAdvTmpID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DrAdvTmpID { get { return _DrAdvTmpID; } set {_DrAdvTmpID = value; } }

		private long _DrID;
		[LVRequired]
        public long DrID { get { return _DrID; } set {_DrID = value; } }

		private long? _V_HCCnslTopic;
        public long? V_HCCnslTopic { get { return _V_HCCnslTopic; } set {_V_HCCnslTopic = value; } }

		private string _AdvTmpCode;
		[LVRequired]
        [LVMaxLength(16)]
        public string AdvTmpCode { get { return _AdvTmpCode; } set {_AdvTmpCode = value; } }

		private string _AdvTmpContent;
		[LVRequired]
        [LVMaxLength(1024)]
        public string AdvTmpContent { get { return _AdvTmpContent; } set {_AdvTmpContent = value; } }

		private DateTime? _ModifiedDtm;
        public DateTime? ModifiedDtm { get { return _ModifiedDtm; } set {_ModifiedDtm = value; } }

		/// <summary>
/// Ref Key: FK_DrAdviceTmp_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_DrMedicineAdvice_DrAdviceTmp
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
    public class KeyedDrAdviceTmp : KeyedCollection<KeyValuePair<string, long>, DrAdviceTmp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrAdviceTmp() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DrAdviceTmp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DrAdvTmpID) { return new KeyValuePair<string, long>("DrAdvTmpID", k_DrAdvTmpID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DrAdviceTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DrAdviceTmp item)
        {
            DrAdviceTmp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DrAdviceTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DrAdviceTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DrAdviceTmp GetObjectByKey(long k_DrAdvTmpID) 
		{
            if (this.Contains(GetKey(k_DrAdvTmpID)) == false) return null;
            DrAdviceTmp ob = this[GetKey(k_DrAdvTmpID)];
            return (DrAdviceTmp)ob;
        }

		public DrAdviceTmp GetObjectByKey(long k_DrAdvTmpID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DrAdvTmpID)) == false) {
				DrAdviceTmp ob = repository.GetQuery<DrAdviceTmp>().FirstOrDefault(o => o.DrAdvTmpID == k_DrAdvTmpID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DrAdviceTmp obj = this[GetKey(k_DrAdvTmpID)];
            return (DrAdviceTmp)obj;
        }

		public DrAdviceTmp GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DrAdviceTmp ob = this[keypair];
            return (DrAdviceTmp)ob;
        }

        public DrAdviceTmp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DrAdviceTmp ob = this[GetKey(keypair)];
            return (DrAdviceTmp)ob;
        }

		bool _LoadAll = false;
        public List<DrAdviceTmp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DrAdviceTmp>().ToList();
			foreach (DrAdviceTmp item in list) {
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

        ~KeyedDrAdviceTmp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
