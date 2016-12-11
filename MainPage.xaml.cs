using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=391641 を参照してください

namespace alarm
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            //お約束？
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;


            //現在の時間を設定
            DispatcherTimer timer = new DispatcherTimer();
            //時刻が進むたびにTimer_Tickを呼び出すイベントハンドラ
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        //現在の時刻と設定された時刻を判断（HHMMSS単位）
        private void Timer_Tick(object sender, object e)
        {
            DateTime now = DateTime.Now;
            now_times.Text = now.Hour.ToString() + ":" + now.Minute.ToString() + ":" + now.Second.ToString();
            TimeSpan dt = time_pick.Time;
            String now_time = DateTime.Now.ToString("HH:mm:ss");
            String set_time = dt.ToString();
            //アラーム時刻の場合
            if (now_time == set_time)
            {
                //メッセージ出力のクラスを呼び出す。
                message();
            }

        }

        //アラームメッセージ出力
        private async void message()
        {
            try
            {
                var dialog = new MessageDialog("アラーム", "アラーム出力");
                dialog.Commands.Add(new UICommand("閉じる"));
                //スヌーズ機能なし
                dialog.Commands.Add(new UICommand("スヌーズ"));
                //閉じるを強調
                dialog.DefaultCommandIndex = 1;
                //ダイアログ出力
                await dialog.ShowAsync();
            }
            catch (Exception e)
            {
                //なぜかダイアログ出力時にエラーする。
                //詳細不明。ダイアログは出る。
                //エラーログ→アクセスが拒否されました。 （HRESULTからの例外：0x80070005（E_ACCESSDENIED））
            }

        }


        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。
        /// このプロパティは、通常、ページを構成するために使用します。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: ここに表示するページを準備します。

            // TODO: アプリケーションに複数のページが含まれている場合は、次のイベントの
            // 登録によりハードウェアの戻るボタンを処理していることを確認してください:
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed イベント。
            // 一部のテンプレートで指定された NavigationHelper を使用している場合は、
            // このイベントが自動的に処理されます。
        }
    }
}
