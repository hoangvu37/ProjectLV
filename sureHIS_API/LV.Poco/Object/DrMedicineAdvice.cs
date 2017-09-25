/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DrMedicineAdvice.cs         
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
	public partial class DrMedicineAdvice : BaseEntity, ICloneable	{
		public DrMedicineAdvice()
		{
			this.DMAID = 0;
			this.DrMedTmpID = 0;
			this.DrAdvTmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DMAID", DMAID); } }


		private long _DMAID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DMAID { get { return _DMAID; } set {_DMAID = value; } }

		private long? _DrMedTmpID;
        public long? DrMedTmpID { get { return _DrMedTmpID; } set {_DrMedTmpID = value; } }

		private long? _DrAdvTmpID;
        public long? DrAdvTmpID { get { return _DrAdvTmpID; } set {_DrAdvTmpID = value; } }

		/// <summary>
/// Ref Key: FK_DrMedicineAdvice_DrAdviceTmp
/// <summary>
/// <summary>
/// Ref Key: FK_DrMedicineAdvice_DrMedicineTmp
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
    public class KeyedDrMedicineAdvice : KeyedCollection<KeyValuePair<string, long>, DrMedicineAdvice>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrMedicineAdvice() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DrMedicineAdvice item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DMAID) { return new KeyValuePair<string, long>("DMAID", k_DMAID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DrMedicineAdvice item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DrMedicineAdvice item)
        {
            DrMedicineAdvice orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DrMedicineAdvice item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DrMedicineAdvice item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DrMedicineAdvice GetObjectByKey(long k_DMAID) 
		{
            if (this.Contains(GetKey(k_DMAID)) == false) return null;
            DrMedicineAdvice ob = this[GetKey(k_DMAID)];
            return (DrMedicineAdvice)ob;
        }

		public DrMedicineAdvice GetObjectByKey(long k_DMAID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DMAID)) == false) {
				DrMedicineAdvice ob = repository.GetQuery<DrMedicineAdvice>().FirstOrDefault(o => o.DMAID == k_DMAID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DrMedicineAdvice obj = this[GetKey(k_DMAID)];
            return (DrMedicineAdvice)obj;
        }

		public DrMedicineAdvice GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DrMedicineAdvice ob = this[keypair];
            return (DrMedicineAdvice)ob;
        }

        public DrMedicineAdvice GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DrMedicineAdvice ob = this[GetKey(keypair)];
            return (DrMedicineAdvice)ob;
        }

		bool _LoadAll = false;
        public List<DrMedicineAdvice> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DrMedicineAdvice>().ToList();
			foreach (DrMedicineAdvice item in list) {
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

        ~KeyedDrMedicineAdvice()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
