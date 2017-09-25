using LV.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Service.Common
{
   public class CommonServices
    {       

       static public string RECEIVE_SEQ
       {
           get
           {
               return "OP";
           }
       }
       static public string PATIENT_SEQ
       {
           get
           {
               return "PT";
           }
       }
       static public string REGISTERSERVICE_SEQ
       {
           get
           {
               return "DL";
           }
       }
       /* Start table AD_tblWhereTransList*/
       static public string WHTRAN_RECEIVE
       {
           get
           {
               return "0";
           }
       }

       static public string WHTRAN_DEPARTMENT
       {
           get
           {
               return "1";
           }
       }

       static public string WHTRAN_EMERGENCY
       {
           get
           {
               return "2";
           }
       }
       static public string WHTRAN_TREATMENT
       {
           get
           {
               return "3";
           }
       }
       static public string WHTRAN_OUT
       {
           get
           {
               return "4";
           }
       }
       /* End table AD_tblWhereTransList*/

       /* Start table AD_tblInsurParameterList*/
        static public string REGLOCALHOSPITAL
       {
           get
           {
               return "IS001";
           }
       }
        static public string INSURANCE_OUT
        {
            get
            {
                return "IS003";
            }
        }
        static public string INSURANCE_IN
        {
            get
            {
                return "IS004";
            }
        }

        static public string INSURPAID_LIMIT
        {
            get
            {
                return "IS002";
            }
        }

        static public string INSURANCE_LENGHT
        {
            get
            {
                return "IS005";
            }
        }

        /* End table AD_tblInsurParameterList*/

       // add by thnthang
        static public int LIMIT_INSURPAID
        {
            get
            {
                return 172500;
            }
        }
    }
}
