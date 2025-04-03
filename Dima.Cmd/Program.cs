using Dima.Cmd;
using Dima.Data;
using Dima.DataModel;




//CRUD  +Create +Read +Update +Delete

var userService = new UserService();

if (userService.IsExistsData())
{
    Console.WriteLine("Том или элис уже есть в бд");
}
else
{
    userService.Create("Tom", 33);
    //userService.Create("Alice", 26);
    Console.WriteLine("Объекты успешно сохранены");
}

userService.OutputList();
Console.WriteLine("\n----------------------------------\n");

var tom = userService.GetByName("Tom");
if (tom == null)
    throw new Exception($"Пользователь с именем Tom не найден");

//обновляем возраст
userService.Update(tom.Id, tom.Name, 34);

var tomAfterChange = userService.GetById(tom.Id);
Console.WriteLine($"Возраст пользователя {tom.Name} изменен c {tom.Age} на {tomAfterChange!.Age}");


userService.OutputList(); 
Console.WriteLine("\n----------------------------------\n");

userService.Delete(tom.Id);

var tomAfterDelete = userService.GetById(tom.Id);
if (tomAfterDelete != null)
    Console.WriteLine("Пользователь не удалился!!!!!!!!!!");
else
    Console.WriteLine("Пользователь удалился");


userService.OutputList();
Console.WriteLine("\n----------------------------------\n");

Console.ReadLine();