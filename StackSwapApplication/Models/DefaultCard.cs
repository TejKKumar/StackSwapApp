using StackSwapApplication.Models.BaseEntities;

namespace StackSwapApplication.Models;

public class DefaultCard : BaseCard
{

    public Champion champion { get; set; }
    public uint ChampId => champion.GetID;
    public uint GetId => base.GetID;

}
