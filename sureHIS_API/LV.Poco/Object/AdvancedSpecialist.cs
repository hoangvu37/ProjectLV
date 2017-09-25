/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AdvancedSpecialist.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class AdvancedSpecialist : BaseEntity, ICloneable	{
		public AdvancedSpecialist()
		{
			this.ASpecID = 0;
			this.EmpID = 0;
			this.QualCode = 0;
            this.DateObtained = DateTime.Now;
            this.SkillNotes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ASpecID", ASpecID); } }


		private long _ASpecID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ASpecID { get { return _ASpecID; } set {_ASpecID = value; } }

		private long _EmpID;
		[LVRequired]
        public long EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private long _QualCode;
		[LVRequired]
        public long QualCode { get { return _QualCode; } set {_QualCode = value; } }

		private DateTime? _DateObtained;
        public DateTime? DateObtained { get { return _DateObtained; } set {_DateObtained = value; } }

		private string _SkillNotes;
        [LVMaxLength(512)]
        public string SkillNotes { get { return _SkillNotes; } set {_SkillNotes = value; } }

		/// <summary>
/// Ref Key: FK_AdvancedSpecialist_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_AdvancedSpecialist_refQualification
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
    public class KeyedAdvancedSpecialist : KeyedCollection<KeyValuePair<string, long>, AdvancedSpecialist>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAdvancedSpecialist() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AdvancedSpecialist item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ASpecID) { return new KeyValuePair<string, long>("ASpecID", k_ASpecID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AdvancedSpecialist item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AdvancedSpecialist item)
        {
            AdvancedSpecialist orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AdvancedSpecialist item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AdvancedSpecialist item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AdvancedSpecialist GetObjectByKey(long k_ASpecID) 
		{
            if (this.Contains(GetKey(k_ASpecID)) == false) return null;
            AdvancedSpecialist ob = this[GetKey(k_ASpecID)];
            return (AdvancedSpecialist)ob;
        }

		public AdvancedSpecialist GetObjectByKey(long k_ASpecID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ASpecID)) == false) {
				AdvancedSpecialist ob = repository.GetQuery<AdvancedSpecialist>().FirstOrDefault(o => o.ASpecID == k_ASpecID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AdvancedSpecialist obj = this[GetKey(k_ASpecID)];
            return (AdvancedSpecialist)obj;
        }

		public AdvancedSpecialist GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AdvancedSpecialist ob = this[keypair];
            return (AdvancedSpecialist)ob;
        }

        public AdvancedSpecialist GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AdvancedSpecialist ob = this[GetKey(keypair)];
            return (AdvancedSpecialist)ob;
        }

		bool _LoadAll = false;
        public List<AdvancedSpecialist> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AdvancedSpecialist>().ToList();
			foreach (AdvancedSpecialist item in list) {
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

        ~KeyedAdvancedSpecialist()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
