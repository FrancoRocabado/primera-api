using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using PrimeraApiNetCore.Models;

namespace PrimeraApiNetCore.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic ListarCliente()
        {
            // todo el codigo

            List<Cliente> clientes = new List<Cliente>
            { 
                new Cliente
                {
                    id = "1",
                    correo = "francorocabado7@gmail.com",
                    edad = "24",
                    nombre = "Franco Rocabado"
                },

                new Cliente
                {
                    id = "2",
                    correo = "claudiorocabado7@gmail.com",
                    edad = "48",
                    nombre = "Claudio Rocabado"
                }
        };

        return  clientes;
    }

    [HttpGet]
    [Route("listarxid")]
    public dynamic listarClientexid(int codigo)
    {
        // obtienes el cliente de la db

                return new Cliente
                {
                    id = codigo.ToString(),
                    correo = "francorocabado7@gmail.com",
                    edad = "24",
                    nombre = "Franco Rocabado"
                };

    }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            // guardas en la db y le asignas id 
            cliente.id = "3";

        return new
        {
            success = true,
            message = "cliente registrado",
            result = cliente
        };
        }
    
    [HttpPost]
    [Route("eliminar")]
    public dynamic eliminarCliente(Cliente cliente)
    {
       string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
      //eliminas en la db

        if (token != "marco123")
        {
            return new
            {
                success = false,
                message = "token incorrecto",
                result = cliente
            };

        }

            return new
            { 
            success = true,
            message = "cliente eliminado",
            result = cliente
            };

    }


    }
}
