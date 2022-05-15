namespace SerieEFilmes
{
    public interface IcrudSerie
    {
       void InsertDB(List<Serie>lista,Serie serie, List<Epsodio> listaEpisodio);
       

       void UpdateDB(List<Serie>lista);
       

       void SelectDB(List<Serie>BuscarNalista,Serie BuscarSerie, List<Epsodio> listaEpisodio, int escolha);
        
       void DeleteDB(List<Serie>lista);
       


    }
}