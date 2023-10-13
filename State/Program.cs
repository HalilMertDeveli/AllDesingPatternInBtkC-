using System;
namespace State
{
    public class Program
    {
        public static void Main()
        {
            Context context = new Context();

            ModifiedState modifiedState = new ModifiedState();
            modifiedState.DoAction(context);

            DeletedState deletedState = new DeletedState();
            deletedState.DoAction(context);

            AddedState addedState = new AddedState();
            addedState.DoAction(context);

            Console.WriteLine(context.GetState().ToString()) ;

            Console.ReadLine();
        }
    }
    interface IState
    {
        void DoAction(Context context);
    }
    class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }
        public IState GetState()
        {
            return _state;
        }
    }
    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("System : Modified!");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Modified state override";
        }
    }
    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Sysem : Deleted !");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted state override";
        }
    }
    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("System : Added");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added state override";
        }
    }



}