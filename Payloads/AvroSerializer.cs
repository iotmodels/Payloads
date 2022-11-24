using Avro.IO;
using Avro.Specific;
using Avro;

internal class AvroSerializer : PayloadBinarySerializer
{
    private readonly Avro.Schema _schema;
    public AvroSerializer(Avro.Schema schema) => _schema = schema;

    public override T FromBytes<T>(byte[] bytes)
    {
        using MemoryStream mem = new(bytes);
        BinaryDecoder decoder = new(mem);
        SpecificDefaultReader reader = new(_schema, _schema);
        T val = default!;
        reader.Read(val, decoder);
        return val;
    }

    public override byte[] ToBytes<T>(T payload)
    {
        using MemoryStream ms = new();
        BinaryEncoder encoder = new(ms);
        SpecificDefaultWriter writer = new(_schema);
        writer.Write(payload, encoder);
        ms.Position = 0;
        byte[] bytes = ms.ToArray();
        return bytes;
    }
}
