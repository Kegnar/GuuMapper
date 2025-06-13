using System.ComponentModel;
using GuuMapper.Commands;

namespace GuuMapper;

public class Mapper
{
    private static Mapper _instance;

    public Queue<ICommand> Commands { get; private set; } = new Queue<ICommand>();

    private Mapper(string code)
    {
        EnqueueCommand(code.ParseCommands());  
    }

    public static Mapper MapperInit(string code)
    {
        if (_instance == null)
        {
            _instance = new Mapper(code);
        }

        return _instance;
    }
// Метод, собирающий очередь комманд
    void EnqueueCommand(List<string> stringQueue)
    {
        foreach (var item in stringQueue)
        {
            if (item.StartsWith("sub "))
            {
                Commands.Enqueue(new SubCommand(item.Replace("sub ", "")));
            }

            if (item.StartsWith("set "))
            {
                var tmp = item.Replace("set ", "");
                var varName = tmp.Split(' ')[0];
                var varValue = int.TryParse(tmp.Split(' ')[1], out var varInt);
                if (varValue == false)
                {
                    throw new InvalidEnumArgumentException("Неверно задано значение переменной");
                }

                Commands.Enqueue(new SetCommand(varName, varInt));
            }

            if (item.StartsWith("call "))
            {
                var tmp = item.Replace("call ", "");
                Commands.Enqueue(new CallCommand(tmp));
            }

            if (item.StartsWith("print "))
            {
                var tmp = item.Replace("print ", "");
                Commands.Enqueue(new PrintCommand(tmp));
            }
        }
    }

    public void Run()
    {
        while (Commands.Count > 0)
        {
            var currentCommand = Commands.Dequeue();
            currentCommand.Execute();
        }
    }
}