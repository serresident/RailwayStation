

namespace RailwayStation.Model
{
    public record Station(string Name, double X, double Y);

    public record Segment(int Id, Station StartStation, Station EndStation);

    public record Path(string Name, List<Segment> Segments);

    public record Park(string Name, List<Path> Paths);
    public class Schem  
    {
        public Schem()
        {

            // Точки

            for (int i = 1; i < 9; i++)
            {

                double x = (double)new Random().Next(1, 100);
                double y = (double)new Random().Next(1, 5);
                schem.AddPoint(new Station((char)(64 + i) + "", x, y));
            }

            // Отрезки
            schem.AddSegment(new Segment(1, schem.Stations[0], schem.Stations[1]));  // 0
            schem.AddSegment(new Segment(2, schem.Stations[1], schem.Stations[2]));  // 1
            schem.AddSegment(new Segment(3, schem.Stations[2], schem.Stations[3]));  // 2
            schem.AddSegment(new Segment(4, schem.Stations[3], schem.Stations[0]));  // 3
            schem.AddSegment(new Segment(5, schem.Stations[4], schem.Stations[5]));  // 4
            schem.AddSegment(new Segment(6, schem.Stations[5], schem.Stations[6]));  // 5
            schem.AddSegment(new Segment(7, schem.Stations[6], schem.Stations[7]));  // 6

            // Пути
            schem.AddPath(new Path("Путь А", new List<Segment> { schem.Segments[0], schem.Segments[1] }));  // 0
            schem.AddPath(new Path("Путь Б", new List<Segment> { schem.Segments[2], schem.Segments[3] }));  // 1
            schem.AddPath(new Path("Путь В", new List<Segment> { schem.Segments[4], schem.Segments[5], schem.Segments[6] }));  // 2

            // Парки
            schem.AddPark(new Park("Парк 1", new List<Path> { schem.Paths[0], schem.Paths[1] }));  // 0
            schem.AddPark(new Park("Парк 2", new List<Path> { schem.Paths[2] }));  // 1

        }

        public List<Station> Stations { get; } = new();
        public List<Segment> Segments { get; } = new();
        public List<Path> Paths { get; } = new();
        public List<Park> Parks { get; } = new();

        public void AddPoint(Station station) => Stations.Add(station);

        public void AddSegment(Segment segment) => Segments.Add(segment);

        public void AddPath(Path path) => Paths.Add(path);

        public void AddPark(Park park) => Parks.Add(park);

    }
}
