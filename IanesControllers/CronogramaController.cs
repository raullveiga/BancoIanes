using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ianes.Dados;
using Ianes.Models;

namespace Ianes.Controllers
{
    [Route("api/[controller]")]
    public class CronogramasController : Controller
    {
        Cronogramas areas = new Cronogramas();

        /*disponibilizar o contexto, sem setar nada para dentro dele, sem atribuir valores a ele
        será usado com uma CONSTANTE, por isso p readonly (somente leitura)*/
        readonly IanesContexto contexto;

        public CronogramasController(IanesContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        //o retorno será de vários Cronogramass, por isso o IEnumerable
        public IEnumerable<Cronogramas> Listar()
        {
            //o equivalente ao SELECT do banco de dados
            return contexto.Cronogramas.ToList();
        }

        [HttpGet("{id}")]
        //o retorno será apenas 1 Cronogramas
        public Cronogramas Listar(int id)
        {
            //especificando 1 individuo, por isso o FirstOrDefault
            return contexto.Cronogramas.Where(x => x.IdCronograma == id).FirstOrDefault();
        }

        [HttpPost]
        //usando void, para nao ter retorno, normalmente podemos usar IActionResult
        public void Cadastrar([FromBody]Cronogramas area)
        {
            //adicionando
            contexto.Cronogramas.Add(area);
            //salvando
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]Cronogramas New)
        {

            if (New == null || New.IdCronograma != id)
            {
                return BadRequest();
            }

            var old = contexto.Cronogramas.FirstOrDefault(x=>x.IdCronograma==id);
            if(old==null)
            return NotFound();

            old.IdCronograma = New.IdCronograma;
            old.DataInicio = New.DataInicio;
            old.DataFim = New.DataFim;
            old.HoraInicio = New.HoraInicio;
            old.HoraFim = New.HoraFim;
            old.Curso = New.Curso;

            /*Não colocar pedido, pois é PFK 
            area.Pedido = Cronogramas.Pedido;*/

            contexto.Cronogramas.Update(old);
            int rs = contexto.SaveChanges();

            if(rs>0)
            return Ok();
            else
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var Cronogramas = contexto.Cronogramas.Where(x=>x.IdCronograma==id).FirstOrDefault();
            if(Cronogramas == null){
                return NotFound();
            }
            contexto.Cronogramas.Remove(Cronogramas);
            int rs = contexto.SaveChanges();
            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }

    }
}