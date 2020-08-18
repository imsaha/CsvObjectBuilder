using System.ComponentModel.DataAnnotations;

namespace CsvObject
{
    public enum ClassAccessModifier
    {
        [Display(Name = "public")]
        Public = 0,

        [Display(Name = "private")]
        Private = 1,

        [Display(Name = "internal")]
        Internal = 2
    }

}