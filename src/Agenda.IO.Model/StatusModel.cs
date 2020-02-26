using System.Collections.Generic;
using System.Linq;

namespace Agenda.IO.Model
{
    public static class StatusModel
    {
        private static Dictionary<string, TipoListaStatus> 
            mapa = new Dictionary<string, TipoListaStatus>
            {
                { "ParaFazer", TipoListaStatus.ParaFazer },
                { "Pendente", TipoListaStatus.Pendente },
                { "Concluida", TipoListaStatus.Concluida },
                { "NaoFazer", TipoListaStatus.NaoFazer }
            };

        public static string ParaString(this TipoListaStatus tipo)
        {
            return mapa.First(s => s.Value == tipo).Key;
        }

        public static TipoListaStatus ParaTipo(this string texto)
        {
            return mapa.First(t => t.Key == texto).Value;
        }
    }

    public enum TipoListaStatus
    {
        ParaFazer,
        Pendente,
        Concluida,
        NaoFazer
    }

    public class ListaStatus
    {
        public string Tipo { get; set; }
        public IEnumerable<AtividadesApiModel> Atividades { get; set; }
    }
}
