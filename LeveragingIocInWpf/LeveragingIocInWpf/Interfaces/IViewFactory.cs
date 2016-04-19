namespace LeveragingIocInWpf.Interfaces
{
    public interface IViewFactory
    {
        IView GetView(string viewName);
    }
}