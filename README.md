# TimeRecorder-CS
出退勤の打刻システムのサンプルです。
- .Net 5.0
- Ulid 1.2.6

## 目指しているところ
- 「抽象への依存」をがんばりすぎない軽量なアーキテクチャ。
  - ファイル数が多くなりすぎるのを抑制したい。
  - レイヤーをまたぐ時のデータモデルの詰め替えを減らしたい。
  - 依存の方向は制御できていること。

## 雑記
- private変数の頭に"_"のprefixを付けているのはC#的なお作法です。
- DTOとかのprivate変数要らないのでは？
  - propertyでpublicなgetter、privateなsetterにした方が端的です。
    - ……端的ですが、コンストラクタでの大文字小文字の間違いに気づかず詰まる事案がしばしば発生したのでこの形式にしています。
- scope全て明記しなくてもデフォルトの使えば？
  - 「デフォルトが何か」という知識に依存させないようにしています。
    - チームメンバーが混乱するので。
- Application層のプロジェクト名がUseCase？
  - 当該レイヤーを「アプリケーション」と呼ぶことに馴染みがなく、会話が混乱しがちだったので「ユースケース」にしちゃいました。
- Domain層にDTOを置くのはいかがなものか。
    永続化層やPresentation層でプリミティブな型のDTOが欲しくなります。
    - Domainオブジェクトのpropertyを公開するやり方もありますが、そうすると公開されるのはValueObjectです。
      「ValueObjectからプリミティブな型の値を取り出さなきゃいけない」が忘れられがちで、「DBに値が登録できないのですが！」が多発したので避けています。
    - Observerパターンを用いてDomainに置かない手法も試したのですが、以下がコピペclassになりがちだったのでやめました。
      - Application層のOutputData
      - 永続化層のDTO
    - 上記経緯から、Domain層にDTOを定義し、Domain層でしかインスタンス生成できない(internal)ようにした、という妥協的配置です。


  ということで、理解や実装の難易度を下げる方に寄せて、アンチパターンとも言われる戦術的DDD(軽量DDD)にしてしまっている面は大いにあります。