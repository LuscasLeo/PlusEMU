using Plus.HabboHotel.GameClients;

namespace Plus.Communication.Packets.Incoming.Crafting;

internal class GetCraftingRecipeEvent : IPacketEvent
{
    public Task Parse(GameClient session, IIncomingPacket packet) => throw new NotImplementedException();
}
