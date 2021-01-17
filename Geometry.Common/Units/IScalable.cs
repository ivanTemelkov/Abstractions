namespace Geometry.Common.Units
{
    public interface IScalable<T>
    {
        T Scale(double factor);
    }
}