using System.Collections;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    IEnumerator Start()
    {
        PizzaStore pizzaStore = null;
        Pizza pizza = null;

        pizzaStore = new LegacyPizzaStore();
        pizza = pizzaStore.OrderPizza("Normal");
        Debug.Log($"주문한 {pizza.Name} 나왔습니다.");

        yield return new WaitForSeconds(1f);
        
        pizza = pizzaStore.OrderPizza("Special");
        Debug.Log($"주문한 {pizza.Name} 나왔습니다.");
        
        yield return new WaitForSeconds(1f);

        pizzaStore = pizzaStore = new NewPizzaStore();
        pizza = pizzaStore.OrderPizza("Normal");
        Debug.Log($"주문한 {pizza.Name} 나왔습니다.");

        yield return new WaitForSeconds(1f);
        
        pizzaStore = pizzaStore = new LegacyPizzaStore();
        pizza = pizzaStore.OrderPizza("Special");
        Debug.Log($"주문한 {pizza.Name} 나왔습니다.");
    }
}
