/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : SAU_tblPrivilegeRole.cs         
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
    public partial class HealthInsurance
    {
        [NotMapped]
        public float RebatePercentage { get; set; } = 0;
    }
}
