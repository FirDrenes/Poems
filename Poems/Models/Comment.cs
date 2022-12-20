namespace Poems.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string PublisherName { get; set; }
    public string Text { get; set; }
    public DateTime PublishDate { get; set; }
}