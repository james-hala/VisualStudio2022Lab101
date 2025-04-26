From: 011netservice@gmail.com
Date: 2025-04-20
Subject: readme-Console101.txt

以下 #### 標記段落, **** 標記常用(流程、設定、備忘)

#### 原版
       static void Main(string[] args)
        {
            // Input
            Console.Write("名稱:");
            string? sName = Console.ReadLine();

            // Process
            int iYear = 0;
            int iThisYear = DateTime.Now.Year;
            while (true) // 迴圈開始
            {
                Console.Write("出生年:");
                string? sYear = Console.ReadLine();
                if (string.IsNullOrEmpty(sYear))
                    return;

                // Try-Catch 錯誤處理專門解決(無法預期的錯誤).
                try
                {
                    iYear = int.Parse(sYear);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"請輸入數字, 因為發生錯誤={ex.Message}.");
                    Console.WriteLine(); // User friendly: 空一行比較易讀美觀.
                    continue; // 下一個指令從迴圈開始執行.
                }

                // (可以預期的錯誤)是開發人員應處理的範圍.
                if (iYear < 1900 || iYear > iThisYear)
                {
                    Console.WriteLine($"請輸入正確的出生年, 1900~{iThisYear}.");
                    continue; // 下一個指令從迴圈開始執行.
                }

                // 這裡的 iYear 是正確的, 可以用來計算年齡.
                break; // 終止迴圈. 執行迴圈後的下一個指令
            }
            int iAge = DateTime.Now.Year - iYear;


            // Output
            string sOutput = $"Hello, {sName} 你今年 {iAge} 歲";
            Console.WriteLine(sOutput);

            // UI: User Interface handlling.
            // 讓使用者看到上方的結果, 確認後再結束.
            Console.WriteLine(); // User friendly: 空一行比較易讀美觀.
            Console.WriteLine("按 Enter鍵結束");
            Console.ReadLine();

#### 改寫為 JavaScript
把這段程式碼放到 <script> 標籤中在 HTML 頁面上執行:
function main() {
    // Input
    const sName = prompt("名稱:");

    // Process
    let iYear = 0;
    const iThisYear = new Date().getFullYear();

    while (true) {
        const sYear = prompt("出生年:");
        if (!sYear) return;

        try {
            iYear = parseInt(sYear);
            if (isNaN(iYear)) throw new Error("不是有效的數字");
        } catch (ex) {
            alert(`請輸入數字, 因為發生錯誤=${ex.message}。\n`);
            continue;
        }

        if (iYear < 1900 || iYear > iThisYear) {
            alert(`請輸入正確的出生年, 1900~${iThisYear}。`);
            continue;
        }

        break; // 輸入正確，離開迴圈
    }

    const iAge = iThisYear - iYear;

    // Output
    const sOutput = `Hello, ${sName} 你今年 ${iAge} 歲`;
    alert(sOutput);

    // UI
    alert("按下 Enter 鍵（或關閉本視窗）結束");
}

main();

#### 改寫為 Web 版： JavaScript + HTML 的版本（純前端，不使用 Node.js）

### Console101-JavaScript-HTML-1.html
功能對應說明：
- Console.Write → 使用 label 和 input。
- Console.ReadLine() → 使用 input.value。
- try-catch 和錯誤處理保留，顯示於畫面上。
- while(true) 改為函式內條件檢查，避免頁面卡住。
- 最後用 div 顯示輸出，模擬 Console.WriteLine。
- 無需 Console.ReadLine() 等待結束，因為網頁一直存在。

<!DOCTYPE html>
<html lang="zh-Hant">
<head>
    <meta charset="UTF-8">
    <title>年齡計算器</title>
    <style>
        body { font-family: Arial, sans-serif; padding: 20px; }
        label, input, button { display: block; margin-top: 10px; }
        .output { margin-top: 20px; color: green; }
        .error { color: red; }
    </style>
</head>
<body>

    <h1>年齡計算器</h1>

    <label for="nameInput">名稱:</label>
    <input type="text" id="nameInput" />

    <label for="yearInput">出生年:</label>
    <input type="text" id="yearInput" />

    <button onclick="calculateAge()">送出</button>

    <div id="message" class="output"></div>

    <script>
        function calculateAge() {
            const name = document.getElementById("nameInput").value.trim();
            const yearStr = document.getElementById("yearInput").value.trim();
            const messageDiv = document.getElementById("message");
            const thisYear = new Date().getFullYear();

            if (yearStr === "") {
                messageDiv.innerHTML = "<span class='error'>請輸入出生年。</span>";
                return;
            }

            let birthYear;
            try {
                birthYear = parseInt(yearStr);
                if (isNaN(birthYear)) throw new Error("不是有效數字");
            } catch (error) {
                messageDiv.innerHTML = `<span class="error">請輸入數字, 發生錯誤: ${error.message}</span>`;
                return;
            }

            if (birthYear < 1900 || birthYear > thisYear) {
                messageDiv.innerHTML = `<span class="error">請輸入正確的出生年，1900 ~ ${thisYear}。</span>`;
                return;
            }

            const age = thisYear - birthYear;
            messageDiv.innerHTML = `Hello, ${name} 你今年 ${age} 歲。<br><br>按 F5 或重新整理結束。`;
        }
    </script>

</body>
</html>

### Console101-JavaScript-HTML-2.html
升級版，加入了：
✅ Enter 鍵送出功能
✅ 清除/重設按鈕
✅ 更好的一點互動體驗

這樣使用者可以：
用滑鼠點擊「送出」
或直接按 Enter
還可以按「清除」快速重填

<!DOCTYPE html>
<html lang="zh-Hant">
<head>
    <meta charset="UTF-8">
    <title>年齡計算器</title>
    <style>
        body { font-family: Arial, sans-serif; padding: 20px; }
        label, input, button { display: block; margin-top: 10px; }
        .output { margin-top: 20px; color: green; }
        .error { color: red; }
    </style>
</head>
<body>

    <h1>年齡計算器</h1>

    <form id="ageForm">
        <label for="nameInput">名稱:</label>
        <input type="text" id="nameInput" required />

        <label for="yearInput">出生年:</label>
        <input type="text" id="yearInput" required />

        <button type="submit">送出</button>
        <button type="button" onclick="resetForm()">清除</button>
    </form>

    <div id="message" class="output"></div>

    <script>
        const form = document.getElementById("ageForm");
        const messageDiv = document.getElementById("message");

        form.addEventListener("submit", function (e) {
            e.preventDefault(); // 阻止表單自動提交（刷新）
            calculateAge();
        });

        function calculateAge() {
            const name = document.getElementById("nameInput").value.trim();
            const yearStr = document.getElementById("yearInput").value.trim();
            const thisYear = new Date().getFullYear();

            if (yearStr === "") {
                messageDiv.innerHTML = "<span class='error'>請輸入出生年。</span>";
                return;
            }

            let birthYear;
            try {
                birthYear = parseInt(yearStr);
                if (isNaN(birthYear)) throw new Error("不是有效數字");
            } catch (error) {
                messageDiv.innerHTML = `<span class="error">請輸入數字, 發生錯誤: ${error.message}</span>`;
                return;
            }

            if (birthYear < 1900 || birthYear > thisYear) {
                messageDiv.innerHTML = `<span class="error">請輸入正確的出生年，1900 ~ ${thisYear}。</span>`;
                return;
            }

            const age = thisYear - birthYear;
            messageDiv.innerHTML = `Hello, ${name} 你今年 ${age} 歲。<br><br>按 F5 或重新整理可再次使用。`;
        }

        function resetForm() {
            form.reset


### Console101-JavaScript-HTML-3.html
表單輸入時自動聚焦或加上簡單動畫提示
再升級✨：

✅ 頁面載入時自動聚焦「名稱」欄位
✅ 輸入錯誤會自動聚焦回「出生年」欄位
✅ 簡單的輸入框動畫（輸入框有小小亮起來）
✅ 更清爽的使用者體驗

<!DOCTYPE html>
<html lang="zh-Hant">
<head>
    <meta charset="UTF-8">
    <title>年齡計算器</title>
    <style>
        body {
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
            padding: 20px;
            background: #f5f5f5;
        }
        h1 {
            color: #333;
        }
        label, input, button {
            display: block;
            margin-top: 12px;
            font-size: 16px;
        }
        input {
            padding: 8px;
            width: 250px;
            border: 1px solid #ccc;
            border-radius: 4px;
            transition: box-shadow 0.3s, border-color 0.3s;
        }
        input:focus {
            outline: none;
            border-color: #007bff;
            box-shadow: 0 0 6px rgba(0, 123, 255, 0.5);
        }
        button {
            margin-right: 10px;
            padding: 8px 16px;
            font-size: 15px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        button[type="button"] {
            background-color: #6c757d;
        }
        button:hover {
            opacity: 0.9;
        }
        .output {
            margin-top: 20px;
            color: green;
            font-weight: bold;
        }
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>

    <h1>年齡計算器</h1>

    <form id="ageForm">
        <label for="nameInput">名稱:</label>
        <input type="text" id="nameInput" required />

        <label for="yearInput">出生年:</label>
        <input type="text" id="yearInput" required />

        <button type="submit">送出</button>
        <button type="button" onclick="resetForm()">清除</button>
    </form>

    <div id="message" class="output"></div>

    <script>
        const form = document.getElementById("ageForm");
        const nameInput = document.getElementById("nameInput");
        const yearInput = document.getElementById("yearInput");
        const messageDiv = document.getElementById("message");

        // 頁面載入時，自動聚焦到名稱欄位
        window.onload = () => {
            nameInput.focus();
        };

        form.addEventListener("submit", function (e) {
            e.preventDefault(); // 阻止表單提交
            calculateAge();
        });

        function calculateAge() {
            const name = nameInput.value.trim();
            const yearStr = yearInput.value.trim();
            const thisYear = new Date().getFullYear();

            if (yearStr === "") {
                showError("請輸入出生年。");
                yearInput.focus();
                return;
            }

            let birthYear;
            try {
                birthYear = parseInt(yearStr);
                if (isNaN(birthYear)) throw new Error("不是有效數字");
            } catch (error) {
                showError(`請輸入數字, 發生錯誤: ${error.message}`);
                yearInput.focus();
                return;
            }

            if (birthYear < 1900 || birthYear > thisYear) {
                showError(`請輸入正確的出生年，1900 ~ ${thisYear}。`);
                yearInput.focus();
                return;
            }

            const age = thisYear - birthYear;
            messageDiv.innerHTML = `Hello, ${name} 你今年 ${age} 歲。<br><br>按 F5 或重新整理可再次使用。`;
            messageDiv.className = "output";
        }

        function showError(msg) {
            messageDiv.innerHTML = msg;
            messageDiv.className = "error";
        }

        function resetForm() {
            form.reset();
            messageDiv.innerHTML = "";
            messageDiv.className = "output";
            nameInput.focus();
        }
    </script>

</body>
</html>



#### 改寫為 Web 版：完整 HTML 程式碼, Node.js 版 JavaScript 程式
放進 .html 檔案就能直接在瀏覽器中使用，跟原本的 C# 很接近

使用方式：
打開一個文字編輯器（例如 VS Code 或記事本）。
貼上上述程式碼並儲存為 index.html。
在瀏覽器中打開這個檔案（雙擊即可）。

<!DOCTYPE html>
<html lang="zh-Hant">
<head>
  <meta charset="UTF-8">
  <title>年齡計算器</title>
</head>
<body>
  <script>
    function main() {
      const sName = prompt("名稱:");
      if (!sName) return;

      let iYear = 0;
      const iThisYear = new Date().getFullYear();

      while (true) {
        const sYear = prompt("出生年:");
        if (!sYear) return;

        try {
          iYear = parseInt(sYear);
          if (isNaN(iYear)) throw new Error("不是有效的數字");
        } catch (ex) {
          alert(`請輸入數字, 因為發生錯誤=${ex.message}。\n`);
          continue;
        }

        if (iYear < 1900 || iYear > iThisYear) {
          alert(`請輸入正確的出生年, 1900~${iThisYear}。`);
          continue;
        }

        break;
      }

      const iAge = iThisYear - iYear;
      const sOutput = `Hello, ${sName} 你今年 ${iAge} 歲`;
      alert(sOutput);

      alert("按下 Enter 鍵（或關閉本視窗）結束");
    }

    main();
  </script>
</body>
</html>

#### 改寫為 現代化 Web UI，使用 HTML + CSS + JavaScript 打造的表單介面，不再用 prompt() 和 alert()，而是使用表單輸入與動態畫面顯示
特點：
- 使用表單輸入姓名與出生年。
- 實時驗證資料格式與範圍。
- 美觀的 UI，使用卡片式設計、按鈕效果與錯誤提示。
- 自適應設計，手機上也能正常顯示。

複製程式碼，儲存成 index.html。用瀏覽器打開即可使用。

現代化年齡計算器（HTML + CSS + JS）
<!DOCTYPE html>
<html lang="zh-Hant">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>年齡計算器</title>
  <style>
    body {
      font-family: "Segoe UI", sans-serif;
      background-color: #f0f4f8;
      display: flex;
      justify-content: center;
      align-items: center;
      height: 100vh;
    }

    .container {
      background-color: white;
      padding: 2rem;
      border-radius: 16px;
      box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
      width: 300px;
      text-align: center;
    }

    h1 {
      font-size: 1.5rem;
      margin-bottom: 1rem;
    }

    input {
      width: 100%;
      padding: 10px;
      margin: 0.5rem 0;
      font-size: 1rem;
      border: 1px solid #ccc;
      border-radius: 8px;
    }

    button {
      margin-top: 1rem;
      padding: 10px 16px;
      font-size: 1rem;
      background-color: #007bff;
      color: white;
      border: none;
      border-radius: 8px;
      cursor: pointer;
      transition: background-color 0.3s ease;
    }

    button:hover {
      background-color: #0056b3;
    }

    .output {
      margin-top: 1rem;
      font-weight: bold;
      color: #333;
    }

    .error {
      color: red;
      font-size: 0.9rem;
      margin-top: 0.5rem;
    }
  </style>
</head>
<body>
  <div class="container">
    <h1>年齡計算器</h1>
    <input type="text" id="name" placeholder="請輸入你的名字">
    <input type="text" id="birthYear" placeholder="請輸入出生年 (例如 1990)">
    <button onclick="calculateAge()">計算年齡</button>
    <div class="output" id="output"></div>
    <div class="error" id="error"></div>
  </div>

  <script>
    function calculateAge() {
      const name = document.getElementById("name").value.trim();
      const yearStr = document.getElementById("birthYear").value.trim();
      const output = document.getElementById("output");
      const error = document.getElementById("error");

      output.textContent = "";
      error.textContent = "";

      const currentYear = new Date().getFullYear();
      let birthYear;

      if (!name) {
        error.textContent = "請輸入名稱。";
        return;
      }

      if (!yearStr) {
        error.textContent = "請輸入出生年。";
        return;
      }

      birthYear = parseInt(yearStr);
      if (isNaN(birthYear)) {
        error.textContent = "請輸入有效的出生年（數字）。";
        return;
      }

      if (birthYear < 1900 || birthYear > currentYear) {
        error.textContent = `請輸入正確的出生年，範圍是 1900~${currentYear}。`;
        return;
      }

      const age = currentYear - birthYear;
      output.textContent = `Hello, ${name}，你今年 ${age} 歲！`;
    }
  </script>
</body>
</html>



#### 改寫為 Node.js 版 JavaScript 程式
- 執行方式：
1. 安裝 Node.js（如果尚未安裝）： https://nodejs.org/
2. 將程式存成一個檔案，例如 age-check.js
3. 在 bash 終端機執行：
node age-check.js


- JavaScript 程式
const readline = require("readline");

// 建立 readline 介面，模擬 Console.ReadLine()
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

function ask(question) {
    return new Promise((resolve) => {
        rl.question(question, (answer) => {
            resolve(answer);
        });
    });
}

async function main() {
    // Input
    const sName = await ask("名稱: ");

    // Process
    let iYear = 0;
    const iThisYear = new Date().getFullYear();

    while (true) {
        const sYear = await ask("出生年: ");
        if (!sYear) {
            rl.close();
            return;
        }

        try {
            iYear = parseInt(sYear);
            if (isNaN(iYear)) throw new Error("不是有效的數字");
        } catch (ex) {
            console.log(`請輸入數字, 因為發生錯誤=${ex.message}。\n`);
            continue;
        }

        if (iYear < 1900 || iYear > iThisYear) {
            console.log(`請輸入正確的出生年, 1900~${iThisYear}。`);
            continue;
        }

        break;
    }

    const iAge = iThisYear - iYear;

    // Output
    const sOutput = `Hello, ${sName} 你今年 ${iAge} 歲`;
    console.log(sOutput);

    console.log(); // 空一行
    console.log("按 Enter 鍵結束");
    await ask(""); // 等使用者按 Enter
    rl.close();
}

main();



#### 改寫為 Java
import java.util.Scanner;
import java.time.Year;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Input
        System.out.print("名稱:");
        String sName = scanner.nextLine();

        // Process
        int iYear = 0;
        int iThisYear = Year.now().getValue();

        while (true) { // 迴圈開始
            System.out.print("出生年:");
            String sYear = scanner.nextLine();

            if (sYear == null || sYear.isEmpty()) {
                return;
            }

            try {
                iYear = Integer.parseInt(sYear);
            } catch (NumberFormatException ex) {
                System.out.println("請輸入數字, 因為發生錯誤=" + ex.getMessage() + ".");
                System.out.println(); // User friendly: 空一行比較易讀美觀.
                continue;
            }

            if (iYear < 1900 || iYear > iThisYear) {
                System.out.println("請輸入正確的出生年, 1900~" + iThisYear + ".");
                continue;
            }

            break; // 終止迴圈
        }

        int iAge = iThisYear - iYear;

        // Output
        String sOutput = "Hello, " + sName + " 你今年 " + iAge + " 歲";
        System.out.println(sOutput);

        // UI: User Interface handling.
        System.out.println(); // User friendly: 空一行比較易讀美觀.
        System.out.println("按 Enter鍵結束");
        scanner.nextLine(); // 等待 Enter 鍵
    }
}


#### 改寫為 Android Java 版程式 (使用 Android Studio 建立的 Activity)
- activity_main.xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:padding="24dp"
    android:orientation="vertical">

    <EditText
        android:id="@+id/editName"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:hint="請輸入名稱" />

    <EditText
        android:id="@+id/editYear"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:hint="請輸入出生年"
        android:inputType="number" />

    <Button
        android:id="@+id/btnCalculate"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="計算年齡" />

    <TextView
        android:id="@+id/txtResult"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text=""
        android:textSize="18sp"
        android:paddingTop="20dp" />
</LinearLayout>

- MainActivity.java
package com.example.agecalculator;

import android.os.Bundle;
import android.view.View;
import android.widget.*;
import androidx.appcompat.app.AppCompatActivity;
import java.util.Calendar;

public class MainActivity extends AppCompatActivity {

    EditText editName, editYear;
    Button btnCalculate;
    TextView txtResult;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        
        editName = findViewById(R.id.editName);
        editYear = findViewById(R.id.editYear);
        btnCalculate = findViewById(R.id.btnCalculate);
        txtResult = findViewById(R.id.txtResult);

        btnCalculate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String name = editName.getText().toString().trim();
                String yearStr = editYear.getText().toString().trim();

                if (yearStr.isEmpty()) {
                    Toast.makeText(MainActivity.this, "請輸入出生年", Toast.LENGTH_SHORT).show();
                    return;
                }

                int iYear;
                int iThisYear = Calendar.getInstance().get(Calendar.YEAR);

                try {
                    iYear = Integer.parseInt(yearStr);
                } catch (NumberFormatException e) {
                    Toast.makeText(MainActivity.this, "請輸入有效數字: " + e.getMessage(), Toast.LENGTH_SHORT).show();
                    return;
                }

                if (iYear < 1900 || iYear > iThisYear) {
                    Toast.makeText(MainActivity.this, "請輸入正確的出生年, 1900~" + iThisYear, Toast.LENGTH_SHORT).show();
                    return;
                }

                int age = iThisYear - iYear;
                String output = "Hello, " + name + " 你今年 " + age + " 歲";
                txtResult.setText(output);
            }
        });
    }
}


