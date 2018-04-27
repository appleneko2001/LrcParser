﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Opportunity.LrcParser.UnitTest
{
    [TestClass]
    public class ParserWithSpeakerTests
    {
        public const string TEST_DATA = @"
[00:17.95][01:25.92][02:06.91][02:35.21][03:01.53][03:15.06][03:30.71]


[00:02.58]全員: いっ]せーの！



[00:03.65]千和: おかえり　(YEAH!)
[00:04.93]真涼: さあ出かけよう　(YEAH!)
[00:06.59]全員: 抜け駆けランデブー
[00:09.49]千和: 絆が大事
[00:12.45]真涼: 恋人が大事
[00:14.27]全員: Girlish Lover
[00:21.25]千和: この痛み　君のせい？
[00:26.52]真涼: 胸のときめき　ウソのつもり
[00:32.84]全員: 今までのポジションを
[00:38.11]越えた未来(あした)は　どうなるの？
[00:44.58]千和: ねぇもっと一緒しよ！　ダメ？
[00:47.97]真涼: ダメ！　わたしだけ
[00:50.19]千和: 油断も隙もない
[00:53.06]全員: 君とのボーダー越えたい
[00:59.27]全員: そうもっと！
[01:00.44]姫香: 大胆で　(YEAH!)
[01:01.70]愛衣: ちょっと強引？　(YEAH!)
[01:03.20]全員: スキを見せたい
[01:06.14]千和: 優しい君も
[01:09.14]真涼: いじわるな君も
[01:10.80]全員: ひとりじめ
[01:12.03]姫香: 気付いて　(YEAH!)
[01:13.35]愛衣: やっぱやめて　(YEAH!)
[01:14.81]全員: ウラハラ　fall in love
[01:17.76]千和: 友達以上
[01:20.84]真涼: 恋人(ホンモノ)未満の
[01:22.52]全員: Girlish Lover
[01:29.62]姫香: 君だけが　きらめいて
[01:34.80]愛衣: 遠い背中も　追いかけたよ
[01:41.08]全員: これからのアプローチ
[01:46.37]過去の分まで　伝えたい
[01:52.82]姫香: ぎゅってしておねだり　ダメ？
[01:56.26]愛衣: ダメ！　不埒です
[01:58.46]姫香: 甘えたい　触れたい
[02:01.38]全員: どこまで？ボーダー教えて
[02:07.61]全員: おっとっと！
[02:08.80]真涼: 手強い　(YEAH!)
[02:10.00]千和: 恋の仇　(YEAH!)
[02:11.53]全員: ムキになったら
[02:14.42]姫香: あったかい胸も
[02:17.56]愛衣: 君の将来も
[02:19.32]全員: 譲れない
[02:20.31]千和: 答えて　(YEAH!)
[02:21.63]真涼: やっぱやめて　(YEAH!)
[02:23.11]全員: 一方通行ランデブー
[02:26.12]姫香: 運命信じて
[02:29.16]愛衣: 約束交わして
[02:30.82]全員: Now Loading Lover
[02:46.75]愛衣: ホントなの？ウソなの？好き？
[02:50.01]千和、真涼、姫香: 好き！
[02:50.69]姫香: 好きだから
[02:52.37]千和、姫香: 笑わず答えて
[02:55.18]全員: 曖昧なボーダー越えよう
[03:03.03]全員: おっとっと！
[03:04.07]千和: 大胆で　(YEAH!)
[03:05.35]真涼: ちょっと強引？　(YEAH!)
[03:06.92]全員: スキを見せたら
[03:09.76]姫香: 君との恋の
[03:12.73]愛衣: 行方も変わるの？
[03:14.55]全員: 答えてよ！
[03:15.76]姫香: ときめき　(YEAH!)
[03:17.17]愛衣: 走り出す　(YEAH!)
[03:18.48]全員: わくわくランデブー
[03:21.45]千和: 友達以上
[03:24.41]真涼: 恋人(ホンモノ)未満の
[03:26.14]全員: Girlish Lover



";

        [TestMethod]
        public void TestAll()
        {
            var r = Lyrics.Parse<LineWithSpeaker>(TEST_DATA);
            var l = r.Lyrics;
            Assert.AreEqual(74, l.Lines.Count);
            Assert.AreEqual("", l.Lines[6].Content);
            Assert.AreEqual("全員: いっ]せーの！", l.Lines[7].Content);
            Assert.AreEqual(Timestamp.Create(2, 580), l.Lines[7].Timestamp);
            foreach (var item in l.Lines)
            {
                Assert.IsNotNull(item.Lyrics);
                Assert.IsNotNull(item.Speaker);
                CollectionAssert.Contains(new[]
                {
                    "全員",
                    "千和",
                    "真涼",
                    "姫香",
                    "愛衣",
                    "千和、真涼、姫香",
                    "千和、姫香",
                    "",
                }, item.Speaker);
            }
        }

        [TestMethod]
        public void Parse10000Times()
        {
            for (var i = 0; i < 10000; i++)
            {
                Lyrics.Parse<LineWithSpeaker>(TEST_DATA);
            }
        }

        [TestMethod]
        public void Stringify10000Times()
        {
            var l = Lyrics.Parse<LineWithSpeaker>(TEST_DATA).Lyrics;
            for (var i = 0; i < 10000; i++)
            {
                l.ToString();
            }
        }
    }
}
