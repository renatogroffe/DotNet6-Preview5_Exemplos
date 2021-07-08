using System;

namespace ExemploDateTimeOnly
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("*** Testes com DateOnly ***");

            var ignite2021 = new DateOnly(2021, 03, 02);
            Console.WriteLine($"Ignite 2021 = {ignite2021}");

            var build2021 = new DateOnly(2021, 05, 25);
            Console.WriteLine($"Build 2021 = {build2021}");

            var dotNetConf2021 = new DateOnly(2021, 11, 09);
            Console.WriteLine($".NET Conf 2021 = {dotNetConf2021}");

            if (build2021 > ignite2021 && build2021 < dotNetConf2021)
                Console.WriteLine("O Build 2021 aconteceu depois do Ignite e antes do .NET Conf!");

            Console.WriteLine();
            Console.WriteLine("*** Testes com TimeOnly ***");

            var inicioDiaTrabalho = new TimeOnly(09, 00);
            Console.WriteLine($"Início do dia de trabalho = {inicioDiaTrabalho}");

            var terminoDiaTrabalho = new TimeOnly(18, 30);
            Console.WriteLine($"Término do dia de trabalho = {terminoDiaTrabalho}");

            var inicioDotNetConf2021 = new TimeOnly(12, 00);
            Console.WriteLine($"Horário de início do .NET Conf 2021 = {inicioDotNetConf2021}");

            if (inicioDotNetConf2021 > inicioDiaTrabalho &&
                inicioDotNetConf2021 < terminoDiaTrabalho)
                    Console.WriteLine("O .NET Conf 2021 começa no meio do horário de trabalho!");
        }
    }
}