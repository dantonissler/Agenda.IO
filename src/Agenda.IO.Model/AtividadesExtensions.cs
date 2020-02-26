namespace Agenda.IO.Model
{
    public static class AtividadesExtensions
    {
        public static AtividadesModel ToAtividade(this AtividadeUpload model)
        {
            return new AtividadesModel
            {
                Id = model.Id,
                Nome = model.Nome,
                Descricao = model.Descricao,
                DataInicio = model.DataInicio,
                DataFim = model.DataFim,
            };
        }

        public static AtividadesApiModel ToApi(this AtividadesModel atividades)
        {
            return new AtividadesApiModel
            {
                Id = atividades.Id,
                Nome = atividades.Nome,
                Descricao = atividades.Descricao,
                DataInicio = atividades.DataInicio,
                DataFim = atividades.DataFim,
            };
        }

        public static AtividadeUpload ToModel(this AtividadesModel atividades)
        {
            return new AtividadeUpload
            {
                Id = atividades.Id,
                Nome = atividades.Nome,
                Descricao = atividades.Descricao,
                DataInicio = atividades.DataInicio,
                DataFim = atividades.DataFim,
            };
        }
    }
}
