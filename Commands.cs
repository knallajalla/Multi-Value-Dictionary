using System.Runtime.Serialization;

namespace Multi_Value_Dictionary
{
    public enum Commands
    {
        [EnumMember(Value = "ADD")]
        ADD,
        [EnumMember(Value = "KEYS")]
        KEYS,
        [EnumMember(Value = "MEMBERS")]
        MEMBERS,
        [EnumMember(Value = "REMOVE")]
        REMOVE,
        [EnumMember(Value = "REMOVEALL")]
        REMOVEALL,
        [EnumMember(Value = "CLEAR")]
        CLEAR,
        [EnumMember(Value = "KEYEXISTS")]
        KEYEXISTS,
        [EnumMember(Value = "VALUEEXISTS")]
        VALUEEXISTS,
        [EnumMember(Value = "ALLMEMBERS")]
        ALLMEMBERS,
        [EnumMember(Value = "ITEMS")]
        ITEMS,
        [EnumMember(Value = "ALL ITEMS")]
        ALL ITEMS
    }
}
