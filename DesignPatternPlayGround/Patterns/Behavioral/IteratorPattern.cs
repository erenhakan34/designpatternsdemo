using System;
using System.Collections.Generic;

namespace DesignPatternPlayGround.Patterns
{
    public static class IteratorPattern
    {
        public static void Run()
        {
            Console.WriteLine("Iterator Pattern\n-----------------\n");

            StudentCollection students = new StudentCollection();
            students.Add(new Student() { Name = "Hakan", Number = 1 });
            students.Add(new Student() { Name = "Eren", Number = 2 });

            var iterator = students.CreateIterator();

            while (iterator.HasItem())
            {
                var currentStudent = iterator.CurrentItem();
                Console.WriteLine($"Name = {currentStudent.Name} - Number = {currentStudent.Number}");
                iterator.NextItem();
            }
        }
    }


    public class Student
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }

    public interface ICollection<TEntity>
    {
        IIterator<TEntity> CreateIterator();
    }

    public class StudentCollection : ICollection<Student>
    {
        private readonly List<Student> _students;

        public StudentCollection()
        {
            _students = new List<Student>();
        }

        public void Add(Student student) => _students.Add(student);
        public Student Get(int index) => _students[index];
        public int Count { get => _students.Count; }

        public IIterator<Student> CreateIterator()
        {
            return new StudentIterator(this);
        }
    }

    public interface IIterator<TEntity>
    {
        //Bir sonraki adımda eleman var mı?
        bool HasItem();
        //Bir sonraki adımdaki elemanı getir.
        TEntity NextItem();
        //Mevcut elemanı getir.
        TEntity CurrentItem();
    }

    public class StudentIterator : IIterator<Student>
    {
        private readonly StudentCollection _students;
        private int currentindex;

        public StudentIterator(StudentCollection students)
        {
            _students = students;
        }

        public Student CurrentItem()
        {
            return _students.Get(currentindex);
        }

        public bool HasItem()
        {
            if (currentindex < _students.Count)
                return true;
            return false;
        }

        public Student NextItem()
        {
            if (HasItem())
                return _students.Get(currentindex++);
            return new Student();
        }
    }
}
