namespace Poems.Models;

public class Poem
{
    public Guid Id { get; set; }
    public Author Author { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public List<Comment> Comments { get; set; }
    public DateTime PublishDate { get; set; }
}