# Queue
- 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
- 입력된 순서대로 처리해야 하는 상황에 이용

```cs
static void Main(string[] args)
{
    Queue<int> queue = new Queue<int>();

    for (int i = 0; i < 5; i++)
    {
        queue.Enqueue(i); // O(1) 데이터 넣기
    }

    Console.WriteLine(queue.Peek()); // O(1) 다음으로 나올 데이터 확인 (맨 앞의 요소를 제거하지 않고 반환)

    while (queue.Count > 0)
    {
        Console.WriteLine(queue.Dequeue()); // O(1) 데이터 꺼내기 (맨 앞의 요소를 제거하고 반환)
    }
}

```

