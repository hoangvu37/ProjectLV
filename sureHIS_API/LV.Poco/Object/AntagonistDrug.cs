/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AntagonistDrug.cs         
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
	public partial class AntagonistDrug : BaseEntity, ICloneable	{
		public AntagonistDrug()
		{
			this.ID = 0;
			this.DrugID = 0;
			this.AntaDrugID = 0;
            this.AntagonistLevel = null;
            this.Result = null;
            this.Handle = null;
            this.Memo = null;
            this.Mechanism = null;
			this.AntagonistKind = 0;
            this.AutoReplace = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ID", ID); } }


		private long _ID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ID { get { return _ID; } set {_ID = value; } }

		private long _DrugID;
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private long _AntaDrugID;
		[LVRequired]
        public long AntaDrugID { get { return _AntaDrugID; } set {_AntaDrugID = value; } }

		private string _AntagonistLevel;
        [LVMaxLength(50)]
        public string AntagonistLevel { get { return _AntagonistLevel; } set {_AntagonistLevel = value; } }

		private string _Result;
        [LVMaxLength(254)]
        public string Result { get { return _Result; } set {_Result = value; } }

		private string _Handle;
        [LVMaxLength(254)]
        public string Handle { get { return _Handle; } set {_Handle = value; } }

		private string _Memo;
        [LVMaxLength(254)]
        public string Memo { get { return _Memo; } set {_Memo = value; } }

		private short? _Mechanism;
        public short? Mechanism { get { return _Mechanism; } set {_Mechanism = value; } }

		private short _AntagonistKind;
		[LVRequired]
        public short AntagonistKind { get { return _AntagonistKind; } set {_AntagonistKind = value; } }

		private bool _AutoReplace;
        public bool AutoReplace { get { return _AutoReplace; } set {_AutoReplace = value; } }

		/// <summary>
/// Ref Key: FK_AntagonistDrug_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_AntagonistDrug_Drug_02
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
    public class KeyedAntagonistDrug : KeyedCollection<KeyValuePair<string, long>, AntagonistDrug>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAntagonistDrug() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AntagonistDrug item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ID) { return new KeyValuePair<string, long>("ID", k_ID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AntagonistDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AntagonistDrug item)
        {
            AntagonistDrug orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AntagonistDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AntagonistDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AntagonistDrug GetObjectByKey(long k_ID) 
		{
            if (this.Contains(GetKey(k_ID)) == false) return null;
            AntagonistDrug ob = this[GetKey(k_ID)];
            return (AntagonistDrug)ob;
        }

		public AntagonistDrug GetObjectByKey(long k_ID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ID)) == false) {
				AntagonistDrug ob = repository.GetQuery<AntagonistDrug>().FirstOrDefault(o => o.ID == k_ID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AntagonistDrug obj = this[GetKey(k_ID)];
            return (AntagonistDrug)obj;
        }

		public AntagonistDrug GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AntagonistDrug ob = this[keypair];
            return (AntagonistDrug)ob;
        }

        public AntagonistDrug GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AntagonistDrug ob = this[GetKey(keypair)];
            return (AntagonistDrug)ob;
        }

		bool _LoadAll = false;
        public List<AntagonistDrug> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AntagonistDrug>().ToList();
			foreach (AntagonistDrug item in list) {
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

        ~KeyedAntagonistDrug()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
