/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refReligion.cs         
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
	public partial class refReligion : BaseEntity, ICloneable	{
		public refReligion()
		{
			this.PtReligionID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtReligionID", PtReligionID); } }


		private long _PtReligionID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtReligionID { get { return _PtReligionID; } set {_PtReligionID = value; } }

		private string _PtReligionCode;
		[LVRequired]
        [LVMaxLength(5)]
        public string PtReligionCode { get { return _PtReligionCode; } set {_PtReligionCode = value; } }

		private string _PtReligionName;
		[LVRequired]
        [LVMaxLength(64)]
        public string PtReligionName { get { return _PtReligionName; } set {_PtReligionName = value; } }

		private string _VNPtReligionName;
        [LVMaxLength(64)]
        public string VNPtReligionName { get { return _VNPtReligionName; } set {_VNPtReligionName = value; } }

		/// <summary>
/// Ref Key: FK_Person_refReligion
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
    public class KeyedrefReligion : KeyedCollection<KeyValuePair<string, long>, refReligion>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefReligion() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refReligion item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtReligionID) { return new KeyValuePair<string, long>("PtReligionID", k_PtReligionID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refReligion item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refReligion item)
        {
            refReligion orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refReligion item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refReligion item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refReligion GetObjectByKey(long k_PtReligionID) 
		{
            if (this.Contains(GetKey(k_PtReligionID)) == false) return null;
            refReligion ob = this[GetKey(k_PtReligionID)];
            return (refReligion)ob;
        }

		public refReligion GetObjectByKey(long k_PtReligionID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtReligionID)) == false) {
				refReligion ob = repository.GetQuery<refReligion>().FirstOrDefault(o => o.PtReligionID == k_PtReligionID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refReligion obj = this[GetKey(k_PtReligionID)];
            return (refReligion)obj;
        }

		public refReligion GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refReligion ob = this[keypair];
            return (refReligion)ob;
        }

        public refReligion GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refReligion ob = this[GetKey(keypair)];
            return (refReligion)ob;
        }

		bool _LoadAll = false;
        public List<refReligion> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refReligion>().ToList();
			foreach (refReligion item in list) {
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

        ~KeyedrefReligion()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
