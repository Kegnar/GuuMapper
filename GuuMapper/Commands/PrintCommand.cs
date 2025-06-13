namespace GuuMapper.Commands;

public class PrintCommand(string value) : ICommand
{
    public string Value { get; init; } = value;

    public void Execute()
    {
        //TODO: реализовать функционал
    }
}