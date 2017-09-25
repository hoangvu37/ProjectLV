/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refInternalReceiptType.cs         
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
	public partial class refInternalReceiptType : BaseEntity, ICloneable	{
		public refInternalReceiptType()
		{
            this.DebitOrCredit = true;
            this.InvTmpURL = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, byte> Key { get { return new KeyValuePair<string, byte>("IntRcptTypeID", IntRcptTypeID); } }


		private byte _IntRcptTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public byte IntRcptTypeID { get { return _IntRcptTypeID; } set {_IntRcptTypeID = value; } }

		private string _IntRcptTypeName;
		[LVRequired]
        [LVMaxLength(128)]
        public string IntRcptTypeName { get { return _IntRcptTypeName; } set {_IntRcptTypeName = value; } }

		private bool? _DebitOrCredit;
        public bool? DebitOrCredit { get { return _DebitOrCredit; } set {_DebitOrCredit = value; } }

		private string _InvTmpURL;
        [LVMaxLength(255)]
        public string InvTmpURL { get { return _InvTmpURL; } set {_InvTmpURL = value; } }

		

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
    public class KeyedrefInternalReceiptType : KeyedCollection<KeyValuePair<string, byte>, refInternalReceiptType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefInternalReceiptType() : base() { }

        protected override KeyValuePair<string, byte> GetKeyForItem(refInternalReceiptType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, byte> GetKey(byte k_IntRcptTypeID) { return new KeyValuePair<string, byte>("IntRcptTypeID", k_IntRcptTypeID); }

        public KeyValuePair<string, byte> GetKey(object keypair) { try { return (KeyValuePair<string, byte>)keypair; } catch { return new KeyValuePair<string, byte>(); } }
        #endregion

        #region Method
        public bool AddObject(refInternalReceiptType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, byte> keypair, refInternalReceiptType item)
        {
            refInternalReceiptType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refInternalReceiptType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refInternalReceiptType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refInternalReceiptType GetObjectByKey(byte k_IntRcptTypeID) 
		{
            if (this.Contains(GetKey(k_IntRcptTypeID)) == false) return null;
            refInternalReceiptType ob = this[GetKey(k_IntRcptTypeID)];
            return (refInternalReceiptType)ob;
        }

		public refInternalReceiptType GetObjectByKey(byte k_IntRcptTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_IntRcptTypeID)) == false) {
				refInternalReceiptType ob = repository.GetQuery<refInternalReceiptType>().FirstOrDefault(o => o.IntRcptTypeID == k_IntRcptTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refInternalReceiptType obj = this[GetKey(k_IntRcptTypeID)];
            return (refInternalReceiptType)obj;
        }

		public refInternalReceiptType GetObjectByKey(KeyValuePair<string, byte> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refInternalReceiptType ob = this[keypair];
            return (refInternalReceiptType)ob;
        }

        public refInternalReceiptType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refInternalReceiptType ob = this[GetKey(keypair)];
            return (refInternalReceiptType)ob;
        }

		bool _LoadAll = false;
        public List<refInternalReceiptType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refInternalReceiptType>().ToList();
			foreach (refInternalReceiptType item in list) {
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

        ~KeyedrefInternalReceiptType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
