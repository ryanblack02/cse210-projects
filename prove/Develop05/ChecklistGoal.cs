using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
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
        string status = IsComplete() ? "[X]" : "[ ]";

        return $"{status} {base.GetDetailsString()} -- Completed {_amountCompleted}/{_target} times";
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }


    public override string GetSaveString()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_amountCompleted}|{_target}|{_bonus}";
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
}