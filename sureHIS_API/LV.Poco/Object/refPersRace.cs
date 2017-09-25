/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refPersRace.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class refPersRace : BaseEntity, ICloneable	{
		public refPersRace()
		{
			this.PersRaceID = 0;
			this.Level = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PersRaceID", PersRaceID); } }


		private long _PersRaceID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PersRaceID { get { return _PersRaceID; } set {_PersRaceID = value; } }

		private string _PersRaceCode;
		[LVRequired]
        [LVMaxLength(6)]
        public string PersRaceCode { get { return _PersRaceCode; } set {_PersRaceCode = value; } }

		private string _PersRaceName;
		[LVRequired]
        [LVMaxLength(43)]
        public string PersRaceName { get { return _PersRaceName; } set {_PersRaceName = value; } }

		private string _VNPersRaceName;
        [LVMaxLength(64)]
        public string VNPersRaceName { get { return _VNPersRaceName; } set {_VNPersRaceName = value; } }

		private string _PPersRaceID;
        [LVMaxLength(6)]
        public string PPersRaceID { get { return _PPersRaceID; } set {_PPersRaceID = value; } }

		private short _Level;
		[LVRequired]
        public short Level { get { return _Level; } set {_Level = value; } }

		/// <summary>
/// Ref Key: FK_Person_refPersRace
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
    public class KeyedrefPersRace : KeyedCollection<KeyValuePair<string, long>, refPersRace>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefPersRace() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refPersRace item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PersRaceID) { return new KeyValuePair<string, long>("PersRaceID", k_PersRaceID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refPersRace item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refPersRace item)
        {
            refPersRace orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refPersRace item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refPersRace item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refPersRace GetObjectByKey(long k_PersRaceID) 
		{
            if (this.Contains(GetKey(k_PersRaceID)) == false) return null;
            refPersRace ob = this[GetKey(k_PersRaceID)];
            return (refPersRace)ob;
        }

		public refPersRace GetObjectByKey(long k_PersRaceID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PersRaceID)) == false) {
				refPersRace ob = repository.GetQuery<refPersRace>().FirstOrDefault(o => o.PersRaceID == k_PersRaceID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refPersRace obj = this[GetKey(k_PersRaceID)];
            return (refPersRace)obj;
        }

		public refPersRace GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refPersRace ob = this[keypair];
            return (refPersRace)ob;
        }

        public refPersRace GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refPersRace ob = this[GetKey(keypair)];
            return (refPersRace)ob;
        }

		bool _LoadAll = false;
        public List<refPersRace> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refPersRace>().ToList();
			foreach (refPersRace item in list) {
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

        ~KeyedrefPersRace()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
