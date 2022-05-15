namespace SerieEFilmes
{
    public abstract class Epsodio
    {
        
        public Epsodio()
        {
           
        }

        public Epsodio(int numEP, string nomeEP, string tempEP, string duraEP, string sinopEP, string serie)
        {
            this._NumEP = numEP;
            this._TituloEP = nomeEP;
            this._TemporadaEP = tempEP;
            this._DuracaoEP = duraEP;
            this._SinopEP = sinopEP;
            this._Serie = serie;

        }
        public int _NumEP { get; set; }
        public string _TituloEP { get; set; }
        public string _TemporadaEP { get; set; }
        public string _DuracaoEP { get; set; }
        public string _SinopEP { get; set; }
        public string _Serie { get; set; }


    }
}