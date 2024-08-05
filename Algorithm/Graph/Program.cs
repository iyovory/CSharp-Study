using System;
using System.Collections.Generic;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new();

            GraphNode<int> node0 = graph.AddNode(0);
            GraphNode<int> node1 = graph.AddNode(1);
            GraphNode<int> node2 = graph.AddNode(2);
            GraphNode<int> node3 = graph.AddNode(3);
            GraphNode<int> node4 = graph.AddNode(4);
            GraphNode<int> node5 = graph.AddNode(5);
            GraphNode<int> node6 = graph.AddNode(6);
            GraphNode<int> node7 = graph.AddNode(7);

            graph.AddEdge(node0, node1);
            graph.AddEdgeCycle(node0, node2);

            graph.AddEdge(node1, node6);

            graph.AddEdge(node3, node7);

            graph.AddEdge(node4, node2);

            graph.AddEdge(node5, node7);

            graph.AddEdge(node6, node4);
            graph.AddEdge(node6, node7);


            graph.PrintGraphInfo();
        }
    }
}

// 그래프 노드
public class GraphNode<T>
{
    public T Value { get; set; }
    public List<GraphNode<T>> NeighborNodes { get; } = new();
    public bool IsVisited { get; set; }

    public GraphNode(T value)
    {
        Value = value;
    }

    public void PrintNeighborNodes()
    {
        Console.WriteLine($"{Value} 인접노드");
        foreach (var neighbor in NeighborNodes)
        {
            Console.WriteLine($"   ㄴ {neighbor.Value}");
        }
    }

    public void AddEdge(GraphNode<T> node)
    {
        NeighborNodes.Add(node);
    }

    public void RemoveEdge(GraphNode<T> node)
    {
        NeighborNodes.Remove(node);
    }
}

public class Graph<T>
{
    private List<GraphNode<T>> _nodes = new();

    public GraphNode<T> AddNode(T value)
    {
        GraphNode<T> node = new(value);
        _nodes.Add(node);
        return node;
    }

    //단방향
    public void AddEdge(GraphNode<T> from, GraphNode<T> to)
    {
        from.NeighborNodes.Add(to);
    }

    //양방향
    public void AddEdgeCycle(GraphNode<T> from, GraphNode<T> to)
    {
        from.NeighborNodes.Add(to);
        to.NeighborNodes.Add(from);
    }

    public void RemoveNode(GraphNode<T> node)
    {
        foreach (var n in _nodes)
        {
            n.RemoveEdge(node);
        }

        _nodes.Remove(node);
    }

    public void PrintGraphInfo()
    {
        Console.WriteLine("그래프 노드 구조 ---");
        foreach (var n in _nodes)
        {
            n.PrintNeighborNodes();
        }
    }

    public List<GraphNode<T>> DFS(GraphNode<T> start, GraphNode<T> end)
    {
        List<GraphNode<T>> visitList = new();
        Stack<GraphNode<T>> nextNodes = new();

        //모든 노드의 방문여부 초기화
        foreach (var n in _nodes)
        {
            n.IsVisited = false;
        }

        //스택에 시작 노드를 추가하고 방문 여부 전환
        nextNodes.Push(start);

        GraphNode<T> currentNode;
        //스택에 아무것도 남지 않을때까지 반복
        while (nextNodes.Count > 0)
        {
            //현재 방문중인 노드를 스택에서 꺼내오고 방문여부 전환, 리스트에 추가
            currentNode = nextNodes.Pop();
            currentNode.IsVisited = true;
            visitList.Add(currentNode);

            //현재 노드가 목표지점 노드와 동일하다면 중지
            if(currentNode == end)
            {
                break;
            }

            //방문하지 않은 근접 노드를 스택에 추가
            foreach (var n in currentNode.NeighborNodes)
            {
                if (!n.IsVisited)
                {
                    nextNodes.Push(n);
                }
            }
        }

        return visitList;
    }
}
