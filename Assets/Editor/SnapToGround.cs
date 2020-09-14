using UnityEngine;
using UnityEditor;
using ICSharpCode.NRefactory.Ast;

public class SnapToGround : MonoBehaviour
{
    [MenuItem("Custom Shortcuts/SnapToGround _END")]

    static void Ground()
    {
        float maxHeightFromGround = 50f;
        float maxHeightBelowGround = 10f;

        foreach (var transform in Selection.transforms)
        {
            //var pivotOffset = transform.localScale.y;
            //RaycastHit rayHit;
            ////var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, maxHeightFromGround);
            //var hitsDown = Physics.RaycastAll(transform.position + (Vector3.up * maxHeightBelowGround), Vector3.down, maxHeightFromGround + maxHeightBelowGround);
            //foreach (var hit in hitsDown)
            //{
            //    if (hit.collider.gameObject == transform.gameObject)
            //        continue;

            //    transform.position = hit.point + (Vector3.up *pivotOffset);
            //    break;
            //}

            var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 20f);
            foreach(var hit in hits)
            {
                if(hit.collider.gameObject != transform.gameObject)
                {
                    transform.position = hit.point + (transform.localScale.y * Vector3.up);
                    break;
                }
            }
        }
    }
}