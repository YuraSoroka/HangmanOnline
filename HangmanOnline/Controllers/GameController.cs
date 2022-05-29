using HangmanOnline.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using HangmanOnline.Services;
using HangmanOnline.Models.Context;
using HangmanOnline.Services.Contracts;
using HangmanOnline.Models.ViewModels;

namespace HangmanOnline.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> logger;
        private readonly IRoomService roomService;
        private readonly ICoreService coreService;

        public GameController(
            ILogger<GameController> logger, 
            IRoomService roomService,
            ICoreService coreService)
        {
            this.logger = logger;
            this.roomService = roomService;
            this.coreService = coreService;
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

            if(!roomService.AddRoom(roomId, name))
            {
                logger.LogInformation("The room is full. Create another");
                return RedirectToAction("Index", "Home");
            }
            GameSession gameSession = coreService.GetSession(roomId.ToString());
            return View("MainScene", gameSession);
        }

        public IActionResult CreateRoomId()
        {
            Guid roomId = new CreateRoomIdHelper().CreateRoomID();
            return RedirectToAction("CreatePlayer", new { roomId });
        }
    }
}