using System.Linq;
using UnityEngine;

public class StudyOrderBy : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    void Start()
    {
        var result = from number in numbers 
            where number > 1 
            orderby number descending 
            select number;
        
        var result2 = numbers.Where(n => n > 1).OrderByDescending(n=>n);

        foreach (var n in result)
            Debug.Log(n);
        
    }
}
