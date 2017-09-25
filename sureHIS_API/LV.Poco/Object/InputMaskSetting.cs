/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : InputMaskSetting.cs         
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
	public partial class InputMaskSetting : BaseEntity, ICloneable	{
		public InputMaskSetting()
		{
			this.InputMaskID = 0;
            this.InputMaskDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, int> Key { get { return new KeyValuePair<string, int>("InputMaskID", InputMaskID); } }


		private int _InputMaskID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public int InputMaskID { get { return _InputMaskID; } set {_InputMaskID = value; } }

		private string _InputMaskName;
		[LVRequired]
        [LVMaxLength(64)]
        public string InputMaskName { get { return _InputMaskName; } set {_InputMaskName = value; } }

		private string _InpuMask;
		[LVRequired]
        [LVMaxLength(32)]
        public string InpuMask { get { return _InpuMask; } set {_InpuMask = value; } }

		private string _InputMaskDesc;
        [LVMaxLength(256)]
        public string InputMaskDesc { get { return _InputMaskDesc; } set {_InputMaskDesc = value; } }

		private string _PlaceholderFmt;
        [LVMaxLength(32)]
        public string PlaceholderFmt { get { return _PlaceholderFmt; } set {_PlaceholderFmt = value; } }

		

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
    public class KeyedInputMaskSetting : KeyedCollection<KeyValuePair<string, int>, InputMaskSetting>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedInputMaskSetting() : base() { }

        protected override KeyValuePair<string, int> GetKeyForItem(InputMaskSetting item)
        {
            return item.Key;
        }

        public KeyValuePair<string, int> GetKey(int k_InputMaskID) { return new KeyValuePair<string, int>("InputMaskID", k_InputMaskID); }

        public KeyValuePair<string, int> GetKey(object keypair) { try { return (KeyValuePair<string, int>)keypair; } catch { return new KeyValuePair<string, int>(); } }
        #endregion

        #region Method
        public bool AddObject(InputMaskSetting item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, int> keypair, InputMaskSetting item)
        {
            InputMaskSetting orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(InputMaskSetting item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(InputMaskSetting item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public InputMaskSetting GetObjectByKey(int k_InputMaskID) 
		{
            if (this.Contains(GetKey(k_InputMaskID)) == false) return null;
            InputMaskSetting ob = this[GetKey(k_InputMaskID)];
            return (InputMaskSetting)ob;
        }

		public InputMaskSetting GetObjectByKey(int k_InputMaskID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_InputMaskID)) == false) {
				InputMaskSetting ob = repository.GetQuery<InputMaskSetting>().FirstOrDefault(o => o.InputMaskID == k_InputMaskID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            InputMaskSetting obj = this[GetKey(k_InputMaskID)];
            return (InputMaskSetting)obj;
        }

		public InputMaskSetting GetObjectByKey(KeyValuePair<string, int> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            InputMaskSetting ob = this[keypair];
            return (InputMaskSetting)ob;
        }

        public InputMaskSetting GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            InputMaskSetting ob = this[GetKey(keypair)];
            return (InputMaskSetting)ob;
        }

		bool _LoadAll = false;
        public List<InputMaskSetting> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<InputMaskSetting>().ToList();
			foreach (InputMaskSetting item in list) {
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

        ~KeyedInputMaskSetting()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
