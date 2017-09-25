/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refSIPrefix.cs         
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
	public partial class refSIPrefix : BaseEntity, ICloneable	{
		public refSIPrefix()
		{
			this.Factor = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, byte> Key { get { return new KeyValuePair<string, byte>("PrefID", PrefID); } }


		private byte _PrefID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public byte PrefID { get { return _PrefID; } set {_PrefID = value; } }

		private string _Prefix;
		[LVRequired]
        [LVMaxLength(64)]
        public string Prefix { get { return _Prefix; } set {_Prefix = value; } }

		private string _Symbol;
		[LVRequired]
        [LVMaxLength(10)]
        public string Symbol { get { return _Symbol; } set {_Symbol = value; } }

		private double _Factor;
		[LVRequired]
        public double Factor { get { return _Factor; } set {_Factor = value; } }

		private string _Notes;
        [LVMaxLength(64)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_refUnitOfMeasure_SIPrefix
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
    public class KeyedrefSIPrefix : KeyedCollection<KeyValuePair<string, byte>, refSIPrefix>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefSIPrefix() : base() { }

        protected override KeyValuePair<string, byte> GetKeyForItem(refSIPrefix item)
        {
            return item.Key;
        }

        public KeyValuePair<string, byte> GetKey(byte k_PrefID) { return new KeyValuePair<string, byte>("PrefID", k_PrefID); }

        public KeyValuePair<string, byte> GetKey(object keypair) { try { return (KeyValuePair<string, byte>)keypair; } catch { return new KeyValuePair<string, byte>(); } }
        #endregion

        #region Method
        public bool AddObject(refSIPrefix item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, byte> keypair, refSIPrefix item)
        {
            refSIPrefix orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refSIPrefix item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refSIPrefix item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refSIPrefix GetObjectByKey(byte k_PrefID) 
		{
            if (this.Contains(GetKey(k_PrefID)) == false) return null;
            refSIPrefix ob = this[GetKey(k_PrefID)];
            return (refSIPrefix)ob;
        }

		public refSIPrefix GetObjectByKey(byte k_PrefID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PrefID)) == false) {
				refSIPrefix ob = repository.GetQuery<refSIPrefix>().FirstOrDefault(o => o.PrefID == k_PrefID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refSIPrefix obj = this[GetKey(k_PrefID)];
            return (refSIPrefix)obj;
        }

		public refSIPrefix GetObjectByKey(KeyValuePair<string, byte> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refSIPrefix ob = this[keypair];
            return (refSIPrefix)ob;
        }

        public refSIPrefix GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refSIPrefix ob = this[GetKey(keypair)];
            return (refSIPrefix)ob;
        }

		bool _LoadAll = false;
        public List<refSIPrefix> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refSIPrefix>().ToList();
			foreach (refSIPrefix item in list) {
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

        ~KeyedrefSIPrefix()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
