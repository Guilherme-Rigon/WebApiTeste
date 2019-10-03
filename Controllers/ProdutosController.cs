using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiContext _Banco;
        public ProdutosController(ApiContext banco)
        {
            _Banco = banco;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Produtos()
        {
            try
            {
                JsonResult json = new JsonResult(_Banco.Produtos.Select(p => new
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    TipoId = p.TipoId,
                    Tipo = p.Tipo.TipoNome
                }).AsNoTracking().ToList());
                

                return new JsonResult(json); 
            }catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [Route("")]
        [HttpPost]
        public ActionResult NovoProduto([FromBody] Produto prod)
        {
            try
            {
                prod.Tipo = _Banco.Tipos.Find(prod.TipoId);
                _Banco.Produtos.Add(prod);
                _Banco.SaveChanges();
                return Ok(true);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult EditarProduto(int id, [FromBody] Produto prod)
        {
            try
            {
                prod.Id = id;
                _Banco.Produtos.Update(prod);
                _Banco.SaveChanges();
                return Ok(true);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeletarProduto(int id)
        {
            try
            {
                _Banco.Produtos.Remove(_Banco.Produtos.Find(id));
                _Banco.SaveChanges();
                return Ok(true);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("tipo")]
        [HttpPost]
        public IActionResult CadastrarTipo([FromBody] Tipo tipo)
        {
            try
            {
                _Banco.Tipos.Add(tipo);
                _Banco.SaveChanges();
                return Ok(true);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("tipo")]
        [HttpGet]
        public IActionResult Tipos()
        {
            try
            {
                return new JsonResult(_Banco.Tipos);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("tipo/{TipoId}")]
        [HttpPut]
        public IActionResult EditarTipo(int TipoId, [FromBody] Tipo tipo)
        {
            try
            {
                tipo.Id = TipoId;
                _Banco.Tipos.Update(tipo);
                _Banco.SaveChanges();
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("tipo/{id}")]
        [HttpGet]
        public IActionResult ProdutosTipo(int id)
        {
            try
            {
                return new JsonResult(_Banco.Produtos.Where(x => x.TipoId == id));
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
