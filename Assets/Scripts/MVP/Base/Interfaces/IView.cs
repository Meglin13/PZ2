namespace MVP.Base.Interfaces
{
    public interface IView
    {
        public void OnInit(IPresenter presenter);

        public void UpdateView();
    }
}