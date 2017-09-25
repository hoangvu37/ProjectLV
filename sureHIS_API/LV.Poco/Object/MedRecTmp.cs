/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedRecTmp.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class MedRecTmp : BaseEntity, ICloneable	{
		public MedRecTmp()
		{
			this.MDTmpID = 0;
            this.MDTmpDesc = null;
            this.URLFilePath = null;
            this.Version = null;
            this.MDTmpDetails = null;
			this.V_PageSize = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MDTmpID", MDTmpID); } }


		private long _MDTmpID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MDTmpID { get { return _MDTmpID; } set {_MDTmpID = value; } }

		private string _MDTmpCode;
		[LVRequired]
        [LVMaxLength(6)]
        public string MDTmpCode { get { return _MDTmpCode; } set {_MDTmpCode = value; } }

		private string _MDTmpTitle;
		[LVRequired]
        [LVMaxLength(64)]
        public string MDTmpTitle { get { return _MDTmpTitle; } set {_MDTmpTitle = value; } }

		private string _MDTmpDesc;
        [LVMaxLength(1024)]
        public string MDTmpDesc { get { return _MDTmpDesc; } set {_MDTmpDesc = value; } }

		private string _URLFilePath;
        [LVMaxLength(256)]
        public string URLFilePath { get { return _URLFilePath; } set {_URLFilePath = value; } }

		private string _Version;
        [LVMaxLength(5)]
        public string Version { get { return _Version; } set {_Version = value; } }

		private string _MDTmpDetails;
        [LVMaxLength(2048)]
        public string MDTmpDetails { get { return _MDTmpDetails; } set {_MDTmpDetails = value; } }

		private long? _V_PageSize;
        public long? V_PageSize { get { return _V_PageSize; } set {_V_PageSize = value; } }

		/// <summary>
/// Ref Key: FK_MedRecOutline_MedRecTmp
/// <summary>
/// <summary>
/// Ref Key: FK_SpecMedRecordTemp_MedRecordTemp
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
    public class KeyedMedRecTmp : KeyedCollection<KeyValuePair<string, long>, MedRecTmp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedRecTmp() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedRecTmp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MDTmpID) { return new KeyValuePair<string, long>("MDTmpID", k_MDTmpID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedRecTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedRecTmp item)
        {
            MedRecTmp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedRecTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedRecTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedRecTmp GetObjectByKey(long k_MDTmpID) 
		{
            if (this.Contains(GetKey(k_MDTmpID)) == false) return null;
            MedRecTmp ob = this[GetKey(k_MDTmpID)];
            return (MedRecTmp)ob;
        }

		public MedRecTmp GetObjectByKey(long k_MDTmpID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MDTmpID)) == false) {
				MedRecTmp ob = repository.GetQuery<MedRecTmp>().FirstOrDefault(o => o.MDTmpID == k_MDTmpID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedRecTmp obj = this[GetKey(k_MDTmpID)];
            return (MedRecTmp)obj;
        }

		public MedRecTmp GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedRecTmp ob = this[keypair];
            return (MedRecTmp)ob;
        }

        public MedRecTmp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedRecTmp ob = this[GetKey(keypair)];
            return (MedRecTmp)ob;
        }

		bool _LoadAll = false;
        public List<MedRecTmp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedRecTmp>().ToList();
			foreach (MedRecTmp item in list) {
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

        ~KeyedMedRecTmp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
