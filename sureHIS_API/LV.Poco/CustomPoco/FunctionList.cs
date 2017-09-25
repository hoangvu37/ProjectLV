/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PT_tblICD10.cs         
 * Created by           : Auto - 15/05/2015 16:52:08                     
 * Last modify          : Auto - 15/05/2015 16:52:08                     
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

namespace LV.Poco
{
    public partial class FunctionList
    {

        private int _Add;
        [NotMapped]
        public int Add
        {
            get
            {                
                return _Add;
            }
            set
            {
                _Add = value;
            }
        }

        private int _Edit;
        [NotMapped]
        public int Edit
        {
            get
            {
                return _Edit;
            }
            set
            {
                _Edit = value;
            }
        }

        private int _Delete;
        [NotMapped]
        public int Delete
        {
            get
            {
                return _Delete;
            }
            set
            {
                _Delete = value;
            }
        }
        
        private int _View;
        [NotMapped]
        public int View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
            }
        }

        private int _ShareRecord;
        [NotMapped]
        public int ShareRecord
        {
            get
            {
                return _ShareRecord;
            }
            set
            {
                _ShareRecord = value;
            }
        }
    }
}
