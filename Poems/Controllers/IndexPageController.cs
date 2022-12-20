using Microsoft.AspNetCore.Mvc;
using Poems.Models;
using Poems.Models.Repositories;

namespace Poems.Controllers;

public class IndexPageController : Controller
{
    private IRepository<Poem> _poemsRepository;

    private List<Poem> _defaultPoems = new()
    {
        new Poem()
        {
            Title = "У неба твои глаза",
            Author = new Author()
            {
                Name = "Мари Есенина-Ковалева",
                Status = "Я Маша"
            },
            
            Text = @"Я скучаю. Я рвусь на части.
            А у неба твои глаза.
            Я беру в свои руки ластик,
            Забираю слова назад.

            Я стираю тебя из жизни,
            Но ты пятноневыводим.
            День уходит, уходишь ты с ним.
            Зашиваю дыру в груди.

            Что-то комом застряло в глотке
            И совсем не даёт дышать.
            Льется кровью на мои шмотки
            Искалеченная душа.

            За окном моросит сегодня,
            Твоё имя шептал мне дождь.
            И клонились деревья сонно
            Рассказать, что ты не придёшь.

            Не поверю их жухлым листьям,
            Всё на ветер, что шелестят.
            Ты опять занимаешь мысли,
            Ты болезнь, лихорадка, яд.

                Как наступит апирексия,
            Ты опять разжигаешь боль.
            Я любила бы так красиво,
            Я любила бы, лишь позволь.

            Поднимаю глаза на небо,
            А у неба твои глаза.
            Вся любовь моя непотребна,
            Ведь любить тебя мне нельзя.",
            
            Comments = new List<Comment>()
            {
                new Comment()
                {
                    PublishDate = DateTime.Now,
                    PublisherName = "ZXC",
                    Text = "Круто",
                }
            },
            
            PublishDate = DateTime.Now,
        },
        
    };
    
    // GET
    public IndexPageController(IRepository<Poem> poemsRepository)
    {
        _poemsRepository = poemsRepository;
    }

    public async Task<IActionResult> Show()
    {
        // Сделать при первом запуске
        /*foreach (var poem in _defaultPoems)
        {
            await _poemsRepository.Create(poem);
        }
        await _poemsRepository.SaveChanges();
        */
        
        var poems = await _poemsRepository.GetAll();
        ViewBag.Poems = poems;
        return View();
    }

    public async Task<IActionResult> SearchByAuthor(Guid authorId)
    {
        var poems = await _poemsRepository.GetAll();
        var filtered = poems.Where(x => x.Author.Id == authorId).ToList();
        ViewBag.Poems = filtered;

        return View("Show");
    }
    
    
    public async Task<IActionResult> SearchByTitle(string titlePrefix)
    {
        var poems = await _poemsRepository.GetAll();
        var filtered = poems.Where(x => x.Title.ToLower().StartsWith(titlePrefix.ToLower())).ToList();
        ViewBag.Poems = filtered;

        return View("Show");
    }
}