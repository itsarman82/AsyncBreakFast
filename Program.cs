class Things
{
    public class Bacon { }

    public class Coffee { }

    public class Eggs { }

    public class Juice { }

    public class Toast { }
}


class Program
{
    static async Task Main(string[] args)
    {

        var cup = readyCoffee();
        Console.WriteLine("Coffee is ready!");

        var eggsTask = FryEggsAsync(2);
        var baconTask = FryBaconAsync(3);
        var toastTask = MakeToastWithButterAndJamAsync(2);

        var breakfastTask = new List<Task> { eggsTask, baconTask, toastTask };
        while (breakfastTask.Count > 0)
        {
            Task finishedTask = await Task.WhenAny(breakfastTask);
            if (finishedTask == eggsTask)
            {
                Console.WriteLine("Eggs are ready!");
            }
            else if (finishedTask == baconTask)
            {
                Console.WriteLine("Bacon is ready!");

            }
            else if (finishedTask == toastTask)
            {
                Console.WriteLine("Toast is ready!");
            }
            breakfastTask.Remove(finishedTask);
        }

        var juice = readyJuice();
        Console.WriteLine("Juice is ready!");
        Console.WriteLine("breakfast is ready!");
    }

    private static Things.Juice readyJuice()
    {
        Console.WriteLine("Pouring orange juice...");
        return new Things.Juice();
    }

    private static async Task<Things.Toast> MakeToastWithButterAndJamAsync(int number)
    {
        var toast = await ToastBreadAsync(number);
        applyButterAndJam(toast);

        return toast;
    }

    private static void applyButterAndJam(Things.Toast toast) =>
        Console.WriteLine("Putting butter and jam on toast");

    private static async Task<Things.Toast> ToastBreadAsync(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("putting a slice of bread in the toaster...");
        }
        Console.WriteLine("start toasting...");
        await Task.Delay(3000);
        Console.WriteLine("Remove toast from toaster");

        return new Things.Toast();
    }

    private static async Task<Things.Bacon> FryBaconAsync(int slices)
    {
        Console.WriteLine("Cooking first side of bacon... ");
        await Task.Delay(3000);

        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("flipping a slice of bacon ");
        }

        Console.WriteLine("Cooking second side of bacon... ");
        await Task.Delay(3000);
        Console.WriteLine("Put bacon on plate ");

        return new Things.Bacon();
    }

    private static async Task<Things.Eggs> FryEggsAsync(int howMany)
    {
        Console.WriteLine("Warming the egg pan...");
        await Task.Delay(3000);

        return new Things.Eggs();
    }

    private static Things.Coffee readyCoffee()
    {
        Console.WriteLine("Pouring coffee... ");
        return new Things.Coffee();
    }
}