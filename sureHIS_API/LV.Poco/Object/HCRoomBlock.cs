/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HCRoomBlock.cs         
 * Created by           : Auto - 09/11/2017 15:20:01                     
 * Last modify          : Auto - 09/11/2017 15:20:01                     
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
	public partial class HCRoomBlock : BaseEntity, ICloneable	{
		public HCRoomBlock()
		{
			this.HCRmBlockID = 0;
            this.HCRmBlockDesc = null;
			this.EstEmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HCRmBlockID", HCRmBlockID); } }


		private long _HCRmBlockID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HCRmBlockID { get { return _HCRmBlockID; } set {_HCRmBlockID = value; } }

		private string _HCRmBlockName;
		[LVRequired]
        [LVMaxLength(64)]
        public string HCRmBlockName { get { return _HCRmBlockName; } set {_HCRmBlockName = value; } }

		private string _HCRmBlockDesc;
        [LVMaxLength(1024)]
        public string HCRmBlockDesc { get { return _HCRmBlockDesc; } set {_HCRmBlockDesc = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_DHCRoomBlock_HCRoomBlock
/// <summary>
/// <summary>
/// Ref Key: FK_RescrUsedInOperation_HCRoomBlock
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
    public class KeyedHCRoomBlock : KeyedCollection<KeyValuePair<string, long>, HCRoomBlock>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHCRoomBlock() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HCRoomBlock item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HCRmBlockID) { return new KeyValuePair<string, long>("HCRmBlockID", k_HCRmBlockID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HCRoomBlock item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HCRoomBlock item)
        {
            HCRoomBlock orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HCRoomBlock item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HCRoomBlock item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HCRoomBlock GetObjectByKey(long k_HCRmBlockID) 
		{
            if (this.Contains(GetKey(k_HCRmBlockID)) == false) return null;
            HCRoomBlock ob = this[GetKey(k_HCRmBlockID)];
            return (HCRoomBlock)ob;
        }

		public HCRoomBlock GetObjectByKey(long k_HCRmBlockID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HCRmBlockID)) == false) {
				HCRoomBlock ob = repository.GetQuery<HCRoomBlock>().FirstOrDefault(o => o.HCRmBlockID == k_HCRmBlockID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HCRoomBlock obj = this[GetKey(k_HCRmBlockID)];
            return (HCRoomBlock)obj;
        }

		public HCRoomBlock GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HCRoomBlock ob = this[keypair];
            return (HCRoomBlock)ob;
        }

        public HCRoomBlock GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HCRoomBlock ob = this[GetKey(keypair)];
            return (HCRoomBlock)ob;
        }

		bool _LoadAll = false;
        public List<HCRoomBlock> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HCRoomBlock>().ToList();
			foreach (HCRoomBlock item in list) {
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

        ~KeyedHCRoomBlock()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
