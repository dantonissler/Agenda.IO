using System.Data;

namespace Agenda.IO.Business.Util
{
    public static class Extensions
    {
        public static string Get(this DataSet ds, string column)
        {
            return ds.Tables[0].Rows[0][column].ToString();
        }
    }
}
