using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";

        return $"{status} {base.GetDetailsString()}";
    }


    public override string GetSaveString()
    {
        return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }

    public void SetComplete(bool complete)
    {
        _isComplete = complete;
    }
}