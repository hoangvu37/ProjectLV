using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Common
{
    public class LVMethodCommon
    {
        /// <summary>
        /// Trả về đúng kiểu entity với tên entity truyền vào
        /// </summary>
        /// <param name="EntityName">Tên Entity</param>
        /// <returns>Kiểu entity</returns>
        public static Type GetEntityType(string EntityName)
        {
            var type = Type.GetType(EntityName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())//Duyệt qua từng assembly có trong reference của project
            {
                type = a.GetType(EntityName);
                if (type != null)
                    return type;
            }
            return null;
        }
    }
}
