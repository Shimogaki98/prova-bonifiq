namespace ProvaPub.Services
{
    public class RandomService
    {
        // int seed;
        Random random = new Random();
        public RandomService()
        {
            // seed = Guid.NewGuid().GetHashCode();
        }
        public int GetRandom()
        {
            return random.Next(0, 100);
        }

    }
}
