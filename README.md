# UnityStuff  
Script tools collect from internet  
从网上收集的代码工具  
Scripts are placed in Unity https://github.com/Ferrarie/UnityStuff/tree/master/Scripts  
源码全丢进Scripts文件夹里

# 1. 2D Bird Fly Path  
2D模拟鸟类飞行路径  

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
在编辑器模式下，显示所有(包括图片隐藏和组建未激活)的UI外框。有效防止傻逼美工或者场景设计师把图片隐藏，造成不必要的性能消耗  
refer to ("sorry,I forgot");  
Game View:  
![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/DebugUILine_GameView.png)  
Scene View:  
![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/DebugUILine_SceneView.png)  

# 3. Get Inspector Rotation value  
refer to https://blog.csdn.net/qq_34444468/article/details/83929841  
获取Inspector上显示Rotaion的值  
![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/GetInspectorRotation.png)

# 4. MyDebug
refer to https://blog.csdn.net/abcdtty/article/details/18862265  
基于OnGUI()，把Debug的信息输出到屏幕上  
![imge](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/MyDebug.png)

# 5. SmoothFPS
Copy From Unity Offical Visual Effect Graph Samples  
Show Smooth FPS  
no Image  

# 6. UDP Receive Base on Socket Class
简单的开启线程，绑定ipv4和端口，接收UDP信息  

# 7. Anti Roguish Windows
dll APi refer to http://www.webtropy.com/articles/art9-2.asp?lib=user32.dll  
&& http://www.pinvoke.net/  
防止广告弹窗突然挡住程序,using user32.dll which can find in C:\Windows\System32  
目前有两种方式：
(1)获取当前系统最前(焦点)的窗口句柄，设置该句柄为最前置顶；
这种方法有种弊端，在双击打开Unity程序时，这个时候由于unity程序需要加载初始化，还没这么快运行到窗口前置功能的部分，这个时候如果打开一个窗口例如,我的电脑，那么当unity程序运行到窗口前置时，获取系统当前焦点的窗口为“我的电脑”，而并非我们预想的Unity程序窗口，运行的结果就是，程序告诉系统，把“我的电脑”窗口最大化并且前置；这功能如果用在开机自动启动多个程序的时候就很尴尬，应该换第2个方法；
(2)通过设置窗口名称来获取句柄，设置该句柄为最前置顶；
这个运行起来不会出现(1)所描述的情况，但是需要在函数参数里指定好Product Name(也就是窗口标题)，这个在Unity Player Setting 中，Player->Product Name里可以设置。。。。有人问我为什么不实时获取Product Name，这样就不用指定参数了,emmmm我试过, UnityEditor.PlayerSettings.productName,这个只能在编辑器使用，不能打包出来。打包的时候会报错不能Using UnityEditor。
Problem unsolve: Can't hide Windows Taskbar(任务栏) when press Alt+Tab.  

# 8.Bezier
create Bezier in 2D or 3D  
refer to https://blog.csdn.net/w6316485/article/details/53215380?utm_source=blogxgwz0  
![image](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/Bezier_2Demension.gif)


