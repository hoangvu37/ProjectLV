/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refExamObservation.cs         
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
	public partial class refExamObservation : BaseEntity, ICloneable	{
		public refExamObservation()
		{
			this.HExmFindingID = 0;
			this.ExamActID = 0;
            this.SymptomID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HExmFindingID", HExmFindingID); } }


		private long _HExmFindingID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HExmFindingID { get { return _HExmFindingID; } set {_HExmFindingID = value; } }

		private string _HExmFindingCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string HExmFindingCode { get { return _HExmFindingCode; } set {_HExmFindingCode = value; } }

		private string _HExmFindingName;
		[LVRequired]
        [LVMaxLength(84)]
        public string HExmFindingName { get { return _HExmFindingName; } set {_HExmFindingName = value; } }

		private string _VNHExmFindingName;
        [LVMaxLength(128)]
        public string VNHExmFindingName { get { return _VNHExmFindingName; } set {_VNHExmFindingName = value; } }

		private long _ExamActID;
		[LVRequired]
        public long ExamActID { get { return _ExamActID; } set {_ExamActID = value; } }

		private long? _SymptomID;
        public long? SymptomID { get { return _SymptomID; } set {_SymptomID = value; } }

		/// <summary>
/// Ref Key: FK_PhysicalExamination_RefExamObservation
/// <summary>
/// <summary>
/// Ref Key: FK_refExamObservation_refProblem
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
    public class KeyedrefExamObservation : KeyedCollection<KeyValuePair<string, long>, refExamObservation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefExamObservation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refExamObservation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HExmFindingID) { return new KeyValuePair<string, long>("HExmFindingID", k_HExmFindingID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refExamObservation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refExamObservation item)
        {
            refExamObservation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refExamObservation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refExamObservation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refExamObservation GetObjectByKey(long k_HExmFindingID) 
		{
            if (this.Contains(GetKey(k_HExmFindingID)) == false) return null;
            refExamObservation ob = this[GetKey(k_HExmFindingID)];
            return (refExamObservation)ob;
        }

		public refExamObservation GetObjectByKey(long k_HExmFindingID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HExmFindingID)) == false) {
				refExamObservation ob = repository.GetQuery<refExamObservation>().FirstOrDefault(o => o.HExmFindingID == k_HExmFindingID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refExamObservation obj = this[GetKey(k_HExmFindingID)];
            return (refExamObservation)obj;
        }

		public refExamObservation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refExamObservation ob = this[keypair];
            return (refExamObservation)ob;
        }

        public refExamObservation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refExamObservation ob = this[GetKey(keypair)];
            return (refExamObservation)ob;
        }

		bool _LoadAll = false;
        public List<refExamObservation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refExamObservation>().ToList();
			foreach (refExamObservation item in list) {
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

        ~KeyedrefExamObservation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
