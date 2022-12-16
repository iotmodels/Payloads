using MessagePack;


namespace Payloads.MsgPack;

[MessagePackObject]
public class Telemetries
{
    [Key(0)]
    public double WorkingSet { get; set; }
}
