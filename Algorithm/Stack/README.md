# Stack
- 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조 (집어넣었던 박스에 꺼내는 박스)
- 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용

```cs
static void Main(string[] args)
{
	Stack<int> stack = new Stack<int>();

	for (int i = 0; i < 5; i++)
	{
		stack.Push(i);  //O(1)  맨 위에 삽입합
	}

	Console.WriteLine(stack.Peek()); //O(1) 다음으로 나올 데이터 확인

	while (stack.Count > 0)
	{
		Console.WriteLine(stack.Pop()); //O(1)  맨 위에서 개체를 제거하고 반환
	}
}
```

