using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LV.Core.DAL.EntityFramework
{
    public class NoLockInterceptor : DbCommandInterceptor
    {
        private static readonly Regex _tableAliasRegex = new Regex(@"((?<!\){1,5})AS \[Extent\d+\](?! WITH \(NOLOCK\)))", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        [ThreadStatic]
        public static bool ApplyNoLock;

        public override void ScalarExecuting(DbCommand command,
            DbCommandInterceptionContext<object> interceptionContext)
        {
            if (ApplyNoLock)
            {
                command.CommandText = _tableAliasRegex.Replace(command.CommandText, delegate (Match mt)
                {
                    return mt.Groups[0].Value + " WITH (NOLOCK) ";
                });
            }
        }

        public override void ReaderExecuting(DbCommand command,
            DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (ApplyNoLock)
            {
                command.CommandText = _tableAliasRegex.Replace(command.CommandText, delegate (Match mt)
                {
                    return mt.Groups[0].Value + " WITH (NOLOCK) ";
                });
            }
        }
    }
}
