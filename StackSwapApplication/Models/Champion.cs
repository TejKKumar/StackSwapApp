using StackSwapApplication.Models.BaseEntities;

namespace StackSwapApplication.Models;

public class Champion : BaseCharacter
{
    public uint GetID => base.Id;
}
