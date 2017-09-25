/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DiagDescribeTmp.cs         
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
	public partial class DiagDescribeTmp : BaseEntity, ICloneable	{
		public DiagDescribeTmp()
		{
			this.DxDTmpID = 0;
            this.Note = null;
			this.EstEmpID = 0;
            this.ModifiedDtm = DateTime.Now;
			this.ParClinExamGroupID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DxDTmpID", DxDTmpID); } }


		private long _DxDTmpID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DxDTmpID { get { return _DxDTmpID; } set {_DxDTmpID = value; } }

		private string _DxDTmpCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string DxDTmpCode { get { return _DxDTmpCode; } set {_DxDTmpCode = value; } }

		private string _DxDTmpName;
		[LVRequired]
        [LVMaxLength(64)]
        public string DxDTmpName { get { return _DxDTmpName; } set {_DxDTmpName = value; } }

		private string _DxDTmpContent;
		[LVRequired]
        [LVMaxLength(1073741823)]
        public string DxDTmpContent { get { return _DxDTmpContent; } set {_DxDTmpContent = value; } }

		private string _Note;
        [LVMaxLength(1024)]
        public string Note { get { return _Note; } set {_Note = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private DateTime? _ModifiedDtm;
        public DateTime? ModifiedDtm { get { return _ModifiedDtm; } set {_ModifiedDtm = value; } }

		private long? _ParClinExamGroupID;
        public long? ParClinExamGroupID { get { return _ParClinExamGroupID; } set {_ParClinExamGroupID = value; } }

		/// <summary>
/// Ref Key: FK_DiagDescribeTmp_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_PatientDiagnosticImaging_DiagDescribeTmp
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
    public class KeyedDiagDescribeTmp : KeyedCollection<KeyValuePair<string, long>, DiagDescribeTmp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDiagDescribeTmp() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DiagDescribeTmp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DxDTmpID) { return new KeyValuePair<string, long>("DxDTmpID", k_DxDTmpID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DiagDescribeTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DiagDescribeTmp item)
        {
            DiagDescribeTmp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DiagDescribeTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DiagDescribeTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DiagDescribeTmp GetObjectByKey(long k_DxDTmpID) 
		{
            if (this.Contains(GetKey(k_DxDTmpID)) == false) return null;
            DiagDescribeTmp ob = this[GetKey(k_DxDTmpID)];
            return (DiagDescribeTmp)ob;
        }

		public DiagDescribeTmp GetObjectByKey(long k_DxDTmpID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DxDTmpID)) == false) {
				DiagDescribeTmp ob = repository.GetQuery<DiagDescribeTmp>().FirstOrDefault(o => o.DxDTmpID == k_DxDTmpID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DiagDescribeTmp obj = this[GetKey(k_DxDTmpID)];
            return (DiagDescribeTmp)obj;
        }

		public DiagDescribeTmp GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DiagDescribeTmp ob = this[keypair];
            return (DiagDescribeTmp)ob;
        }

        public DiagDescribeTmp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DiagDescribeTmp ob = this[GetKey(keypair)];
            return (DiagDescribeTmp)ob;
        }

		bool _LoadAll = false;
        public List<DiagDescribeTmp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DiagDescribeTmp>().ToList();
			foreach (DiagDescribeTmp item in list) {
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

        ~KeyedDiagDescribeTmp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
