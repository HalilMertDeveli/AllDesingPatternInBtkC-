using System;
namespace MediatorDesing
{
    public class Program
    {
        public static void Main()
        {
            Mediator mediator = new Mediator();

            Teacher engin = new Teacher(mediator);
            engin.Name = "Engin";
            mediator.Teacher = engin;


            Student derin = new Student(mediator);
            derin.Name = "derin";
            


            Student salih = new Student(mediator);
            salih.Name = "salih";

            mediator.Students = new List<Student> { derin, salih };

            engin.SendNewImageUrl("slide1.jpg");
            engin.ReceiveQuestion("is it true ?", salih);

            Console.ReadLine();




        }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            this.Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
            
        }

        internal void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher Received a question from Student, question : {0}, student Name:{1}", question, student.Name);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slied = {0}",url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered qestion, student Name: {0},asnwer question: {1}",student.Name,answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public string Name { get; internal set; }

        public void receieImage(string url)
        {
            Console.WriteLine("{1} received Image and url :{0}",url,Name);
        }

        internal void ReceiveAnswer(string answer, Student student)
        {
            Console.WriteLine("Student received answer: {0}", answer);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach(var student in Students)
            {
                student.receieImage(url);
            }
        }
        public void SendQuestion(string question,Student student)
        {
            Teacher.ReceiveQuestion(question,student);
        }
        public void AnswerQuestion(string answer,Student student)
        {
            student.ReceiveAnswer(answer, student);
        }
    }
}