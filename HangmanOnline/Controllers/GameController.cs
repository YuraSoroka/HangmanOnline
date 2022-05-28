using HangmanOnline.Services.Helpers;
using HangmanOnline.Models;
using Microsoft.AspNetCore.Mvc;
using HangmanOnline.Services;
using HangmanOnline.Models.Context;

namespace HangmanOnline.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> logger;
        private readonly HttpClient httpClient;
        private readonly HangmanContext context;

        public GameController(
            ILogger<GameController> logger, 
            HttpClient httpClient,
            HangmanContext context)
        {
            this.logger = logger;
            this.httpClient = httpClient;
            this.context = context;
        }

        // game/room
        [Route("game/{roomid:Guid}")]
        public IActionResult CreatePlayer([FromRoute]Guid roomId)
        {
            logger.LogInformation("Redirected to CreatePlayer action");
            return View();
        }

        [HttpPost]
        [Route("game/{roomid:Guid}")]
        public IActionResult CreatePlayer([FromRoute] Guid roomId, string name)
        {
            logger.LogInformation("Redirected to CreatePlayer action Post");
            return RedirectToAction("RenderScene", new { roomId, name});
        }

        [Route("game/{roomid:Guid}/play")]
        public IActionResult RenderScene([FromRoute] Guid roomId, string name)
        {
            logger.LogInformation("Redirected to RenderScene action");
            CreateWordService service = new CreateWordService(httpClient);
            string word = service.GetWord().Result;
            Room room = new Room
            {
                Id = roomId.ToString(),
                Word = word
            };

            context.Rooms.Add(new Room
            {
                Id = roomId.ToString(),
                Word = word,
                PlayerOne = new Player
                {
                    Name = name,
                    Health = 5
                }
            });
            context.SaveChanges();

            logger.LogInformation($"{room.Id} + { room.Word} + {name}");
            ViewData["word"] = room.Word;
            return View("MainScene");
        }

        public IActionResult CreateRoomId()
        {
            Guid roomId = new CreateRoomIdHelper().CreateRoomID();
            return RedirectToAction("CreatePlayer", new { roomId });
        }
    }
}