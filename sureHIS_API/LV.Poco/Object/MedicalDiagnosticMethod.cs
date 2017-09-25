/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalDiagnosticMethod.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class MedicalDiagnosticMethod : BaseEntity, ICloneable	{
		public MedicalDiagnosticMethod()
		{
			this.MedDiagMethodID = 0;
            this.MedDiagNote = null;
            this.MedDiagDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedDiagMethodID", MedDiagMethodID); } }


		private long _MedDiagMethodID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedDiagMethodID { get { return _MedDiagMethodID; } set {_MedDiagMethodID = value; } }

		private string _PrefixCode;
		[LVRequired]
        [LVMaxLength(1)]
        public string PrefixCode { get { return _PrefixCode; } set {_PrefixCode = value; } }

		private string _MedDiagNote;
        [LVMaxLength(128)]
        public string MedDiagNote { get { return _MedDiagNote; } set {_MedDiagNote = value; } }

		private string _MedDiagDesc;
        [LVMaxLength(2048)]
        public string MedDiagDesc { get { return _MedDiagDesc; } set {_MedDiagDesc = value; } }

		/// <summary>
/// Ref Key: FK_ParaClinicalExamGroup_MedicalDiagnosticMethod
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
    public class KeyedMedicalDiagnosticMethod : KeyedCollection<KeyValuePair<string, long>, MedicalDiagnosticMethod>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalDiagnosticMethod() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalDiagnosticMethod item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedDiagMethodID) { return new KeyValuePair<string, long>("MedDiagMethodID", k_MedDiagMethodID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalDiagnosticMethod item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalDiagnosticMethod item)
        {
            MedicalDiagnosticMethod orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalDiagnosticMethod item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalDiagnosticMethod item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalDiagnosticMethod GetObjectByKey(long k_MedDiagMethodID) 
		{
            if (this.Contains(GetKey(k_MedDiagMethodID)) == false) return null;
            MedicalDiagnosticMethod ob = this[GetKey(k_MedDiagMethodID)];
            return (MedicalDiagnosticMethod)ob;
        }

		public MedicalDiagnosticMethod GetObjectByKey(long k_MedDiagMethodID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedDiagMethodID)) == false) {
				MedicalDiagnosticMethod ob = repository.GetQuery<MedicalDiagnosticMethod>().FirstOrDefault(o => o.MedDiagMethodID == k_MedDiagMethodID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalDiagnosticMethod obj = this[GetKey(k_MedDiagMethodID)];
            return (MedicalDiagnosticMethod)obj;
        }

		public MedicalDiagnosticMethod GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalDiagnosticMethod ob = this[keypair];
            return (MedicalDiagnosticMethod)ob;
        }

        public MedicalDiagnosticMethod GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalDiagnosticMethod ob = this[GetKey(keypair)];
            return (MedicalDiagnosticMethod)ob;
        }

		bool _LoadAll = false;
        public List<MedicalDiagnosticMethod> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalDiagnosticMethod>().ToList();
			foreach (MedicalDiagnosticMethod item in list) {
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

        ~KeyedMedicalDiagnosticMethod()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
