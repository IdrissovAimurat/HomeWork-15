using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace HomeWork_15
{
    /// <summary>
    ///     Сперва не знал почему выводися несколько некоторые методы класса Console, 
    ///     но потом понял, что это из-за перегрузки.
    ///     Вот, например, метод WriteLine имеет множество перегрузок для различных типов данных
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // 1. С помощью рефлексии получить список методов класса Console и вывести на экран.
            Type consoleType = typeof(Console);
            MethodInfo[] consoleMethods = consoleType.GetMethods();
            Console.WriteLine("1) Список методов класса Console:");
            foreach (MethodInfo method in consoleMethods)
            {
                Console.WriteLine(method.Name);
            }

            // 2. Создать экземпляр класса Employee и инициализировать его свойства.
            Employee employee = new Employee("Idrissov", "Aimurat", 20, "AntiFacist");

            // 3. С помощью рефлексии получить свойства и их значения из созданного экземпляра класса.
            Type employeeType = typeof(Employee);
            PropertyInfo[] employeeProperties = employeeType.GetProperties();
            Console.WriteLine("\n3) Описание и свойство: ");
            foreach (PropertyInfo property in employeeProperties)
            {
                object value = property.GetValue(employee);
                Console.WriteLine($"{property.Name}: {value}");
            }

            // 4. С помощью рефлексии вызвать метод Substring класса String и извлечь из строки подстроку заданного размера.
            string sampleString = "Футбольчик";
            MethodInfo substringMethod = typeof(string).GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
            object[] parameters = { 0, 6 };
            string result = (string)substringMethod.Invoke(sampleString, parameters);
            Console.WriteLine($"\n4) Substring: '{sampleString}' - {result}");
        }
    }
}
