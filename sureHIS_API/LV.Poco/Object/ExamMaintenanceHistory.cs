/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ExamMaintenanceHistory.cs         
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
	public partial class ExamMaintenanceHistory : BaseEntity, ICloneable	{
		public ExamMaintenanceHistory()
		{
			this.TIANo = 0;
			this.EqpMDSrcrID = 0;
			this.MEHisCode = 0;
            this.MEHisDate = DateTime.Now;
            this.MEHisCost = null;
            this.MEHisResponsibleItem = null;
            this.IsMaintain = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MEHisCode", MEHisCode); } }


		private long _TIANo;
		[LVRequired]
        public long TIANo { get { return _TIANo; } set {_TIANo = value; } }

		private long _EqpMDSrcrID;
		[LVRequired]
        public long EqpMDSrcrID { get { return _EqpMDSrcrID; } set {_EqpMDSrcrID = value; } }

		private long _MEHisCode;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MEHisCode { get { return _MEHisCode; } set {_MEHisCode = value; } }

		private DateTime _MEHisDate;
		[LVRequired]
        public DateTime MEHisDate { get { return _MEHisDate; } set {_MEHisDate = value; } }

		private string _MEHisCause;
		[LVRequired]
        [LVMaxLength(512)]
        public string MEHisCause { get { return _MEHisCause; } set {_MEHisCause = value; } }

		private string _MEHisResult;
		[LVRequired]
        [LVMaxLength(128)]
        public string MEHisResult { get { return _MEHisResult; } set {_MEHisResult = value; } }

		private double? _MEHisCost;
        public double? MEHisCost { get { return _MEHisCost; } set {_MEHisCost = value; } }

		private string _MEHisResponsibleItem;
        [LVMaxLength(128)]
        public string MEHisResponsibleItem { get { return _MEHisResponsibleItem; } set {_MEHisResponsibleItem = value; } }

		private bool? _IsMaintain;
        public bool? IsMaintain { get { return _IsMaintain; } set {_IsMaintain = value; } }

		/// <summary>
/// Ref Key: FK_ExamMaintenanceHistory_MedicalEquimentsResources
/// <summary>
/// <summary>
/// Ref Key: FK_ExamMaintenanceHistory_TechnicalInspectionAgency
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
    public class KeyedExamMaintenanceHistory : KeyedCollection<KeyValuePair<string, long>, ExamMaintenanceHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedExamMaintenanceHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ExamMaintenanceHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MEHisCode) { return new KeyValuePair<string, long>("MEHisCode", k_MEHisCode); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ExamMaintenanceHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ExamMaintenanceHistory item)
        {
            ExamMaintenanceHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ExamMaintenanceHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ExamMaintenanceHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ExamMaintenanceHistory GetObjectByKey(long k_MEHisCode) 
		{
            if (this.Contains(GetKey(k_MEHisCode)) == false) return null;
            ExamMaintenanceHistory ob = this[GetKey(k_MEHisCode)];
            return (ExamMaintenanceHistory)ob;
        }

		public ExamMaintenanceHistory GetObjectByKey(long k_MEHisCode, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MEHisCode)) == false) {
				ExamMaintenanceHistory ob = repository.GetQuery<ExamMaintenanceHistory>().FirstOrDefault(o => o.MEHisCode == k_MEHisCode);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ExamMaintenanceHistory obj = this[GetKey(k_MEHisCode)];
            return (ExamMaintenanceHistory)obj;
        }

		public ExamMaintenanceHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ExamMaintenanceHistory ob = this[keypair];
            return (ExamMaintenanceHistory)ob;
        }

        public ExamMaintenanceHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ExamMaintenanceHistory ob = this[GetKey(keypair)];
            return (ExamMaintenanceHistory)ob;
        }

		bool _LoadAll = false;
        public List<ExamMaintenanceHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ExamMaintenanceHistory>().ToList();
			foreach (ExamMaintenanceHistory item in list) {
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

        ~KeyedExamMaintenanceHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
