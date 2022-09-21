简述
-----------------

TTC  (TIKTOK Comment System for windows x64)，基于 [TikTokLiveSharp](https://github.com/sebheron/TikTokLiveSharp) 开发的winform 应用使用 .NET Core 3.1。运行时 [.NET Desktop Runtime 3.1.28 x64](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-3.1.28-windows-x64-installer)

特性
-----------------

- 程序名称决定启动方式
- 代理检测：**SS/SSR/Astrill/Fiddler**
- 错误提示：直播间段出现错误先解决再重启软件

- **完全本地化**：所有直播间数据保存在本地 **C:\Users\Administration\AppData\Local\Temp\ttc**

配置
-----------------

- 保存直播间评论.txt：**File -> Open comment record folder**
- 恢复历史直播间：**File -> Restore live stream history**
- 自动翻译： **Setup -> Configure -> translation language** 支持 英文，中文，马来语。默认自动识别
- 字体大小：**Setup -> Configure -> Comment/Joined/Viewer Panel Font Size** 默认 14
- 可选加入成员面板：**Setup -> Configure -> show joined panel** 


面板
------------------

+ Comment：当前直播信息，先连接直播间，或者点击恢复直播间历史数据。
+ Debug：输出运行数据。
+ Configure：配置面板。

程序名称决定启动方式
------------------

- 推荐格式： **win-ttc.feature-timestamp.\[unique_id][proxy_port].exe**
  - **win-ttc**：固定
  - **feature**：snapshot，intelligent
  - **timestamp**：当前时间 202209202254 (GMT+8)
  - **[unique_id]**：tiktok账号，如[fbs.students]
  - **[proxy_port]**：本地代理端口，1080:SS/SSR，3213:Astrill，8888:Fiddler
- 例子：自动选择直播间，自动使用本地1080端口代理，自动连接直播间
  - **ttc-win.intelligent-202209202218.\[fbs.students][1080].exe**
  - **ttc-win.intelligent.\[fbs.students][1080].exe**
  - **ttc-win.\[fbs.students][1080].exe**
  - **\[fbs.students][1080].exe**
- 例子：自动选择直播间，不使用代理，自动连接直播间。
  - ...
  - **\[fbs.students][0].exe**
- 例子：自动选择直播间，自动检测代理，手动连接直播间。
  - ...
  - **\[fbs.students].exe**
- 例子：正常启动，手动选择直播间，自动检测代理，手动连接直播间。
  - ...
  - **ttc-win.exe**