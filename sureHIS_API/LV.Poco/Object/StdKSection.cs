/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : StdKSection.cs         
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
	public partial class StdKSection : BaseEntity, ICloneable	{
		public StdKSection()
		{
			this.StdKSectD = 0;
			this.V_DocType = 0;
            this.StdKSectSummary = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("StdKSectD", StdKSectD); } }


		private long _StdKSectD;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long StdKSectD { get { return _StdKSectD; } set {_StdKSectD = value; } }

		private long _V_DocType;
		[LVRequired]
        public long V_DocType { get { return _V_DocType; } set {_V_DocType = value; } }

		private string _StdKSectTile;
		[LVRequired]
        [LVMaxLength(128)]
        public string StdKSectTile { get { return _StdKSectTile; } set {_StdKSectTile = value; } }

		private string _StdKSectSummary;
        [LVMaxLength(1024)]
        public string StdKSectSummary { get { return _StdKSectSummary; } set {_StdKSectSummary = value; } }

		private string _FilePathLocation;
		[LVRequired]
        [LVMaxLength(256)]
        public string FilePathLocation { get { return _FilePathLocation; } set {_FilePathLocation = value; } }

		/// <summary>
/// Ref Key: FK_ContractDocument_StdKSection
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
    public class KeyedStdKSection : KeyedCollection<KeyValuePair<string, long>, StdKSection>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedStdKSection() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(StdKSection item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_StdKSectD) { return new KeyValuePair<string, long>("StdKSectD", k_StdKSectD); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(StdKSection item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, StdKSection item)
        {
            StdKSection orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(StdKSection item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(StdKSection item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public StdKSection GetObjectByKey(long k_StdKSectD) 
		{
            if (this.Contains(GetKey(k_StdKSectD)) == false) return null;
            StdKSection ob = this[GetKey(k_StdKSectD)];
            return (StdKSection)ob;
        }

		public StdKSection GetObjectByKey(long k_StdKSectD, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_StdKSectD)) == false) {
				StdKSection ob = repository.GetQuery<StdKSection>().FirstOrDefault(o => o.StdKSectD == k_StdKSectD);
				if(ob != null) this.Add(ob);
				return ob;
			}
            StdKSection obj = this[GetKey(k_StdKSectD)];
            return (StdKSection)obj;
        }

		public StdKSection GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            StdKSection ob = this[keypair];
            return (StdKSection)ob;
        }

        public StdKSection GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            StdKSection ob = this[GetKey(keypair)];
            return (StdKSection)ob;
        }

		bool _LoadAll = false;
        public List<StdKSection> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<StdKSection>().ToList();
			foreach (StdKSection item in list) {
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

        ~KeyedStdKSection()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
