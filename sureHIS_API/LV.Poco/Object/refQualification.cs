/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refQualification.cs         
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
	public partial class refQualification : BaseEntity, ICloneable	{
		public refQualification()
		{
			this.QualID = 0;
            this.QualDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("QualID", QualID); } }


		private long _QualID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long QualID { get { return _QualID; } set {_QualID = value; } }

		private string _QualCode;
        [LVMaxLength(5)]
        public string QualCode { get { return _QualCode; } set {_QualCode = value; } }

		private string _QualTitle;
		[LVRequired]
        [LVMaxLength(128)]
        public string QualTitle { get { return _QualTitle; } set {_QualTitle = value; } }

		private string _VNQualTitle;
        [LVMaxLength(128)]
        public string VNQualTitle { get { return _VNQualTitle; } set {_VNQualTitle = value; } }

		private string _QualDesc;
        [LVMaxLength(2048)]
        public string QualDesc { get { return _QualDesc; } set {_QualDesc = value; } }

		/// <summary>
/// Ref Key: FK_AdvancedSpecialist_refQualification
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
    public class KeyedrefQualification : KeyedCollection<KeyValuePair<string, long>, refQualification>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefQualification() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refQualification item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_QualID) { return new KeyValuePair<string, long>("QualID", k_QualID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refQualification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refQualification item)
        {
            refQualification orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refQualification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refQualification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refQualification GetObjectByKey(long k_QualID) 
		{
            if (this.Contains(GetKey(k_QualID)) == false) return null;
            refQualification ob = this[GetKey(k_QualID)];
            return (refQualification)ob;
        }

		public refQualification GetObjectByKey(long k_QualID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_QualID)) == false) {
				refQualification ob = repository.GetQuery<refQualification>().FirstOrDefault(o => o.QualID == k_QualID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refQualification obj = this[GetKey(k_QualID)];
            return (refQualification)obj;
        }

		public refQualification GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refQualification ob = this[keypair];
            return (refQualification)ob;
        }

        public refQualification GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refQualification ob = this[GetKey(keypair)];
            return (refQualification)ob;
        }

		bool _LoadAll = false;
        public List<refQualification> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refQualification>().ToList();
			foreach (refQualification item in list) {
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

        ~KeyedrefQualification()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
