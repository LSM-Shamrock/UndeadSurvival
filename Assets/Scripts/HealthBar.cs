using UnityEngine;

public class HealthBar : WorldSpaceUI
{
    [SerializeField]
    private RectTransform _fill;

    private Vector3 _offsetVector =  Vector3.up * 2f;
    private Transform _targetTransform;
    private IDamageable _targetDamageable;

    protected override void Update()
    {
        base.Update();

        transform.position = _targetTransform.position + _offsetVector;

        float fillValue;
        if (_targetDamageable.MaxHealth == 0)
            fillValue = 0;
        else
            fillValue = (float)_targetDamageable.CurHealth / _targetDamageable.MaxHealth;
        
        Vector3 scaleVec = Vector3.one;
        scaleVec.x = fillValue;
        _fill.localScale = scaleVec;
    }

    public void Init(IDamageable targetDamageable, Transform targetTransform)
    {
        _targetDamageable = targetDamageable;
        _targetTransform = targetTransform;
    }
}
