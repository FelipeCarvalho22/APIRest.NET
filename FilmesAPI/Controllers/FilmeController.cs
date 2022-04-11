using FilmesAPI.Controllers.Models;
using Microsoft.AspNetCore.Mvc;                                             //Biblioteca dotNET responsavel pelo CORE HTTP

namespace FilmesAPI.Controllers
{
    [ApiController]                                                         //Anotação que define a API Controller
    [Route("[controller]")]                                                 //Anotação que define a Rota da API
    public class FilmeController : ControllerBase                           //Deve herdar do ControllerBase
    {
        private static int id = 1;
        private static List<Filme> filmes = new List<Filme>();

        [HttpPost]                                                                              //Verbo HTTP que indica que a ação seguinte é um POST
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);  //Segundo as melhores praticas do REST esse retorno nos fornece a rota para acesso
                                                                                                //deste objeto criado
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()                                                  //Por ser uma lista ele implementa a intermace IEnumerable,
                                                                                                //sendo um melhor tipo para esta aplicação
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]                                                                       //Ao especificarmos o parametro, definimos que
                                                                                                //quando passado na URL este GET sera acionado
        public IActionResult RecuperarFilmePorId(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);                       //Sintaxe JS usando uma expressão Lambda
            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
