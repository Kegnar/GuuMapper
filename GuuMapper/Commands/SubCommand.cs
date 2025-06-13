namespace GuuMapper.Commands;

public class SubCommand(string procedureName) : ICommand
{
    public string ProcedureName { get; init; } = procedureName;

    public void Execute()
    {
        // TODO: реализовать функционал команды
    }
}