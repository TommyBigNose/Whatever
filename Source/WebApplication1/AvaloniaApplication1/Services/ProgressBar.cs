namespace AvaloniaApplication1.Services;

public interface IProgressBar
{
    void Increment(float increment = 1.0f);
    float GetValue();
}

public class ProgressBar : IProgressBar
{
    private float _value;
    private float _minValue;
    private float _maxValue;
    
    public ProgressBar()
    {
        _value = 0.0f;
        _maxValue = 100.0f;
        _minValue = 0.0f;
    }
    
    public void Increment(float increment = 1.0f)
    {
        if ((_value + increment) >= _maxValue)
        {
            _value = _minValue;
        }
        else
        {
            _value += increment;
        }
    }

    public float GetValue()
    {
        return _value;
    }
}