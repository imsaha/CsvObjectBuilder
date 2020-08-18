using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvObject
{
    public class CsvObjectRow
    {
        public CsvObjectRow()
        {
            Cells = new HashSet<CsvObjectCell>();
        }


        public ICollection<CsvObjectCell> Cells { get; private set; }

        bool isLastCell(CsvObjectCell cell) => cell.Equals(Cells.ElementAtOrDefault(this.Cells.Count - 1));

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("{");
            Cells.Select(cell => builder.AppendLine($"{cell.ColumnName}={cell.Value}{(isLastCell(cell) ? "" : ",")}")).ToList();
            builder.Append("}");

            return builder.ToString();
        }

    }

}