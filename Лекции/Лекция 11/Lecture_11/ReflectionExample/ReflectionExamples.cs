using System;
using System.Reflection;

namespace ReflectionExample;

public class ReflectionExamples
{
    public static void Example1()
    {
        string str = "simple string";

        Type type = str.GetType();

        Console.WriteLine($"Type of variable str: {type}");

        Person person = new Person("Anton", "Mileshko", 10);
        Console.WriteLine($"Type of variable person: {person.GetType()}");
    }

    public static void Example2()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        foreach (MethodInfo methodInfo in type.GetMethods())
        {
            Console.WriteLine(methodInfo.Name);
        }
    }

    public static void Example3()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        foreach (ConstructorInfo constructorInfo in type.GetConstructors())
        {
            Console.WriteLine(constructorInfo.Name);
        }
    }

    public static void Example4()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        foreach (PropertyInfo propertyInfo in type.GetProperties())
        {
            Console.WriteLine(propertyInfo.Name);
        }
    }

    public static void Example5()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        MethodInfo? methodInfo = type.GetMethod("ToString");

        if (methodInfo is not null)
        {
            string str = methodInfo.Invoke(person, null) as string ?? "Is not string";
            Console.WriteLine(str);
        }
    }

    public static void Example6()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        PropertyInfo? propertyInfo = type.GetProperty("Age");
        int age = (int)propertyInfo.GetValue(person);

        Console.WriteLine(age);
    }

    public static void Example7()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        PropertyInfo? propertyInfo = type.GetProperty("Age");

        if (propertyInfo is not null)
        {
            propertyInfo.SetValue(person, 20);

            Console.WriteLine(person);
        }
        
    }

    public static void Example8()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        ConstructorInfo? constructorInfo = type.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(int) });

        if (constructorInfo is not null)
        {
            Person? newPerson = constructorInfo.Invoke(new object []{"Anton", "Mileshko", 30}) as Person;

            Console.WriteLine(newPerson);
        }
    }

    public static void Example9()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        foreach (PropertyInfo propertyInfo in type.GetProperties())
        {
            foreach (Attribute customAttribute in propertyInfo.GetCustomAttributes())
            {
                Console.WriteLine(customAttribute);
            }
        }
    }

    public static void Example10()
    {
        Person person = new Person("Anton", "Mileshko", 10);
        Type type = person.GetType();

        foreach (PropertyInfo propertyInfo in type.GetProperties())
        {
            foreach (Attribute customAttribute in propertyInfo.GetCustomAttributes())
            {
                if (customAttribute is TestClassAttribute testClassAttribute)
                {
                    if (string.Equals(testClassAttribute.Param1, "Name"))
                    {
                        Console.WriteLine($"Person name is {propertyInfo.GetValue(person)}");
                    }
                    else if (string.Equals(testClassAttribute.Param2, "Age"))
                    {
                        Console.WriteLine($"Person age is {propertyInfo.GetValue(person)}");
                    }
                    
                }
            }
        }
    }

    public static void Example11()
    {
        Attribute attribute1 = new TestClassAttribute();
        Attribute attribute2 = new TestClassAttribute();
        string str = "Simple string";
        Person person = new Person("Anton", "Mileshko", 10);

        Console.WriteLine(attribute1.Match(str));
        Console.WriteLine(attribute1.Match(attribute2));
    }

}