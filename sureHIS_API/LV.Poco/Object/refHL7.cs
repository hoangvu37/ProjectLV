/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refHL7.cs         
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
	public partial class refHL7 : BaseEntity, ICloneable	{
		public refHL7()
		{
			this.H7ID = 0;
            this.ObjValueVN = null;
            this.Ordinal = 0;
            this.IsActivated = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("H7ID", H7ID); } }


		private long _H7ID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long H7ID { get { return _H7ID; } set {_H7ID = value; } }

		private string _ObjName;
		[LVRequired]
        [LVMaxLength(64)]
        public string ObjName { get { return _ObjName; } set {_ObjName = value; } }

		private string _ObjCode;
		[LVRequired]
        [LVMaxLength(32)]
        public string ObjCode { get { return _ObjCode; } set {_ObjCode = value; } }

		private string _ObjValue;
		[LVRequired]
        [LVMaxLength(128)]
        public string ObjValue { get { return _ObjValue; } set {_ObjValue = value; } }

		private string _ObjValueVN;
        [LVMaxLength(256)]
        public string ObjValueVN { get { return _ObjValueVN; } set {_ObjValueVN = value; } }

		private string _ObjNotes;
        [LVMaxLength(1024)]
        public string ObjNotes { get { return _ObjNotes; } set {_ObjNotes = value; } }

		private byte? _Ordinal;
        public byte? Ordinal { get { return _Ordinal; } set {_Ordinal = value; } }

		private bool? _IsActivated;
        public bool? IsActivated { get { return _IsActivated; } set {_IsActivated = value; } }

		

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
    public class KeyedrefHL7 : KeyedCollection<KeyValuePair<string, long>, refHL7>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefHL7() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refHL7 item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_H7ID) { return new KeyValuePair<string, long>("H7ID", k_H7ID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refHL7 item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refHL7 item)
        {
            refHL7 orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refHL7 item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refHL7 item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refHL7 GetObjectByKey(long k_H7ID) 
		{
            if (this.Contains(GetKey(k_H7ID)) == false) return null;
            refHL7 ob = this[GetKey(k_H7ID)];
            return (refHL7)ob;
        }

		public refHL7 GetObjectByKey(long k_H7ID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_H7ID)) == false) {
				refHL7 ob = repository.GetQuery<refHL7>().FirstOrDefault(o => o.H7ID == k_H7ID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refHL7 obj = this[GetKey(k_H7ID)];
            return (refHL7)obj;
        }

		public refHL7 GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refHL7 ob = this[keypair];
            return (refHL7)ob;
        }

        public refHL7 GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refHL7 ob = this[GetKey(keypair)];
            return (refHL7)ob;
        }

		bool _LoadAll = false;
        public List<refHL7> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refHL7>().ToList();
			foreach (refHL7 item in list) {
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

        ~KeyedrefHL7()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
