using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySearcher.Bll.Tests
{
    public class AssertHelper
    {
        public static void HasEqualPropertyValues<T>(T expected, T actual)
        {
            var failures = new List<string>();
            var type = typeof(T);
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var v1 = property.GetValue(expected);
                var v2 = property.GetValue(actual);
                if (v1 == null && v2 == null) continue;
                if (!v1.Equals(v2)) failures.Add(string.Format("{0}: Expected:<{1}> Actual:<{2}>", property.Name, v1, v2));
            }
            if (failures.Any())
                Assert.Fail("AssertHelper.HasEqualpropertyValues failed. " + Environment.NewLine + string.Join(Environment.NewLine, failures));
        }
    }
}


