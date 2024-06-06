
// Создаем станцию

using RailwayStation.Model;
using Path = RailwayStation.Model.Path;


var schem = new Schem();

// Точки

for (int i = 1; i < 9; i++)
{
   
         double x = (double)new Random().Next(1, 100);
    double y = (double)new Random().Next(1, 5);
    schem.AddPoint(new Station((char)(64 + i)+"",x, y));
}

// Отрезки
schem.AddSegment(new Segment(1,schem.Stations[0], schem.Stations[1]));  // 0
schem.AddSegment(new Segment(2,schem.Stations[1], schem.Stations[2]));  // 1
schem.AddSegment(new Segment(3,schem.Stations[2], schem.Stations[3]));  // 2
schem.AddSegment(new Segment(4,schem.Stations[3], schem.Stations[0]));  // 3
schem.AddSegment(new Segment(5,schem.Stations[4], schem.Stations[5]));  // 4
schem.AddSegment(new Segment(6,schem.Stations[5], schem.Stations[6]));  // 5
schem.AddSegment(new Segment(7, schem.Stations[6], schem.Stations[7]));  // 6

// Пути
schem.AddPath(new Path("Путь А", new List<Segment> { schem.Segments[0], schem.Segments[1] }));  // 0
schem.AddPath(new Path("Путь Б", new List<Segment> { schem.Segments[2], schem.Segments[3] }));  // 1
schem.AddPath(new Path("Путь В", new List<Segment> { schem.Segments[4], schem.Segments[5], schem.Segments[6] }));  // 2

// Парки
schem.AddPark(new Park("Парк 1", new List<Path> { schem.Paths[0], schem.Paths[1] }));  // 0
schem.AddPark(new Park("Парк 2", new List<Path> { schem.Paths[2] }));  // 1

// Вывод доступных парков
Console.WriteLine("Список доступных парков:");
for (int i = 0; i < schem.Parks.Count; i++)
{
    Console.WriteLine($"{i}. {schem.Parks[i].Name}");
}

// Заливка парка
    Console.WriteLine("\nВершины, описывающие парки:");
foreach (var park in schem.Parks)
{
    var vertices = SchemHelper.FillPark(park);
    Console.WriteLine($"  {park.Name}: {string.Join(", ", vertices.Select(v => $"{v.Name}"))}");
}
        



// Поиск кратчайшего пути
Console.Write("Введите индекс начального отрезка: ");
if (int.TryParse(Console.ReadLine(), out int startSegmentIndex) && startSegmentIndex >= 0 && startSegmentIndex < schem.Segments.Count)
{
    Console.Write("Введите индекс конечного отрезка: ");
    if (int.TryParse(Console.ReadLine(), out int endSegmentIndex) && endSegmentIndex >= 0 && endSegmentIndex < schem.Segments.Count)
    {
        var shortestPath = SchemHelper.FindShortestPath(schem, startSegmentIndex, endSegmentIndex);
        if (shortestPath != null)
        {
            Console.WriteLine($"Кратчайший путь: {string.Join(", ", shortestPath)}");
        }
        else
        {
            Console.WriteLine("Пути не существует.");
        }
    }
    else
    {
        Console.WriteLine("Неверный индекс конечного отрезка.");
    }
}
else
{
    Console.WriteLine("Неверный индекс начального отрезка.");
}

Console.ReadKey();