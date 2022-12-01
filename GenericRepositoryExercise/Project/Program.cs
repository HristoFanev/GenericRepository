using DataAccess.Implementation;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.Transactions;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            Breed breed = new Breed();
            GenericRepositoryImplementation<Animal> a = new GenericRepositoryImplementation<Animal>();
            GenericRepositoryImplementation<Breed> b = new GenericRepositoryImplementation<Breed>();

            Console.WriteLine("What you want to do?");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine("What you want to create?");
                Console.WriteLine("1. Animal");
                Console.WriteLine("2. Breed");
                int m = int.Parse(Console.ReadLine());
                if (m == 1)
                {
                    Console.WriteLine("Enter name:");
                    animal.Name = Console.ReadLine();
                    Console.WriteLine("Enter age:");
                    animal.Age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter description:");
                    animal.Description = Console.ReadLine();
                    Console.WriteLine("Enter breedId:");
                    animal.BreedId = int.Parse(Console.ReadLine());
                    a.Create(animal);
                    a.Save();
                }
                else if(m == 2)
                {
                    breed.Id = animal.BreedId;
                    Console.WriteLine("Enter name:");
                    breed.Name = Console.ReadLine();
                    Console.WriteLine("Enter type:");
                    breed.Type = Console.ReadLine();
                    b.Create(breed);
                    b.Save();
                }
            }
            else if (n == 2)
            {
                Console.WriteLine("What do you want to read?");
                Console.WriteLine("1. Animal");
                Console.WriteLine("2. Breed");
                int m = int.Parse(Console.ReadLine());
                if (m == 1)
                {
                    Console.WriteLine("How do you want to read it?");
                    Console.WriteLine("1. By id");
                    Console.WriteLine("2. List All");
                    int k = int.Parse(Console.ReadLine());
                    if (k == 1)
                    {
                        Console.WriteLine("Enter name to find:");
                        var i = int.Parse(Console.ReadLine());
                        Animal animal1 = a.GetById(i);
                        if (animal1 != null)
                        {
                            Console.WriteLine("ID: " + animal1.Id);
                            Console.WriteLine("Name: " + animal1.Name);
                            Console.WriteLine("Age: " + animal1.Age);
                            Console.WriteLine("Description: " + animal1.Description);
                            Console.WriteLine("BreedId: " + animal1.BreedId);
                        }
                        else
                        {
                            Console.WriteLine("Animal is not found!");
                        }
                    }
                    else if (k == 2)
                    {
                        IEnumerable<Animal> a1 = a.GetAll();
                        foreach (var item in a1)
                        {
                            Console.WriteLine(item.Id + " " + item.Name + " " + item.Age + " " + item.Description + " " + item.BreedId);
                        }
                    }
                }
                else if (m == 2)
                {
                    Console.WriteLine("How do you want to read it?");
                    Console.WriteLine("1. By id");
                    Console.WriteLine("2. List All");
                    int k = int.Parse(Console.ReadLine());
                    if (k == 1)
                    {
                        Console.WriteLine("Enter id");
                        int i = int.Parse(Console.ReadLine());
                        Breed breed1 = b.GetById(i);
                        if (breed1 != null)
                        {
                            Console.WriteLine("ID: " + breed1.Id);
                            Console.WriteLine("Name: " + breed1.Name);
                            Console.WriteLine("Type: " + breed1.Type);
                        }
                        else
                        {
                            Console.WriteLine("Breed is not found!");
                        }
                    }
                    else if (k == 2)
                    {
                        IEnumerable<Breed> b1 = b.GetAll();
                        foreach (var item in b1)
                        {
                            Console.WriteLine(item.Id + " " + item.Name + " " + item.Type);
                        }
                    }
                }
            }
            else if (n == 3)
            {
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("1. Animal");
                Console.WriteLine("2. Breed");
                int m = int.Parse(Console.ReadLine());
                if (m == 1)
                {
                    Console.WriteLine("Enter name to find:");
                    int i = int.Parse(Console.ReadLine());
                    Animal animal1 = a.GetById(i);
                    if (animal1 != null)
                    {
                        Console.WriteLine("Enter new name:");
                        animal1.Name = Console.ReadLine();
                        Console.WriteLine("Enter new age:");
                        animal1.Age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new description:");
                        animal1.Description = Console.ReadLine();
                        animal1.BreedId = breed.Id;
                        a.Update(animal1);
                        a.Save();
                    }
                    else
                    {
                        Console.WriteLine("Animal is not found!");
                    }
                }
                else if (m == 2)
                {
                    Console.WriteLine("Eneter id:");
                    int i = int.Parse(Console.ReadLine());
                    Breed breed1 = b.GetById(i);
                    if (breed1 != null)
                    {
                        Console.WriteLine("Enter new name:");
                        breed1.Name = Console.ReadLine();
                        Console.WriteLine("Enter new type:");
                        breed1.Type = Console.ReadLine();
                        b.Update(breed1);
                        b.Save();
                    }
                    else
                    {
                        Console.WriteLine("Breed is not found!");
                    }
                }
            }
            else if(n == 4)
            {
                Console.WriteLine("What do you want to delete?");
                Console.WriteLine("1. Animal");
                Console.WriteLine("2. Breed");
                int m = int.Parse(Console.ReadLine());
                if (m == 1)
                {
                    Console.WriteLine("Enter id for delete");
                    a.Delete(int.Parse(Console.ReadLine()));
                    a.Save();
                }
                else if (m == 2)
                {
                    Console.WriteLine("Enter id for delete: ");
                    b.Delete(int.Parse(Console.ReadLine()));
                    b.Save();
                }

            }




        }
    }
}