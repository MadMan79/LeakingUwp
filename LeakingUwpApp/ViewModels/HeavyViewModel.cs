using System;
using System.Windows.Input;

namespace LeakingUwpApp.ViewModels
{
    public sealed class HeavyViewModel
    {
        private readonly byte[] m_heavyPayload = new byte[1024 * 1024 * 10];

        public HeavyViewModel()
        {
            LeakingCommand = new DelegateCommand(Leak);
        }

        public ICommand LeakingCommand { get; }

        public void Leak()
        {
            // ICommand is hold by XAML, it holds Action, Action holds SecondaryPageViewModel
        }
    }

    public sealed class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action m_action;

        public DelegateCommand(Action action)
        {
            m_action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_action();
        }
    }
}
