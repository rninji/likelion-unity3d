using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyLinq2 : MonoBehaviour
{
    public class Person
    {
        public string name;
        public int score;

        public Person(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public List<Person> persons = new List<Person>();
    public int cutline = 70;
    
    void Start()
    {
        persons.Add(new Person("John", 65));
        persons.Add(new Person("Sarah", 80));
        persons.Add(new Person("David", 95));
        persons.Add(new Person("Emily", 70));
        persons.Add(new Person("Michael", 50));
        
        CheckScore();
    }

    void CheckScore()
    {
        // Linq 사용 X
        foreach (Person p in persons)
        {
            if (p.score > cutline)
                Debug.Log($"통과 {p.name}");
            else
                Debug.Log($"불통 {p.name}");
        }
        
        // Linq 사용
        var passPerons = persons.Where(p => p.score >= cutline);
        var failPersons = persons.Except(passPerons);

        foreach (var p in  passPerons)
            Debug.Log($"<color=green>{p.name}</color>");
        foreach (var p in  failPersons)
            Debug.Log($"<color=red>{p.name}</color>");
    }
}
