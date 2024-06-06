using RailwayStation.Model;
using System.Linq;

namespace RailwayStation.Model
{
    public class SchemHelper
    {
        public static List<Station> FillPark(Park park)
           => park.Paths.SelectMany(path => path.Segments.SelectMany(segment => new[] { segment.StartStation, segment.EndStation })).ToList();

        public static List<int> FindShortestPath(Schem schem, int startSegmentIndex, int endSegmentIndex)
        {
            if (startSegmentIndex == endSegmentIndex)
            {
                return new List<int> { startSegmentIndex };
            }

            var distances = Enumerable.Repeat(int.MaxValue, schem.Segments.Count).ToList();
            distances[startSegmentIndex] = 0;

            var visited = new HashSet<int>();
            var queue = new PriorityQueue<int, int>();
            queue.Enqueue(startSegmentIndex, 0);

            var predecessors = new Dictionary<int, int>();

            while (queue.Count > 0)
            {
                var currentSegmentIndex = queue.Dequeue();

                if (visited.Contains(currentSegmentIndex))
                {
                    continue;
                }

                visited.Add(currentSegmentIndex);

                if (currentSegmentIndex == endSegmentIndex)
                {
                    var path = new List<int>();
                    while (currentSegmentIndex != startSegmentIndex)
                    {
                        path.Add(currentSegmentIndex);
                        currentSegmentIndex = predecessors[currentSegmentIndex];
                    }

                    path.Add(startSegmentIndex);
                    path.Reverse();
                    return path;
                }

                for (int i = 0; i < schem.Segments.Count; i++)
                {
                    if (i != currentSegmentIndex && !visited.Contains(i))
                    {
                        var currentSegment = schem.Segments[currentSegmentIndex];
                        var otherSegment = schem.Segments[i];
                        if ((currentSegment.StartStation == otherSegment.EndStation || currentSegment.EndStation == otherSegment.StartStation) &&
                            distances[currentSegmentIndex] + 1 < distances[i])
                        {
                            distances[i] = distances[currentSegmentIndex] + 1;
                            queue.Enqueue(i, distances[i]);
                            predecessors[i] = currentSegmentIndex;
                        }
                    }
                }
            }

            return null;
        }
    }
}
