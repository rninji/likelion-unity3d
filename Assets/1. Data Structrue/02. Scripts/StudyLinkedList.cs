using System.Collections.Generic;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> linkedList = new LinkedList<int>();

    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            linkedList.AddLast(i);
        }

        var index = linkedList.AddFirst(100);
        linkedList.AddAfter(index, 200);
        linkedList.AddBefore(index, 300);
    }
}
