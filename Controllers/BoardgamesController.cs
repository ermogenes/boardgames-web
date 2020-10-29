using Microsoft.AspNetCore.Mvc;
using boardgames_web.db;
using System.Collections.Generic;
using System.Linq;

namespace boardgames_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardgamesController : ControllerBase
    {
        private boardgamesContext _db { get; set; }
        public BoardgamesController(boardgamesContext contexto)
        {
            _db = contexto;
        }

        [HttpGet]
        public List<Boardgame> Get()
        {
            var todosOsBoardGames = _db.Boardgame
                .OrderByDescending(bg => bg.Nota)
                .ThenBy(bg => bg.Ano)
                .ThenBy(bg => bg.Nome)
                .ToList<Boardgame>();
            return todosOsBoardGames;
        }
    }
}