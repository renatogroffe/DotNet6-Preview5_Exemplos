namespace ExemplosLINQ
{
    public class Pais
    {
        public string Nome { get; set; }
        public string Continente { get; set; }
    }

    public class Demografia
    {
        public string Nome { get; set; }
        public string Pais { get; set; }
        public int Populacao { get; set; }
    }    

    public class Cidade
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
    }
}