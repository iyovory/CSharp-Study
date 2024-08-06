# Searching

## 순차 탐색, 이진 탐색

### 순차 탐색
-  자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
-  시간복잡도 - O(n)
### 이진 탐색
- 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색
- 단, 이진 탐색은 정렬이 되어 있는 자료에만 적용 가능
- 시간복잡도 - O(logn)

```cs
{
	static void Main(string[] args)
	{
		int[] array = { 1, 3, 5, 8, 6, 4, 2, 0 };
		Console.Write("배열: ");
		foreach (var value in array)
		{
			Console.Write($" {value} ");
		}
		Console.WriteLine();

		int index = Util.IndexOf(array, 2);
		int index2 = Array.IndexOf(array, 2); //c#에서 있는 기능!
		Console.WriteLine($"순차탐색 결과 위치 : {index}");
		Console.WriteLine($"순차탐색 결과 위치 : {index2}");

		int index3 = Util.BinarySearch(array, 2);
		Console.WriteLine($"이진탐색 결과 위치 : {index3}"); //정렬되어있는곳에서면 사용 가능.

		Array.Sort(array);
		Console.Write("배열 : ");
		foreach (int value in array)
		{
			Console.Write($" {value} ");
		}
		Console.WriteLine();
		int index4 = Util.BinarySearch(array, 2);
		int index5 = Array.BinarySearch(array, 2); //c#에서 있는 기능!
		Console.WriteLine($"이진탐색 결과 위치 : {index4}");
		Console.WriteLine();
	}
}

public class Util
{
	//순차탐색
	public static int IndexOf(int[] array, int target) //target찾기
	{
		int result = -1; //배열 인덱스가 -1이 나오지않으니 값이 안나왔다는걸 티나게 표시
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == target)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	//이진탐색
	public static int BinarySearch(int[] array, int target)
	{
		int result = -1;
		int min = 0;
		int max = array.Length - 1;


		while (min <= max)
		{
			int mid = (min + max) / 2; //중간위치

			if (array[mid] < target)
			{
				min = mid + 1; //오른쪽보기
			}
			else if (array[mid] > target)
			{
				max = mid - 1; //왼쪽보기
			}
			else // if (array[mid] == target)
			{
				result = mid; //찾았다!
			}
		}

		return result;
	}
}
```

## 깊이 우선 탐색(DFS),  너비 우선 탐색(BFS)
### 깊이 우선 탐색 DFS
- 최대한 깊이 내려간 뒤, 더이상 깊어질 수 없을때 옆으로 이동해서 똑같이 내려감
- 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
- 분기의 탐색을 마쳤을 때 다음 분기를 탐색
- 재귀(스택)를 통해 구현
- 장점) 지금 탐색하고있는 경로의 메모리만 사용해도 동작 가능. 안사용하고있으면 버림
- 단점) 최단경로 보장X
- 트리에서 사용하기 좋음 (트리: 경로가 하나밖에 없음)
https://www.cs.usfca.edu/~galles/visualization/DFS.html (Start Vertex에 0넣고 run)

### 너비 우선 탐색 BFS 
- 최대한 넓게 이동한 뒤, 더이상 옆으로 갈 수 없을때 아래로 이동
- 그래프의 분기를 만났을때 모든 분기들을 탐색한 뒤, 다음 깊이의 분기들을 검색
- 큐를 통해서 구현
- 장점) 최단경로 보장
- 단점) 다음으로 탐색해야하는 정점들까지 메모리에 보관하고 있어야함
- 그래프에서 사용하기 좋음 (그래프: 경로가 여러개 있을 수 있음)
https://www.cs.usfca.edu/~galles/visualization/BFS.html

```cs

//깊이 우선 탐색(DFS) https://www.cs.usfca.edu/~galles/visualization/DFS.html - visited, parent
public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
{
	int size = graph.GetLength(0);      // size : 그래프의 정점갯수
	visited = new bool[size];           // visited : 탐색 여부
	parent = new int[size];             // parent : 정점을 탐색한 정점이 누구인지 (역순으로 따라가면 경로)

	// 초기 세팅 (처음으로 가져야 되는 값들)
	for (int i = 0; i < size; i++)
	{
		visited[i] = false;
		parent[i] = -1;
	}

	SearchNode(graph, start, visited, parent);  // 처음 정점부터 탐색 시작
}

public static void SearchNode(bool[,] graph, int vertex, bool[] visited, int[] parent)
{
	int size = graph.GetLength(0);  // 정점의 갯수
	visited[vertex] = true;         // 탐색한 정점을 탐색 완료 표시

	for (int i = 0; i < size; i++)  // 전체 정점들을 전부 확인하면서
	{
		if (graph[vertex, i] == true &&     // 연결되어 있는 정점
			visited[i] == false)            // 찾은적 없는 정점
		{
			parent[i] = vertex;             // 해당 정점을 탐색한 정점 표시
			SearchNode(graph, i, visited, parent);  // 정점 탐색 시작
		}
	}
}


//너비 우선 탐색 (BFS) https://www.cs.usfca.edu/~galles/visualization/BFS.html - visited, parent
public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
{
	int size = graph.GetLength(0);      // size : 그래프 정점의 갯수
	visited = new bool[size];           // visited : 정점의 탐색 여부
	parent = new int[size];             // parent : 해당 정점을 누가 찾았았는지 (역순으로 따라가면 경로)

	// 초기 설정
	for (int i = 0; i < size; i++)
	{
		visited[i] = false;
		parent[i] = -1;
	}

	Queue<int> queue = new Queue<int>();    // 큐 : 탐색해야하는 정점들의 대기열
	queue.Enqueue(start);           // 처음으로 탐색해야하는 정점은 시작 정점
	visited[start] = true;          // 탐색 여부 체크 (도착지를 찾은 정점은 출발지이니 도착지 parent를 출발지로 표시)

	while (queue.Count > 0)         // 대기열에 아무것도 없을 때까지
	{
		int vertex = queue.Dequeue();   // 다음으로 탐색해야하는 정점 나오게 된다

		for (int i = 0; i < size; i++)  // 모든 정점들을 확인
		{
			if (graph[vertex, i] == true &&   // 연결되어 있는 정점
				visited[i] == false)          // 찾은적 없는 정점
			{
				visited[i] = true;  // 탐색 여부 체크
				parent[i] = vertex; // 탐색하게되는 정점을 표시
				queue.Enqueue(i);   // 탐색해야하는 정점을 대기열에 추가
			}
		}
	}
}
```