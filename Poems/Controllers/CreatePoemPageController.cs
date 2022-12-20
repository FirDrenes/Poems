using Microsoft.AspNetCore.Mvc;
using Poems.Models;
using Poems.Models.Repositories;

namespace Poems.Controllers;

public class CreatePoemPageController : Controller
{
    private IRepository<Author> _authorsRepository;
    private IRepository<Poem> _poemsRepository;

    // GET
    public CreatePoemPageController(IRepository<Author> authorsRepository, IRepository<Poem> poemsRepository)
    {
        _authorsRepository = authorsRepository;
        _poemsRepository = poemsRepository;
    }

    public async Task<IActionResult> Show()
    {
        return View();
    }

    public async Task<IActionResult> Create(string authorName, string text, string title)
    {
        var authors = await _authorsRepository.GetAll();
        var targetAuthor = authors.FirstOrDefault(x => x.Name == authorName);
        if (default == targetAuthor)
        {
            targetAuthor = new Author()
            {
                Name = authorName,
                Status = string.Empty
            };

            await _authorsRepository.Create(targetAuthor);
            await _authorsRepository.SaveChanges();
        }

        var newPoem = new Poem()
        {
            Title = title,
            Author = targetAuthor,
            Text = text,
            PublishDate = DateTime.Now,
        };

        await _poemsRepository.Create(newPoem);
        await _poemsRepository.SaveChanges();
        return RedirectToAction("Show", "IndexPage");
    }
}