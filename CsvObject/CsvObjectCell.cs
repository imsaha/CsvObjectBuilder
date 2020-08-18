namespace CsvObject
{
    public class CsvObjectCell
    {
        private string _columnName;
        public string ColumnName { get => StringHelper.GetPascalCase(_columnName); set => _columnName = value; }
        public string TypeName { get; set; }
        public string Value { get; private set; }


        public CsvObjectCell Copy() => new CsvObjectCell
        {
            ColumnName = this.ColumnName,
            Value = this.Value,
            TypeName = this.TypeName,
        };

        public void SetValue(string value)
        {
            switch (this.TypeName)
            {
                case "string":
                    Value = $"\"{value}\"";
                    break;
                default:
                    Value = value;
                    break;
            }
        }

        public override string ToString() => $"{TypeName} {ColumnName} {{get;set;}}";
        public string ToString(ClassAccessModifier modifier) => $"{EnumHelper.DisplayValue(modifier)} {ToString()}";
    }

}