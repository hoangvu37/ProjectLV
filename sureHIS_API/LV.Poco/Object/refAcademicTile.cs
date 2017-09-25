/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refAcademicTile.cs         
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
	public partial class refAcademicTile : BaseEntity, ICloneable	{
		public refAcademicTile()
		{
			this.AcademicCode = 0;
            this.AcademicDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, int> Key { get { return new KeyValuePair<string, int>("AcademicCode", AcademicCode); } }


		private int _AcademicCode;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public int AcademicCode { get { return _AcademicCode; } set {_AcademicCode = value; } }

		private string _AcademicName;
		[LVRequired]
        [LVMaxLength(64)]
        public string AcademicName { get { return _AcademicName; } set {_AcademicName = value; } }

		private string _VNAcademicName;
        [LVMaxLength(64)]
        public string VNAcademicName { get { return _VNAcademicName; } set {_VNAcademicName = value; } }

		private string _AcademicDesc;
        [LVMaxLength(256)]
        public string AcademicDesc { get { return _AcademicDesc; } set {_AcademicDesc = value; } }

		/// <summary>
/// Ref Key: FK_Employee_refAcademicTile
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
    public class KeyedrefAcademicTile : KeyedCollection<KeyValuePair<string, int>, refAcademicTile>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefAcademicTile() : base() { }

        protected override KeyValuePair<string, int> GetKeyForItem(refAcademicTile item)
        {
            return item.Key;
        }

        public KeyValuePair<string, int> GetKey(int k_AcademicCode) { return new KeyValuePair<string, int>("AcademicCode", k_AcademicCode); }

        public KeyValuePair<string, int> GetKey(object keypair) { try { return (KeyValuePair<string, int>)keypair; } catch { return new KeyValuePair<string, int>(); } }
        #endregion

        #region Method
        public bool AddObject(refAcademicTile item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, int> keypair, refAcademicTile item)
        {
            refAcademicTile orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refAcademicTile item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refAcademicTile item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refAcademicTile GetObjectByKey(int k_AcademicCode) 
		{
            if (this.Contains(GetKey(k_AcademicCode)) == false) return null;
            refAcademicTile ob = this[GetKey(k_AcademicCode)];
            return (refAcademicTile)ob;
        }

		public refAcademicTile GetObjectByKey(int k_AcademicCode, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AcademicCode)) == false) {
				refAcademicTile ob = repository.GetQuery<refAcademicTile>().FirstOrDefault(o => o.AcademicCode == k_AcademicCode);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refAcademicTile obj = this[GetKey(k_AcademicCode)];
            return (refAcademicTile)obj;
        }

		public refAcademicTile GetObjectByKey(KeyValuePair<string, int> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refAcademicTile ob = this[keypair];
            return (refAcademicTile)ob;
        }

        public refAcademicTile GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refAcademicTile ob = this[GetKey(keypair)];
            return (refAcademicTile)ob;
        }

		bool _LoadAll = false;
        public List<refAcademicTile> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refAcademicTile>().ToList();
			foreach (refAcademicTile item in list) {
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

        ~KeyedrefAcademicTile()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
