using DataAccess.Models;

namespace WebAPI.Helpers
{
    public static class MockData
    {
        static Random rnd = new Random();
        public static Track GetTrack()
        {
            return new Track
            {
                Id = rnd.Next(100),
                Name = "Blue Sky",
                Rating = 8.5F,
                Duration = new TimeSpan(0, 3, 45)
            };
        }
        public static IEnumerable<Track> GetTrackList(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Track
                {
                    Id = rnd.Next(100),
                    Name = "Blue Sky",
                    Rating = 8.5F,
                    Duration = new TimeSpan(0, 2, 10)
                };
            }

            //List<Track> list = new List<Track>(count);

            //for (int i = 0; i < count; i++)
            //{
            //    list.Add(new Track
            //    {
            //        Id = rnd.Next(100),
            //        Name = "Blue Sky",
            //        Rating = 8.5F,
            //        Duration = "2:35"
            //    });
            //}
            //return list;
        }
    }
}
