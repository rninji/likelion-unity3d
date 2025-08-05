using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyLinq : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    void Start()
    {
        // IEnumerable result = from number in numbers 
        //                             where number > 3 
        //                             select number;

        var result = numbers.Where(n => n > 3);

        foreach (var n in result)
            Debug.Log(n);
        
    }
}
