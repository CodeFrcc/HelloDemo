// HelloDemo - 一个 C# 控制台小 Demo：彩色输出 + 猜数字小游戏
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

PrintBanner();
RunGuessGame();
PrintFooter();

static void PrintBanner()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔══════════════════════════════════╗");
    Console.WriteLine("║      C# Demo · 猜数字小游戏       ║");
    Console.WriteLine("║   运行在 .NET 10 · by Kimi        ║");
    Console.WriteLine("╚══════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();
}

static void RunGuessGame()
{
    var secret = Random.Shared.Next(1, 101);
    var attempts = 0;
    const int maxAttempts = 7;

    Console.WriteLine("我想好了一个 1 ~ 100 之间的数字，你有 7 次机会猜中它。\n");

    while (attempts < maxAttempts)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"第 {attempts + 1} 次，请输入你的猜测: ");
        Console.ResetColor();

        var input = Console.ReadLine();
        if (input is null) // 输入流结束，直接退出
        {
            Console.WriteLine($"\n（输入结束）答案是 {secret}，欢迎下次再玩！");
            return;
        }
        if (!int.TryParse(input, out var guess) || guess < 1 || guess > 100)
        {
            Console.WriteLine("请输入 1 ~ 100 的整数哦。\n");
            continue;
        }

        attempts++;

        if (guess == secret)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n🎉 恭喜！{attempts} 次就猜中了，答案就是 {secret}！");
            Console.ResetColor();
            return;
        }

        Console.WriteLine(guess < secret ? "太小了，往大猜~\n" : "太大了，往小猜~\n");
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n机会用完啦，答案是 {secret}。下次一定行！");
    Console.ResetColor();
}

static void PrintFooter()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"运行时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss} · .NET {Environment.Version}");
    Console.ResetColor();
}
