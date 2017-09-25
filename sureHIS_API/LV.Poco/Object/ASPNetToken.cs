/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ASPNetToken.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class ASPNetToken : BaseEntity, ICloneable	{
		public ASPNetToken()
		{
			this.TokenID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("TokenID", TokenID); } }


		private long _TokenID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long TokenID { get { return _TokenID; } set {_TokenID = value; } }

		private string _Value;
		[LVRequired]
        [LVMaxLength(128)]
        public string Value { get { return _Value; } set {_Value = value; } }

		private string _ValidUntilUTC;
        [LVMaxLength(128)]
        public string ValidUntilUTC { get { return _ValidUntilUTC; } set {_ValidUntilUTC = value; } }

		

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
    public class KeyedASPNetToken : KeyedCollection<KeyValuePair<string, long>, ASPNetToken>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedASPNetToken() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ASPNetToken item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_TokenID) { return new KeyValuePair<string, long>("TokenID", k_TokenID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ASPNetToken item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ASPNetToken item)
        {
            ASPNetToken orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ASPNetToken item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ASPNetToken item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ASPNetToken GetObjectByKey(long k_TokenID) 
		{
            if (this.Contains(GetKey(k_TokenID)) == false) return null;
            ASPNetToken ob = this[GetKey(k_TokenID)];
            return (ASPNetToken)ob;
        }

		public ASPNetToken GetObjectByKey(long k_TokenID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_TokenID)) == false) {
				ASPNetToken ob = repository.GetQuery<ASPNetToken>().FirstOrDefault(o => o.TokenID == k_TokenID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ASPNetToken obj = this[GetKey(k_TokenID)];
            return (ASPNetToken)obj;
        }

		public ASPNetToken GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ASPNetToken ob = this[keypair];
            return (ASPNetToken)ob;
        }

        public ASPNetToken GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ASPNetToken ob = this[GetKey(keypair)];
            return (ASPNetToken)ob;
        }

		bool _LoadAll = false;
        public List<ASPNetToken> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ASPNetToken>().ToList();
			foreach (ASPNetToken item in list) {
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

        ~KeyedASPNetToken()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
