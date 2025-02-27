using Microsoft.AspNetCore.Mvc;
// passo 1 -- importar a biblioteca MVC
using PrjApiLembrete.Models;
using PrjApiLembrete.DTO;
using System.Text.Json;

namespace PrjApiLembrete.Controllers
{
    [ApiController] // passo 2 -- colocar a anotation 
    [Route("[controller]")]
    public class PessoaController : ControllerBase // passo 3 - herdar de ControllerBase
    {



        //[HttpGet("pessoasample")] // paso 4 -- definir o verbo que acessa a rota e o nome da rota que será exposto
        //public Pessoa GetPessoa() // passo 5 -- criar o metodo que atende a rota
        //{
        //    Pessoa person = new Pessoa("Juca", 45);
        //    return person;
        //}

        [HttpGet("all")]
        public List<Pessoa> GetAll()
        {
            return Pessoa.Pessoas;
        }

        [HttpPost("add")]
        //public Pessoa InserirPessoa(string name, int age)
        //{
        //    Pessoa person = new Pessoa(name, age); // mandou info para a model
        //                                            // mandar info para o Array
        //    return person;
        //}

        [HttpPost("addperson")] //rota estatica
        public IActionResult AddPerson(PessoaDTO personDTO) //DTO = data transfer object
        {
            Pessoa newPerson;
            try
            {
                newPerson = new Pessoa(personDTO.NomePessoa, personDTO.IdadePessoa);
                newPerson.InserirPessoa();
            }
            catch (Exception ex) 
            {
                return BadRequest(JsonSerializer.Serialize($"Erro:{ex.Message}"));
            }

            return Ok(newPerson);
        }

        [HttpGet("get/{name}")] //rota dinamica
        public IActionResult GetPerson(string name) 
        {
            Pessoa person;
            try
            {
                Pessoa personSearch = new Pessoa(name);
                person = personSearch.BuscarPessoaPeloNome();
            }
            catch (Exception ex) 
            {
                return BadRequest(JsonSerializer.Serialize($"Erro:{ex.Message}"));
            }
            return Ok(person);
        }

        [HttpDelete("del/{name}")]
        public IActionResult DeletePerson(string name) 
        {
            Pessoa person;
            try
            {
                person = new Pessoa(name);
                person.BuscarPessoaPeloNome().RemoverPessoa();
            }
            catch (Exception ex) 
            {
                return BadRequest($"Erro:{ex.Message}");
            }
            return Ok(person);
        }

        [HttpPut("update/{name}")]
        public IActionResult UpdatePerson(PessoaDTO personDTO, string name)
        {
            Pessoa person;

            try
            {
                person = new Pessoa(personDTO.NomePessoa, personDTO.IdadePessoa);
                person.AtualizarPessoa(name);
            }

            catch (Exception ex) 
            {
                return BadRequest(JsonSerializer.Serialize($"Erro:{ex.Message}"));
            }

            return Ok(person);
        }

    }
}
