namespace Dealership.Data.Interfaces
{
    public interface IPictureService<T>
    {
        public T ConvertPicture(byte[] picture); 
    }
}
