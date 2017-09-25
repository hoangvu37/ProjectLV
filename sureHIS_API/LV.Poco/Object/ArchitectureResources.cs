/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ArchitectureResources.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class ArchitectureResources : BaseEntity, ICloneable	{
		public ArchitectureResources()
		{
			this.ARescrID = 0;
			this.PARescrID = 0;
			this.PDepreciationRate = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ARescrID", ARescrID); } }


		private long _ARescrID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ARescrID { get { return _ARescrID; } set {_ARescrID = value; } }

		private long? _PARescrID;
        public long? PARescrID { get { return _PARescrID; } set {_PARescrID = value; } }

		private string _PhysicalLocation;
		[LVRequired]
        [LVMaxLength(64)]
        public string PhysicalLocation { get { return _PhysicalLocation; } set {_PhysicalLocation = value; } }

		private string _PhysicalAddress;
		[LVRequired]
        [LVMaxLength(1024)]
        public string PhysicalAddress { get { return _PhysicalAddress; } set {_PhysicalAddress = value; } }

		private double? _PDepreciationRate;
        public double? PDepreciationRate { get { return _PDepreciationRate; } set {_PDepreciationRate = value; } }

		/// <summary>
/// Ref Key: FK_Allocation_ArchitectureResources
/// <summary>
/// <summary>
/// Ref Key: FK_ArchitectureResources_ArchitectureResources
/// <summary>
/// <summary>
/// Ref Key: FK_ArchitectureResources_ArchitectureResources
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
    public class KeyedArchitectureResources : KeyedCollection<KeyValuePair<string, long>, ArchitectureResources>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedArchitectureResources() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ArchitectureResources item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ARescrID) { return new KeyValuePair<string, long>("ARescrID", k_ARescrID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ArchitectureResources item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ArchitectureResources item)
        {
            ArchitectureResources orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ArchitectureResources item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ArchitectureResources item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ArchitectureResources GetObjectByKey(long k_ARescrID) 
		{
            if (this.Contains(GetKey(k_ARescrID)) == false) return null;
            ArchitectureResources ob = this[GetKey(k_ARescrID)];
            return (ArchitectureResources)ob;
        }

		public ArchitectureResources GetObjectByKey(long k_ARescrID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ARescrID)) == false) {
				ArchitectureResources ob = repository.GetQuery<ArchitectureResources>().FirstOrDefault(o => o.ARescrID == k_ARescrID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ArchitectureResources obj = this[GetKey(k_ARescrID)];
            return (ArchitectureResources)obj;
        }

		public ArchitectureResources GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ArchitectureResources ob = this[keypair];
            return (ArchitectureResources)ob;
        }

        public ArchitectureResources GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ArchitectureResources ob = this[GetKey(keypair)];
            return (ArchitectureResources)ob;
        }

		bool _LoadAll = false;
        public List<ArchitectureResources> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ArchitectureResources>().ToList();
			foreach (ArchitectureResources item in list) {
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

        ~KeyedArchitectureResources()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
