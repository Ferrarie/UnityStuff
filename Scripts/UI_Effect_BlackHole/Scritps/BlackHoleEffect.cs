//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackHoleEffect : BaseMeshEffect
{
    [Header("UI mesh")]
    [SerializeField]
    private Mesh mesh = null;

    [Header("黑洞参数")]
    [SerializeField]
    private Transform trans_BlackHole = null;
    /// <summary>
    /// 黑洞半径
    /// </summary>
    [SerializeField]
    [Range(0f, 3840f)]
    private float radius_BlackHole = 100f;

    /// <summary>
    /// 吸附强度
    /// </summary>
    [SerializeField]
    [Range(0.5f, 200f)]
    private float power_BlackHole = 1.5f;
    [SerializeField]
    private bool 是否显示黑洞边缘 = true;
    [SerializeField]
    private float dis;
    private Vector3 _BlackHolePos;

    private RectTransform rectTrans = null;

    //VertexHelper
    private List<UIVertex> vertexs;
    private List<Vector3> vertexs_worldPos;
    private List<int> indices;
    private Color32 color32_White;
    private UIVertex uIVertex;

    //mesh
    private List<Vector2> uv;
    private List<Vector3> vec3;

    protected override void OnEnable()
    {
        rectTrans = GetComponent<RectTransform>();

        vertexs = new List<UIVertex>();
        vertexs_worldPos = new List<Vector3>();
        indices = new List<int>();
        color32_White = new Color32(255, 255, 255, 255);

        uv = new List<Vector2>();
        vec3 = new List<Vector3>();
    }

    private void Update()
    {
        graphic.SetVerticesDirty();
    }


    public override void ModifyMesh(UnityEngine.UI.VertexHelper vh)
    {
        if (!IsActive())
        {
            return;
        }

        vh.Clear();
        vertexs.Clear();
        vertexs_worldPos.Clear();
        indices.Clear();
        uv.Clear();
        vec3.Clear();


        //显示
        mesh.GetVertices(vec3);
        mesh.GetIndices(indices, 0);
        mesh.GetUVs(0, uv);
        for (int i = 0; i < vec3.Count; i++)
        {
            uIVertex = new UIVertex();
            uIVertex.position = new Vector3(vec3[i].x * rectTrans.rect.width * 0.05f, vec3[i].y * rectTrans.rect.height * 0.05f, vec3[i].z);
            uIVertex.uv0 = uv[i];
            uIVertex.color = color32_White;
            vertexs.Add(uIVertex);

            vertexs_worldPos.Add(transform.TransformPoint(uIVertex.position));
        }
        vh.AddUIVertexStream(vertexs, indices);


        //变形 worldPosition
        if (trans_BlackHole != null)
        {
            _BlackHolePos = trans_BlackHole.position;

            for (int i = 0; i < vertexs.Count; i++)
            {
                var vertex = vertexs[i];

                dis = Vector3.Distance(vertexs_worldPos[i], _BlackHolePos);

                if (dis < radius_BlackHole)
                {
                    Vector3 worldPos_Translated = Vector3.Lerp(vertexs_worldPos[i], _BlackHolePos, Mathf.Clamp01((radius_BlackHole - dis) * power_BlackHole / radius_BlackHole));

                    vertex.position = transform.InverseTransformPoint(worldPos_Translated);
                }
                vh.SetUIVertex(vertex, i);
            }
        }

        ////变形 localPosition
        //if (trans != null)
        //{
        //    _BlackHolePos = trans.localPosition;
        //    for (int i = 0; i < vh.currentVertCount; i++)
        //    {
        //        var vertex = vertexs[i];
        //        dis = Vector3.Distance(vertex.position, _BlackHolePos);
        //        if (dis < radius)
        //        {
        //            vertex.position = Vector3.Lerp(vertex.position, _BlackHolePos, Mathf.Clamp01((radius - dis) * power / radius));
        //        }

        //        vh.SetUIVertex(vertex, i);
        //    }
        //};
    }

    private void OnDrawGizmos()
    {
        if (是否显示黑洞边缘)
        {
            if (trans_BlackHole != null)
            {
                Gizmos.DrawWireSphere(trans_BlackHole.position, radius_BlackHole);
            }
        }


        //for (int i = 0; i < vertexs_worldPos.Count; i++)
        //{
        //    Gizmos.DrawLine(vertexs_worldPos[i] + (Vector3.one* offset), vertexs_worldPos[ (i + 1)% vertexs_worldPos.Count]);
        //}
    }


}
