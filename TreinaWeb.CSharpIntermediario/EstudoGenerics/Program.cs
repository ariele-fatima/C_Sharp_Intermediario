using System;

namespace EstudoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa
            {
                Id = 1,
                Nome = "TreinaWeb"
            };
            Animal animal = new Animal
            {
                Id = 1,
                Especie = "Cachorro"
            };

            //Sem Generics é necessário fazer uma classe repositório (RepositorioPessoa e RepositorioAnimal) para cada classe (Pessoa e Animal)
            //RepositorioPessoa repositorioPessoa = new RepositorioPessoa();
            //RepositorioAnimal repositorioAnimal = new RepositorioAnimal();

            //Com Generics apenas uma classe repositório (RepositorioGenerico) é necessária para cada classe (Pessoa e Animal)
            RepositorioGenerico<Pessoa> repositorioPessoa = new RepositorioGenerico<Pessoa>();
            RepositorioGenerico<Animal> repositorioAnimal = new RepositorioGenerico<Animal>();

            repositorioPessoa.Insert(pessoa);
            repositorioAnimal.Insert(animal);
            foreach (Pessoa p in repositorioPessoa.Get())
            {
                Console.WriteLine("Nome da pessoa: " + p.Nome);
            }
            foreach (Animal a in repositorioAnimal.Get())
            {
                Console.WriteLine("Especie do animal: " + a.Especie);
            }
            Console.ReadKey();
        }
    }
}
