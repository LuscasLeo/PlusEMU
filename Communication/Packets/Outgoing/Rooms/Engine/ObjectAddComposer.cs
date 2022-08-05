﻿using Plus.HabboHotel.GameClients;
using Plus.HabboHotel.Items;
using Plus.Utilities;

namespace Plus.Communication.Packets.Outgoing.Rooms.Engine;

public class ObjectAddComposer : IServerPacket
{
    private readonly Item _item;
    public uint MessageId => ServerPacketHeader.ObjectAddComposer;

    public ObjectAddComposer(Item item)
    {
        _item = item;
    }

    public void Compose(IOutgoingPacket packet)
    {
        packet.WriteUInteger(_item.Id);
        packet.WriteInteger(_item.Definition.SpriteId);
        packet.WriteInteger(_item.GetX);
        packet.WriteInteger(_item.GetY);
        packet.WriteInteger(_item.Rotation);
        packet.WriteString(TextHandling.GetString(_item.GetZ));
        packet.WriteString(string.Empty);
        if (_item.UniqueNumber > 0)
        {
            packet.WriteInteger(1);
            packet.WriteInteger(256);
            packet.WriteString(_item.LegacyDataString);
            packet.WriteUInteger(_item.UniqueNumber);
            packet.WriteUInteger(_item.UniqueSeries);
        }
        else
            ItemBehaviourUtility.GenerateExtradata(_item, packet);
        packet.WriteInteger(-1); // to-do: check
        packet.WriteInteger(_item.Definition.Modes > 1 ? 1 : 0);
        packet.WriteInteger(_item.UserId);
        packet.WriteString(_item.Username);

    }
}
