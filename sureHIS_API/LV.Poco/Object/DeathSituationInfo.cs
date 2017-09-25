/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DeathSituationInfo.cs         
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
	public partial class DeathSituationInfo : BaseEntity, ICloneable	{
		public DeathSituationInfo()
		{
			this.DCertID = 0;
			this.HCEpiIDCode = 0;
            this.HCFEDispDiagICDCode = null;
            this.DCertDeathCauseCode = null;
            this.DCertDeathCauseDesc = null;
            this.IsPostMorternExam = false;
            this.PostMorternExamDiagnosis = null;
			this.V_CategoryOfDeath = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DCertID", DCertID); } }


		private long _DCertID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DCertID { get { return _DCertID; } set {_DCertID = value; } }

		private string _DCertText;
		[LVRequired]
        [LVMaxLength(20)]
        public string DCertText { get { return _DCertText; } set {_DCertText = value; } }

		private long _HCEpiIDCode;
		[LVRequired]
        public long HCEpiIDCode { get { return _HCEpiIDCode; } set {_HCEpiIDCode = value; } }

		private long? _HCFEDispDiagICDCode;
        public long? HCFEDispDiagICDCode { get { return _HCFEDispDiagICDCode; } set {_HCFEDispDiagICDCode = value; } }

		private DateTime _DCertDeathDtm;
		[LVRequired]
        public DateTime DCertDeathDtm { get { return _DCertDeathDtm; } set {_DCertDeathDtm = value; } }

		private string _DCertDeathCauseCode;
        [LVMaxLength(20)]
        public string DCertDeathCauseCode { get { return _DCertDeathCauseCode; } set {_DCertDeathCauseCode = value; } }

		private string _DCertDeathCauseDesc;
        [LVMaxLength(254)]
        public string DCertDeathCauseDesc { get { return _DCertDeathCauseDesc; } set {_DCertDeathCauseDesc = value; } }

		private bool _IsPostMorternExam;
        public bool IsPostMorternExam { get { return _IsPostMorternExam; } set {_IsPostMorternExam = value; } }

		private string _PostMorternExamDiagnosis;
        [LVMaxLength(254)]
        public string PostMorternExamDiagnosis { get { return _PostMorternExamDiagnosis; } set {_PostMorternExamDiagnosis = value; } }

		private long? _V_CategoryOfDeath;
        public long? V_CategoryOfDeath { get { return _V_CategoryOfDeath; } set {_V_CategoryOfDeath = value; } }

		/// <summary>
/// Ref Key: FK_DeathSituationInfo_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_DeathSituationInfo_ReceivePatient
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
    public class KeyedDeathSituationInfo : KeyedCollection<KeyValuePair<string, long>, DeathSituationInfo>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDeathSituationInfo() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DeathSituationInfo item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DCertID) { return new KeyValuePair<string, long>("DCertID", k_DCertID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DeathSituationInfo item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DeathSituationInfo item)
        {
            DeathSituationInfo orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DeathSituationInfo item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DeathSituationInfo item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DeathSituationInfo GetObjectByKey(long k_DCertID) 
		{
            if (this.Contains(GetKey(k_DCertID)) == false) return null;
            DeathSituationInfo ob = this[GetKey(k_DCertID)];
            return (DeathSituationInfo)ob;
        }

		public DeathSituationInfo GetObjectByKey(long k_DCertID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DCertID)) == false) {
				DeathSituationInfo ob = repository.GetQuery<DeathSituationInfo>().FirstOrDefault(o => o.DCertID == k_DCertID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DeathSituationInfo obj = this[GetKey(k_DCertID)];
            return (DeathSituationInfo)obj;
        }

		public DeathSituationInfo GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DeathSituationInfo ob = this[keypair];
            return (DeathSituationInfo)ob;
        }

        public DeathSituationInfo GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DeathSituationInfo ob = this[GetKey(keypair)];
            return (DeathSituationInfo)ob;
        }

		bool _LoadAll = false;
        public List<DeathSituationInfo> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DeathSituationInfo>().ToList();
			foreach (DeathSituationInfo item in list) {
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

        ~KeyedDeathSituationInfo()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
