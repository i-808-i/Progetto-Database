using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoDatabaseSiintTest
{
    static class RowUtilities
    {
        public static int FieldInt32(DataRow row, string name)
        {
            try
            {
                return (row.IsNull(name) ? 0 : System.Convert.ToInt32(row[name]));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static short FieldInt16(DataRow row, string name)
        {
            try
            {
                return (row.IsNull(name) ? (short)0 : System.Convert.ToInt16(row[name]));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static decimal FieldDecimal(DataRow row, string name)
        {
            try
            {
                return (row.IsNull(name) ? 0 : System.Convert.ToDecimal(row[name]));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static long FieldLong(DataRow row, string name)
        {
            try
            {
                return (row.IsNull(name) ? (long)0 : System.Convert.ToInt64(row[name]));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public static double FieldDouble(DataRow row, string name)
        {
            try
            {
                return (row.IsNull(name) ? (double)0 : System.Convert.ToDouble(row[name]));
            }
            catch (Exception ex)
            {
                return 0.0;
            }
        }

        public static string FieldString(DataRow row, string name)
        {
            try
            {
                return (row.IsNull(name) ? "" : System.Convert.ToString(row[name]));
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
