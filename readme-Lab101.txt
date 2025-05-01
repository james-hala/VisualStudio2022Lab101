From: 011netservice@gmail.com
Date: 2025-04-26
Subject: 適合(已能看懂程式語法)的初學者, 學習如何以 C# 開發軟體的 練習題.
網址: https://svc.011.idv.tw/CodeHelper/cs/vs2022/Lab/VS2022Lab101/



以下 #### 標記段落, **** 標記常用(流程、設定、備忘)

#### 摘要

- 需下載: 
   Visual Studio 2022, 以英文的環境開發 https://visualstudio.microsoft.com/zh-hant/vs/
   git 工具,  https://git-scm.com/downloads/win, 2.49.0
   Teams, 開發人員常用通訊軟體, https://www.microsoft.com/zh-tw/microsoft-teams/download-app
   notepad-plus-plus, https://notepad-plus-plus.org/downloads/

- Run from Shell (cmd in Power Shell)
1. 以檔案總管選擇一個資料夾.
2. 在資料夾上面按滑鼠右鍵, 選擇 在終端機開啟.
   執行結果: 開啟了 Windows PowerShell 指令視窗, 在這個視窗中可執行 PowerShell 指令.
3. 輸入 cmd 可改成使用 Console command 的指令:
   例如1: dir 可查詢資料夾中的檔案清單.
   例如2: 若檔案清單中有 .exe 的檔案, 則可輸入(檔案名稱), 或 (檔案名稱).exe 執行該程式.
   
   PowerShell 也可以執行程式, 但是要使用不同的指令, 建議使用以上的 cmd 就好.
   例如1: dir 可查詢資料夾中的檔案清單.
   例如2: 若檔案清單中有 .exe 的檔案, 則可輸入.\(檔案名稱), 或 .\(檔案名稱).exe 執行該程式.


#### Lab1: Input, output, process
- 主題
以 Console program 接收 Input 處理後產生 Output.
1. Input by user interactive.
2. Input from command.

測試
1. Run from IDE, Integrated Development Environment.
2. Run from File-Explorer
3. Run from Shell (cmd/Power Shell)

- 學習重點:
熟悉開發環境.

- 練習
1. 將 Input 改為以字串陣列 string[] args 輸入.
2. 將 Input 改為以 CommandLine 物件 輸入.
並於(IDE, 檔案總管, 和 cmd Shell 測試執行)

- 參考 
readme-Console101.txt
Console101-JavaScript-HTML-1.html
Console101-JavaScript-HTML-2.html
Console101-JavaScript-HTML-3.html

#### Lab2: WinForms Component
- 主題
  1. 以 WinForms program 接收 Input 處理後產生 Output.
  2. 請學員在自己的開發環境上展現上次練習題的成果.
  

- 上課大綱
-- 示範從無到有如何開發 WinForms 的程式.
	1. 複製本地 Repository 到別的資料夾, 新建 LAB2 test 的資料夾 \VS2022Lab101\Test2\ 資料夾後講解主題.
	2. 課後再示範將 \VS2022Lab101\Test2\ 上傳, 並說明相關常用概念.
	3. 有時間的話: 請學員以 Teams 再自己的電腦上展示上次練習的成果.
   
-- 比較一下 Program.cs 在 Console 和 WinForms 的不同.

-- Class (或物件)
	WinForms 中所有的物件, 均為 Class. 現代程式語言大多數以 Class 的架構寫程式. 
    
	Class 中主要有三種成分
	1. Properties 屬性
	   簡單的屬性, 例如 Text, Name, Count, Width....
	   複雜的屬性可以是一個 Class, 例如:  Form 表單物件中, 可以包含了 TextBox, Label, Button, ListBox, ListView... 等物件的屬性.

    2. Method/Function (或函數)
	   a. 沒有回傳值的函數叫做方法, 有回傳值的函數就叫做函數. 
	      不過不見得大家都這麼區分.
       b. 成立函數的原則:
          當重複撰寫相同的程式碼時, 就要考慮將這些程式碼抽取成為函數.
          要是沒有這樣做的話, 當要修改這些程式碼時, 就必須在每一個地方都修改, 這樣就會增加錯誤的機率.
	   
	3. Event (或事件)
	   觸發執行函數的事件
	   WinForms 建立 EventHandler 的方法
	       a. 在設計畫面上, 以滑鼠 double click (物件), 可建立預設的 EventHandler.
	       b. 以 (物件).Properties.Events 清單, 選擇需要建立的 EventHandler 項目 建立.
	       c. 以 (物件).Event += ... 語法建立, 建議盡量用這種方法建立 Event delegate 函數, 可以集中在同一個地方管理那些事件已被設定要觸發.
	   EventHandler 是一種 WinForms 環境中定義的 事件, 呼叫的函數型別永遠是
			public delegate void EventHandler(object? sender, EventArgs e)
		例如: 
		private void Form1_Load(object sender, EventArgs e)	
        private void BtnAdd_Click(object sender, EventArgs e)
		private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
		private void ListView1_ItemSelectionChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
	   
	   表單的執行順序 Order of Events in Windows Forms
	     ref: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/order-of-events-in-windows-forms?view=netframeworkdesktop-4.8
	   除了以下 3 個常用事件之外, 其餘不常使用.
	   啟動:
			Control.HandleCreated
			Control.BindingContextChanged
			Form.Load ---> 已載入設計元件, 但還未顯示到畫面上.
			Control.VisibleChanged
			Form.Activated
			Form.Shown ---> 表單顯示到畫面之前, 最後一個事件.	   
       結束:
			Form.Closing
			Form.FormClosing --> 表單正要關閉
			Form.Closed
			Form.FormClosed
			Form.Deactivate	   

	   
-- 變數範圍
   1. 函數中宣告的變數, 有效範圍只在該函數中, 因此只能在該函數中使用.
   2. Class 範圍的變數, 有效範圍是整個 Class, 因此整個 Class 中的函數都可以使用.
   3. 另外還有更大的範圍, 等用到再說明. 
      跨 Class 範圍
	  跨 Assembly 範圍

-- 常用示範, 
主要只講這些就好: 
1. OnLine Help 示範在 Visual Studio 2022 中, 自動連結到微軟說明文件.
2. Go to Defination 查詢宣告的地方, 例如變數宣告, 函數內容, 甚至可以查到 .NET 底層函數實作的 Open Source.
3. 常用的功能都有快速鍵可以按, 可以背下來快速使用.
   以下是我常用的快速鍵, 請練習找出他的 Menu 位置, 可以用操作的方式執行
   a. Windows 本身的快速鍵, 例如: Ctrl-C, Ctrl-V...之類的.
   b. Ctrl-K, Ctrl-D: 排版編輯中的檔案.
   c. Ctrl-F: 查詢、全文查詢、全文修改視窗.
4. Find All Referenced: 查詢某個函數在那些地方被呼叫了? 例如: MyShowLength()
5. 全文查詢、全文修改、所有檔案查詢、所有檔案修改.
   不要侷限在 Visual Studio(或是任何工具軟體 Eclipse、git工具...等都一樣)提供的功能中.
   a. 工具軟體中不見得有提供你需要的功能.
   b. 開發人員經常交叉使用不同的工具解決問題.
6. 將查詢結果成為(再製品)的輸入: 
   a. 示範 章節目錄製作
   b. 查詢結果若與 Script 結合成為程式, 或是以程式讀取查詢結果處理後輸出, 可以加速自動化處理.
      資訊領域常簡稱這種模式的(Script 或程式)為 job, 或 batch job.

常用功能太多了, 必須有需求才懂適用情境, 就不整理成文件了! 


- 測試
測試 表單 功能.

- 學習重點:
WinForm 基本物件.

- 練習
參考 WinFormsApp1 專案的內容, 自己從空白專案開始, 實作出同樣的功能.
只有自己真正撰寫過, 才會了解撰寫程式的思路, 以及會碰到的問題.

因此本次練習題, 必須等到學員完成的作業上傳到 github VS2022Lab101 中交付測試通過後, 再進行下一個課程.
完成主要的新增、修改、刪除功能就可以. 

開發人員應了解自己在資訊領域的指標, 例如: 本 Lab 的程式,
1. 筆者: 從零開始撰寫, 同時還完成交材文件, 大約1日內可完成.
   一般已經在工作的 C# 程式開發者, 都差不多在這樣的時間範圍可完成.
   即使換成不同的開發環境或語言, 同樣的功能, 業界應有的基本要求, 也差不多是要在這樣的時間內完成, 
     因為大部分資訊從業人員, 不需要經常撰寫那些從無到有的程式, 而是直接拿既有的程式, 或是可取得的範例,
	 或是自己的範本, 再修改成需要的結果, 因此可以縮短開發程式的時間. 
2. AI: 不到1分鐘可完成程式, 包括簡易說明.
3. 學員你呢?


本練習重點是: 
1. 開發人員應可以在(有參考的程式碼、Google查詢、微軟說明文件), 重寫或改寫出自己的程式碼.
2. 本 Lab 中使用到的 WinForms 元件是最基本、最常用的, 必須非常熟練!

- 前次問題
  有時間再補充說明以下內容.
-- git clone: 
	https://github.com/github-honda/GitPratice/blob/main/readme-GitHub.txt
    參考 常用流程: 複製遠端資料庫 為 本機新子資料夾

-- git 簡易教學
  a. git help
	- 文件說明
	  git help <command> | Help command. 輔助文件, 存放位置: C:\Program Files\Git\mingw64\share\doc\git-doc\index.html
	  git help clone, 存放位置 file:///C:/Program%20Files/Git/mingw64/share/doc/git-doc/git-clone.html
	- 示範 git-clone.html 檔案中與 HTML 效果的對應.
	
  b. readme-GitHub.txt
	https://github.com/github-honda/GitPratice/blob/main/readme-GitHub.txt
    - 查詢章節
	- 查詢常用
	- 查詢 Keyword.
	- 跨檔案查詢, 以 C:\Program Files\Git\mingw64\share\doc\git-doc\index.html 為例

  c. 學習指令的觀念 (適用於各種不同的指令工作: 例如 git, cmd, PowerShell... 任何指令模式.)
    - 任何工具軟體, 底層都是以指令為基礎. 
	  1. 不同的工具軟體會有不同的操作方式或名詞定義, 容易造成混淆, 但是指令是固定不變、定義一致, 不會混淆.
	  2. 連續的指令可以串接起來, 成為自動化執行的程式, 處理更複雜的作業流程. 但是工具軟體只能以人工操作一次一個步驟. 
	     串接指令為程式, 簡稱為 Script. MIS 人員經常會把常用的操作流程, 改用 Script 程式執行, 好處是: 
		   * 不會漏掉應執行的步驟.
           * 以一個 Script 程式替代多個指令執行工作, 比較方便、快速且不易出錯.		   
    - 沒用過的指令可以等到需要用的時候再學, 學過以後就該記住, 不要重複浪費學習過程的時間.
	- 不常用的話, 久了一定會忘記! 怕忘記的話, 就要就作筆記留存.
	- 用過的指令, 查自己的筆記一定比上網查詢快.

-- 使用 Teams 的用意
	a. 習慣上, 資訊人員上班期間會開啟公司規範使用的通訊軟體, 例如 Teams, 下班後則可關閉.
	b. Teams 可以共享畫面, 協調開會時間...等協同工作所需的常用功能.


-- ASCII、Unicode 和 UTF-8 字碼表.
   若上課時間充裕, 再補充說明:
	- ASCII 
	  https://zh.wikipedia.org/zh-tw/ASCII
	  a. 是所有其他字碼表的基礎, 只能顯示英語. 
	  b. 每個字碼占用 1 byte. 共定義了128個字元, 包含數字, 英文標點符號, 英文大小寫字母, 和33個字元無法顯示的控制字元.
	  
	- Unicode
	  https://zh.wikipedia.org/zh-tw/Unicode
	  中文名稱為統一碼，又譯作萬國碼、統一字元碼、統一字元編碼，是資訊科技領域的業界標準，
	  其整理、編碼了世界上大部分的文字系統，使得電腦能以通用劃一的字元集來處理和顯示文字.
	   
	- UTF-8
	  https://zh.wikipedia.org/zh-tw/UTF-8
	  a. UTF-8 也是 Unicode. 是 Unicode 其中一種編碼方式, 全名為 8-bit Unicode Transformation Format.
	  b. UTF-8 以變動長度 (1到4 bytes) 進行編碼, 是目前最廣泛使用、也是各國最新統一使用的字碼表.
	  
	  
	- 各國文字均有不同的字碼規範與歷史版本. 
	例如台灣舊版的字碼是 Big-5 碼, 中國的字碼為 GB2312, GBK...等不同版本.

#### Lab3: Database
- 課程大綱
>	新的 WinForms 元件及操作
	快速展示一下 Lab3 程式的執行效果. 

>	Multi-Form.
>	ToolStripMenuItem
	快速鍵

>	StatusStrip
	左右對齊的 Label

>	AboutBox.cs
	1. 自動產生的 Template 程式.
		Template: 開發人員應收集一些常用的樣板程式, 以樣板為基礎添加新功能比較快, 而不是每次都從零開始寫起. 

	2. 示範重複啟動 AboutBox

	Value Type vs Reference Type
	數值型別變數 Value Type: 有效範圍結束自動回收.
	參考型別變數 Reference Type: 
		1. 參考型別建立的物件叫做 Instance. Instance 均由 new 關鍵字建立.
		   數值型別的變數不會有 Instance.
		   參考型別的變數代表一個數值參考到一個系統中的 Instance: 參考型別的變數在有效範圍結束時, 變數的數值會自動回收, 但是變數參考到的 Instance 仍存在!
		2. 參考型別的變數必須自行回收, 或由 garbage collector 回收.
				自行回收的方法是呼叫本身的標準介面 Dispose(), 或是使用 using 關鍵字在範圍內會自動呼叫標準介面 Dispose().
		3. 系統會依據系統資源狀況, 不定時啟動 garbage collector 進行回收作業. 
		   程式結束的時候, garbage collector 會針對程式範圍進行一次回收作業.
		4. garbage collector 只能回收那些(沒有被任何變數參考到的 Instance).
		   若還有變數參考到的 Instance, 則會殘留無法回收.
				例外: 若一個參考型別變數中, 僅有數值型別的成員時, 則在有效範圍外, 也會被 garbage collector 回收. 
					例如: FormEntry.BtnDelete_Click() 中的 CRecord Record1 = new();
		
    靜態變數
    1. 整個程式只有一份, 生命週期是整個程式執行期間, 直到程式結束.
    2. 就算是宣告在函數範圍內, 也不會在函數結束時釋放.
       例如: 在函數中宣告 static int i = 0; // i 會在整個程式執行期間都存在.

    參考型別靜態變數
    1. 整個程式只有一份 Instance, 生命週期是整個程式執行期間, 直到程式結束.
    2. 啟動點是靜態建構子, 會在第一次使用這個類別成員(屬性或方法)時候, 自動執行.
       由於這樣的啟動點不好預期, 甚至有些情況會造成錯誤.
       所以建議在靜態建構子中, 增加一個函數, 在可預期的地方執行, 啟動靜態變數建構子.
       例如: CProject.Run().
    3. 結束點是程式結束, 會自動釋放靜態變數.
    練習: 測試靜態變數 CProject 的啟動點. 

	Assemply
		編譯以後的可執行檔, 不一定是 .exe, 可能是其他副檔名, 例如 .dll
		內含一些屬性可取得, 例如: AssemblyTitle, AssemblyProduct, AssemblyVersion, AssemblyCopyright, AssemblyCompany, AssemblyDescription.

	程式設計師要確保程式結束的時候, 所有用到的變數都被回收, 不可以殘留!
		若仍有殘留變數未回收的程式, 則系統會認定為(仍在執行中的程式)
		練習: 檢查執行中的程式清單.

>	複製 Form
	複製 Form 的時候必須把 (Form.cs, Form.Designer.cs, Form.resx...等檔案)同時複製才能成功.
	以下步驟可確保複製成功, 以 Form1 複製為 FormQuery 為例:
	1. 以檔案總管將 (Form1.cs, Form1.resx, Form1.Designer.cs) 複製到不同的資料夾(非 Visual Studio 專案範圍, 例如: C:\temp).
	2. 在 Visual Studio Solution Explorer 將 Form1 改名為 FormQuery. 
		a. Visual Studio 會提示: 相關檔案都會一起變更為新檔案名稱.
		b. 改名後最好 F6 重新編譯一次, 確定改名成功. 
	3. 以檔案總管將 C:\temp\(Form1.cs, Form1.resx, Form1.Designer.cs) 複製回專案的資料夾中.
		a. Visual Studio 2022 會自動將 Form1 重新加入專案中.
			舊版的 Visual Studio 不會自動將 Form1 重新加入專案中, 必須在專案中自行加回 Form1.
	4. F6 重新編譯一次, 確定包含 Form1 和 FormQuery 可編譯成功.

>	資料庫: MySql.Data
	NuGet 可下載第三方元件. 例如: MySql.Data
	專案已安裝的元件在專案 \Dependencies\Packages\ 中.
	
>	Table
	1. database 內碼應選用 UTF8.
	2. PRIMARY KEY, UNIQUE KEY.
	3. NOT NULL vs DEFAULT NULL.
	3. varchar vs nvarchar.
	4. 自動寫入新增 record 時間: `fcreate_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP.
	5. 自動寫入修改 record 時間: `fupdate_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
	6. 自動編號: 例如從 1000 開編號, 第一個號碼 1000, 依序編號. 


	參考: Lab3-Database\Dump_lab101_20250427.sql 如下:
CREATE TABLE `tlab3` (
  `fpk1` int NOT NULL,
  `fsku` varchar(16) NOT NULL,
  `fname` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `fprice` decimal(13,2) NOT NULL,
  `fqty` int NOT NULL,
  `famount` decimal(13,2) NOT NULL,
  `fcreate_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fupdate_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`fpk1`)
  UNIQUE KEY `fpk1_UNIQUE` (`fpk1`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
	練習: Dump database.

>	講解程式
		依照資料流順序說明程式
		
#### Lab4: File
- 課程大綱
>	以 AI 上課
	1. AI-1.txt: 閱讀後可了解一般跟 AI 互動的模式, 該怎樣提問 AI 取得我們所需要的答案. 
	2. AI-2.txt: 
		a. 展示如何提問 Lab3 曾經撰寫過撰寫的程式.
		b. 比對一下跟 Lab3 既有的程式有什麼不同 ?
		c. 思考一下若要將 AI 的答案, 寫入 Lab3 程式的過程, 應如何進行.
		
	3. File IO 實作. 
		a. AI-3.txt: 是 AI 以 CSV    格式提供的匯入匯出的函數.
		b. AI-4.txt: 是 AI 以 Json   格式提供的匯入匯出的函數.
		c. AI-5.txt: 是 AI 以 Binary 格式提供的匯入匯出的函數.
		請增加 Lab4 專案, 以 Lab3 為基礎, 增加可將資料庫資料, 匯入匯出3種格式(CSV, Json, Binary)檔案的功能.
		練習過程優先嘗試問 AI 後, 再問我.

