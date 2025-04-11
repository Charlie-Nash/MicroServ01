using MicroServ01.Domain.Models;

namespace MicroServ01.Application.Interfaces
{
    public interface ITablaRepository
    {
        Task<List<TablaResult>> Tabla_PS_Listado(TablaRequest tablaRequest);
    }
}
