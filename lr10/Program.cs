using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace lr10
{

    class Transformer : IComparable<Transformer>
    {
        public Transformer(string mark, int powerLevel) => (Mark, PowerLevel) = (mark, powerLevel);

        public DateTime CreationDate { get; } = DateTime.Now;

        public readonly string Mark;
        public int PowerLevel{get; set;}
        public int CompareTo(Transformer other) => PowerLevel.CompareTo(other.PowerLevel);

        public override string ToString() => $"Трансформер \"{Mark}\", Уровень мощности: {PowerLevel}, Дата создания: {CreationDate.ToString("d")}";
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1
            var arrayList = new ArrayList();

            var rand = new Random();

            for(int i = 0; i < 5; i++)
            {
                arrayList.Add(rand.Next(10));
            }


            var @string = "string";
            arrayList.Add(@string);


            var student = new Student("савельев талан михайлович 03.07.1998", "улица1 блаблабла", "+375445938865", "ХТиТ", 2, 3);
            arrayList.Add(student);

          
            arrayList.Remove(@string);

            Console.WriteLine(arrayList.Count);

            foreach (var el in arrayList)
            {
                Console.WriteLine(el);
            }
           
            var target = student;

           
            Console.WriteLine((from object obj in arrayList where obj.Equals(target) select obj).First());




            //2

            var hashSet = new HashSet<long>() { 1335, 1245, 109, 475, 137 };

            foreach (var el in hashSet)
            {
                Console.WriteLine(el);
            }
        
             
            hashSet.RemoveWhere(el => el <= 475); //удалено 3 последовательных

            hashSet.Add(10);

  
            var linkedList = new LinkedList<long>();
            

            foreach(var el in hashSet)
            {
                linkedList.AddLast(el);
            }

            Console.WriteLine(linkedList.Find(1335).Value);
            //f


            var hashSetT = new HashSet<Transformer>() { new Transformer("Тестовая модель", 4),
                new Transformer("Тестовая модель", 3), new Transformer("Тестовая модель", 2),
                new Transformer("Тестовая модель", 2), new Transformer("Тестовая модель", 1),
                new Transformer("Тестовая модель", 9)
            };

            foreach (var el in hashSetT)
            {
                Console.WriteLine(el);
            }


            hashSetT.RemoveWhere(el => el.PowerLevel <= 3);

            var mark5 = new Transformer("Модель 5", 8);

            hashSetT.Add(mark5);


            
            var linkedListT = new LinkedList<Transformer>();
 
            foreach (var el in hashSetT)
            {
                linkedListT.AddLast(el);
            }

            Console.WriteLine(linkedListT.Find(mark5).Value);


            var observableTransformers = new ObservableCollection<Transformer>() { new Transformer("Тестовая модель", 4) };
            observableTransformers.CollectionChanged += ChangeHandler;

            observableTransformers.Add(new Transformer("Тестовая модель 2", 7));
            observableTransformers[0] = new Transformer("Новая модель", 13);
            observableTransformers.RemoveAt(0);
            observableTransformers.Clear();

            void ChangeHandler(object obj, NotifyCollectionChangedEventArgs args)
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Console.WriteLine($"Добавлен {args.NewItems[0] as Transformer}");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Console.WriteLine($"Удален элемент {args.OldItems[0] as Transformer}");
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        Console.WriteLine("Коллекция сброшена");
                        break;

                    case NotifyCollectionChangedAction.Replace:  
                        Console.WriteLine($"Элемент {args.OldItems[0] as Transformer} заменен на {args.NewItems[0] as Transformer}");
                        break;
                    default: break;
                }
           }


        }
    }
}
