
public class FloatNumber
{
    float min;
    float max;
    float value;

    public FloatNumber(float minValue, float maxValue, float initialValue = 0)
    {
        min = minValue;
        max = maxValue;
        value = initialValue;
    }

    public void SetValue(float number)
    {
        value = number;
        PreventValueOutOfBounds();
    }

    public float GetValue()
    {
        return value;
    }

    public FloatNumber Add(FloatNumber number)
    {
        return Add(number.GetValue());
    }

    public FloatNumber Add(float number)
    {
        value += number;
        PreventValueOutOfBounds();

        return this;
    }

    public FloatNumber Subtract(FloatNumber number)
    {
        return Subtract(number.GetValue());
    }

    public FloatNumber Subtract(float number)
    {
        value -= number;

        PreventValueOutOfBounds();

        return this;
    }

    public FloatNumber Multiply(float number)
    {
        value *= number;

        PreventValueOutOfBounds();

        return this;
    }

    private void PreventValueOutOfBounds()
    {
        if (value < min)
            value = min;

        if (value > max)
            value = max;
    }

    public override string ToString()
    {
        return string.Format("(FloatNumber) {{ value : {0}, min : {1}, max : {2}  }}", value, min, max);
    }
}