/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedImagingRepository.cs         
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
	public partial class MedImagingRepository : BaseEntity, ICloneable	{
		public MedImagingRepository()
		{
			this.PAItemID = 0;
			this.V_MedImageReference = 0;
			this.PtDiagImgID = 0;
            this.V_DocSource = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PAItemID", PAItemID); } }


		private long _PAItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PAItemID { get { return _PAItemID; } set {_PAItemID = value; } }

		private byte _SerialNum;
		[LVRequired]
        public byte SerialNum { get { return _SerialNum; } set {_SerialNum = value; } }

		private string _PAItemName;
		[LVRequired]
        [LVMaxLength(64)]
        public string PAItemName { get { return _PAItemName; } set {_PAItemName = value; } }

		private long _V_MedImageReference;
		[LVRequired]
        public long V_MedImageReference { get { return _V_MedImageReference; } set {_V_MedImageReference = value; } }

		private string _FilePathName;
		[LVRequired]
        [LVMaxLength(256)]
        public string FilePathName { get { return _FilePathName; } set {_FilePathName = value; } }

		private long _PtDiagImgID;
		[LVRequired]
        public long PtDiagImgID { get { return _PtDiagImgID; } set {_PtDiagImgID = value; } }

		private long? _V_DocSource;
        public long? V_DocSource { get { return _V_DocSource; } set {_V_DocSource = value; } }

		/// <summary>
/// Ref Key: FK_MedImagingRepository_PatientDiagnosticImaging
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
    public class KeyedMedImagingRepository : KeyedCollection<KeyValuePair<string, long>, MedImagingRepository>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedImagingRepository() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedImagingRepository item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PAItemID) { return new KeyValuePair<string, long>("PAItemID", k_PAItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedImagingRepository item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedImagingRepository item)
        {
            MedImagingRepository orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedImagingRepository item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedImagingRepository item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedImagingRepository GetObjectByKey(long k_PAItemID) 
		{
            if (this.Contains(GetKey(k_PAItemID)) == false) return null;
            MedImagingRepository ob = this[GetKey(k_PAItemID)];
            return (MedImagingRepository)ob;
        }

		public MedImagingRepository GetObjectByKey(long k_PAItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PAItemID)) == false) {
				MedImagingRepository ob = repository.GetQuery<MedImagingRepository>().FirstOrDefault(o => o.PAItemID == k_PAItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedImagingRepository obj = this[GetKey(k_PAItemID)];
            return (MedImagingRepository)obj;
        }

		public MedImagingRepository GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedImagingRepository ob = this[keypair];
            return (MedImagingRepository)ob;
        }

        public MedImagingRepository GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedImagingRepository ob = this[GetKey(keypair)];
            return (MedImagingRepository)ob;
        }

		bool _LoadAll = false;
        public List<MedImagingRepository> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedImagingRepository>().ToList();
			foreach (MedImagingRepository item in list) {
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

        ~KeyedMedImagingRepository()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
