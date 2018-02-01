using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ianes.Dados;
using Ianes.Models;

namespace Ianes.Controllers
{
    [Route("api/[controller]")]
    public class CursosController : Controller
    {
        Cursos areas = new Cursos();

        /*disponibilizar o contexto, sem setar nada para dentro dele, sem atribuir valores a ele
        será usado com uma CONSTANTE, por isso p readonly (somente leitura)*/
        readonly IanesContexto contexto;

        public CursosController(IanesContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        //o retorno será de vários Cursoss, por isso o IEnumerable
        public IEnumerable<Cursos> Listar()
        {
            //o equivalente ao SELECT do banco de dados
            return contexto.Cursos.ToList();
        }

        [HttpGet("{id}")]
        //o retorno será apenas 1 Cursos
        public Cursos Listar(int id)
        {
            //especificando 1 individuo, por isso o FirstOrDefault
            return contexto.Cursos.Where(x => x.IdCurso == id).FirstOrDefault();
        }

        [HttpPost]
        //usando void, para nao ter retorno, normalmente podemos usar IActionResult
        public void Cadastrar([FromBody]Cursos area)
        {
            //adicionando
            contexto.Cursos.Add(area);
            //salvando
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]Cursos New)
        {

            if (New == null || New.IdCurso != id)
            {
                return BadRequest();
            }

            var old = contexto.Cursos.FirstOrDefault(x=>x.IdCurso==id);
            if(old==null)
            return NotFound();

            old.IdCurso = New.IdCurso;
            old.NomeCurso = New.NomeCurso;
            old.AreaCurso = New.AreaCurso;

            /*Não colocar pedido, pois é PFK 
            area.Pedido = Cursos.Pedido;*/

            contexto.Cursos.Update(old);
            int rs = contexto.SaveChanges();

            if(rs>0)
            return Ok();
            else
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var Cursos = contexto.Cursos.Where(x=>x.IdCurso==id).FirstOrDefault();
            if(Cursos == null){
                return NotFound();
            }
            contexto.Cursos.Remove(Cursos);
            int rs = contexto.SaveChanges();
            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }

    }
}