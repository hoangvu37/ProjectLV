/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedLabRepository.cs         
 * Created by           : Auto - 09/11/2017 15:20:00                     
 * Last modify          : Auto - 09/11/2017 15:20:00                     
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
	public partial class MedLabRepository : BaseEntity, ICloneable	{
		public MedLabRepository()
		{
			this.LabItemID = 0;
			this.V_DocType = 0;
			this.V_FormatType = 0;
			this.PtSpecTestID = 0;
            this.V_DocSource = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("LabItemID", LabItemID); } }


		private long _LabItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long LabItemID { get { return _LabItemID; } set {_LabItemID = value; } }

		private string _LabItemName;
		[LVRequired]
        [LVMaxLength(64)]
        public string LabItemName { get { return _LabItemName; } set {_LabItemName = value; } }

		private long _V_DocType;
		[LVRequired]
        public long V_DocType { get { return _V_DocType; } set {_V_DocType = value; } }

		private long _V_FormatType;
		[LVRequired]
        public long V_FormatType { get { return _V_FormatType; } set {_V_FormatType = value; } }

		private string _FilePathName;
		[LVRequired]
        [LVMaxLength(256)]
        public string FilePathName { get { return _FilePathName; } set {_FilePathName = value; } }

		private long _PtSpecTestID;
		[LVRequired]
        public long PtSpecTestID { get { return _PtSpecTestID; } set {_PtSpecTestID = value; } }

		private long? _V_DocSource;
        public long? V_DocSource { get { return _V_DocSource; } set {_V_DocSource = value; } }

		/// <summary>
/// Ref Key: FK_MedLabRepository_TestOnPatientSpecimen
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
    public class KeyedMedLabRepository : KeyedCollection<KeyValuePair<string, long>, MedLabRepository>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedLabRepository() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedLabRepository item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_LabItemID) { return new KeyValuePair<string, long>("LabItemID", k_LabItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedLabRepository item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedLabRepository item)
        {
            MedLabRepository orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedLabRepository item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedLabRepository item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedLabRepository GetObjectByKey(long k_LabItemID) 
		{
            if (this.Contains(GetKey(k_LabItemID)) == false) return null;
            MedLabRepository ob = this[GetKey(k_LabItemID)];
            return (MedLabRepository)ob;
        }

		public MedLabRepository GetObjectByKey(long k_LabItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_LabItemID)) == false) {
				MedLabRepository ob = repository.GetQuery<MedLabRepository>().FirstOrDefault(o => o.LabItemID == k_LabItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedLabRepository obj = this[GetKey(k_LabItemID)];
            return (MedLabRepository)obj;
        }

		public MedLabRepository GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedLabRepository ob = this[keypair];
            return (MedLabRepository)ob;
        }

        public MedLabRepository GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedLabRepository ob = this[GetKey(keypair)];
            return (MedLabRepository)ob;
        }

		bool _LoadAll = false;
        public List<MedLabRepository> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedLabRepository>().ToList();
			foreach (MedLabRepository item in list) {
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

        ~KeyedMedLabRepository()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
