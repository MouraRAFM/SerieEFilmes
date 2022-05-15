namespace SerieEFilmes
{
    public interface IcrudFilme
    {
       void InsertDB(List<Filme>lista,Filme filme, string tipo, int indice);
       

       void UpdateDB(List<Filme>lista,Filme filme,int indice);
       

       void SelectDB(List<Filme>lista,Filme filme);
        
       void DeleteDB(List<Filme>lista,Filme filme);
       

    }
}