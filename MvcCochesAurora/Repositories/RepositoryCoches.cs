using MvcCochesAurora.Data;
using MvcCochesAurora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCochesAurora.Repositories
{
    public class RepositoryCoches
    { 
     private CochesContext context;

    public RepositoryCoches(CochesContext context)
    {
        this.context = context;
    }

    public List<Coche> GetCoches()
    {
        return this.context.Coches.ToList();
    }

    public Coche FindCoche(int id)
    {
        return this.context.Coches.SingleOrDefault(x => x.IdCoche == id);
    }

    public void InsertCoche(int id, string marca, string modelo, string conductor, string imagen)
    {
            Coche p = new Coche
            {
            IdCoche = id,
            Marca = marca,
            Modelo = modelo,
            Conductor = conductor,
            Imagen = imagen
        };
        this.context.Coches.Add(p);
        this.context.SaveChanges();
    }
}
}
