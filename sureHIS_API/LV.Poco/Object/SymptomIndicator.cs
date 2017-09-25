/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : SymptomIndicator.cs         
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
	public partial class SymptomIndicator : BaseEntity, ICloneable	{
		public SymptomIndicator()
		{
			this.SxIndicatorID = 0;
			this.ICDID = 0;
			this.PHProbID = 0;
            this.Note = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SxIndicatorID", SxIndicatorID); } }


		private long _SxIndicatorID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SxIndicatorID { get { return _SxIndicatorID; } set {_SxIndicatorID = value; } }

		private long _ICDID;
		[LVRequired]
        public long ICDID { get { return _ICDID; } set {_ICDID = value; } }

		private long _PHProbID;
		[LVRequired]
        public long PHProbID { get { return _PHProbID; } set {_PHProbID = value; } }

		private string _Note;
        [LVMaxLength(1024)]
        public string Note { get { return _Note; } set {_Note = value; } }

		/// <summary>
/// Ref Key: FK_SymptomIndicator_IDC10
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
    public class KeyedSymptomIndicator : KeyedCollection<KeyValuePair<string, long>, SymptomIndicator>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedSymptomIndicator() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(SymptomIndicator item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SxIndicatorID) { return new KeyValuePair<string, long>("SxIndicatorID", k_SxIndicatorID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(SymptomIndicator item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, SymptomIndicator item)
        {
            SymptomIndicator orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(SymptomIndicator item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(SymptomIndicator item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public SymptomIndicator GetObjectByKey(long k_SxIndicatorID) 
		{
            if (this.Contains(GetKey(k_SxIndicatorID)) == false) return null;
            SymptomIndicator ob = this[GetKey(k_SxIndicatorID)];
            return (SymptomIndicator)ob;
        }

		public SymptomIndicator GetObjectByKey(long k_SxIndicatorID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SxIndicatorID)) == false) {
				SymptomIndicator ob = repository.GetQuery<SymptomIndicator>().FirstOrDefault(o => o.SxIndicatorID == k_SxIndicatorID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            SymptomIndicator obj = this[GetKey(k_SxIndicatorID)];
            return (SymptomIndicator)obj;
        }

		public SymptomIndicator GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            SymptomIndicator ob = this[keypair];
            return (SymptomIndicator)ob;
        }

        public SymptomIndicator GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            SymptomIndicator ob = this[GetKey(keypair)];
            return (SymptomIndicator)ob;
        }

		bool _LoadAll = false;
        public List<SymptomIndicator> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<SymptomIndicator>().ToList();
			foreach (SymptomIndicator item in list) {
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

        ~KeyedSymptomIndicator()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
