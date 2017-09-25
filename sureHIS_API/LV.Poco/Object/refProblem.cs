/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refProblem.cs         
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
	public partial class refProblem : BaseEntity, ICloneable	{
		public refProblem()
		{
			this.PHProbId = 0;
            this.ProbLatin = null;
            this.ProbDesc = null;
			this.H7PHProbType = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PHProbId", PHProbId); } }


		private long _PHProbId;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PHProbId { get { return _PHProbId; } set {_PHProbId = value; } }

		private string _PHProbCode;
		[LVRequired]
        [LVMaxLength(9)]
        public string PHProbCode { get { return _PHProbCode; } set {_PHProbCode = value; } }

		private string _PHProbTitleText;
		[LVRequired]
        [LVMaxLength(256)]
        public string PHProbTitleText { get { return _PHProbTitleText; } set {_PHProbTitleText = value; } }

		private string _ProbLatin;
        [LVMaxLength(128)]
        public string ProbLatin { get { return _ProbLatin; } set {_ProbLatin = value; } }

		private string _ProbDesc;
        [LVMaxLength(1024)]
        public string ProbDesc { get { return _ProbDesc; } set {_ProbDesc = value; } }

		private long? _H7PHProbType;
        public long? H7PHProbType { get { return _H7PHProbType; } set {_H7PHProbType = value; } }

		/// <summary>
/// Ref Key: FK_PatientProblem_RefProblem
/// <summary>
/// <summary>
/// Ref Key: FK_refExamObservation_refProblem
/// <summary>
/// <summary>
/// Ref Key: FK_SymptomIndicator_refProblem
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
    public class KeyedrefProblem : KeyedCollection<KeyValuePair<string, long>, refProblem>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefProblem() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refProblem item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PHProbId) { return new KeyValuePair<string, long>("PHProbId", k_PHProbId); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refProblem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refProblem item)
        {
            refProblem orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refProblem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refProblem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refProblem GetObjectByKey(long k_PHProbId) 
		{
            if (this.Contains(GetKey(k_PHProbId)) == false) return null;
            refProblem ob = this[GetKey(k_PHProbId)];
            return (refProblem)ob;
        }

		public refProblem GetObjectByKey(long k_PHProbId, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PHProbId)) == false) {
				refProblem ob = repository.GetQuery<refProblem>().FirstOrDefault(o => o.PHProbId == k_PHProbId);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refProblem obj = this[GetKey(k_PHProbId)];
            return (refProblem)obj;
        }

		public refProblem GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refProblem ob = this[keypair];
            return (refProblem)ob;
        }

        public refProblem GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refProblem ob = this[GetKey(keypair)];
            return (refProblem)ob;
        }

		bool _LoadAll = false;
        public List<refProblem> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refProblem>().ToList();
			foreach (refProblem item in list) {
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

        ~KeyedrefProblem()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
