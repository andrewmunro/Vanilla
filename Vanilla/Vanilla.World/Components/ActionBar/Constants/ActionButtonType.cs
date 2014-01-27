namespace Vanilla.World.Components.ActionBar.Constants
{
    public enum ActionButtonType
    {
        ACTION_BUTTON_SPELL = 0x00,
        ACTION_BUTTON_C = 0x01,                     // click?
        ACTION_BUTTON_MACRO = 0x40,
        ACTION_BUTTON_CMACRO = ACTION_BUTTON_C | ACTION_BUTTON_MACRO,
        ACTION_BUTTON_ITEM = 0x80
    };
}
