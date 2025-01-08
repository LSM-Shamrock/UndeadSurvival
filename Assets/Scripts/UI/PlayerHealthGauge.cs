using UnityEngine;

public class PlayerHealthGauge : WorldSpaceUI
{
    [SerializeField]
    private RectTransform gaugeFill;

    private Player player;
    private Vector3 offsetVector =  Vector3.up * 2f;

    protected override void Awake()
    {
        base.Awake();
        player = GameManager.Player;
    }

    protected override void Update()
    {
        base.Update();
        transform.position = player.transform.position + offsetVector;
        SetFillValue((float)player.Health / player.Stat.maxHealth);
    }

    private void SetFillValue(float value)
    {
        Vector3 _scaleVec = Vector3.one;
        _scaleVec.x = value;
        gaugeFill.localScale = _scaleVec;
    }
}
