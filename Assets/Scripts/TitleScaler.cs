using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom;
using SonicBloom.Koreo;

public class TitleScaler : MonoBehaviour
{
    [EventID]
    public string eventID;

    public float minScale;
    public float maxScale;

    void Start()
    {
        //���UKoreography�ƥ�C
        Koreographer.Instance.RegisterForEventsWithTime(eventID, AdjustScale);
    }
    void OnDestroy()
    {
        //���ɭ�Koreographer Instance�|���e�M�z�C
        if (Koreographer.Instance != null)
        {
            //�����Ҧ����U���ƥ�
            Koreographer.Instance.UnregisterForAllEvents(this);
        }
    }
    void AdjustScale(KoreographyEvent evt, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        if (evt.HasCurvePayload())//�p�G�ƾڬOSonicBloom.Koreo.CurvePayload����
        {
            //�����e���W��m�����u�ȡC �o�N�O�@��[0, 1] �������ȡA�N�b�U���Ω󴡭�

            float curveValue = evt.GetValueOfCurveAtTime(sampleTime);

            transform.localScale = Vector2.one * Mathf.Lerp(minScale, maxScale, curveValue);
        }
    }
}
