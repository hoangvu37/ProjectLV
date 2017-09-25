/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refShelfDrugLocation.cs         
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
	public partial class refShelfDrugLocation : BaseEntity, ICloneable	{
		public refShelfDrugLocation()
		{
			this.SdlID = 0;
            this.Length = 0;
            this.Width = 0;
            this.Height = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SdlID", SdlID); } }


		private long _SdlID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SdlID { get { return _SdlID; } set {_SdlID = value; } }

		private string _SdlName;
		[LVRequired]
        [LVMaxLength(100)]
        public string SdlName { get { return _SdlName; } set {_SdlName = value; } }

		private string _SdlDescription;
        [LVMaxLength(254)]
        public string SdlDescription { get { return _SdlDescription; } set {_SdlDescription = value; } }

		private decimal _Length;
		[LVRequired]
        public decimal Length { get { return _Length; } set {_Length = value; } }

		private decimal _Width;
		[LVRequired]
        public decimal Width { get { return _Width; } set {_Width = value; } }

		private decimal _Height;
		[LVRequired]
        public decimal Height { get { return _Height; } set {_Height = value; } }

		/// <summary>
/// Ref Key: FK_InOutwardDrug_refShelfDrugLocation
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
    public class KeyedrefShelfDrugLocation : KeyedCollection<KeyValuePair<string, long>, refShelfDrugLocation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefShelfDrugLocation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refShelfDrugLocation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SdlID) { return new KeyValuePair<string, long>("SdlID", k_SdlID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refShelfDrugLocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refShelfDrugLocation item)
        {
            refShelfDrugLocation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refShelfDrugLocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refShelfDrugLocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refShelfDrugLocation GetObjectByKey(long k_SdlID) 
		{
            if (this.Contains(GetKey(k_SdlID)) == false) return null;
            refShelfDrugLocation ob = this[GetKey(k_SdlID)];
            return (refShelfDrugLocation)ob;
        }

		public refShelfDrugLocation GetObjectByKey(long k_SdlID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SdlID)) == false) {
				refShelfDrugLocation ob = repository.GetQuery<refShelfDrugLocation>().FirstOrDefault(o => o.SdlID == k_SdlID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refShelfDrugLocation obj = this[GetKey(k_SdlID)];
            return (refShelfDrugLocation)obj;
        }

		public refShelfDrugLocation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refShelfDrugLocation ob = this[keypair];
            return (refShelfDrugLocation)ob;
        }

        public refShelfDrugLocation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refShelfDrugLocation ob = this[GetKey(keypair)];
            return (refShelfDrugLocation)ob;
        }

		bool _LoadAll = false;
        public List<refShelfDrugLocation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refShelfDrugLocation>().ToList();
			foreach (refShelfDrugLocation item in list) {
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

        ~KeyedrefShelfDrugLocation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
