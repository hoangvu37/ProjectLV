/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalBills.cs         
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
	public partial class MedicalBills : BaseEntity, ICloneable	{
		public MedicalBills()
		{
			this.MedBillsID = 0;
			this.MedBillID = 0;
			this.DrugID = 0;
			this.Qty = 0;
			this.UnitPrice = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedBillsID", MedBillsID); } }


		private long _MedBillsID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedBillsID { get { return _MedBillsID; } set {_MedBillsID = value; } }

		private long _MedBillID;
		[LVRequired]
        public long MedBillID { get { return _MedBillID; } set {_MedBillID = value; } }

		private long _DrugID;
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private string _DrugNameOrAcPrincipleName;
		[LVRequired]
        [LVMaxLength(64)]
        public string DrugNameOrAcPrincipleName { get { return _DrugNameOrAcPrincipleName; } set {_DrugNameOrAcPrincipleName = value; } }

		private string _MedcnDoseUnitCode;
        [LVMaxLength(10)]
        public string MedcnDoseUnitCode { get { return _MedcnDoseUnitCode; } set {_MedcnDoseUnitCode = value; } }

		private double _Qty;
		[LVRequired]
        public double Qty { get { return _Qty; } set {_Qty = value; } }

		private double _UnitPrice;
		[LVRequired]
        public double UnitPrice { get { return _UnitPrice; } set {_UnitPrice = value; } }

		private string _Notes;
        [LVMaxLength(128)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_MedicalBills_MedicalBill
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
    public class KeyedMedicalBills : KeyedCollection<KeyValuePair<string, long>, MedicalBills>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalBills() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalBills item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedBillsID) { return new KeyValuePair<string, long>("MedBillsID", k_MedBillsID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalBills item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalBills item)
        {
            MedicalBills orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalBills item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalBills item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalBills GetObjectByKey(long k_MedBillsID) 
		{
            if (this.Contains(GetKey(k_MedBillsID)) == false) return null;
            MedicalBills ob = this[GetKey(k_MedBillsID)];
            return (MedicalBills)ob;
        }

		public MedicalBills GetObjectByKey(long k_MedBillsID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedBillsID)) == false) {
				MedicalBills ob = repository.GetQuery<MedicalBills>().FirstOrDefault(o => o.MedBillsID == k_MedBillsID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalBills obj = this[GetKey(k_MedBillsID)];
            return (MedicalBills)obj;
        }

		public MedicalBills GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalBills ob = this[keypair];
            return (MedicalBills)ob;
        }

        public MedicalBills GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalBills ob = this[GetKey(keypair)];
            return (MedicalBills)ob;
        }

		bool _LoadAll = false;
        public List<MedicalBills> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalBills>().ToList();
			foreach (MedicalBills item in list) {
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

        ~KeyedMedicalBills()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
