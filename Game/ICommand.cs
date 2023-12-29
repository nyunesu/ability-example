using Cysharp.Threading.Tasks;

interface ICommand
{
    UniTask Execute();
}