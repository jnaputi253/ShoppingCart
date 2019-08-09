using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Utilities.Extensions
{
    public static class ListExtensions
    {
        public static string ConvertToSqlPlaceholders(this List<int> ids)
        {
            var sqlStringBuilder = new StringBuilder();
            sqlStringBuilder.Append("(");
            sqlStringBuilder.Append(
                ids.Select(id => id.ToString())
                    .Aggregate((firstId, secondId) => $"{firstId},{secondId}"));
            sqlStringBuilder.Append(")");

            return sqlStringBuilder.ToString();
        }
    }
}
