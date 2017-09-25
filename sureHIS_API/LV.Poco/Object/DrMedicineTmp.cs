/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DrMedicineTmp.cs         
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
	public partial class DrMedicineTmp : BaseEntity, ICloneable	{
		public DrMedicineTmp()
		{
			this.DrMedTmpID = 0;
			this.MedcnID = 0;
			this.DrID = 0;
            this.Note = null;
            this.ModifiedDtm = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DrMedTmpID", DrMedTmpID); } }


		private long _DrMedTmpID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DrMedTmpID { get { return _DrMedTmpID; } set {_DrMedTmpID = value; } }

		private long? _MedcnID;
        public long? MedcnID { get { return _MedcnID; } set {_MedcnID = value; } }

		private long? _DrID;
        public long? DrID { get { return _DrID; } set {_DrID = value; } }

		private string _Note;
        [LVMaxLength(1024)]
        public string Note { get { return _Note; } set {_Note = value; } }

		private DateTime? _ModifiedDtm;
        public DateTime? ModifiedDtm { get { return _ModifiedDtm; } set {_ModifiedDtm = value; } }

		/// <summary>
/// Ref Key: FK_DrMedicineAdvice_DrMedicineTmp
/// <summary>
/// <summary>
/// Ref Key: FK_DrMedicineTmp_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_DrMedicineTmp_Employee
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
    public class KeyedDrMedicineTmp : KeyedCollection<KeyValuePair<string, long>, DrMedicineTmp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrMedicineTmp() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DrMedicineTmp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DrMedTmpID) { return new KeyValuePair<string, long>("DrMedTmpID", k_DrMedTmpID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DrMedicineTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DrMedicineTmp item)
        {
            DrMedicineTmp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DrMedicineTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DrMedicineTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DrMedicineTmp GetObjectByKey(long k_DrMedTmpID) 
		{
            if (this.Contains(GetKey(k_DrMedTmpID)) == false) return null;
            DrMedicineTmp ob = this[GetKey(k_DrMedTmpID)];
            return (DrMedicineTmp)ob;
        }

		public DrMedicineTmp GetObjectByKey(long k_DrMedTmpID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DrMedTmpID)) == false) {
				DrMedicineTmp ob = repository.GetQuery<DrMedicineTmp>().FirstOrDefault(o => o.DrMedTmpID == k_DrMedTmpID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DrMedicineTmp obj = this[GetKey(k_DrMedTmpID)];
            return (DrMedicineTmp)obj;
        }

		public DrMedicineTmp GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DrMedicineTmp ob = this[keypair];
            return (DrMedicineTmp)ob;
        }

        public DrMedicineTmp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DrMedicineTmp ob = this[GetKey(keypair)];
            return (DrMedicineTmp)ob;
        }

		bool _LoadAll = false;
        public List<DrMedicineTmp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DrMedicineTmp>().ToList();
			foreach (DrMedicineTmp item in list) {
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

        ~KeyedDrMedicineTmp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
