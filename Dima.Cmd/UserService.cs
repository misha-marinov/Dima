using Dima.Data;
using Dima.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Dima.Cmd
{
    /// <summary>
    /// Сервис для работы с таблицей Users в базе данных
    /// </summary>
    public class UserService
    {

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <returns></returns>
        public List<User> GetList()
        {
            using var db = new DataContext();
            // получаем объекты из бд и выводим на консоль
            var users = db.Users.ToList();//.Where(u => u.Name == "Tom")
            return users;
        }
        /// <summary>
        /// Вывести список пользователей в консоль
        /// </summary>
        public void OutputList()
        {
            var users = GetList();
            Console.WriteLine("Список объектов:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
        }
        /// <summary>
        /// проверить есть ли в таблице хоть один пользователь
        /// </summary>
        /// <returns></returns>
        public bool IsExistsData()
        {
            //если нужно проверить что-то определенное то в Any добавляестя условие
            //_db.Users.Any(user => user.Name == "Tom" || user.Name == "Alice")
            using var db = new DataContext();
            var any = db.Users.Any();
            return any;
            //var anyTomAndAlice = _db.Users.Any(user => user.Name == "Tom" || user.Name == "Alice");
        }

        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User? GetById(int id)
        {
            using var db = new DataContext();
            return GetById(db,id);
        }
        /// <summary>
        /// получить пользователя по айди, с передачей контекста для дальнейших операций
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private User? GetById(DataContext db, int id)
        {
            //Если уверен что запись есть то First(user => user.Id == id)
            var user = db.Users.FirstOrDefault(user => user.Id == id);
            return user;
        }


        /// <summary>
        /// Получить пользователя по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User? GetByName(string name) 
        {
            using var db = new DataContext();
            var user = db.Users.FirstOrDefault(user => user.Name == name);
            return user;
        }
        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public User Create(string name, int age)
        {
            using var db = new DataContext();
            // создаем тома
            User tom = new User { Name = name, Age = age };
            // добавляем его в бд
            db.Users.Add(tom);
            db.SaveChanges();
            return tom;
        }
        /// <summary>
        /// Обновить у пользователя имя и возраст
        /// </summary>
        /// <param name="id">айди пользователя</param>
        /// <param name="name">имя</param>
        /// <param name="age">возраст</param>
        /// <returns></returns>
        /// <exception cref="Exception">Срабатывает если не найден пользователь</exception>
        public User Update(int id, string? name, int age)
        {
            using var db = new DataContext();
            var user = GetById(db, id);
            if (user == null)
                throw new Exception($"Пользователь с Id {id} не найден");
            user.Name = name;
            user.Age = age;
            db.SaveChanges();
            return user;
        }
        /// <summary>
        /// Обновить у пользователя имя 
        /// </summary>
        /// <param name="id">айди пользователя</param>
        /// <param name="name">имя</param>
        /// <returns></returns>
        /// <exception cref="Exception">Срабатывает если не найден пользователь</exception>
        public User UpdateName(int id, string name)
        {
            using var db = new DataContext();
            var user = GetById(db, id);
            if (user == null)
                throw new Exception($"Пользователь с Id {id} не найден");
            user.Name = name;
            db.SaveChanges();
            return user;
        }
        /// <summary>
        /// Обновить у пользователя  возраст
        /// </summary>
        /// <param name="id">айди пользователя</param>
        /// <param name="age">возраст</param>
        /// <returns></returns>
        /// <exception cref="Exception">Срабатывает если не найден пользователь</exception>
        public User UpdateAge(int id, int age)
        {
            using var db = new DataContext();
            var user = GetById(db, id);
            if (user == null)
                throw new Exception($"Пользователь с Id {id} не найден");
            user.Age = age;
            db.SaveChanges();
            return user;
        }
        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id">ид</param>
        public void Delete(int id) 
        {
            using var db = new DataContext();
            var user = GetById(db,id);
            if (user == null)
                return;
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
