using ef.core.demo.ForegnKey;
using ef.core.demo.ManyToMany;
using ef.core.demo.OneToMany;
using ef.core.demo.OneToOne;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace ef.core.demo;

internal class Program
{
    static void Main(string[] args)
    {
        MainManyToMany();
    }

    static public void MainForeignKey()
    {
        var dbContext = new ApplicationContextForeignKey();

        var company1 = new CompanyForeignKey { Name = "Mallenom" };

        var user1 = new UserForeignKey { Name = "Hohol", Company = company1 };
        var user2 = new UserForeignKey { Name = "RussianHero", Company = company1 };

        dbContext.Companies.Add(company1);
        dbContext.Users.AddRange(user1, user2);
        dbContext.SaveChanges();
    }

    #region OneToOne

    static public void MainOneToOne()
    {
        // Отношение один к одному предполагает, что главная сущность может ссылаться только на один объект зависимой сущности.
        // В свою очередь, зависимая сущность может ссылаться только на один объект главной сущности.

        var dbContext = new ApplicationContextOneToOne();

        var user1 = new UserOneToOne { Login = "login1", Password = "pass1234" };
        var user2 = new UserOneToOne { Login = "login2", Password = "12345" };
        dbContext.Users.AddRange(user1, user2);

        var profile1 = new UserProfileOneToOne { Age = 22, Name = "Tom", User = user1 };
        var profile2 = new UserProfileOneToOne { Age = 27, Name = "Alice", User = user2 };
        dbContext.UserProfiles.AddRange(profile1, profile2);

        dbContext.SaveChanges();
    }

    static public void OneToOnePractice()
    {
        var dbContext = new ApplicationContextOneToOne();

        var user = dbContext.Users.Include(u => u.Profile).FirstOrDefault();

        var profile = dbContext.UserProfiles.Include(p => p.User).FirstOrDefault(p => p.Name == "Alice");
    }

    #endregion

    #region OneToMany

    static public void MainOneToMany()
    {
        // Отношение OneToMany представлячет ситуацию, когда одна сущность хранит ссылку на один объект другой сущности,
        // а вторая сущность может ссылаться на коллекцию объектов первой сущности.
        // Например в одной компании может работать несколько сотрудников, а каждый сотрудник, в свою очередь, может официально работать только в одной компании

        var dbContext = new ApplicationContextOneToMany();

        var microsoft = new CompanyOneToMany { Name = "Microsoft" };
        var google = new CompanyOneToMany { Name = "Google" };
        dbContext.Company.AddRange(microsoft, google);

        var tom = new UserOneToMany { Name = "Tom", Company = microsoft };
        var bob = new UserOneToMany { Name = "Bob", Company = microsoft };
        var alice = new UserOneToMany { Name = "Alice", Company = google };
        dbContext.Users.AddRange(tom, bob, alice);

        dbContext.SaveChanges();
    }

    static public void OneToManyPractice()
    {
        var dbContext = new ApplicationContextOneToMany();

        var users = dbContext.Users.Include(u => u.Company).ToList();
        foreach (var user in users)
            Console.WriteLine($"{user.Name} {user.Company?.Name}");

        var companies = dbContext.Company.Include(c => c.Users).ToList();
        foreach (var company in companies)
        {
            foreach (var userInCompany in company.Users)
                Console.WriteLine($"{company.Name} {userInCompany.Name}");
        }
    }

    static public void OneToManyPractice2()
    {
        var dbContext = new ApplicationContextOneToMany();

        var company = dbContext.Company.FirstOrDefault(c => c.Name == "Microsoft");
        if(company != null)
        {
            company.Name = "Mallenom";
            dbContext.SaveChanges();
        }

        var companyFromDb = dbContext.Company.Include(c => c.Users).FirstOrDefault(c => c.Name == "Mallenom");
        foreach (var userInCompany in companyFromDb!.Users)
            Console.WriteLine($"{companyFromDb.Name} - {userInCompany.Name}");
    }

    #endregion

    #region ManyToMany

    static public void MainManyToMany()
    {
        // Отношение многие-ко-многим представляет связь, при которой объект одной сущности может ссылаться на множество объектов второй сущности,
        // а объекта второй сущности, в свою очередь, может ссылаться на множество объектов первой сущности.
        // Примером подобного отношения может служить посещение студентами университетских курсов.
        // Один студент может посещать сразу несколько курсов, и, в свою очередь, один курс может посещаться множеством студентов.

        var dbContext = new ApplicationContextManyToMany();

        var tom = new Student { Name = "Tom" };
        var alice = new Student { Name = "Alice" };
        var bob = new Student { Name = "Bob" };
        dbContext.Students.AddRange(tom, alice, bob);

        var algorithms = new Course { Name = "Алгоритмы" };
        var basics = new Course { Name = "Основы программирования" };
        dbContext.Courses.AddRange(algorithms, basics);

        tom.Courses.Add(algorithms);
        tom.Courses.Add(basics);

        alice.Courses.Add(algorithms);

        bob.Courses.Add(basics);

        dbContext.SaveChanges();
    }

    #endregion
}
