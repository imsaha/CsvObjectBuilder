# CsvObjectBuilder 
### v 1.0


### Write this
```csharp

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


            var obj = new CsvObject.CsvObjectConverter(testData, "MyClass");
            Console.WriteLine(obj.GetClassDefinition());
            Console.WriteLine(obj.GetDataArray());
        }
    }


```


### Output 
```csharp

  internal class MyClass
  {
      internal long CountryId { get; set; }
      internal string CountryName { get; set; }
  }

  MyClass[] data = {
      new MyClass{
          CountryId=1,
          CountryName="Afghanistan"
      },
      new MyClass{
          CountryId=2,
          CountryName="Albania"
      },
      new MyClass{
          CountryId=3,
          CountryName="Algeria"
      },
      new MyClass{
          CountryId=4,
          CountryName="Andorra"
      },
      new MyClass{
          CountryId=5,
          CountryName="Angola"
      },
      new MyClass{
          CountryId=6,
          CountryName="Antigua and Barbuda"
      },
      new MyClass{
          CountryId=7,
          CountryName="Argentina"
      },
      new MyClass{
          CountryId=8,
          CountryName="Armenia"
      },
      new MyClass{
          CountryId=9,
          CountryName="Australia"
      },
      new MyClass{
          CountryId=10,
          CountryName="Austria"
      },
      new MyClass{
          CountryId=11,
          CountryName="Azerbaijan"
      },
      new MyClass{
          CountryId=12,
          CountryName="Bahamas"
      },
      new MyClass{
          CountryId=13,
          CountryName="Bahrain"
      },
      new MyClass{
          CountryId=14,
          CountryName="Bangladesh"
      },
      new MyClass{
          CountryId=15,
          CountryName="Barbados"
      }
  };
        
```

