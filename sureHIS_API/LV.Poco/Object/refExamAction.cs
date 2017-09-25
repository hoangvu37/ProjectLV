/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refExamAction.cs         
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
	public partial class refExamAction : BaseEntity, ICloneable	{
		public refExamAction()
		{
			this.ExamActID = 0;
            this.IsExclusionZone = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ExamActID", ExamActID); } }


		private long _ExamActID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ExamActID { get { return _ExamActID; } set {_ExamActID = value; } }

		private string _ExamActCode;
        [LVMaxLength(7)]
        public string ExamActCode { get { return _ExamActCode; } set {_ExamActCode = value; } }

		private string _ExamActName;
		[LVRequired]
        [LVMaxLength(34)]
        public string ExamActName { get { return _ExamActName; } set {_ExamActName = value; } }

		private string _VNExamActName;
        [LVMaxLength(64)]
        public string VNExamActName { get { return _VNExamActName; } set {_VNExamActName = value; } }

		private bool? _IsExclusionZone;
        public bool? IsExclusionZone { get { return _IsExclusionZone; } set {_IsExclusionZone = value; } }

		/// <summary>
/// Ref Key: FK_BodyRegion_refExamAction
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
    public class KeyedrefExamAction : KeyedCollection<KeyValuePair<string, long>, refExamAction>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefExamAction() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refExamAction item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ExamActID) { return new KeyValuePair<string, long>("ExamActID", k_ExamActID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refExamAction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refExamAction item)
        {
            refExamAction orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refExamAction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refExamAction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refExamAction GetObjectByKey(long k_ExamActID) 
		{
            if (this.Contains(GetKey(k_ExamActID)) == false) return null;
            refExamAction ob = this[GetKey(k_ExamActID)];
            return (refExamAction)ob;
        }

		public refExamAction GetObjectByKey(long k_ExamActID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ExamActID)) == false) {
				refExamAction ob = repository.GetQuery<refExamAction>().FirstOrDefault(o => o.ExamActID == k_ExamActID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refExamAction obj = this[GetKey(k_ExamActID)];
            return (refExamAction)obj;
        }

		public refExamAction GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refExamAction ob = this[keypair];
            return (refExamAction)ob;
        }

        public refExamAction GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refExamAction ob = this[GetKey(keypair)];
            return (refExamAction)ob;
        }

		bool _LoadAll = false;
        public List<refExamAction> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refExamAction>().ToList();
			foreach (refExamAction item in list) {
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

        ~KeyedrefExamAction()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
