/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MesrtConv.cs         
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
	public partial class MesrtConv : BaseEntity, ICloneable	{
		public MesrtConv()
		{
			this.CMSID = 0;
			this.UOMNo = 0;
			this.CnvUOMNo = 0;
            this.ConvFactor = 1;
            this.Factor = 0;
            this.PrioOp = true;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("CMSID", CMSID); } }


		private long _CMSID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long CMSID { get { return _CMSID; } set {_CMSID = value; } }

		private long _UOMNo;
		[LVRequired]
        public long UOMNo { get { return _UOMNo; } set {_UOMNo = value; } }

		private long _CnvUOMNo;
		[LVRequired]
        public long CnvUOMNo { get { return _CnvUOMNo; } set {_CnvUOMNo = value; } }

		private bool? _IsMultiply;
        public bool? IsMultiply { get { return _IsMultiply; } set {_IsMultiply = value; } }

		private double _ConvFactor;
		[LVRequired]
        public double ConvFactor { get { return _ConvFactor; } set {_ConvFactor = value; } }

		private double _Factor;
		[LVRequired]
        public double Factor { get { return _Factor; } set {_Factor = value; } }

		private bool? _PrioOp;
        public bool? PrioOp { get { return _PrioOp; } set {_PrioOp = value; } }

		private string _Notes;
        [LVMaxLength(1024)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_ConversionMS_refUnitOfMeasure
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
    public class KeyedMesrtConv : KeyedCollection<KeyValuePair<string, long>, MesrtConv>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMesrtConv() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MesrtConv item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_CMSID) { return new KeyValuePair<string, long>("CMSID", k_CMSID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MesrtConv item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MesrtConv item)
        {
            MesrtConv orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MesrtConv item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MesrtConv item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MesrtConv GetObjectByKey(long k_CMSID) 
		{
            if (this.Contains(GetKey(k_CMSID)) == false) return null;
            MesrtConv ob = this[GetKey(k_CMSID)];
            return (MesrtConv)ob;
        }

		public MesrtConv GetObjectByKey(long k_CMSID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_CMSID)) == false) {
				MesrtConv ob = repository.GetQuery<MesrtConv>().FirstOrDefault(o => o.CMSID == k_CMSID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MesrtConv obj = this[GetKey(k_CMSID)];
            return (MesrtConv)obj;
        }

		public MesrtConv GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MesrtConv ob = this[keypair];
            return (MesrtConv)ob;
        }

        public MesrtConv GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MesrtConv ob = this[GetKey(keypair)];
            return (MesrtConv)ob;
        }

		bool _LoadAll = false;
        public List<MesrtConv> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MesrtConv>().ToList();
			foreach (MesrtConv item in list) {
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

        ~KeyedMesrtConv()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
