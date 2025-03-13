using Microsoft.AspNetCore.Mvc;
using PrjApiLembrete.Context;
using PrjApiLembrete.Entities;
using PrjApiLembrete.models;
using PrjApiLembrete.Models;
using System.Text.Json;
using System.Xml.Linq;
using Lembrete = PrjApiLembrete.Entities.Lembrete;

namespace PrjApiLembrete.Controllers
{
    [ApiController] // passo 2 -- colocar a anotation 
    [Route("[controller]")]

    public class LembreteController : ControllerBase
    {
        private readonly AppLembretesContext _contextoDB;

        public LembreteController(AppLembretesContext contextoDB)
        {
            _contextoDB = contextoDB;
        }

        [HttpPost]
        public IActionResult AddLembrete(Lembrete lembrete)  //adicionar o lembrete recebido no banco de dados
        {
            _contextoDB.Add(lembrete);  //adicionar o lembrete recebido no banco de dados
            _contextoDB.SaveChanges();  // salvar as alterações no banco de dados

            return Ok();  //retornando o lembrete adicionado
        }

        [HttpGet("{id}")] //verbo + rota dinamica (com parametro)
        public IActionResult GetLembrete(int id)  //receber o id do lembrete a ser exibido
        {
            var lembrete = _contextoDB.Lembretes.Find(id);  //pesquisar entre os lembretes do contexto aquele que possui o id recebido,
                                                            //gardando o lembrete na variavel

            if (lembrete == null)  //verifica se foi encontrado algum lembrete 
            {
                return NotFound(); //se não encontrar retornará erro 404 - not found
            }

            return Ok(lembrete);  //se for encontrado retornará o proprio lembrete
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLembrete(int id, Lembrete lembrete)
        {

            var lembreteBanco = _contextoDB.Lembretes.Find(id);


            if (lembrete == null)
            {
                return NotFound();
            }

            lembreteBanco.TituloLembrete = lembrete.TituloLembrete;
            lembreteBanco.CorpoLembrete = lembrete.CorpoLembrete;
            lembreteBanco.StatusLembrete = lembrete.StatusLembrete;

            _contextoDB.Lembretes.Update(lembreteBanco);
            _contextoDB.SaveChanges();

            return Ok(lembreteBanco);
        }

        [HttpDelete("id")]
        public IActionResult DeleteLembrete(int id, Lembrete lembrete)
        {
            var lembreteBanco = _contextoDB.Lembretes.Find(id);

            if (lembrete == null)
            {
                return NotFound();
            }

            _contextoDB.Lembretes.Remove(lembreteBanco);

            _contextoDB.SaveChanges();

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAllLembretes()
        {
            return Ok(_contextoDB.Lembretes);
        }


    }
}
