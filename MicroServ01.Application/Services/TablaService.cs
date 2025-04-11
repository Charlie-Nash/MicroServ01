using MicroServ01.Application.Interfaces;
using MicroServ01.Domain.Models;

namespace MicroServ01.Application.Services
{
    public class TablaService : ITablaService
    {
        private readonly ITablaRepository _tablaRepository;

        public TablaService(ITablaRepository tablaRepository) {
            _tablaRepository = tablaRepository;
        }

        public async Task<List<TablaResult>> ListadoAsync(TablaRequest request)
        {
            var listado = await _tablaRepository.Tabla_PS_Listado(request);

            return listado;
        }
    }
}
