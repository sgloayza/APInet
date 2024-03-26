using webapi.Models;

namespace webapi.Services;

public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task SaveAsync(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async void Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if(tareaActual!=null)
        {
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.FechaCreacion = tarea.FechaCreacion;
            tareaActual.Categoria = tarea.Categoria;
            tareaActual.Resumen = tarea.Resumen;

            await context.SaveChangesAsync();
        }
    }

    public async void Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if(tareaActual!=null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task SaveAsync(Tarea tarea);
    void Update(Guid id, Tarea tarea);
    void Delete(Guid id);
}