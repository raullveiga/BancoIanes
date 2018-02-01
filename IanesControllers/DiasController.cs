using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ianes.Dados;
using Ianes.Models;

namespace Ianes.Controllers
{
    [Route("api/[controller]")]
    public class DiasController : Controller
    {
        Dias areas = new Dias();

        /*disponibilizar o contexto, sem setar nada para dentro dele, sem atribuir valores a ele
        será usado com uma CONSTANTE, por isso p readonly (somente leitura)*/
        readonly IanesContexto contexto;

        public DiasController(IanesContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        //o retorno será de vários Diass, por isso o IEnumerable
        public IEnumerable<Dias> Listar()
        {
            //o equivalente ao SELECT do banco de dados
            return contexto.Dias.ToList();
        }

        [HttpGet("{id}")]
        //o retorno será apenas 1 Dias
        public Dias Listar(int id)
        {
            //especificando 1 individuo, por isso o FirstOrDefault
            return contexto.Dias.Where(x => x.IdDiaSemana == id).FirstOrDefault();
        }

        [HttpPost]
        //usando void, para nao ter retorno, normalmente podemos usar IActionResult
        public void Cadastrar([FromBody]Dias area)
        {
            //adicionando
            contexto.Dias.Add(area);
            //salvando
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]Dias New)
        {

            if (New == null || New.IdDiaSemana != id)
            {
                return BadRequest();
            }

            var old = contexto.Dias.FirstOrDefault(x=>x.IdDiaSemana==id);
            if(old==null)
            return NotFound();

            old.IdDiaSemana = New.IdDiaSemana;
            old.DiaSemana = New.DiaSemana;
            old.IdChronograma = New.IdChronograma;

            /*Não colocar pedido, pois é PFK 
            area.Pedido = Dias.Pedido;*/

            contexto.Dias.Update(old);
            int rs = contexto.SaveChanges();

            if(rs>0)
            return Ok();
            else
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var Dias = contexto.Dias.Where(x=>x.IdDiaSemana==id).FirstOrDefault();
            if(Dias == null){
                return NotFound();
            }
            contexto.Dias.Remove(Dias);
            int rs = contexto.SaveChanges();
            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }

    }
}