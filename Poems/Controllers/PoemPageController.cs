using Microsoft.AspNetCore.Mvc;
using Poems.Models;
using Poems.Models.Repositories;

namespace Poems.Controllers;

public class PoemPageController : Controller
{
    private IRepository<Poem> _poemsRepository;
    
    // GET
    public PoemPageController(IRepository<Poem> poemsRepository)
    {
        _poemsRepository = poemsRepository;
    }

    public async Task<IActionResult> Show(Guid poemId)
    {
        var poem = await _poemsRepository.Find(poemId);
        if (default == poem)
            return new NotFoundResult();
        
        ViewBag.Poem = poem;
        
        return View();
    }

    public async Task<IActionResult> AddComment(Guid poemId, string name, string message)
    {
        var poem = await _poemsRepository.Find(poemId);
        if (default == poem)
            return new NotFoundResult();

        var comment = new Comment()
        {
            PublisherName = name,
            Text = message,
            PublishDate = DateTime.Now
        };
        
        poem.Comments.Add(comment);
        await _poemsRepository.SaveChanges();

        return RedirectToAction("Show", "PoemPage", new {poemId});
    }
}