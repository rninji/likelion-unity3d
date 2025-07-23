using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue : MonoBehaviour
{
    private List<Node> nodes = new List<Node>();

    // 노드 개수
    public int Length
    {
        get { return nodes.Count; }
    }

    // 특정 노드 포함 여부
    public bool Contains(Node node)
    {
        return nodes.Contains(node);
    }

    // 가장 우선순위가 높은 노드 반환 (F값이 가장 작은 노드)
    public Node First()
    {
        if (nodes.Count == 0)
            return null;

        return nodes[0];
    }

    // 노드 추가 후 정렬
    public void Push(Node node)
    {
        nodes.Add(node);
        nodes.Sort(); // 내부적으로 Node.CompareTo()를 자동 호출
    }

    // 노드 제거 후 정렬
    public void Remove(Node node)
    {
        nodes.Remove(node);
        nodes.Sort();
    }
}