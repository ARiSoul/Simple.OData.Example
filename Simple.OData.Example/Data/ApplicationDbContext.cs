using Simple.OData.Example.Entities;

namespace Simple.OData.Example.Data;

public class ApplicationDbContext
{
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }

    public ApplicationDbContext()
    {
        Parents = [
            new Parent
            {
                Key = "P1",
                Name = "Parent 1",
                Children =
                [
                    new Child
                    {
                        Key = "C1",
                        Name = "Child 1",
                        ParentKey = "P1"
                    },
                    new Child
                    {
                        Key = "C2",
                        Name = "Child 2",
                        ParentKey = "P1"
                    }
                ]
            },
            new Parent
            {
                Key = "P2",
                Name = "Parent 2",
                Children =
                [
                    new Child
                    {
                        Key = "C3",
                        Name = "Child 3",
                        ParentKey = "P2"
                    },
                    new Child
                    {
                        Key = "C4",
                        Name = "Child 4",
                        ParentKey = "P2"
                    }
                ]
            }
        ];

        Children = Parents.SelectMany(p => p.Children).ToList();
    }
}
