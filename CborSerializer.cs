

using Dahomey.Cbor;
using Dahomey.Cbor.Util;

namespace Payloads;

internal class CborSerializer : PayloadBinarySerializer
{
    public override T FromBytes<T>(byte[] bytes) => Cbor.Deserialize<T>(bytes);

    public override byte[] ToBytes<T>(T payload)
    {
        ByteBufferWriter buffer = new ByteBufferWriter();
        Cbor.Serialize<T>(payload, buffer);
        return buffer.WrittenSpan.ToArray();
    }
}
