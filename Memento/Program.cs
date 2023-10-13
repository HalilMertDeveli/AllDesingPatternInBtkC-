using System;
namespace Memento
{
    public class Program
    {
        public static void Main()
        {

            Console.ReadLine();
        }
    }
}
public class Book
{
    private string _title;
    private string _author;
    private string _isbn;
    private DateTime _lastEdited;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            SetLastEdited();
        }
    }
    public string Author { get => _author; set { _author = value; SetLastEdited(); } }
    public string Isbn { get => _isbn; set { _isbn = value; SetLastEdited(); } }
    private void SetLastEdited()
    {
        _lastEdited = DateTime.UtcNow;
    }
    public Memontos CreateUndo()
    {
        return new Memontos(_isbn, _title, _author, _lastEdited);
    }
    public void ResotoreFromUndo(Memontos memontos)
    {
        _title = mement
    }
}
public class Memontos
{
    public string Title { get; set; }
    public string  Author { get; set; }
    public string Isbn { get; set; }
    public DateTime LastEdited { get; set; }

    public Memontos(string title,string author,string isbn,DateTime LastEdited)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        
    }
   
}
public class CareTaker
{
    public Memontos Memonto { get; set; }
}
