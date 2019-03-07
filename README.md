# UnityStuff
Script tools collect from internet

#1. 2D Bird Fly Path
//2D模拟鸟类飞行，不考虑扑扇事件

    Vector3[] FlyPath(int length, Vector3 start, Vector3 end)
    {
        Vector3[] vector3s = new Vector3[length];
        float dis = Vector3.Distance(start, end);
        float step = dis / (length + 1);//每步的长度

        for (int i = 0; i < vector3s.Length; i++)
        {
            if (i % 3 == 0)
            {
                vector3s[i] = Vector3.Lerp(start, end, (step * (i + 1)) / dis);
                vector3s[i].y += Random.Range(0.5f, 0.8f);
            }
            else
            {
                vector3s[i] = Vector3.Lerp(start, end, (step * (i + 1)) / dis);
            }
        }
        return vector3s;
    }
