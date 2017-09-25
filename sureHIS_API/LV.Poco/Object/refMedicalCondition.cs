/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refMedicalCondition.cs         
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
	public partial class refMedicalCondition : BaseEntity, ICloneable	{
		public refMedicalCondition()
		{
			this.MCID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MCID", MCID); } }


		private long _MCID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MCID { get { return _MCID; } set {_MCID = value; } }

		private string _MCDescription;
		[LVRequired]
        [LVMaxLength(254)]
        public string MCDescription { get { return _MCDescription; } set {_MCDescription = value; } }

		private string _MedConditionType;
        [LVMaxLength(64)]
        public string MedConditionType { get { return _MedConditionType; } set {_MedConditionType = value; } }

		/// <summary>
/// Ref Key: FK_DonorMedicalConditions_refMedicalConditions
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalConditionRecord_refMedicalCondition
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
    public class KeyedrefMedicalCondition : KeyedCollection<KeyValuePair<string, long>, refMedicalCondition>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefMedicalCondition() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refMedicalCondition item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MCID) { return new KeyValuePair<string, long>("MCID", k_MCID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refMedicalCondition item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refMedicalCondition item)
        {
            refMedicalCondition orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refMedicalCondition item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refMedicalCondition item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refMedicalCondition GetObjectByKey(long k_MCID) 
		{
            if (this.Contains(GetKey(k_MCID)) == false) return null;
            refMedicalCondition ob = this[GetKey(k_MCID)];
            return (refMedicalCondition)ob;
        }

		public refMedicalCondition GetObjectByKey(long k_MCID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MCID)) == false) {
				refMedicalCondition ob = repository.GetQuery<refMedicalCondition>().FirstOrDefault(o => o.MCID == k_MCID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refMedicalCondition obj = this[GetKey(k_MCID)];
            return (refMedicalCondition)obj;
        }

		public refMedicalCondition GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refMedicalCondition ob = this[keypair];
            return (refMedicalCondition)ob;
        }

        public refMedicalCondition GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refMedicalCondition ob = this[GetKey(keypair)];
            return (refMedicalCondition)ob;
        }

		bool _LoadAll = false;
        public List<refMedicalCondition> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refMedicalCondition>().ToList();
			foreach (refMedicalCondition item in list) {
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

        ~KeyedrefMedicalCondition()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
