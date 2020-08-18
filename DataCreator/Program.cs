using System;
using System.IO;
using System.Text;


namespace DataCreator
{
    class Program
    {
        static void Main(string[] args)
        {

            var testData = "country id,country name \n"
                            + "long,string \n"
                            + "1,Afghanistan \n"
                            + "2,Albania \n"
                            + "3,Algeria \n"
                            + "4,Andorra \n"
                            + "5,Angola \n"
                            + "6,Antigua and Barbuda \n"
                            + "7,Argentina \n"
                            + "8,Armenia \n"
                            + "9,Australia \n"
                            + "10,Austria \n"
                            + "11,Azerbaijan \n"
                            + "12,Bahamas \n"
                            + "13,Bahrain \n"
                            + "14,Bangladesh \n"
                            + "15,Barbados \n";


            var obj = new CsvObject.CsvObject(testData, "MyClass");
            Console.WriteLine(obj.GetClassDefinition());
            Console.WriteLine(obj.GetDataArray());
        }
    }
}
