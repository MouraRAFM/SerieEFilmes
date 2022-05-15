namespace SerieEFilmes
{
    public class Filme : IcrudFilme
    {



        public string _Nome { get; set; }
        public string _Descricao { get; set; }
        public int _Ano { get; set; }
        public string _Duracao { get; set; }
        public enum Genero { Ação, Drama, Suspense, Terror, Aventura, Outros }
        public Genero _genero { get; set; }
        public enum Idade { Livre, Infantil, Adolescente, Adulto }
        public Idade _Idade { get; set; }

        public Filme()
        {
        }

        public Filme(Filme filme)
        {
            this._Nome = filme._Nome;
            this._Descricao = filme._Descricao;
            this._Ano = filme._Ano;
            this._Duracao = filme._Duracao;
            this._genero = filme._genero;
            this._Idade = filme._Idade;

        }

        private ConsoleKey bt;
        private int _laco;
        private string _NomeFilmeMSG = "\r                       Informe nome do filme: ";
        private string _NomeFilmeEdicaoMSG = "\r                       Aperte (ENTER) para manter nome: {0}\n                       ou informe Edição:";

        private string _descricaoMSG = "\r                       Informe Descrição do filme: ";

        private string _descricaoEditarMSG = "\r                       Aperte (ENTER) para manter Descrição: {0}\n                       ou informe Edição:";



        private string _anoMSG = "\r                       Informe ano do filme entre (1950 e 2022): ";

        private string _anoEdicaoMSG = "\r                       Informe ({0}) para manter Ano\n                       ou informe edição entre (1950 e 2022): ";

        private int _entrada;
        private string _generoMSG = "\r                       Informe gênero do filme:(0) Ação,(1) Drama,(2) Suspense\n                       (3) Terror,(4) Aventura,(5) Outros :";

        private string _generoEdicaoMSG = "\r                       Aperte (Enter) para manter gênero: {0}\n                       Ou informe opção:(0) Ação,(1) Drama,(2) Suspense\n                       (3) Terror,(4) Aventura,(5) Outros :";


        private string _duracaoMSG = "\r                       Informe tempo de duração em *minuto(s)* do filme: ";

        private string _duracaoEdicaoMSG = "\r                       Informe valor:({0}) para manter Duração\n                       ou informe Edição:";


        private string _idadeMSG = "\r                       Informe classificação indicativa do filme:(0) - Para livre\n                       (1) - Para criança, (2) - Para Adolescente,(3) - Para Adulto:";

        private string _idadeEdicaoMSG = "\r                       Aperte (Enter) para manter classificação: {0}\n                       ou informe opção: (0) - Para Livre, (1) - Para criança\n                       (2) - Para Adolescente,(3) - Para Adulto :";



        private int localizado;

        internal void LayoutFilmes(List<Filme> listaFilmes, Filme filme)
        {

            Console.Clear();
            Console.WriteLine("                                   C# CONSOLE");
            Console.WriteLine("\n                      ==================================");
            Console.WriteLine("                                         ______");
            Console.WriteLine("                         Bem            |");
            Console.WriteLine("                             Vindo(a)   |____");
            Console.WriteLine("                         Ao             |");
            Console.WriteLine("                             Portal     | ilmes");
            Console.WriteLine("                       ================================");
            Console.WriteLine();
            SelectDB(listaFilmes, filme);

        }

        public void InsertDB(List<Filme> listaFilme, Filme filme, string tipo, int indice)
        {

            _laco = 1;
            while (_laco == 1)
            {
                if (tipo == "Criar")
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("\n============================== CRIANDO NOVO FILME ========================================\n");
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("\n============================== EDITANDO  FILME ========================================\n");

                }

                if (tipo == "Criar")
                {
                    Console.Write(_NomeFilmeMSG);
                }
                else
                {
                    Console.Write(_NomeFilmeEdicaoMSG, listaFilme[indice]._Nome);
                }

                filme._Nome = Console.ReadLine().ToUpper();
                while (filme._Nome.Length == 0)
                {
                    if (tipo == "Editar")
                    {
                        filme._Nome = listaFilme[indice]._Nome;
                    }
                    else
                    {
                        Console.Write(_NomeFilmeMSG);

                        filme._Nome = Console.ReadLine().ToUpper();
                    }
                }

                List<Filme> Pesquisar = listaFilme.FindAll(delegate (Filme filmeExistente) { return filmeExistente._Nome == filme._Nome; });
                if (Pesquisar.Count > 0 && tipo == "Criar")
                {

                    Console.WriteLine("***FILME JÁ EXISTE***, Aperte (1) - Para informar outro nome, ou aperte qualquer (tecla) para sair.");
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
                    if (tipo == "Criar")
                    {
                        Console.Write(_descricaoMSG);
                    }
                    else
                    {
                        Console.Write(_descricaoEditarMSG, listaFilme[indice]._Descricao);
                    }
                    filme._Descricao = Console.ReadLine();
                    while (filme._Descricao.Length == 0)
                    {
                        if (tipo == "Editar")
                        {
                            filme._Descricao = listaFilme[indice]._Descricao;
                        }
                        else
                        {
                            Console.Write(_descricaoMSG);
                            filme._Descricao = Console.ReadLine();
                        }

                    }

                    _laco = 1;
                    while (_laco == 1)
                    {
                        if (tipo == "Criar")
                        {
                            Console.Write(_anoMSG);
                        }
                        else
                        {
                            Console.Write(_anoEdicaoMSG, listaFilme[indice]._Ano);


                        }

                        while (!Int32.TryParse(Console.ReadLine(), out _entrada))
                        {
                            Console.Write(_anoMSG);
                        }

                        if (_entrada > 1949 && _entrada < 2023)
                        {
                            filme._Ano = _entrada;

                            _laco = 0;
                            _entrada = 0;
                        }



                    }

                    _laco = 1;
                    while (_laco == 1)
                    {
                        if (tipo == "Criar")
                        {
                            Console.Write(_duracaoMSG);
                        }
                        else
                        {
                            Console.Write(_duracaoEdicaoMSG, listaFilme[indice]._Duracao);
                        }

                        while (!Int32.TryParse(Console.ReadLine(), out _entrada))
                        {
                            Console.Write(_duracaoMSG);

                        }
                        if (_entrada > 0)
                        {
                            _laco = 0;
                            filme._Duracao = _entrada + "-Minutos";
                            _entrada = 0;
                        }
                    }

                    _laco = 1;
                    while (_laco == 1)
                    {
                        if (tipo == "Criar")
                        {

                            Console.Write(_generoMSG);
                        }
                        else
                        {

                            Console.Write(_generoEdicaoMSG, listaFilme[indice]._genero);
                        }

                        bt = Console.ReadKey().Key;
                        if ((bt == ConsoleKey.NumPad0 || bt == ConsoleKey.D0) || (bt == ConsoleKey.NumPad1 || bt == ConsoleKey.D1)
                        || (bt == ConsoleKey.NumPad2 || bt == ConsoleKey.D2) || (bt == ConsoleKey.NumPad3 || bt == ConsoleKey.D3) ||
                        (bt == ConsoleKey.NumPad4 || bt == ConsoleKey.D4) || (bt == ConsoleKey.NumPad5 || bt == ConsoleKey.D5) || (bt == ConsoleKey.Enter && tipo == "Editar"))
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

                            if (tipo == "Criar")
                            {

                                filme._genero = (Genero)_laco;
                            }
                            else
                            {
                                if (bt == ConsoleKey.Enter)
                                {
                                    filme._genero = listaFilme[indice]._genero;
                                }
                                else
                                {
                                    filme._genero = (Genero)_laco;
                                }

                            }

                            _laco = 0;
                        }
                    }


                    _laco = 1;
                    while (_laco == 1)
                    {
                        if (tipo == "Criar")
                        {
                            Console.Write(_idadeMSG);
                        }
                        else
                        {
                            Console.Write(_idadeEdicaoMSG, listaFilme[indice]._Idade);
                        }


                        bt = Console.ReadKey().Key;
                        if ((bt == ConsoleKey.NumPad0 || bt == ConsoleKey.D0) || (bt == ConsoleKey.NumPad1 || bt == ConsoleKey.D1)
                        || (bt == ConsoleKey.NumPad2 || bt == ConsoleKey.D2) || (bt == ConsoleKey.NumPad3 || bt == ConsoleKey.D3) ||
                        (bt == ConsoleKey.Enter && tipo == "Editar"))
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
                            if (tipo == "Criar")
                            {
                                filme._Idade = (Idade)_laco;
                            }
                            else
                            {
                                if (bt == ConsoleKey.Enter)
                                {
                                    filme._Idade = listaFilme[indice]._Idade;
                                }
                                else
                                {
                                    filme._Idade = (Idade)_laco;
                                }

                            }
                            _laco = 0;
                        }
                    }

                    if (tipo == "Criar")
                    {
                        listaFilme.Add(new Filme(filme));
                    }
                    else
                    {
                        listaFilme[indice]._Nome = filme._Nome;
                        listaFilme[indice]._Descricao = filme._Descricao;
                        listaFilme[indice]._Ano = filme._Ano;
                        listaFilme[indice]._Duracao = filme._Duracao;
                        listaFilme[indice]._genero = filme._genero;
                        listaFilme[indice]._Idade = filme._Idade;

                    }
                }//fim else

            }//fim laco

            if (tipo == "Criar")
            {
                LayoutFilmes(listaFilme, filme);
            }
        }

        public void UpdateDB(List<Filme> listaFilme, Filme filme, int indice)
        {
            InsertDB(listaFilme, filme, "Editar", indice);
        }

        public void SelectDB(List<Filme> listaFilme, Filme filme)
        {

            Console.WriteLine("\n=============================== ({0}) - Filme(s) Disponível(is) ===========================\n", listaFilme.Count);

            if (listaFilme.Count == 0)
            {
                Console.Write("        Aperte (1) - Para novo filme, ou qualquer (tecla) - Para sair :");

            }
            else
            {
                Console.Write("   Aperte (1) - Para listar filme(s), (2) - Novo filme, ou qualquer (tecla) - Para sair :");

            }

            bt = Console.ReadKey().Key;

            if ((bt == ConsoleKey.D1 && listaFilme.Count == 0) || (bt == ConsoleKey.NumPad1 && listaFilme.Count == 0))
            {
                InsertDB(listaFilme, filme, "Criar", 0);
            }
            else if ((bt == ConsoleKey.D2 && listaFilme.Count > 0) || (bt == ConsoleKey.NumPad2 && listaFilme.Count > 0))
            {
                InsertDB(listaFilme, filme, "Criar", 0);
            }
            else if ((bt == ConsoleKey.D1 && listaFilme.Count > 0) || (bt == ConsoleKey.NumPad1 && listaFilme.Count > 0))
            {

                playFilme(listaFilme, filme);
            }

        }

        private void playFilme(List<Filme> listaFilme, Filme filme)
        {
            Console.Clear();

            Console.WriteLine("\n============================= FILME(S) DISPONÍVEL(IS) =========================================");


            for (int indiceFilmes = 0; indiceFilmes <= listaFilme.Count - 1; indiceFilmes++)
            {
                Console.WriteLine("\nFilme:{0}", listaFilme[indiceFilmes]._Nome);
                Console.WriteLine("\nDescrição:{0}", listaFilme[indiceFilmes]._Descricao);
                Console.WriteLine("\nDuração:{0} / Ano:{1} / Classificação:{2} / Gênero:{3}", listaFilme[indiceFilmes]._Duracao, listaFilme[indiceFilmes]._Ano, listaFilme[indiceFilmes]._Idade, listaFilme[indiceFilmes]._genero);
                Console.WriteLine("-----------------------------------------------------------------------------");

            }



            string coletor = "";
            while ((coletor.Length == 0))
            {

                Console.Write(" Informe (filme) para exibi-lo, ou (S) para Sair :");
                coletor = Console.ReadLine().ToUpper();
                if (coletor.Length > 0 && coletor != "S")
                {

                    for (int indice = 0; indice < listaFilme.Count; indice++)
                    {
                        if (listaFilme[indice]._Nome == coletor)
                        {

                            localizado = 1;
                            Console.Clear();

                            Console.WriteLine("***************************EXIBINDO FILME***************************");
                            Console.WriteLine("\nFilme:{0}", listaFilme[indice]._Nome);
                            Console.WriteLine("\nDescrição:{0}", listaFilme[indice]._Descricao);
                            Console.WriteLine("\nDuração:{0} / Ano:{1} / Classificação:{2} / Gênero:{3}", listaFilme[indice]._Duracao, listaFilme[indice]._Ano, listaFilme[indice]._Idade, listaFilme[indice]._genero);
                            Console.WriteLine("*************************************************************************\n");

                            Console.Write(" APERTE (E) PARA EDITAR FILME, OU QUALQUER (TECLA) PARA SAIR DA REPRODUÇÂO: ");
                            bt=Console.ReadKey().Key;
                            if (bt==ConsoleKey.E)
                            {
                                UpdateDB(listaFilme, filme, indice);
                                indice -= 1;
                            }
                            else
                            {

                                indice = listaFilme.Count;
                            }
                        }

                    }
                    if (localizado == 1)
                    {
                        localizado = 0;
                    }
                    else
                    {
                        coletor = "";
                    }

                }
                else if (coletor != "S")
                {
                    coletor = "";
                }
            }


        }

        public void DeleteDB(List<Filme> listaFilme, Filme filme)
        {
            throw new NotImplementedException();
        }





    }
}