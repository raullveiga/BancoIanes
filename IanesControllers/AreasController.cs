using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ianes.Dados;
using Ianes.Models;

namespace Ianes.Controllers
{
    [Route("api/[controller]")]
    public class AreasController : Controller
    {
        Areas areas = new Areas();

        /*disponibilizar o contexto, sem setar nada para dentro dele, sem atribuir valores a ele
        será usado com uma CONSTANTE, por isso p readonly (somente leitura)*/
        readonly IanesContexto contexto;

        public AreasController(IanesContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        //o retorno será de vários Areass, por isso o IEnumerable
        public IEnumerable<Areas> Listar()
        {
            //o equivalente ao SELECT do banco de dados
            return contexto.Areas.ToList();
        }

        [HttpGet("{id}")]
        //o retorno será apenas 1 Areas
        public Areas Listar(int id)
        {
            //especificando 1 individuo, por isso o FirstOrDefault
            return contexto.Areas.Where(x => x.IdArea == id).FirstOrDefault();
        }

        [HttpPost]
        //usando void, para nao ter retorno, normalmente podemos usar IActionResult
        public void Cadastrar([FromBody]Areas area)
        {
            //adicionando
            contexto.Areas.Add(area);
            //salvando
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]Areas New)
        {

            if (New == null || New.IdArea != id)
            {
                return BadRequest();
            }

            var old = contexto.Areas.FirstOrDefault(x=>x.IdArea==id);
            if(old==null)
            return NotFound();

            old.IdArea = New.IdArea;
            old.NomeArea = New.NomeArea;

            /*Não colocar pedido, pois é PFK 
            area.Pedido = Areas.Pedido;*/

            contexto.Areas.Update(old);
            int rs = contexto.SaveChanges();

            if(rs>0)
            return Ok();
            else
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var Areas = contexto.Areas.Where(x=>x.IdArea==id).FirstOrDefault();
            if(Areas == null){
                return NotFound();
            }
            contexto.Areas.Remove(Areas);
            int rs = contexto.SaveChanges();
            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }

    }
}