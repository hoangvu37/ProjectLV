/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MRParagraph.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class MRParagraph : BaseEntity, ICloneable	{
		public MRParagraph()
		{
			this.PParID = 0;
			this.ParID = 0;
            this.ParDesc = null;
            this.InputInstruction = null;
            this.HTMLOutlineCont = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ParID", ParID); } }


		private long? _PParID;
        public long? PParID { get { return _PParID; } set {_PParID = value; } }

		private long _ParID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ParID { get { return _ParID; } set {_ParID = value; } }

		private string _ParCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string ParCode { get { return _ParCode; } set {_ParCode = value; } }

		private string _ParTitle;
		[LVRequired]
        [LVMaxLength(128)]
        public string ParTitle { get { return _ParTitle; } set {_ParTitle = value; } }

		private string _ParDesc;
        [LVMaxLength(2048)]
        public string ParDesc { get { return _ParDesc; } set {_ParDesc = value; } }

		private string _InputInstruction;
        [LVMaxLength(2048)]
        public string InputInstruction { get { return _InputInstruction; } set {_InputInstruction = value; } }

		private string _HTMLOutlineCont;
        public string HTMLOutlineCont { get { return _HTMLOutlineCont; } set {_HTMLOutlineCont = value; } }

		private string _TextOutlineCont;
        public string TextOutlineCont { get { return _TextOutlineCont; } set {_TextOutlineCont = value; } }

		/// <summary>
/// Ref Key: FK_MRPar_MRPar
/// <summary>
/// <summary>
/// Ref Key: FK_MRPar_MRPar
/// <summary>
/// <summary>
/// Ref Key: FK_MRSectionOutline_MRParagraph
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
    public class KeyedMRParagraph : KeyedCollection<KeyValuePair<string, long>, MRParagraph>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMRParagraph() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MRParagraph item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ParID) { return new KeyValuePair<string, long>("ParID", k_ParID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MRParagraph item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MRParagraph item)
        {
            MRParagraph orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MRParagraph item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MRParagraph item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MRParagraph GetObjectByKey(long k_ParID) 
		{
            if (this.Contains(GetKey(k_ParID)) == false) return null;
            MRParagraph ob = this[GetKey(k_ParID)];
            return (MRParagraph)ob;
        }

		public MRParagraph GetObjectByKey(long k_ParID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ParID)) == false) {
				MRParagraph ob = repository.GetQuery<MRParagraph>().FirstOrDefault(o => o.ParID == k_ParID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MRParagraph obj = this[GetKey(k_ParID)];
            return (MRParagraph)obj;
        }

		public MRParagraph GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MRParagraph ob = this[keypair];
            return (MRParagraph)ob;
        }

        public MRParagraph GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MRParagraph ob = this[GetKey(keypair)];
            return (MRParagraph)ob;
        }

		bool _LoadAll = false;
        public List<MRParagraph> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MRParagraph>().ToList();
			foreach (MRParagraph item in list) {
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

        ~KeyedMRParagraph()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
