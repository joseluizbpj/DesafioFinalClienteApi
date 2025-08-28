
using System.Net.Http.Headers;
using DesafioFinalClienteApi.Models;
using DesafioFinalClienteApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinalClienteApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> ObterTodos()
        {
            return Ok(_service.ListarTodos());
        }
        /// <summary>
        /// Retorna um cliente específico pelo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<Cliente> ObterPorId(int id)
        {
            var cliente = _service.BuscarPorId(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
        /// <summary>
        /// Obtem lista dos clientes que contenham o nome do parâmetro.
        /// </summary>
        /// <param name="nome">Nome a ser buscado.</param>
        /// <returns>Os clientes que possuem ao menos parcialmente o nome.</returns>
        [HttpGet("nome/{nome}")]
        public ActionResult<IEnumerable<Cliente>> ObterPorNome(string nome)
        {
            var resultados = _service.BuscarPorNome(nome);
            return Ok(resultados);
        }
        /// <summary>
        /// Conta quantos clientes estão cadastrados.
        /// </summary>
        /// <returns>Um int com a quantidade dos clientes.</returns>
        [HttpGet("contar")]
        public ActionResult<int> ContarClientes()
        {
            return Ok(_service.Contar());
        }
        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="cliente">O cliente a ser criado.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Cliente> CriarCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var sucesso = _service.Criar(cliente);
            return CreatedAtAction(nameof(ObterPorId), new { id = sucesso.Id }, sucesso);
        }
        /// <summary>
        /// Atualiza um cliente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public IActionResult AtualizarCliente(int id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var sucesso = _service.Atualizar(id, cliente);
            return sucesso ? NoContent() : NotFound();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeletarCliente(int id)
        {
            var sucesso = _service.Deletar(id);
            return sucesso ? NoContent() : NotFound();
        }
    }
}