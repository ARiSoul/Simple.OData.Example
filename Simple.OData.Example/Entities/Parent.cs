namespace Simple.OData.Example.Entities;

public class Parent
{
    public string Key { get; set; } 
    public string Name { get; set; }
    public ICollection<Child> Children { get; set; }

    public Parent()
    {
        Children = new List<Child>();
    }
}
