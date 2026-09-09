namespace NovaHarvest.Core.Player;

public enum PlayerDirection
{
    Down,
    Up,
    Left,
    Right
}

public enum PlayerAnimation
{
    Idle,
    Walk,
    Mining,
    Chopping,
    Planting,
    Watering,
    Interact,
    Pickup,
    Hurt,
    Death
}

public sealed class PlayerAnimationState
{
    public PlayerDirection Direction { get; private set; } =
        PlayerDirection.Down;

    public PlayerAnimation Animation { get; private set; } =
        PlayerAnimation.Idle;

    public bool IsMoving =>
        Animation == PlayerAnimation.Walk;

    public void SetDirection(
        PlayerDirection direction)
    {
        Direction = direction;
    }

    public void SetAnimation(
        PlayerAnimation animation)
    {
        Animation = animation;
    }

    public void SetMovement(
        int deltaX,
        int deltaY)
    {
        if (deltaX == 0 && deltaY == 0)
        {
            Animation = PlayerAnimation.Idle;
            return;
        }

        Animation = PlayerAnimation.Walk;

        if (Math.Abs(deltaX) > Math.Abs(deltaY))
        {
            Direction = deltaX > 0
                ? PlayerDirection.Right
                : PlayerDirection.Left;
        }
        else
        {
            Direction = deltaY > 0
                ? PlayerDirection.Up
                : PlayerDirection.Down;
        }
    }
}