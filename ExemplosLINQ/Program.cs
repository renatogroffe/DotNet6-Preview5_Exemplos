using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ExemplosLINQ
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("*** Testes com o método Zip ***");
            Console.WriteLine();

            var numeros = new int[] { 1, 2, 3, 10, 100 };
            var numerosRomanos = new string[] { "I", "II", "III", "X", "C" };
            var descricoes = new string[] { "um", "dois", "três", "dez", "cem" };
            
            var resultados = numeros.Zip(descricoes, numerosRomanos);
            foreach (var resultado in resultados)
                Console.WriteLine(resultado);


            var paises = new Pais[]{
                new () { Nome = "Alemanha", Continente = "Europa" },                
                new () { Nome = "Austrália", Continente = "Oceania" },
                new () { Nome = "Brasil", Continente = "América do Sul" },
                new () { Nome = "Canadá", Continente = "América do Norte" },
                new () { Nome = "Chile", Continente = "América do Sul" },
                new () { Nome = "Espanha", Continente = "Europa" },                
                new () { Nome = "Egito", Continente = "África" },
                new () { Nome = "Estados Unidos", Continente = "América do Norte" },
                new () { Nome = "Inglaterra", Continente = "Europa" },                
                new () { Nome = "Itália", Continente = "Europa" },                
                new () { Nome = "Japão", Continente = "Ásia" },                
                new () { Nome = "Rússia", Continente = "Europa" },
            };

            var paisesUniaoEuropeia = new Pais[]{
                new () { Nome = "Alemanha", Continente = "Europa" },                
                new () { Nome = "Espanha", Continente = "Europa" },                
                new () { Nome = "França", Continente = "Europa" },
                new () { Nome = "Itália", Continente = "Europa" }                
            };

            Console.WriteLine($"No. de elementos nos arrays: " +
                $"{nameof(paises)} = {paises.Length}, " +
                $"{nameof(paisesUniaoEuropeia)} = {paisesUniaoEuropeia.Length} ");

            var paisesExcetoUniaoEuropeia = paises.ExceptBy(
                paisesUniaoEuropeia.Select(pUE => pUE.Nome), p => p.Nome);
            ExibirResultadoPaises(
                "Testes com ExceptBy (ignorando países da União Européia)",
                paisesExcetoUniaoEuropeia);

            var paisesParcial = paises.Union(paisesUniaoEuropeia);
            Console.WriteLine($"No. de elementos no Enumerable " +
                $"{nameof(paisesParcial)} = {paisesParcial.Count()}");

            var paisesDistinct = paisesParcial.DistinctBy(p => p.Nome);
            ExibirResultadoPaises(
                $"Testes com DistinctBy (todos os países distintos em {nameof(paisesDistinct)})",
                paisesDistinct);


            Console.WriteLine("*** Testes com o método Chunk ***");
            var subGrupos = paises.Chunk(5);
            for (int i = 0; i < subGrupos.Count(); i++)
                ExibirResultadoPaises($"Sub-grupo = posição {i}", subGrupos.ElementAt(i));            


            Console.WriteLine();
            Console.WriteLine("*** Testes com MaxBy e MinBy ***");
            Console.WriteLine();

            var seisMaioresCidades = new Demografia[]
            {
                new () { Nome = "Cairo", Pais = "Egito", Populacao = 20_076_000 },
                new () { Nome = "Cidade do Mexico", Pais = "Mexico", Populacao = 21_581_000 },
                new () { Nome = "Delhi", Pais = "India", Populacao = 28_514_000 },
                new () { Nome = "Sao Paulo", Pais = "Brasil", Populacao = 21_650_000 },
                new () { Nome = "Shanghai", Pais = "China", Populacao = 25_582_000 },
                new () { Nome = "Toquio", Pais = "Japao", Populacao = 37_400_068 }
            };

            Console.WriteLine(
                $"Dados das 6 maiores cidades: {JsonSerializer.Serialize(seisMaioresCidades)}");

            Console.WriteLine();
            var maiorCidade = seisMaioresCidades.MaxBy(c => c.Populacao);
            Console.WriteLine($"Maior cidade do mundo em população: {maiorCidade.Nome} | " +
                $"País: {maiorCidade.Pais} | População: {maiorCidade.Populacao}");

            Console.WriteLine();
            var sextaMaiorCidade = seisMaioresCidades.MinBy(c => c.Populacao);
            Console.WriteLine($"6a. maior cidade do mundo em população: {sextaMaiorCidade.Nome} | " +
                $"País: {sextaMaiorCidade.Pais} | População: {sextaMaiorCidade.Populacao}");


            var cidades1 = new Cidade[]{
                new () { Nome = "Sao Paulo", Estado = "SP" },
                new () { Nome = "Rio de Janeiro", Estado = "RJ" },
                new () { Nome = "Belo Horizonte", Estado = "MG" }
            };

            var cidades2 = new Cidade[]{
                new () { Nome = "Belo Horizonte", Estado = "MG" },
                new () { Nome = "Sao Paulo", Estado = "SP" },
                new () { Nome = "Porto Alegre", Estado = "RS" },
                new () { Nome = "Salvador", Estado = "BA" },
            };

            var cidadesUnionBy = cidades1.UnionBy(cidades2, c => c.Nome);
            ExibirResultadoCidades("Testes com UnionBy (propriedade Nome)", cidadesUnionBy);

            var cidadesIntersectBy = cidades1.IntersectBy(
                cidades2.Select(c2 => c2.Nome),  c => c.Nome);
            ExibirResultadoCidades("Testes com IntersectBy (propriedade Nome)", cidadesIntersectBy);


            Console.WriteLine();
            Console.WriteLine("*** FirstOrDefault, LastOrDefault e SingleOrDefault " +
                "com parâmetros default ***");

            var ultimasOlimpiadas = new string[]
            {
                "Rio de Janeiro 2016",
                "Londres 2012",
                "Pequim 2008",
                "Atenas 2004",
                "Sidney 2000"
            };

            Console.WriteLine();
            Console.WriteLine("*** Pesquisa sobre as últimas 5 Olimpíadas ***");
            var textoPesquisaOlimpiada = ReadSearchString();
            if (!String.IsNullOrWhiteSpace(textoPesquisaOlimpiada))
            {
                var resultadoOlimpiada = ultimasOlimpiadas
                    .Where(s => s.Contains(textoPesquisaOlimpiada,
                        StringComparison.InvariantCultureIgnoreCase))
                    .FirstOrDefault("### Ocorrência não encontrada! ###");
                Console.WriteLine($"Resultado = {resultadoOlimpiada}");
            }

            var ultimasDerrotasCopas = new string[]
            {
                "Holanda 1974",
                "Italia 1982",
                "Franca 1986",
                "Argentina 1990",
                "Noruega 1998",
                "Franca 1998",
                "Franca 2006",
                "Holanda 2010",
                "Alemanha 2014",
                "Holanda 2014",
                "Belgica 2018"
            };

            Console.WriteLine();
            Console.WriteLine("*** Pesquisa sobre as 11 últimas " +
                "derrotas do Brasil em Copas  ***");
            var textoPesquisaUltimaDerrota = ReadSearchString();
            if (!String.IsNullOrWhiteSpace(textoPesquisaUltimaDerrota))
            {
                var resultadoDerrota = ultimasDerrotasCopas
                    .Where(s => s.Contains(textoPesquisaUltimaDerrota,
                        StringComparison.OrdinalIgnoreCase))
                    .LastOrDefault("### Derrota não encontrada! ###");
                Console.WriteLine($"Resultado = {resultadoDerrota}");
            }
            
            Console.WriteLine();
            Console.WriteLine("*** E quanto a 1994? ***");
            var resultado1978 = ultimasDerrotasCopas.Where(s => s.EndsWith("1994"))
                .SingleOrDefault("Não houve derrota");
            Console.WriteLine($"1994 = {resultado1978}");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*** Suporte a Index e Ranges em LINQ ***");

            // Refatoração dos exemplos do artigo
            // Novidades do C# 8.0: como habilitar, Ranges e Indices
            // https://renatogroffe.medium.com/novidades-do-c-8-0-como-habilitar-ranges-e-indices-68396fe9afc1

            var tecnologias =
                new string[] { ".NET 6", "C#", "ASP.NET Core", "Azure", "Blazor", "Visual Studio 2022" };

            ImprimirElementos(tecnologias.Take(2..5), // tecnologias.Take(5).Skip(2) = tecnologias[range]
                "Retornando elementos dos índices 2 a 4");

            Range range = 2..5;
            ImprimirElementos(tecnologias.Take(range), // tecnologias.Take(5).Skip(2) = tecnologias[range]
                "Retornando elementos dos índices 2 a 4 via struct Range");

            ImprimirElementos(tecnologias.Take(0..5), // tecnologias.Take(5) = tecnologias[0..5],
                "Retornando elementos dos índices 0 a 4");
            ImprimirElementos(tecnologias.Take(..5), // tecnologias.Take(5) = tecnologias[..5]
                "Retornando até o elemento de posição 4 (desde a posição 0)");

            ImprimirElementos(tecnologias.Take(1..^2), // tecnologias.SkipLast(2).Skip(1) = tecnologias[1..^2]
                "Retornando elementos da posição 1 até o antepenúltimo");
            ImprimirElementos(tecnologias.Take(1..^1), // tecnologias.SkipLast(1).Skip(1) = tecnologias[1..^1],
                "Retornando elementos da posição 1 até o penúltimo");
            ImprimirElementos(tecnologias.Take(..^1), // tecnologias.SkipLast(1) = tecnologias[..^1]
                "Retornando até o penúltimo elemento");

            ImprimirElementos(tecnologias.Take(3..), // tecnologias.Skip(3)
                "Ignorando os 3 primeiros elementos");
            ImprimirElementos(tecnologias.Take(^2..), // tecnologias.TakeLast(2)
                "Retornando os 2 últimos elementos");
            ImprimirElementos(tecnologias.Take(^4..^2), // tecnologias.TakeLast(4).SkipLast(2)
                "Retornando o terceiro e o quarto elementos");
            Console.WriteLine($"Penúltimo elemento: *{tecnologias.ElementAt(^2)}*");
        }

        static void ExibirResultadoPaises(string tipoTeste,
            IEnumerable<Pais> paises)
        {
            Console.WriteLine();
            Console.WriteLine($"*** {tipoTeste} ***");
            Console.WriteLine();
            
            Console.WriteLine($"No. de elementos: {paises.Count()}");
            Console.WriteLine();
            
            Console.WriteLine($"Dados: {JsonSerializer.Serialize(paises)}");
            Console.WriteLine();

            Console.WriteLine("Países:");
            foreach (var pais in paises)
                Console.WriteLine($"  * {pais.Nome} ({pais.Continente})");
            Console.WriteLine();
        }

        static void ExibirResultadoCidades(string tipoTeste,
            IEnumerable<Cidade> cidades)
        {
            Console.WriteLine();
            Console.WriteLine($"*** {tipoTeste} ***");
            Console.WriteLine();
            
            Console.WriteLine($"No. de elementos: {cidades.Count()}");
            Console.WriteLine();
            
            Console.WriteLine($"Dados: {JsonSerializer.Serialize(cidades)}");
            Console.WriteLine();

            Console.WriteLine("Cidades:");
            foreach (var cidade in cidades)
                Console.WriteLine($"  * {cidade.Nome}-{cidade.Estado}");
            Console.WriteLine();
        }        

        private static string ReadSearchString()
        {
            Console.Write(
                "Digite um valor para pesquisa (sem caracteres especiais): ");
            var searchString = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(searchString))
                Console.WriteLine("### Não foi informado um valor para pesquisa! ###");
            return searchString;
        }

        private static void ImprimirElementos(
            IEnumerable<string> selecaoTecnologias,
            string mensagem)
        {
            Console.Write($"{mensagem}: [");
            foreach (string tecnologia in selecaoTecnologias)
                Console.Write($"  *{tecnologia}*");
            Console.Write("  ]" + Environment.NewLine);
        }
    }
}