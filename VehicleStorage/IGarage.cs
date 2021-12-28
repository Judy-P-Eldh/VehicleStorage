namespace VehicleStorage
{
    public interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
        int Size { get; }

        void ExamineGarage();
        bool ParkVehicles(T vehicle);
        bool UnparkVehicles(T vehicle);
    }
}