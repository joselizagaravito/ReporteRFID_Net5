using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PyS.RFID.APIRest.Context;
using PyS.RFID.APIRest.Interfaces;
using PyS.RFID.APIRest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PyS.RFID.APIRest.Controllers
{
    public class ArchivoController : BaseApiController
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;

        public ArchivoController(DataContext context, ITokenService tokenService)
        {
            this.context = context;
            this.tokenService = tokenService;
        }
        public ActionResult Get()
        {

            try
            {
                // return Ok(context.Archivo.ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult PostArchivos([FromForm] List<IFormFile> files)
        {
            List<Archivo> archivos = new List<Archivo>();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var filePath = @"C:\Mis Documentos\PedroClavijo\ReporteRFID_Net5\PyS.RFID.APIRest\Files\" + file.FileName;
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            file.CopyToAsync(stream);
                        }
                        double tamanio = file.Length;
                        tamanio /= 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        Archivo archivo = new Archivo();
                        archivo.Extension = Path.GetExtension(file.FileName).Substring(1);
                        archivo.Nombre = Path.GetFileNameWithoutExtension(file.FileName);
                        archivo.Tamanio = tamanio;
                        archivo.Ubicacion = filePath;
                        archivos.Add(archivo);
                    }
                    context.Archivo.AddRange(archivos);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(archivos);
        }
    }
}
