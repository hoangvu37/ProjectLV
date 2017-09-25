/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Employeer.cs         
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
	public partial class Employeer : BaseEntity, ICloneable	{
		public Employeer()
		{
			this.EmployeerID = 0;
			this.PersonID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EmployeerID", EmployeerID); } }


		private long _EmployeerID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EmployeerID { get { return _EmployeerID; } set {_EmployeerID = value; } }

		private long? _PersonID;
        public long? PersonID { get { return _PersonID; } set {_PersonID = value; } }

		/// <summary>
/// Ref Key: FK_Employeer_Person
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
    public class KeyedEmployeer : KeyedCollection<KeyValuePair<string, long>, Employeer>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEmployeer() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Employeer item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EmployeerID) { return new KeyValuePair<string, long>("EmployeerID", k_EmployeerID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Employeer item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Employeer item)
        {
            Employeer orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Employeer item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Employeer item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Employeer GetObjectByKey(long k_EmployeerID) 
		{
            if (this.Contains(GetKey(k_EmployeerID)) == false) return null;
            Employeer ob = this[GetKey(k_EmployeerID)];
            return (Employeer)ob;
        }

		public Employeer GetObjectByKey(long k_EmployeerID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EmployeerID)) == false) {
				Employeer ob = repository.GetQuery<Employeer>().FirstOrDefault(o => o.EmployeerID == k_EmployeerID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Employeer obj = this[GetKey(k_EmployeerID)];
            return (Employeer)obj;
        }

		public Employeer GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Employeer ob = this[keypair];
            return (Employeer)ob;
        }

        public Employeer GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Employeer ob = this[GetKey(keypair)];
            return (Employeer)ob;
        }

		bool _LoadAll = false;
        public List<Employeer> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Employeer>().ToList();
			foreach (Employeer item in list) {
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

        ~KeyedEmployeer()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
