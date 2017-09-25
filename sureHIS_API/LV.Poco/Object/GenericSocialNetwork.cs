/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : GenericSocialNetwork.cs         
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
	public partial class GenericSocialNetwork : BaseEntity, ICloneable	{
		public GenericSocialNetwork()
		{
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, byte> Key { get { return new KeyValuePair<string, byte>("SNetID", SNetID); } }


		private byte _SNetID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public byte SNetID { get { return _SNetID; } set {_SNetID = value; } }

		private string _SNetName;
		[LVRequired]
        [LVMaxLength(64)]
        public string SNetName { get { return _SNetName; } set {_SNetName = value; } }

		private string _SNetDetails;
        [LVMaxLength(2048)]
        public string SNetDetails { get { return _SNetDetails; } set {_SNetDetails = value; } }

		/// <summary>
/// Ref Key: FK_NetworkGuestAccount_GenericSocialNetwork
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
    public class KeyedGenericSocialNetwork : KeyedCollection<KeyValuePair<string, byte>, GenericSocialNetwork>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedGenericSocialNetwork() : base() { }

        protected override KeyValuePair<string, byte> GetKeyForItem(GenericSocialNetwork item)
        {
            return item.Key;
        }

        public KeyValuePair<string, byte> GetKey(byte k_SNetID) { return new KeyValuePair<string, byte>("SNetID", k_SNetID); }

        public KeyValuePair<string, byte> GetKey(object keypair) { try { return (KeyValuePair<string, byte>)keypair; } catch { return new KeyValuePair<string, byte>(); } }
        #endregion

        #region Method
        public bool AddObject(GenericSocialNetwork item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, byte> keypair, GenericSocialNetwork item)
        {
            GenericSocialNetwork orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(GenericSocialNetwork item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(GenericSocialNetwork item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public GenericSocialNetwork GetObjectByKey(byte k_SNetID) 
		{
            if (this.Contains(GetKey(k_SNetID)) == false) return null;
            GenericSocialNetwork ob = this[GetKey(k_SNetID)];
            return (GenericSocialNetwork)ob;
        }

		public GenericSocialNetwork GetObjectByKey(byte k_SNetID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SNetID)) == false) {
				GenericSocialNetwork ob = repository.GetQuery<GenericSocialNetwork>().FirstOrDefault(o => o.SNetID == k_SNetID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            GenericSocialNetwork obj = this[GetKey(k_SNetID)];
            return (GenericSocialNetwork)obj;
        }

		public GenericSocialNetwork GetObjectByKey(KeyValuePair<string, byte> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            GenericSocialNetwork ob = this[keypair];
            return (GenericSocialNetwork)ob;
        }

        public GenericSocialNetwork GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            GenericSocialNetwork ob = this[GetKey(keypair)];
            return (GenericSocialNetwork)ob;
        }

		bool _LoadAll = false;
        public List<GenericSocialNetwork> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<GenericSocialNetwork>().ToList();
			foreach (GenericSocialNetwork item in list) {
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

        ~KeyedGenericSocialNetwork()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
