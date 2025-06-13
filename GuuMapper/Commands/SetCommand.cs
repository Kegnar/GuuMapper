namespace GuuMapper.Commands;

public class SetCommand(string varName, int varValue) : ICommand
{
    public string Name { get; init; } = varName;
    public int Value { get; set; } = varValue;

    public void Execute()
    {
        //TODO: реализовать функционал
    }
}