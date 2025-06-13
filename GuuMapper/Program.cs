
using GuuMapper;

var code = "sub main\n  set a 1\n\n\ncall foo\nprint a\n\nsub foo\nset a 2";
var mapper = Mapper.MapperInit(code);
#if DEBUG
Console.WriteLine(code);
Console.WriteLine("---");
foreach (var line in code.ParseCommands())
{
    Console.WriteLine(line);
}
#endif
