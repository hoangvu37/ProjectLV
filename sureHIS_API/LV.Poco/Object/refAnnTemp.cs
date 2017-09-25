/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refAnnTemp.cs         
 * Created by           : Auto - 09/11/2017 15:20:02                     
 * Last modify          : Auto - 09/11/2017 15:20:02                     
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
	public partial class refAnnTemp : BaseEntity, ICloneable	{
		public refAnnTemp()
		{
			this.V_AnnTempType = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, byte> Key { get { return new KeyValuePair<string, byte>("AnnTempID", AnnTempID); } }


		private byte _AnnTempID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public byte AnnTempID { get { return _AnnTempID; } set {_AnnTempID = value; } }

		private string _AnnTempName;
		[LVRequired]
        [LVMaxLength(128)]
        public string AnnTempName { get { return _AnnTempName; } set {_AnnTempName = value; } }

		private string _AnnTempContent;
		[LVRequired]
        [LVMaxLength(1073741823)]
        public string AnnTempContent { get { return _AnnTempContent; } set {_AnnTempContent = value; } }

		private long _V_AnnTempType;
		[LVRequired]
        public long V_AnnTempType { get { return _V_AnnTempType; } set {_V_AnnTempType = value; } }

		private string _Notes;
        [LVMaxLength(512)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		

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
    public class KeyedrefAnnTemp : KeyedCollection<KeyValuePair<string, byte>, refAnnTemp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefAnnTemp() : base() { }

        protected override KeyValuePair<string, byte> GetKeyForItem(refAnnTemp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, byte> GetKey(byte k_AnnTempID) { return new KeyValuePair<string, byte>("AnnTempID", k_AnnTempID); }

        public KeyValuePair<string, byte> GetKey(object keypair) { try { return (KeyValuePair<string, byte>)keypair; } catch { return new KeyValuePair<string, byte>(); } }
        #endregion

        #region Method
        public bool AddObject(refAnnTemp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, byte> keypair, refAnnTemp item)
        {
            refAnnTemp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refAnnTemp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refAnnTemp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refAnnTemp GetObjectByKey(byte k_AnnTempID) 
		{
            if (this.Contains(GetKey(k_AnnTempID)) == false) return null;
            refAnnTemp ob = this[GetKey(k_AnnTempID)];
            return (refAnnTemp)ob;
        }

		public refAnnTemp GetObjectByKey(byte k_AnnTempID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AnnTempID)) == false) {
				refAnnTemp ob = repository.GetQuery<refAnnTemp>().FirstOrDefault(o => o.AnnTempID == k_AnnTempID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refAnnTemp obj = this[GetKey(k_AnnTempID)];
            return (refAnnTemp)obj;
        }

		public refAnnTemp GetObjectByKey(KeyValuePair<string, byte> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refAnnTemp ob = this[keypair];
            return (refAnnTemp)ob;
        }

        public refAnnTemp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refAnnTemp ob = this[GetKey(keypair)];
            return (refAnnTemp)ob;
        }

		bool _LoadAll = false;
        public List<refAnnTemp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refAnnTemp>().ToList();
			foreach (refAnnTemp item in list) {
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

        ~KeyedrefAnnTemp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
