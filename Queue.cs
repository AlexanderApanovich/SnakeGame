using System;

namespace Snake
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y) { X = x; Y = y; }
    }

    class Queue
    {
        public int Length { get; private set; }
        public Point[] queue;

        public Queue() { Length = 0; }

        public void Push(Point point)
        {
            //Вспомогательный массив
            Point[] arr = new Point[Length];

            //Создание нового массива с индексом + 1
            for (int i = 0; i < Length; i++) arr[i] = queue[i];
            queue = new Point[++Length];
            for (int i = 0; i < Length - 1; i++) queue[i] = arr[i];

            //Добавление точки в конец очереди
            queue[Length - 1] = point;
        }

        public void RemoveFirst()
        {
            //Вспомогательный массив
            Point[] arr = new Point[Length];

            //Создание нового массива без первого элемента
            for (int i = 0; i < Length; i++) arr[i] = queue[i];
            queue = new Point[--Length];
            for (int i = 0; i < Length; i++) queue[i] = arr[i + 1];
        }
    }
}
