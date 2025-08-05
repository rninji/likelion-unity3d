using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyOuterJoin : MonoBehaviour
{
    [Serializable]
    public class Student
    {
        public int studentID;
        public string studentName;

        public Student(int studentID, string studentName)
        {
            this.studentID = studentID;
            this.studentName = studentName;
        }
    }

    [Serializable]
    public class Grade
    {
        public int studentID;
        public int score;
        public string subject;

        public Grade(int studentID, int score, string subject)
        {
            this.studentID = studentID;
            this.score = score;
            this.subject = subject;
        }
    }
    
    public List<StudyInnerJoin.Student> students = new List<StudyInnerJoin.Student>();
    public List<StudyInnerJoin.Grade> grades = new List<StudyInnerJoin.Grade>();

    void Start()
    {
        students.Add(new StudyInnerJoin.Student(1, "Alice"));
        students.Add(new StudyInnerJoin.Student(2, "Bob"));
        students.Add(new StudyInnerJoin.Student(4, "Eve"));
        students.Add(new StudyInnerJoin.Student(6, "Dave"));

        grades.Add(new StudyInnerJoin.Grade(1, 90, "Math"));
        grades.Add(new StudyInnerJoin.Grade(2, 85, "Science"));
        grades.Add(new StudyInnerJoin.Grade(3, 92, "English"));
        grades.Add(new StudyInnerJoin.Grade(5, 76, "Math"));
        grades.Add(new StudyInnerJoin.Grade(6, 90, "History"));
        
        OuterJoin();
    }

    void OuterJoin()
    {
        var leftOuterJoin = from student in students
                                                            join grade in grades.DefaultIfEmpty() on student.studentID equals grade.studentID into studentGrades
                                                            from grade in studentGrades.DefaultIfEmpty()
                                                            select new
                                                            {
                                                                StudentId = student.studentID,
                                                                StudentName = student.studentName,
                                                                Subject = grade?.subject,
                                                                Score = grade?.score ?? 0 // null이면 0을 넣는다.
                                                            };
        Debug.Log("Left");
        foreach (var person in leftOuterJoin)
        {
            Debug.Log($"ID : {person.StudentId} / Name : {person.StudentName} / Subject : {person.Subject} / Score : {person.Score}");
        }
        
        var rightOuterJoin = from grade in grades
                                                            join student in students on grade.studentID equals student.studentID into gradeStudents
                                                            from student in gradeStudents.DefaultIfEmpty()
                                                            where student == null
                                                            select new
                                                            {
                                                                StudentId = grade.studentID,
                                                                StudentName = "N/A",
                                                                Subject = grade.subject,
                                                                Score = grade.score 
                                                            };

        var outerJoin = leftOuterJoin.Union(rightOuterJoin);

        Debug.Log("Full");
        foreach (var person in outerJoin)
        {
            Debug.Log($"ID : {person.StudentId} / Name : {person.StudentName} / Subject : {person.Subject} / Score : {person.Score}");
        }
    }
}
