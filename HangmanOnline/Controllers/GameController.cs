using HangmanOnline.Services.Helpers;
using HangmanOnline.Models;
using Microsoft.AspNetCore.Mvc;
using HangmanOnline.Services;

namespace HangmanOnline.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> logger;
        private HttpClient client;

        public GameController(
            ILogger<GameController> logger, 
            HttpClient httpClient)
        {
            this.logger = logger;
            client = httpClient;
        }

        // game/room
        [Route("game/{roomid:Guid}")]
        public IActionResult RenderScene([FromRoute]Guid roomId)
        {
            logger.LogInformation("Redirected to RenderScene action");
            CreateWordService service = new CreateWordService(client);
            string word = service.GetWord().Result;
            Room room = new Room(roomId.ToString(), word);
            logger.LogInformation($"{room.Id} + { room.Word}");
            ViewData["word"] = room.Word;
            return View("MainScene");
        }

        public IActionResult CreateRoomId()
        {
            Guid roomId = new CreateRoomIdHelper().CreateRoomID();
            return RedirectToAction("RenderScene", new { roomId });
        }
    }
}