/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalEquimentsResources.cs         
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
	public partial class MedicalEquimentsResources : BaseEntity, ICloneable	{
		public MedicalEquimentsResources()
		{
			this.EquipMDSrcrID = 0;
            this.LatestDateExam = DateTime.Now;
            this.ExamCyle = null;
            this.MaintenanceCycle = null;
            this.ExpiryDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EquipMDSrcrID", EquipMDSrcrID); } }


		private long _EquipMDSrcrID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EquipMDSrcrID { get { return _EquipMDSrcrID; } set {_EquipMDSrcrID = value; } }

		private string _SerialNumber;
		[LVRequired]
        [LVMaxLength(32)]
        public string SerialNumber { get { return _SerialNumber; } set {_SerialNumber = value; } }

		private string _Model;
		[LVRequired]
        [LVMaxLength(32)]
        public string Model { get { return _Model; } set {_Model = value; } }

		private string _Barcode;
		[LVRequired]
        [LVMaxLength(20)]
        public string Barcode { get { return _Barcode; } set {_Barcode = value; } }

		private DateTime? _LatestDateExam;
        public DateTime? LatestDateExam { get { return _LatestDateExam; } set {_LatestDateExam = value; } }

		private byte? _ExamCyle;
        public byte? ExamCyle { get { return _ExamCyle; } set {_ExamCyle = value; } }

		private byte? _MaintenanceCycle;
        public byte? MaintenanceCycle { get { return _MaintenanceCycle; } set {_MaintenanceCycle = value; } }

		private DateTime? _ExpiryDate;
        public DateTime? ExpiryDate { get { return _ExpiryDate; } set {_ExpiryDate = value; } }

		/// <summary>
/// Ref Key: FK_AssignMedEquip_MedicalEquimentsResources
/// <summary>
/// <summary>
/// Ref Key: FK_EquipHistory_MedicalEquimentsResources
/// <summary>
/// <summary>
/// Ref Key: FK_ExamMaintenanceHistory_MedicalEquimentsResources
/// <summary>
/// <summary>
/// Ref Key: FK_PatientDiagnosticImaging_MedicalEquimentsResources
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_MedicalEquimentsResources
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
    public class KeyedMedicalEquimentsResources : KeyedCollection<KeyValuePair<string, long>, MedicalEquimentsResources>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalEquimentsResources() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalEquimentsResources item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EquipMDSrcrID) { return new KeyValuePair<string, long>("EquipMDSrcrID", k_EquipMDSrcrID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalEquimentsResources item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalEquimentsResources item)
        {
            MedicalEquimentsResources orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalEquimentsResources item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalEquimentsResources item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalEquimentsResources GetObjectByKey(long k_EquipMDSrcrID) 
		{
            if (this.Contains(GetKey(k_EquipMDSrcrID)) == false) return null;
            MedicalEquimentsResources ob = this[GetKey(k_EquipMDSrcrID)];
            return (MedicalEquimentsResources)ob;
        }

		public MedicalEquimentsResources GetObjectByKey(long k_EquipMDSrcrID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EquipMDSrcrID)) == false) {
				MedicalEquimentsResources ob = repository.GetQuery<MedicalEquimentsResources>().FirstOrDefault(o => o.EquipMDSrcrID == k_EquipMDSrcrID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalEquimentsResources obj = this[GetKey(k_EquipMDSrcrID)];
            return (MedicalEquimentsResources)obj;
        }

		public MedicalEquimentsResources GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalEquimentsResources ob = this[keypair];
            return (MedicalEquimentsResources)ob;
        }

        public MedicalEquimentsResources GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalEquimentsResources ob = this[GetKey(keypair)];
            return (MedicalEquimentsResources)ob;
        }

		bool _LoadAll = false;
        public List<MedicalEquimentsResources> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalEquimentsResources>().ToList();
			foreach (MedicalEquimentsResources item in list) {
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

        ~KeyedMedicalEquimentsResources()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
