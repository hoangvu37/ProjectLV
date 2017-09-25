/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Trigs.cs         
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
	public partial class Trigs : BaseEntity, ICloneable	{
		public Trigs()
		{
            this.Desc = null;
		}

	    #region Properties
		[NotMapped]
		public  Key { get { return ; } }


		private string _tblName;
		[LVRequired]
        [LVMaxLength(64)]
        public string tblName { get { return _tblName; } set {_tblName = value; } }

		private string _fID;
        [LVMaxLength(50)]
        public string fID { get { return _fID; } set {_fID = value; } }

		private string _Desc;
        [LVMaxLength(512)]
        public string Desc { get { return _Desc; } set {_Desc = value; } }

		

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
    public class KeyedTrigs : KeyedCollection<, Trigs>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedTrigs() : base() { }

        protected override  GetKeyForItem(Trigs item)
        {
            return item.Key;
        }

        public  GetKey() { return ; }

        public  GetKey(object keypair) { try { return ()keypair; } catch { return new (); } }
        #endregion

        #region Method
        public bool AddObject(Trigs item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem( keypair, Trigs item)
        {
            Trigs orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Trigs item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Trigs item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Trigs GetObjectByKey() 
		{
            if (this.Contains(GetKey()) == false) return null;
            Trigs ob = this[GetKey()];
            return (Trigs)ob;
        }

		public Trigs GetObjectByKey(, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey()) == false) {
				Trigs ob = repository.GetQuery<Trigs>().FirstOrDefault(o => );
				if(ob != null) this.Add(ob);
				return ob;
			}
            Trigs obj = this[GetKey()];
            return (Trigs)obj;
        }

		public Trigs GetObjectByKey( keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Trigs ob = this[keypair];
            return (Trigs)ob;
        }

        public Trigs GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Trigs ob = this[GetKey(keypair)];
            return (Trigs)ob;
        }

		bool _LoadAll = false;
        public List<Trigs> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Trigs>().ToList();
			foreach (Trigs item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<Trigs> LoadUQ_Trigs(string p_tblName, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<Trigs>().Where(o=> o.tblName == p_tblName).ToList();
			foreach (Trigs item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
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

        ~KeyedTrigs()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
