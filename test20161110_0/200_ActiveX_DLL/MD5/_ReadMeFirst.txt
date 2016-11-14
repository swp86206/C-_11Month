安裝註冊 ActiveX 元件:

1. 將 RH.dll 複製到任一資料夾，例如 C:\tools\RH.dll

2. 開始 | 啟行，輸入: regsvr32 <path>RH.dll
   <path> 為步驟一的資料夾，例如 c:\tools



解除安裝:

開始 | 啟行，輸入: regsvr32 /u <path>RH.dll
 <path> 為步驟一的資料夾，例如 c:\tools


<Note>
此 DLL 以 Visual Basic 6 寫成，也許需要安裝 VB6 Runtime Library 方可執行。
