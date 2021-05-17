using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PyS.RFID.APIRest.Context;
using PyS.RFID.APIRest.DTOs;
using PyS.RFID.APIRest.Interfaces;
using PyS.RFID.APIRest.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PyS.RFID.APIRest.Controllers
{
    public class ReportesController : BaseApiController
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;

        public ReportesController(DataContext context, ITokenService tokenService)
        {
            this.context = context;
            this.tokenService = tokenService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUser(int id)
        {
            return await context.Usuarios.FindAsync(id);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UsuarioDto>> Register(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.UserName)) return BadRequest("El usuario ya exite");

            using var hmac = new HMACSHA512();
            Empresa empresa = context.Empresas.Where(a => a.Nombre == registerDto.Empresa).FirstOrDefault();
            var user = new Usuario
            {
                Nombre = registerDto.Nombre,
                ApellidoPaterno = registerDto.ApellidoPaterno,
                ApellidoMaterno = registerDto.ApellidoMaterno,
                Dni = registerDto.Dni,
                Cargo = registerDto.Cargo,
                Email = registerDto.Email,
                Telefono = registerDto.Telefono,
                Celular = registerDto.Celular,
                Direccion = registerDto.Direccion,
                UserName = registerDto.UserName.ToLower(),
                EmpresaId = empresa.Id,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            context.Usuarios.Add(user);

            await context.SaveChangesAsync();
            return new UsuarioDto
            {
                Nombre = user.Nombre,
                ApellidoPaterno = user.ApellidoPaterno,
                ApellidoMaterno = user.ApellidoMaterno,
                Dni = user.Dni,
                Cargo = user.Cargo,
                Email = user.Email,
                Telefono = user.Telefono,
                Celular = user.Celular,
                Direccion = user.Direccion,
                UserName = user.UserName.ToLower(),
                Token = tokenService.CreateToke(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto)
        {
            Usuario user = await context.Usuarios
                .SingleOrDefaultAsync(a => a.UserName == loginDto.UserName);

            if (user == null) return Unauthorized("Usuario Invalido");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i])
                    return Unauthorized("Password No valido");
            }

            return new UsuarioDto
            {
                UserName = user.UserName,
                Token = tokenService.CreateToke(user)
            };
        }
        private async Task<bool> UserExist(string username)
        {
            return await context.Usuarios.AnyAsync(x => x.UserName == username.ToLower());
        }
        [Authorize]
        [HttpPost("LecturasDelDia")]
        public async Task<ActionResult<List<LecturasTagDto>>> LecturasDelDia(ParametrosDto parametros)
        {
            List<LecturasTagDto> results = new List<LecturasTagDto>();
            using (DataContext context = new DataContext())
            {
                try
                {
                results = await context.Set<LecturasTagDto>().FromSqlRaw($"EXECUTE usp_LecturasPorDia  @FECHA = '{parametros.Fecha}', @RUC = '{parametros.Ruc}'").ToListAsync();
                }
                catch (System.Exception ex)
                {

                    parametros.Ruc = ex.Message;
                    throw;
                }
            }
            return results;
        }
        [Authorize]
        [HttpPost("LecturasAlertadasPorDia")]
        public async Task<ActionResult<List<LecturasTagDto>>> LecturasAlertadasPorDia(string Fecha, string Ruc)
        {
            List<LecturasTagDto> results = new List<LecturasTagDto>();
            using (DataContext context = new DataContext())
            {
                results = await context.Set<LecturasTagDto>().FromSqlRaw($"EXECUTE usp_LecturasAlertadasPorDia  @FECHA = '{Fecha}', @RUC = '{Ruc}'").ToListAsync();
            }
            return results;
        }
    }
}
