using Avro.IO;
using Avro.Specific;

internal class AvroSerializer : PayloadBinarySerializer
{
    private readonly Avro.Schema _schema;
    public AvroSerializer(Avro.Schema schema) => _schema = schema;

    public override T FromBytes<T>(byte[] bytes)
    {
        using MemoryStream mem = new(bytes);
        BinaryDecoder decoder = new(mem);
        SpecificDefaultReader reader = new(_schema, _schema);
        return reader.Read<T>(default!, decoder);
    }

    public override byte[] ToBytes<T>(T payload)
    {
        using MemoryStream ms = new();
        SpecificDefaultWriter writer = new(_schema);
        writer.Write(payload, new BinaryEncoder(ms));
        return ms.ToArray();
    }
}
