# CharArt
這是一個將圖片轉成文字表現的小工具，使用後的效果會像這樣，圖片來源https://x.com/meiyaya0815

![點擊綠色按鈕下載](https://github.com/user-attachments/assets/73160296-c4be-4c21-a67a-3d20eda51c03)

接下來是使用方式，收先點擊綠色按鈕

![點擊綠色按鈕下載](https://github.com/user-attachments/assets/7ab4bd4a-7b23-43db-aaf1-245631a30a51)

下載原始碼的壓縮檔

![下載原始碼壓縮檔](https://github.com/user-attachments/assets/143cc925-8245-41bd-b209-165b6b9c09e9)

把下載的壓縮檔解壓縮

![解壓縮](https://github.com/user-attachments/assets/da434e9e-55a4-4f34-a6a6-351adf35988b)

進到指定資料夾位置

![資料夾位置](https://github.com/user-attachments/assets/d86d302d-8d72-4560-b40b-f833ec677027)

把專案路徑輸入到cmd後按Enter開始執行

![cmd啟動](https://github.com/user-attachments/assets/7401a6d5-192c-43d3-bee3-1e1989869f60)

把終端機畫面最大化後輸入dotnet run並按Enter鍵執行，有出現圖案代表成功執行可以直接跳到最後一步

![dotnet run](https://github.com/user-attachments/assets/62d04473-c65c-4946-801e-c0c824d1052b)

如果出現'dotnet'不是內部或外部命令、可執行的程式或批次檔的訊息，代表電腦沒裝過.NETSDK，需要到微軟官網下載，版本只需要8.0以上就可以了https://dotnet.microsoft.com/zh-tw/download

![dotnet sdk install](https://github.com/user-attachments/assets/ad22f389-ccac-4011-a6c4-a499f499d576)

打開剛下載的安裝檔進行安裝完成後，重複剛才打開終端機的步驟，輸入dotnet --version指令後按下Enter，這時應該會出現安裝的版本號碼，若沒出現可能需要重開電腦

![dotnet sdk install](https://github.com/user-attachments/assets/9b448eea-96ad-4fcf-87fd-ce5fcf82a69a)

確認安裝成功後再次輸入dotnet run並按Enter鍵執行

![dotnet sdk install](https://github.com/user-attachments/assets/61348ccc-ec96-4700-94a3-5eed50855523)

執行完後可以在指定路徑找到輸出的檔案

![輸出結果](https://github.com/user-attachments/assets/47258f79-8790-439c-b72a-5bb229e30c4f)

---

額外功能說明:

要用自訂圖片時把可以將Image資料夾中的圖換掉，要注意的是存在複數圖片的情況下只會讀第一張圖

![圖片更換](https://github.com/user-attachments/assets/8904d063-bde5-46c5-be26-44a066617fcf)

可變動的設定都會在Config.txt把設定值寫在等號後面存檔就能運作，不填值會使用預設數值，以下為各項設定內容:

OutputPath: 指定輸出路徑，須包含輸出後的檔案及副檔名

PerformanceResizeWidth: 預覽表演用數值，修改新圖片的寬度，由於圖片太大時會發生顯示上的排版問題，如果只想要成品這個值

OutputResizeWidth: 輸出的圖片大小

Char: 填滿顏色時的字符，例如A、B、1、!、@、#之類的

GrayScale: 填0~255之間的值，這個值會作為亮度分界線來決定是否要填色

DelayMilliseconds: 預覽表演用數值，單位為毫秒，單純讓預覽表演好看的功能，不填會使用預設數值

![圖片更換](https://github.com/user-attachments/assets/aed631f8-5bda-4cbe-a98e-dce38a70fd69)
