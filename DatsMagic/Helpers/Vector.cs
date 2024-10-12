namespace DatsMagic.Helpers;

public class Vector<T>
{
    public T X { get; init; }
    public T Y { get; init; }

    public Vector(T x, T y)
    {
        X = x;
        Y = y;
    }

    public double Length => Math.Abs(Math.Sqrt(
        Convert.ToDouble(X) * Convert.ToDouble(X)
        + Convert.ToDouble(Y) * Convert.ToDouble(Y)));

    public double K(double maxAccel) => maxAccel / Length;

    public (double X, double Y) GetKVector(double maxAccel) =>
        (Convert.ToDouble(X) * K(maxAccel), Convert.ToDouble(Y) * K(maxAccel));
}
