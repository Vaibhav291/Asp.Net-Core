using System.Xml.Linq;
using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza_> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza_>
        {
            new Pizza_ { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza_ { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Pizza_> GetAll() => Pizzas;

    public static Pizza_? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza_ pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza_ pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}