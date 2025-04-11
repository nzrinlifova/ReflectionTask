/*İstifadəçi clasi yaradin{
private id,
private name,
private soyad
private static age

void GetFullName() metodu ad+tam ad consola yazdirir
statik void ChangeAge(int age) metodu yaş deyerini deyisir
}
Reflection ilə obyekt instance - sını yaradın.
Propertilərin dəyərini set edin daha sonra consola yazdırın.
metodik çağırış edin*/

using ReflectionTask;
using System;
using System.Reflection;
using System.Security.Claims;

Type userType = typeof(User);

User user1 = (User)Activator.CreateInstance(userType);


FieldInfo fieldId = userType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
fieldId.SetValue(user1, "1");

FieldInfo fieldName = userType.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);
fieldName.SetValue(user1, "Nezrin");

FieldInfo fieldSurname = userType.GetField("surname", BindingFlags.NonPublic | BindingFlags.Instance);
fieldSurname.SetValue(user1, "Alifova");

FieldInfo fieldAge = userType.GetField("age", BindingFlags.NonPublic | BindingFlags.Static);
fieldAge.SetValue(user1, 21);


Console.WriteLine("ID: " + fieldId.GetValue(user1));
Console.WriteLine("Ad: " + fieldName.GetValue(user1));
Console.WriteLine("Soyad: " + fieldSurname.GetValue(user1));
Console.WriteLine("Yaş: " + fieldAge.GetValue(user1));



MethodInfo method1 = userType.GetMethod("GetFullName", BindingFlags.Public | BindingFlags.Instance);
method1.Invoke(user1, null);
MethodInfo changeAgeMethod = userType.GetMethod("ChangeAge", BindingFlags.Public | BindingFlags.Static);
changeAgeMethod.Invoke(user1, [22]);

Console.WriteLine($"yasi deyis:{changeAgeMethod}");


