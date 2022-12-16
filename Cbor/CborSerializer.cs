internal class CborSerializer : PayloadBinarySerializer
{
    public override T FromBytes<T>(byte[] bytes) => Dahomey.Cbor.Cbor.Deserialize<T>(bytes);

    public override byte[] ToBytes<T>(T payload)
    {
        Dahomey.Cbor.Util.ByteBufferWriter buffer = new();
        Dahomey.Cbor.Cbor.Serialize(payload, buffer);
        return buffer.WrittenSpan.ToArray();
    }
}
