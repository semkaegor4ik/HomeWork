using System;
using System.Linq;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Create();
            Read();
            Update();
            Read();
            Delete();
            Read();
        }

        private static void Delete()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Users.RemoveRange(db.Users.Where(user => user.Id % 2 == 1));
                db.SaveChanges();
            }
        }

        private static void Update()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                users.ForEach(u => ++u.Age);
                db.SaveChanges();
            }
        }

        private static void Read()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Users list:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }

        private static void Create()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                db.Users.AddRange(user1, user2);
                db.SaveChanges();
            }
        }
    }
}
