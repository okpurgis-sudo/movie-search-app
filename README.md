# Movie Search App

C# WinForms と SQLite で作成した、個人用の映画データベースアプリです。

作品名、出演者、ジャンル、ナイスポイント、評価、URLを登録し、検索・編集・削除できます。

## Features

- 映画データの登録・編集・削除
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

このアプリは個人利用を目的として作成したものです。

本ソフトウェアは現状のまま提供されます。
動作保証、データ消失、その他利用によって発生した問題について、作者は責任を負いません。

重要なデータを扱う場合は、各自でバックアップを取ってください。

License

This project is licensed under the MIT License.