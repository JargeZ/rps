public class SelectedPlayerInfo
{
    public string SelectedPlayerName;
    public string SelectedCharSkin;
}

public static class GlobalState
{
    public static SelectedPlayerInfo LeftPlayerInfo = new SelectedPlayerInfo();
    public static SelectedPlayerInfo RightPlayerInfo = new SelectedPlayerInfo();
    public static PlayerState? winner = null;
}


public enum PlayerSide
{
    Left,
    Right
}
