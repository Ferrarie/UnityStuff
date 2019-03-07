# UnityStuff
Script tools collect from internet
从网上收集的代码工具

# 1. 2D Bird Fly Path
//2D模拟鸟类飞行路径

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
Here is points with " FlyPath(50, start, end); "
![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/BirdFlyPath.png)

# 2. Debuge UI Line
//在编辑器模式下，显示所有(包括图片隐藏和组建未激活)的UI外框。有效防止傻逼美工或者场景设计师把图片隐藏，造成不必要的性能消耗

Game View:

![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/DebugUILine_GameView.png)


Scene View:

![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/DebugUILine_SceneView.png)


# 3. Get Inspector Rotation value

//获取Inspector上显示Rotaion的值

![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/GetInspectorRotation.png)

# 4. MyDebug
//基于OnGUI()，把Debug的信息输出到屏幕上

![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/MyDebug.png)

# 5. SmoothFPS
//Copy From Unity Offical Visual Effect Graph Samples
//Show Smooth FPS
//[image](null)

# 6. UDP Receive Base on Socket Class
//简单的开启线程，绑定ipv4和端口，接收UDP信息

# 7. Anti Roguish Windows
//防止广告弹窗突然挡住程序,using user32.dll which can find in C:\Windows\System32

//Problem unsolve: Can't hide Windows Taskbar(任务栏) when press Alt+Tab.

