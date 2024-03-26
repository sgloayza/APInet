using webapi.Models;

namespace webapi.Services;

public class CategoriaService : ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task SaveAsync(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async void Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual!=null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }
    }

    public async void Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual!=null)
        {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task SaveAsync(Categoria categoria);
    void Update(Guid id, Categoria categoria);
    void Delete(Guid id);
}