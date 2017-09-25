/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refCommonTerm.cs         
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
	public partial class refCommonTerm : BaseEntity, ICloneable	{
		public refCommonTerm()
		{
			this.CTermID = 0;
            this.TermPhase = null;
            this.Meaning = null;
            this.AbbreviationsVNS = null;
            this.TermPhaseVNs = null;
			this.V_ComTermCatg = 0;
            this.IsNotActivated = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, short> Key { get { return new KeyValuePair<string, short>("CTermID", CTermID); } }


		private short _CTermID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public short CTermID { get { return _CTermID; } set {_CTermID = value; } }

		private string _Abbreviation;
		[LVRequired]
        [LVMaxLength(20)]
        public string Abbreviation { get { return _Abbreviation; } set {_Abbreviation = value; } }

		private string _TermPhase;
        [LVMaxLength(128)]
        public string TermPhase { get { return _TermPhase; } set {_TermPhase = value; } }

		private string _Meaning;
        [LVMaxLength(256)]
        public string Meaning { get { return _Meaning; } set {_Meaning = value; } }

		private string _AbbreviationsVNS;
        [LVMaxLength(20)]
        public string AbbreviationsVNS { get { return _AbbreviationsVNS; } set {_AbbreviationsVNS = value; } }

		private string _TermPhaseVNs;
        [LVMaxLength(256)]
        public string TermPhaseVNs { get { return _TermPhaseVNs; } set {_TermPhaseVNs = value; } }

		private long _V_ComTermCatg;
		[LVRequired]
        public long V_ComTermCatg { get { return _V_ComTermCatg; } set {_V_ComTermCatg = value; } }

		private bool? _IsNotActivated;
        public bool? IsNotActivated { get { return _IsNotActivated; } set {_IsNotActivated = value; } }

		/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm_02
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm_03
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm_04
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm_05
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm_02
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm_03
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm_04
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm_05
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
    public class KeyedrefCommonTerm : KeyedCollection<KeyValuePair<string, short>, refCommonTerm>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefCommonTerm() : base() { }

        protected override KeyValuePair<string, short> GetKeyForItem(refCommonTerm item)
        {
            return item.Key;
        }

        public KeyValuePair<string, short> GetKey(short k_CTermID) { return new KeyValuePair<string, short>("CTermID", k_CTermID); }

        public KeyValuePair<string, short> GetKey(object keypair) { try { return (KeyValuePair<string, short>)keypair; } catch { return new KeyValuePair<string, short>(); } }
        #endregion

        #region Method
        public bool AddObject(refCommonTerm item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, short> keypair, refCommonTerm item)
        {
            refCommonTerm orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refCommonTerm item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refCommonTerm item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refCommonTerm GetObjectByKey(short k_CTermID) 
		{
            if (this.Contains(GetKey(k_CTermID)) == false) return null;
            refCommonTerm ob = this[GetKey(k_CTermID)];
            return (refCommonTerm)ob;
        }

		public refCommonTerm GetObjectByKey(short k_CTermID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_CTermID)) == false) {
				refCommonTerm ob = repository.GetQuery<refCommonTerm>().FirstOrDefault(o => o.CTermID == k_CTermID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refCommonTerm obj = this[GetKey(k_CTermID)];
            return (refCommonTerm)obj;
        }

		public refCommonTerm GetObjectByKey(KeyValuePair<string, short> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refCommonTerm ob = this[keypair];
            return (refCommonTerm)ob;
        }

        public refCommonTerm GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refCommonTerm ob = this[GetKey(keypair)];
            return (refCommonTerm)ob;
        }

		bool _LoadAll = false;
        public List<refCommonTerm> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refCommonTerm>().ToList();
			foreach (refCommonTerm item in list) {
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

        ~KeyedrefCommonTerm()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
