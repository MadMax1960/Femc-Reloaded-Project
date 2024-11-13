namespace P3R.CostumeFramework.Utils;

public static class ModUtils
{
    public static void IfNotNull<TInput>(TInput input, Action<TInput> action)
    {
        if (input != null)
        {
            action(input);
        }
    }
}
