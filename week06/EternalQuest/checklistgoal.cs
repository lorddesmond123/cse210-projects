public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int target,
        int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int amountCompleted,
        int target,
        int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox;

        if (IsComplete())
        {
            checkbox = "[X]";
        }
        else
        {
            checkbox = "[ ]";
        }

        return $"{checkbox} {GetName()} ({GetDescription()}) " +
               $"-- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_amountCompleted}|{_target}|{_bonus}";
    }
}