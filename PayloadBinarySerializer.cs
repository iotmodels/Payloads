
public abstract class PayloadBinarySerializer
{
    public abstract byte[] ToBytes<T>(T payload);
    public abstract T FromBytes<T>(byte[] bytes);
}