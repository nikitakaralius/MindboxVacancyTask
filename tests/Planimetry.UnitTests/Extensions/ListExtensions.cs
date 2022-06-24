namespace Planimetry.UnitTests.Extensions;

public static class ListExtensions
{
    public static IReadOnlyList<T> Shuffled<T>(this IReadOnlyList<T> list)
    {
        List<T> shuffledList = new(list);
        Random random = new();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int index = random.Next(i + 1);
            (shuffledList[index], shuffledList[i]) = (shuffledList[i], shuffledList[index]);
        }
        return shuffledList;
    }
}