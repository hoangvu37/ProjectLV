/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DHCRoomBlock.cs         
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
	public partial class DHCRoomBlock : BaseEntity, ICloneable	{
		public DHCRoomBlock()
		{
			this.DHCRmBlockID = 0;
			this.HCRmBlockID = 0;
			this.RoomID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DHCRmBlockID", DHCRmBlockID); } }


		private long _DHCRmBlockID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DHCRmBlockID { get { return _DHCRmBlockID; } set {_DHCRmBlockID = value; } }

		private long _HCRmBlockID;
		[LVRequired]
        public long HCRmBlockID { get { return _HCRmBlockID; } set {_HCRmBlockID = value; } }

		private long _RoomID;
		[LVRequired]
        public long RoomID { get { return _RoomID; } set {_RoomID = value; } }

		/// <summary>
/// Ref Key: FK_DHCRoomBlock_HCRoomBlock
/// <summary>
/// <summary>
/// Ref Key: FK_DHCRoomBlock_RoomAllocation
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
    public class KeyedDHCRoomBlock : KeyedCollection<KeyValuePair<string, long>, DHCRoomBlock>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDHCRoomBlock() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DHCRoomBlock item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DHCRmBlockID) { return new KeyValuePair<string, long>("DHCRmBlockID", k_DHCRmBlockID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DHCRoomBlock item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DHCRoomBlock item)
        {
            DHCRoomBlock orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DHCRoomBlock item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DHCRoomBlock item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DHCRoomBlock GetObjectByKey(long k_DHCRmBlockID) 
		{
            if (this.Contains(GetKey(k_DHCRmBlockID)) == false) return null;
            DHCRoomBlock ob = this[GetKey(k_DHCRmBlockID)];
            return (DHCRoomBlock)ob;
        }

		public DHCRoomBlock GetObjectByKey(long k_DHCRmBlockID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DHCRmBlockID)) == false) {
				DHCRoomBlock ob = repository.GetQuery<DHCRoomBlock>().FirstOrDefault(o => o.DHCRmBlockID == k_DHCRmBlockID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DHCRoomBlock obj = this[GetKey(k_DHCRmBlockID)];
            return (DHCRoomBlock)obj;
        }

		public DHCRoomBlock GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DHCRoomBlock ob = this[keypair];
            return (DHCRoomBlock)ob;
        }

        public DHCRoomBlock GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DHCRoomBlock ob = this[GetKey(keypair)];
            return (DHCRoomBlock)ob;
        }

		bool _LoadAll = false;
        public List<DHCRoomBlock> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DHCRoomBlock>().ToList();
			foreach (DHCRoomBlock item in list) {
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

        ~KeyedDHCRoomBlock()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
