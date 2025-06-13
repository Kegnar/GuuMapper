namespace GuuMapper.Commands;

public class CallCommand(string procedureName) : ICommand
{
    public string ProcedureName { get; init; } = procedureName;

    public void Execute()
    {
        //TODO: реализовать функционал
    }
}