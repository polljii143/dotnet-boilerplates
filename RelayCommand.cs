
/// <summary>
/// Implements the ICommand interface to provide a reusable command that can be bound to UI elements in WPF.
/// </summary>
/// <remarks>
/// This class is a key component of the MVVM pattern, allowing view models to expose commands that UI elements 
/// can bind to. It eliminates the need to create custom command classes for each command action in the application.
/// Uses C# 12.0 primary constructor syntax for concise implementation.
/// </remarks>
/// <param name="execute">The action to execute when the command is invoked.</param>
/// <param name="canExecute">Optional predicate that determines whether the command can be executed. 
/// If null, the command is always enabled.</param>
public class RelayCommand(
    Action<object> execute,
    Func<object, bool> canExecute = null!)
    : ICommand
{
    /// <summary>
    /// Event that is raised when the ability to execute the command changes.
    /// </summary>
    /// <remarks>
    /// This implementation leverages the CommandManager.RequerySuggested event to handle automatic command state updates.
    /// When the CommandManager detects a potential change in command state, it raises this event to trigger UI updates.
    /// </remarks>
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    /// <summary>
    /// Determines whether the command can be executed in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command. If the command does not require data, this parameter can be set to null.</param>
    /// <returns>true if this command can be executed; otherwise, false.</returns>
    public bool CanExecute(object? parameter)
    {
        return canExecute == null! || canExecute(parameter!);
    }

    /// <summary>
    /// Executes the command action.
    /// </summary>
    /// <param name="parameter">Data used by the command. If the command does not require data, this parameter can be set to null.</param>
    public void Execute(object? parameter)
    {
        execute(parameter!);
    }
}
