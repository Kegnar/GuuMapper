namespace GuuMapper;

public static class Extensions
{
    /// <summary>
    /// Метод, формирующий список строк, очищенный от лишних пробелов и подготовленный к созданию очереди команд ICommand
    /// </summary>
    /// <param name="input"> Принимает строку - текст программы на Guu</param>
    /// <returns> List string </returns>
    /// <exception cref="ArgumentNullException"> если текст пустой</exception>
    public static List<string> ParseCommands(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException($"{nameof(input)} Не может быть null");
        }

        var result = new List<string>();
        string[] commandStrings = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        foreach (string commandString in commandStrings)
        {
            result.Add(commandString.Trim());
        }

        return result;
    }
}