using System.Reflection;
using System.Runtime.InteropServices;

Type type = typeof(Person);

FieldInfo fieldInfo = type.GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);
PropertyInfo propertyInfo = type.GetProperty("Name");
MethodInfo methodInfo = type.GetMethod("GetName");


//Person instance = Activator.CreateInstance(type, new object[] {"Alex", 30}) as Person;
Person instance = Activator.CreateInstance(type, "Alex", 30) as Person;

//Console.WriteLine(instance.GetName());

fieldInfo.SetValue(instance, "Gogo");

//Console.WriteLine(instance.GetName());

object result = methodInfo.Invoke(instance, new object[] {"Grisho"});
Console.WriteLine(result);

MemberInfo[] members = type.GetMembers();

;

public class Person
{
    private string name;

    public Person(string name, int age)
    {
        this.name = name;
        Age = age;
    }

    public Person() { }

    public int Age { get; private set; }



    public string GetName(string name) => name;
}






//Type[] types = Assembly.GetExecutingAssembly().GetTypes();

//foreach (Type type in types)
//{
//    Console.WriteLine(type.Name);
//    foreach (var method in type.GetMethods())
//    {
//        Attribute obsolete = method.GetCustomAttribute(typeof(ObsoleteAttribute));

//        if (obsolete != null)
//        {
//            Console.WriteLine(method.Name + " is obsolete");
//        }
//    }
//}


//class Methods
//{
//    [Obsolete]
//    public void RelativelyOldMethod()
//    {

//    }

//    [Obsolete]
//    public void VeryOldMethod()
//    {

//    }
//}









//Type laptop = typeof(Laptop);

//ConstructorInfo[] constructors = laptop.GetConstructors();

//foreach (ConstructorInfo constructor in constructors)
//{
//    ParameterInfo[] parameters = constructor.GetParameters();

//    object[] paramValues = new object[parameters.Length];

//    int index = 0;
//    foreach (ParameterInfo paramInfo in parameters)
//    {
//        paramValues[index++] = GetDefault(paramInfo.ParameterType);
//    }

//    Laptop product = Activator.CreateInstance(laptop, paramValues) as Laptop;

//    Console.WriteLine(product.Name);
//    Console.WriteLine(product.Model);
//    Console.WriteLine(product.Description);
//}


//object GetDefault(Type type)
//{
//    if (type.IsValueType)
//    {
//        Activator.CreateInstance(type);
//    }

//    return null;
//}





//Random rand = (Random)Activator.CreateInstance(typeof(Random));

//Random random = new Random();

//Console.WriteLine(rand.Next());
//Console.WriteLine(random.Next());




//Type type = typeof(Product);

//PropertyInfo[] properties = type.GetProperties((BindingFlags)60);

//foreach (PropertyInfo property in properties)
//{
//    Console.WriteLine(property.Name);
//}

//class Product
//{
//    public string Name { get; set; }

//    private int Value { get; set; }
//}


//Days promotions = Days.Thursday | Days.Saturday | Days.Friday;

//if (promotions.HasFlag(Days.Thursday))
//{
//    Console.WriteLine("Thursday promotion");
//}

//if (promotions.HasFlag(Days.Saturday))
//{
//    Console.WriteLine("Saturday promotion");
//}

//Console.WriteLine((int)promotions);


//enum Days
//{
//    Monday = 0,
//    Tuesday = 1,
//    Wednesday = 2,
//    Thursday = 4,
//    Friday = 8,
//    Saturday = 16,
//    Frist = 32,
//}


//Type type = typeof(Product);

//BindingFlags allFields = BindingFlags.NonPublic
//    | BindingFlags.Instance
//    | BindingFlags.Static
//    | BindingFlags.Public;


//Console.WriteLine((BindingFlags)60);

//FieldInfo[] fields = type.GetFields((BindingFlags)60);

//foreach (FieldInfo field in fields)
//{
//    Console.WriteLine(field.Name);
//}

//class Product
//{
//    public string publicField;
//    private string privateField;
//    protected string protectedField;
//    internal string internalField;

//    public static int publicStaticField;
//}






//Laptop laptop = new()
//{
//    model = 5,
//    name = 6,
//    description = 7,
//    type = 8,
//};

//while (true)
//{
//    Console.WriteLine("Wich field you want to read");

//    string fieldName = Console.ReadLine();

//    GetPropertyValue(DateTime.Now, fieldName);
//}

//void GetPropertyValue(object obj, string fieldName)
//{
//    Type type = obj.GetType();

//    PropertyInfo prop = type.GetProperty(fieldName);

//    Console.WriteLine(prop.GetValue(obj));

//    //field.SetValue(laptop, (int)field.GetValue(laptop) + 1);

//}


//Type type = typeof(Laptop);

//FieldInfo[] fields = type.GetFields();

//foreach (FieldInfo field in fields)
//{
//    Console.WriteLine($"FieldName: {field.Name}");
//    Console.WriteLine($"DeclaringType.Name: {field.DeclaringType.Name}");
//    Console.WriteLine($"IsFamily: {field.IsFamily}");
//    Console.WriteLine($"IsPublic: {field.IsPublic}");
//    Console.WriteLine($"IsStatic: {field.IsStatic}");

//}


