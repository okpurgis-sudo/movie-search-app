# Movie Search App

C# WinForms と SQLite で作成した、個人用の作品データベースアプリです。

作品名、出演者、ジャンル、ナイスポイント、評価、URLを登録し、検索・編集・削除できます。

## Features

- 作品データの登録・編集・削除
- 作品名 / 出演者 / ジャンル / ナイスポイントによる検索
- OR検索 / AND検索の切り替え
- 検索結果の昇順 / 降順ソート
- セルクリックによるテキストコピー
- 出演者 / ジャンル / ナイスポイントの頻出ランキング
- 気分に合わせたランダム作品選択
- SQLiteによるローカル保存

## Database

データベースは以下に保存されます。

```text
%LOCALAPPDATA%\MovieSearchApp\MovieSearchApp.db

Requirements
Windows
.NET Desktop Runtime 10.0 or later
Disclaimer

## License

This project is distributed under a custom license.

個人利用および非商用利用は無料です。  
改変・再配布は可能ですが、元の著作権表示とライセンス文を含めてください。

商用利用を行う場合は、事前に作者の許可を得てください。

本ソフトウェアは現状のまま提供され、作者は動作保証、データ消失、その他利用によって発生した問題について責任を負いません。
