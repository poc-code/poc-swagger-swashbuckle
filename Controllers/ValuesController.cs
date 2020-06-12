using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PocSwagger.ViewModel;

namespace PocSwagger.Controllers
{
    /// <summary>
    /// Serviço para imprimir valores 
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Produces("application/json")]
    [Route("api/v1/values")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Retorna uma lista de valores
        /// </summary>
        /// <returns>Busca os valores</returns>
        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok("Retorna o valor de get");
        }

        /// <summary>
        /// Adiciona os valores
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Insere um valor</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ValueViewModel request)
        {

            return Ok(request);
        }

        /// <summary>
        /// Atualiza valores
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Autaliza o valor</returns>
        [HttpPut("update/{id}")]
        public IActionResult Put([FromBody] object request)
        {

            return Ok(request);
        }

        /// <summary>
        /// Exclui logicamente os valores
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Excluir o valor</returns>
        [HttpPut]
        [Route("delete/{id}")]
        public IActionResult Delete([FromBody] int id)
        {

            return Ok(id);
        }
    }
}