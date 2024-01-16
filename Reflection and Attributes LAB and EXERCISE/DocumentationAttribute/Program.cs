using DocumentationAttributes;
using System.Reflection;

Type[] types = Assembly.GetExecutingAssembly().GetTypes();

foreach (Type type in types)
{
    Console.WriteLine(type.Name);

    DocumentationAttribute doccumentationAttr = type.GetCustomAttribute
            (typeof(DocumentationAttribute)) as DocumentationAttribute;

    if (doccumentationAttr != null)
    {
        Console.WriteLine(doccumentationAttr.Documentation);
    }

    foreach (var method in type.GetMethods())
    {
        doccumentationAttr = method.GetCustomAttribute
            (typeof(DocumentationAttribute)) as DocumentationAttribute;

        if (doccumentationAttr != null)
        {
            Console.WriteLine(doccumentationAttr.Documentation);
        }
    }
}