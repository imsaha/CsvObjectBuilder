using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvObject
{
    public class CsvObject
    {
        private readonly string[] _csvRows;
        private readonly string _className;
        private readonly int _headerIndex;
        private readonly int _dataTypeIndex;
        private readonly int _startLineIndex;


        public CsvObject(
            string csvData,
            string className = "Model",
            int headerIndex = 0,
            int dataTypeIndex = 1,
            int startLineIndex = 2)
        {
            if (string.IsNullOrEmpty(csvData))
                throw new ArgumentNullException(nameof(csvData));


            _csvRows = csvData.Trim().Split('\n');
            _className = className;
            _headerIndex = headerIndex;
            _dataTypeIndex = dataTypeIndex;
            _startLineIndex = startLineIndex;
        }

        private List<CsvObjectCell> getCsvHeadings()
        {
            var headerStrings = _csvRows[_headerIndex];
            var dataTypeStrings = _csvRows[_dataTypeIndex];

            if (string.IsNullOrWhiteSpace(headerStrings) || string.IsNullOrWhiteSpace(dataTypeStrings))
                return null;

            var header = headerStrings.Trim().Split(',');
            var dataTypes = dataTypeStrings.Trim().Split(',');

            var result = new List<CsvObjectCell>();
            for (int i = 0; i < header.Length; i++)
            {
                var headerName = header[i].Replace("\r", "");
                var dataTypeName = dataTypes[i].Replace("\r", "");
                result.Add(new CsvObjectCell
                {
                    ColumnName = headerName.Trim(),
                    TypeName = getTypeName(dataTypeName)
                });
            }
            return result;
        }

        private List<CsvObjectRow> getRows()
        {
            var heading = getCsvHeadings();
            var lines = _csvRows[_startLineIndex..];

            if (lines == null || lines.Length == 0)
                return null;

            // Rows 
            //_______
            //_______
            var result = new List<CsvObjectRow>();
            for (int i = 0; i < lines.Length; i++)
            {
                var row = new CsvObjectRow();
                var lineString = lines[i].Trim();
                if (string.IsNullOrEmpty(lineString))
                    continue;

                // Columns | xx | x | x |
                var columnData = lineString.Split(',');
                for (int j = 0; j < heading.Count; j++)
                {
                    var cell = heading[j].Copy();
                    cell.SetValue(columnData[j].Trim().Replace("\r", ""));
                    row.Cells.Add(cell);
                }
                result.Add(row);
            }
            return result;
        }

        private string getTypeName(string typeName)
        {
            return (typeName.ToLower()) switch
            {
                "long" => "long",
                "int" => "int",
                "double" => "double",
                "float" => "float",
                "string" => "string",
                // Custom
                "number" => "int",
                _ => typeName,
            };
        }
        bool isLastRow(List<CsvObjectRow> rows, CsvObjectRow row) => row.Equals(rows.ElementAtOrDefault(rows.Count - 1));


        /// <summary>
        /// Returns class definition as string
        /// </summary>
        /// <param name="modifier">Access modifier</param>
        /// <returns></returns>
        public string GetClassDefinition(ClassAccessModifier modifier = ClassAccessModifier.Internal)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{EnumHelper.DisplayValue(modifier)} class {_className}");
            builder.AppendLine("{");

            getCsvHeadings().Select(s => builder.AppendLine($"{s.ToString(modifier)}")).ToList();

            builder.AppendLine("}");

            return builder.ToString();
        }


        /// <summary>
        /// Returns the passing object as array of data by the class definition
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string GetDataArray(string propertyName = "data")
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{_className}[] {propertyName} = {{");


            var rows = getRows();
            rows.Select(row =>
                builder.Append($"new {_className}{row}{(isLastRow(rows, row) ? "" : ",")}\n")
            ).ToList();

            builder.AppendLine("}");

            return builder.ToString();
        }
    }

}