using MicroServ01.Domain.Models;

namespace MicroServ01.Application.Interfaces
{
    public interface ITablaService
    {
        Task<List<TablaResult>> ListadoAsync(TablaRequest request);
    }
}
