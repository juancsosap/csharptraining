namespace Game.Communications
{
    interface IObserver
    {
        void update(ICommand command);
    }
}
