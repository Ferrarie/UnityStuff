# UnityStuff  
Script tools collect from the internet  
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

# 6. UDP Receive Base on Socket Class,直接上Mirror插件
简单的开启线程，绑定ipv4和端口，接收UDP信息  
直接上Mirror插件:https://github.com/vis2k/Mirror

# 7. Anti Roguish Windows
The Plugins API refer to http://www.webtropy.com/articles/art9-2.asp?lib=user32.dll  
&& http://www.pinvoke.net/  
防止广告弹窗突然挡住程序, using user32.dll which can find in C:\Windows\System32  
目前有两种方式：
  (1)获取当前系统最前(焦点)的窗口句柄，设置该句柄为最前置顶；  
  
  这种方法有种弊端，在双击打开Unity程序时，这个时候由于unity程序需要加载初始化，还没这么快运行到窗口前置功能的部分，这个时候如果打开一个窗口例如,我的电脑，那么当unity程序运行到窗口前置时，获取系统当前焦点的窗口为“我的电脑”，而并非我们预想的Unity程序窗口，运行的结果就是，程序告诉系统，把“我的电脑”窗口最大化并且前置；这功能如果用在开机自动启动多个程序的时候就很尴尬，应该换第2个方法；  
  
  (2)通过设置窗口名称来获取句柄，设置该句柄为最前置顶；
  
  这个运行起来不会出现(1)所描述的情况，但是需要在函数参数里指定好Product Name(也就是窗口标题)，这个在Unity Player Setting 中，Player->Product Name里可以设置。。。。有人问我为什么不实时获取Product Name，这样就不用指定参数了,emmmm我试过, UnityEditor.PlayerSettings.productName,这个只能在编辑器使用，不能打包出来。打包的时候会报错不能Using UnityEditor。
Problem unsolve: Can't hide Windows Taskbar(任务栏) when pressing Alt+Tab.  

# 8.Bezier
create Bezier in 2D or 3D  
refer to https://blog.csdn.net/w6316485/article/details/53215380?utm_source=blogxgwz0  
![image](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/Bezier_2Demension.gif)

# 9.Dark Skin For Unity 2018.4 Editor
refer to https://www.8bitzone.com/482.html
1. Use HxD https://mh-nexus.de/en/hxd/
2. Search HEX 74 04 33 C0 EB 02 8B 03 48 8B 4C
3. Change 74 to 75
if( in_Windows_Platform)
{
  4. Press Ctrl+R to open regedit.exe;
     Find HKEY_CURRENT_USER\Software\Unity Technologies\Unity Editor 5.x;
     verify "UserSkin_h307680651"s value from 0 to 1;
     save regedit;
     open Unity.exe directly or with Unity Hub;
     Done!;
}

有逆向经验可以参考这篇 https://kosro.de/unity-dark-theme/
1. Download x64dbg
2. Create a copy of Unity.exe
3. Open the original .exe in x64dbg
4. Switch to the "Symbols" tab and select the "unity.exe" Module
5. Search for the Symbol "getskinidx" and double click the highlighted result
6. Find the highlighted lines (might start with "jne" or "je")
Replace the "je" with "jne" or the other way around, depending on your Unity version
7. Create a patch using the highlighted icon and choose the copy of the .exe
8. Finally replace the original .exe with the copy (or keep it as a backup)

# 10.好用的类
运行时间
System.Diagnostics.Stopwatch sw =  new Stopwatch();
sw.Start();
//run code
sw.Stop();
Debug.Log(sw.ElapsedMilliseconds);

XXXX秒数转时分
System.TimeSpan timeSpan = new TimeSpane(0, 0, (int)total_Seconds);
if (timeSpan.Hours > 0)
{
    temp = timeSpan.Hours.ToString() + ":" + timeSpan.Minutes.ToString() + ":" + timeSpan.Seconds.ToString();
}
else
{
    temp =  timeSpan.Minutes.ToString() + ":" + timeSpan.Seconds.ToString();
}

# 10.SingleTonBase<T>
继承自MonoBehavior的范型单例
    
# 11.Black Hole Effect For UI Image, RawImage, Text
Learning from https://gameinstitute.qq.com/community/detail/113641  
UI的黑洞效果，利用BaseMeshEffect类，重载ModifyMesh函数，对UI的顶点进行实时偏移运算，达到黑洞效果 
用法：  
把BlackHoleEffect组件挂载到Image处即可  
需要设置的参数:  
mesh -> UI的mesh，网格数越密集，黑洞效果越显著，  
注意，如果直接用Unity 自带的Plane会有问题，因为Plane模型的坐标默认是平放，正面朝向+Y，  
所以，最好自己做一个Plane，正面朝向为-Z即可；  
trans_BlackHole -> 黑洞的Transform,可以为空物体；  
radius_BlackHole -> 黑洞半径；  
power_BlackHole -> 吸附强度；  

![image](https://github.com/Ferrarie/UnityStuff/blob/master/Texture/BlackHoleEffect.gif)  
    
  
