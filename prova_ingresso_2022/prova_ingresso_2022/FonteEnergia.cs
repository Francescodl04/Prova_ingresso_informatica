namespace prova_ingresso_2022
{
    class FonteEnergia
    {
        protected string nome { get; set; }

        public FonteEnergia (string nome)
        {
            this.nome = nome;
        }

        public string GetNome()
        {
            return nome;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
