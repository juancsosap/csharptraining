namespace Game.Communications
{
    interface ISubject
    {
        void register(IObserver ob);
        void unregister(IObserver ob);
        void notifyOne(IObserver ob, ICommand command);
        void notifyAll(ICommand command);

        void update(IObserver ob, IInformation info);
    }
}
