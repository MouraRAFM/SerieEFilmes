namespace SerieEFilmes
{
    public class Serie : Epsodio, IcrudSerie
    {
        public Serie()
        {

        }

        private int _laco;
        
        private int _entrada;
        private string _anoMSG = "\r                       Informe ano da série, aceito de (1950 à 2022): ";
        private string _temporadaMSG = "\r                       Informe número total de temporada(s) da série: ";
        private string _episodioMSG = "\r                       Informe número total de episódios da série: ";
        private string _descricaoMSG = "\r                       Informe descrição da série: ";
        private string _serieMSG = "\r                       Informe nome da série: ";
        private string _duracaoEPMSG = "\r                       Informe tempo de duração em *minuto(s)* do episódio ({0}): ";
        private string _tituloEPMSG = "\r                       Informe titulo do episódio {0}: ";
        private string _descricaoEPMSG = "\r                       Informe descrição do episódio ({0}): ";
        private string _temporadaEPMSG = "\r                       Episódio: ({0}) pertence a qual temporada? Série: ({1}), Possui: ({2})-Temporada(s) :";
        private string _generoMSG = "\r                       Informe gênero da série: Ação (0), Aventura (1), Drama (2),\n                       Ficção (3),Suspense (4), Terror (5), Romance (6), Comédia (7) :";


        private ConsoleKey bt;
        public Serie(Serie objeto)
        {

            this._Sinops = objeto._Sinops;
            this._Ano = objeto._Ano;
            this._Temporada = objeto._Temporada;
            this._Epsodio = objeto._Epsodio;
            this._Genero = objeto._Genero;

            base._Serie = objeto._Serie;
            base._NumEP = objeto._NumEP;
            base._DuracaoEP = objeto._DuracaoEP;
            base._TituloEP = objeto._TituloEP;
            base._SinopEP = objeto._SinopEP;
            base._TemporadaEP = objeto._TemporadaEP;

        }


        public enum Genero { Ação, Aventura, Drama, Ficção, Suspense, Terror, Romance, Comédia }
        public int _Ano { get; set; }
        public Genero _Genero { get; set; }
        public int _Temporada { get; set; }
        public int _Epsodio { get; set; }
        public string _Sinops { get; set; }

        public void InsertDB(List<Serie> listaSerie, Serie serie, List<Epsodio> listaEpisodio)
        {
            _laco = 1;
            while (_laco == 1)
            {
                Console.WriteLine("\n");
                Console.WriteLine("\n============================== CRIANDO NOVA SÉRIE ========================================\n");


                Console.Write(_serieMSG);
                serie._Serie = Console.ReadLine();
                while (serie._Serie.Length == 0)
                {
                    Console.Write(_serieMSG);

                    serie._Serie = Console.ReadLine();
                }

                List<Serie> Pesquisar = listaSerie.FindAll(delegate (Serie seriadoExistente) { return seriadoExistente._Serie == serie._Serie; });
                if (Pesquisar.Count > 0)
                {
                    Console.WriteLine("***SÉRIE JÁ EXISTE***, Aperte (1) - Para informar outro nome, ou aperte qualquer (tecla) para sair.");
                    bt = Console.ReadKey().Key;
                    if (bt == ConsoleKey.D1 || bt == ConsoleKey.NumPad1)
                    {

                    }
                    else
                    {
                        _laco = 0;
                    }
                }
                else
                {

                    Console.Write(_descricaoMSG);
                    serie._Sinops = Console.ReadLine();
                    while (serie._Sinops.Length == 0)
                    {
                        Console.Write(_descricaoMSG);
                        serie._Sinops = Console.ReadLine();

                    }

                    _laco = 1;
                    while (_laco == 1)
                    {
                        Console.Write(_anoMSG);

                        while (!Int32.TryParse(Console.ReadLine(), out _entrada))
                        {
                            Console.Write(_anoMSG);
                        }

                        if (_entrada > 1949 && _entrada < 2023)
                        {
                            serie._Ano = _entrada;

                            _laco = 0;
                            _entrada = 0;
                        }



                    }


                    _laco = 1;
                    Console.Write(_generoMSG);
                    while (_laco == 1)
                    {

                        bt = Console.ReadKey().Key;
                        if ((bt == ConsoleKey.NumPad0 || bt == ConsoleKey.D0) || (bt == ConsoleKey.NumPad1 || bt == ConsoleKey.D1)
                        || (bt == ConsoleKey.NumPad2 || bt == ConsoleKey.D2) || (bt == ConsoleKey.NumPad3 || bt == ConsoleKey.D3) ||
                        (bt == ConsoleKey.NumPad4 || bt == ConsoleKey.D4) || (bt == ConsoleKey.NumPad5 || bt == ConsoleKey.D5) ||
                        (bt == ConsoleKey.NumPad6 || bt == ConsoleKey.D6) || (bt == ConsoleKey.NumPad7 || bt == ConsoleKey.D7))
                        {
                            if (bt == ConsoleKey.NumPad0 || bt == ConsoleKey.D0)
                            {
                                _laco = 0;
                            }
                            else if (bt == ConsoleKey.NumPad1 || bt == ConsoleKey.D1)
                            {
                                _laco = 1;
                            }
                            else if (bt == ConsoleKey.NumPad2 || bt == ConsoleKey.D2)
                            {
                                _laco = 2;
                            }
                            else if (bt == ConsoleKey.NumPad3 || bt == ConsoleKey.D3)
                            {
                                _laco = 3;
                            }
                            else if (bt == ConsoleKey.NumPad4 || bt == ConsoleKey.D4)
                            {
                                _laco = 4;
                            }
                            else if (bt == ConsoleKey.NumPad5 || bt == ConsoleKey.D5)
                            {
                                _laco = 5;
                            }
                            else if (bt == ConsoleKey.NumPad6 || bt == ConsoleKey.D6)
                            {
                                _laco = 6;
                            }
                            else if (bt == ConsoleKey.NumPad7 || bt == ConsoleKey.D7)
                            {
                                _laco = 7;
                            }

                            serie._Genero = (Genero)_laco;
                            _laco = 0;
                        }




                    }

                    _laco = 1;
                    while (_laco == 1)
                    {
                        Console.Write("\n" + _episodioMSG);

                        while (!int.TryParse(Console.ReadLine(), out _entrada))
                        {
                            Console.Write(_episodioMSG);
                        }

                        if (_entrada > 0)
                        {
                            serie._Epsodio = _entrada;
                            _laco = 0;
                            _entrada = 0;
                        }

                    }

                    if (serie._Epsodio == 1)
                    {
                        serie._Temporada = 1;
                    }
                    else
                    {
                        _laco = 1;
                        while (_laco == 1)
                        {
                            Console.Write(_temporadaMSG);

                            while (!int.TryParse((Console.ReadLine()), out _entrada))
                            {
                                Console.Write(_temporadaMSG);

                            }
                            if (_entrada > 0 && _entrada <=serie._Epsodio) 
                            {
                                serie._Temporada = _entrada;
                                _laco = 0;
                                _entrada = 0;
                            }

                        }
                    }

                    listaSerie.Add(new Serie(serie));

                    for (int x = 1; x <= serie._Epsodio; x++)
                    {
                        Console.WriteLine("\n==================== Adicionando ({0}) de ({1}) Episódio(s) da Série ({2}) ====================\n", x, serie._Epsodio, serie._Serie);
                        serie._NumEP = x;
                        Console.Write(_tituloEPMSG, x);
                        serie._TituloEP = Console.ReadLine();
                        while (serie._TituloEP.Length == 0)
                        {
                            Console.Write(_tituloEPMSG, x);
                            serie._TituloEP = Console.ReadLine();

                        }

                        Console.Write(_descricaoEPMSG, serie._TituloEP);
                        serie._SinopEP = Console.ReadLine();
                        while (serie._SinopEP.Length == 0)
                        {
                            Console.Write(_descricaoEPMSG, serie._TituloEP);

                            serie._SinopEP = Console.ReadLine();

                        }
                        _laco = 1;
                        while (_laco == 1)
                        {
                            Console.Write(_duracaoEPMSG, serie._TituloEP);

                            while (!Int32.TryParse(Console.ReadLine(), out _entrada))
                            {
                                Console.Write(_duracaoEPMSG, serie._TituloEP);

                            }
                            if (_entrada != 0)
                            {
                                _laco = 0;
                                serie._DuracaoEP = _entrada + "-Minutos";
                                _entrada = 0;
                            }
                        }
                        if (serie._Temporada == 1)
                        {
                            serie._TemporadaEP = "1";
                        }
                        else
                        {


                            _laco = 1;
                            while (_laco == 1)
                            {
                                Console.Write(_temporadaEPMSG, serie._TituloEP, serie._Serie, serie._Temporada);

                                while (!int.TryParse((Console.ReadLine()), out _entrada))
                                {
                                    Console.Write(_temporadaEPMSG, serie._TituloEP, serie._Serie, serie._Temporada);

                                }
                                if (_entrada > 0 && _entrada <= serie._Temporada)
                                {
                                    serie._TemporadaEP = _entrada.ToString();
                                    _laco = 0;
                                    _entrada = 0;
                                }
                            }
                        }


                        listaEpisodio.Add(new Serie(serie));




                    }

                    _laco = 0;

                }
            }




            LayoutSeries(listaSerie, serie, listaEpisodio, 1);

        }

        public void UpdateDB(List<Serie> lista)
        {

        }

        public void SelectDB(List<Serie> listaSerie, Serie serie, List<Epsodio> listaEpisodio, int escolha)
        {

            Console.WriteLine("\n=============================== ({0}) - Série(s) Disponível(is) ===========================\n", listaSerie.Count);

            if (listaSerie.Count == 0)//caso nao encontre nenhuma serie na listagem
            {
                Console.Write("        Aperte (1) - Para nova série, ou qualquer (tecla) - Para sair :");

            }
            else
            {
                Console.Write("   Aperte (1) - Para listar série(s), Aperte (2) - Para nova série, ou qualquer (tecla) - Para sair :");

            }

            bt = Console.ReadKey().Key;

            if ((bt == ConsoleKey.D1 && listaSerie.Count == 0) || (bt == ConsoleKey.NumPad1 && listaSerie.Count == 0))
            {
                InsertDB(listaSerie, serie, listaEpisodio);
            }
            else if ((bt == ConsoleKey.D2 && listaSerie.Count > 0) || (bt == ConsoleKey.NumPad2 && listaSerie.Count > 0))
            {
                InsertDB(listaSerie, serie, listaEpisodio);
            }
            else if ((bt == ConsoleKey.D1 && listaSerie.Count > 0) || (bt == ConsoleKey.NumPad1 && listaSerie.Count > 0))
            {

                playSERIE(listaSerie, serie, listaEpisodio, escolha);








            }


        }

        private void playSERIE(List<Serie> listaSerie, Serie serie, List<Epsodio> listaEpisodio, int indiceSerieEpsodio)
        {

            Console.Clear();

            Console.WriteLine("\n============================= SÉRIE(S) DISPONÍVEL(IS) =========================================");


            for (int indiceSerie = 0; indiceSerie <= listaSerie.Count - 1; indiceSerie++)
            {
                Console.WriteLine("\nSérie:{0} / - Para exibi-la aperte opção:({1})", listaSerie[indiceSerie]._Serie, indiceSerie);
                Console.WriteLine("\nDescrição:{0}", listaSerie[indiceSerie]._Sinops);
                Console.WriteLine("\nTemporada(s):{0} / Episódios:{1} / Ano:{2} / Gênero:{3}", listaSerie[indiceSerie]._Temporada, listaSerie[indiceSerie]._Epsodio, listaSerie[indiceSerie]._Ano, listaSerie[indiceSerie]._Genero);
                Console.WriteLine("-----------------------------------------------------------------------------");

            }

            Console.Write("\n   Aperte opção:(?)- Para exibir série, ou qualque (tecla)- Para Sair :");
            bt = Console.ReadKey().Key;

            for (int indiceEP = 0; indiceEP < listaSerie.Count; indiceEP++)
            {
                if (bt == ConsoleKey.D0 + indiceEP || bt == ConsoleKey.NumPad0 + indiceEP)
                {
                         
                    List<Epsodio> epsodiosSERIEX = listaEpisodio.FindAll(delegate (Epsodio episodiosX) { return episodiosX._Serie == listaSerie[indiceEP]._Serie; });
                    _laco = 1;
                    int ep=0;
                    while (_laco == 1)
                    {    
                        
                         Console.Clear();
                        
                         Console.WriteLine("\nSérie:{0} / - EM EXIBIÇÂO", listaSerie[indiceEP]._Serie);
                         Console.WriteLine("\nDescrição:{0}", listaSerie[indiceEP]._Sinops);
                         Console.WriteLine("\nTemporada(s):{0} / Episódios:{1} / Ano:{2} / Gênero:{3}", listaSerie[indiceEP]._Temporada, listaSerie[indiceEP]._Epsodio, listaSerie[indiceEP]._Ano, listaSerie[indiceEP]._Genero);
                         Console.WriteLine("-----------------------------------------------------------------------------\n");
         
                        Console.WriteLine("***************************EXIBINDO EPISÓDIO***************************");
                        Console.WriteLine("Epsodio ({0}) - Titulo: {1}", epsodiosSERIEX[ep]._NumEP, epsodiosSERIEX[ep]._TituloEP);
                        Console.WriteLine("Descrição: {0}", epsodiosSERIEX[ep]._SinopEP);
                        Console.WriteLine("Duração: {0}", epsodiosSERIEX[ep]._DuracaoEP);
                        Console.WriteLine("Temporada: {0}", epsodiosSERIEX[ep]._TemporadaEP);
                        Console.WriteLine("*************************************************************************\n");
                        Console.Write("\rAPERTE (-) // (+) PARA NAVEGAR ENTRE OS EPISÓDIOS, OU (X) PARA SAIR: ");

                        bt = Console.ReadKey().Key;

                        if (bt == ConsoleKey.Subtract && ep > 0 || bt == ConsoleKey.OemMinus && ep > 0)
                        {
                            ep -= 1;

                        }
                        else if (bt == ConsoleKey.OemPlus && ep < epsodiosSERIEX.Count - 1 || bt == ConsoleKey.Add && ep < epsodiosSERIEX.Count - 1)
                        {
                            ep += 1;

                        }
                        else if (bt == ConsoleKey.X)
                        {
                            _laco = 0;
                        }

                    }


                }
            }


           
            




        }

        public void DeleteDB(List<Serie> lista)
        {

        }

        public void LayoutSeries(List<Serie> listaSerei, Serie serie, List<Epsodio> listaEpisodio, int escolha)
        {
            Console.Clear();
            Console.WriteLine("                                   C# CONSOLE");
            Console.WriteLine("\n                      ==================================");
            Console.WriteLine("                                            _________");
            Console.WriteLine("                         Bem               /");
            Console.WriteLine("                               Vindo(a)   /_____");
            Console.WriteLine("                         Ao                    /");
            Console.WriteLine("                               Portal    _____/ éries");
            Console.WriteLine("                       ================================");
            SelectDB(listaSerei, serie, listaEpisodio, escolha);//busca series e exibie opções

        }
    }


}