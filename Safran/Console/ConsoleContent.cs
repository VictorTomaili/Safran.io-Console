using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SafranConsole.Console
{
    public partial class ConsoleContent : INotifyPropertyChanged
    {
        public ConsoleContent(TextBox inpuTextBox, ScrollViewer scrollViewer)
        {
            var commands =
                Application.ResourceAssembly.GetTypes()
                    .Where(s => s.BaseType == typeof (ConsoleCommand))
                    .OrderBy(s => s.Name);

            foreach (var command in commands)
            {
                this.RegisterCommand((ConsoleCommand)Activator.CreateInstance(command, new object[] { }));
            }

            this.InputBlock = inpuTextBox;
            this.Scroller = scrollViewer;

            InputBlock.KeyDown += InputBlock_KeyDown;
            InputBlock.Focus();
        }

        string consoleInput = string.Empty;
        ObservableCollection<string> consoleOutput = new ObservableCollection<string>();
        public string ConsoleInput
        {
            get
            {
                return consoleInput;
            }
            set
            {
                consoleInput = value.ToLowerInvariant();
                OnPropertyChanged("ConsoleInput");
            }
        }

        public ObservableCollection<string> ConsoleOutput
        {
            get
            {
                return consoleOutput;
            }
            set
            {
                consoleOutput = value;
                OnPropertyChanged("ConsoleOutput");
            }
        }

        public TextBox InputBlock { get; set; }
        public ScrollViewer Scroller { get; set; }

        public void RunCommand()
        {
            if (string.IsNullOrWhiteSpace(ConsoleInput))
            {
                consoleInput = string.Empty;
                return;
            }

            ConsoleOutput.Add(ConsoleInput);
            OnCommandReceived(ConsoleInput);
        }

        public void RegisterCommand(ConsoleCommand consoleCommand)
        {
            if (CommandList.ContainsKey(consoleCommand.Command))
                throw new InvalidOperationException(string.Format("Command Already Registered : {0} ",
                    consoleCommand.Command));

            consoleCommand.Console = this;
            CommandList.Add(consoleCommand.Command, consoleCommand);   
        }

        public Dictionary<string, ConsoleCommand> CommandList = new Dictionary<string, ConsoleCommand>(); 
    }
}