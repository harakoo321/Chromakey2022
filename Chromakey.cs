using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Chromakey2022
{
    internal class Chromakey
    {
        public bool flgFlip = false;
        public int bgIndex = 0;
        public int Hlow = 40, Hup = 80, Slow = 80, Sup = 255, Vlow = 50, Vup = 255;
        public double Scale = 1.0, Rotate = 0.0, TransX = 0.0, TransY = 0.0;
        private List<Mat> bgList = new List<Mat>();
        private int cntCam = 0, cntBg = 0; //カメラの個数,背景の個数
        private bool flgRun = false;
        private bool flgCap = false;
        private int cam1, cam2;
        private Bitmap bmp;

        public Chromakey()  //コンストラクタ
        {
            using (VideoCapture cap = new VideoCapture())
            {
                while (true)    //カメラ接続台数確認
                {
                    if (!cap.Open(cntCam))
                    {
                        break;
                    }
                    cntCam++;
                }
            }
        }

        public void Run(int cam1, int cam2)
        {
            flgRun = true;
            this.cam1 = cam1;
            this.cam2 = cam2;
            Thread th1 = new Thread(new ThreadStart(Capture));
            th1.Start(); //スレッドの起動
        }

        public int Numofcam()   //カメラの接続台数を返す
        {
            return cntCam;
        }

        public void SetBackground(string path)   //背景画像を可変長配列bglistに追加
        {
            bgList.Add(Cv2.ImRead(path));
        }

        public void RemoveBackground(int selectedIndex) //指定した背景画像の削除
        {
            bgList.RemoveAt(selectedIndex);
        }

        public void Stop()  //flgRunフラグをfalseにセット
        {
            flgRun = false;
        }

        public Bitmap GetImage()   //flgCapフラグをtrueにセット後、Bitmap画像を返す
        {
            flgCap = true;
            while (flgCap) { }  //flgCapがfalseになるまで待つ
            using (Bitmap bitmap = (Bitmap)bmp.Clone())
            {
                bmp.Dispose();
                return bitmap;
            }
        }

        private void Capture()
        {
            flgRun = true;

            VideoCapture cap1 = new VideoCapture(cam1);
            if(!cap1.IsOpened())
            {
                return;
            }

            VideoCapture cap2 = new VideoCapture(cam2);
            Mat temp = new Mat();

            if(cam2 != -1)
            {
                cap2.Open(cam2);
                if (cap2.IsOpened())
                {
                    cap2.Read(temp);
                    bgList.Add(temp);
                }
            }

            var sw = new System.Diagnostics.Stopwatch();

            while (flgRun)
            {
                sw.Restart(); //処理時間の計測開始

                Mat flame = new Mat(); //カメラ画像
                Mat showImg = new Mat(); //最終的に表示する画像
                Mat flipImg = new Mat(); //最終的に表示する反転画像

                //カメラからフレームを取得
                cap1.Read(flame);
                cap2.Read(temp);

                double resizeRatio = (double)flame.Width / (double)bgList[bgIndex].Width;  //背景画像をカメラの横幅に合わせるための倍率の算出

                if (resizeRatio <= 0) { //カメラが切断されたらresizeRatioが0になる
                    MessageBox.Show("カメラが切断されました。", "エラー", MessageBoxButtons.OK);
                    break;
                }
                
                Cv2.Resize(bgList[bgIndex], showImg, new OpenCvSharp.Size(), resizeRatio, resizeRatio); //リサイズした背景画像の取得
                Mat transformedFlame = TransformMat(flame, showImg.Height, showImg.Width); //取得したフレームの回転、縮小・拡大、移動
                Mat maskImg = GetMask2(transformedFlame); //マスクの作成（緑部分を黒、それ以外を白）
                //Cv2.ImShow("ChromakeySrc", transformedFlame);
                //Cv2.ImShow("ChromakeyMask", maskImg);

                transformedFlame.CopyTo(showImg, maskImg); //マスク処理：元の画像、背景画像、マスクを合わせる
                if(flgFlip) Cv2.Flip(showImg, showImg, FlipMode.Y); //反転がオンの場合反転

                Cv2.Flip(showImg, flipImg, FlipMode.Y);
                Cv2.ImShow("ChromakeyFlip", flipImg); //showImgの反転画像の表示
                Cv2.ImShow("Chromakey", showImg); //最終的な画像の表示

                if(flgCap)  //キャプチャー
                {
                    bmp = BitmapConverter.ToBitmap(showImg); //ビットマップ画像の取得
                    flgCap = false;
                }

                Cv2.WaitKey(1);

                //以下リソースの解放
                flame.Dispose();
                maskImg.Dispose();
                showImg.Dispose();
                flipImg.Dispose();
                transformedFlame.Dispose();

                sw.Stop(); //計測終了
                Console.WriteLine(1 / (sw.ElapsedMilliseconds * 0.001)); //フレームレートの算出
            }
            Cv2.DestroyAllWindows();
            cap1.Dispose();
            cap2.Dispose();
        }

        private Mat TransformMat(Mat src, int height, int width)
        {
            Mat dst = new Mat(height, width, src.Type(), new Scalar(0, 255, 0)); //緑で塗りつぶした画像
            Mat temp = Cv2.GetRotationMatrix2D(new Point2f(src.Cols / 2, src.Rows / 2), Rotate, Scale);  //flameの中心座標の取得し、回転後の座標を取得 引数:中心、回転角度、大きさ
            
            temp.At<double>(0, 2) += TransX; //x方向への移動
            temp.At<double>(1, 2) += TransY; //y方向への移動
            
            Cv2.WarpAffine(src, dst, temp, new OpenCvSharp.Size(width, height), InterpolationFlags.Linear, BorderTypes.Transparent); //アフィン変換 (元画像、変換後画像、変換行列、大きさ、補完方法、ピクセル外挿方法)
            
            temp.Dispose();
            return dst;
        }

        private Mat GetMask(Mat src) //ポインタを使った方法
        {
            Mat temp = src.Clone(); //カメラ画像
            Mat dst = new Mat(temp.Rows, temp.Cols, MatType.CV_8UC3, new Scalar(255, 255, 255)); //黒の画像を用意
            Cv2.MedianBlur(temp, temp, 7); //ブラー処理
            Cv2.CvtColor(temp, temp, ColorConversionCodes.BGR2HSV); //HSV変換

            unsafe
            {
                byte* temp_px = temp.DataPointer;
                byte* mask_px = dst.DataPointer;
                for (int y = 0; y < temp.Rows; y++)
                {
                    for (int x = 0; x < temp.Cols; x++)
                    {
                        //透過させる色の範囲内かどうか1ピクセルずつ判定する
                        if (temp_px[0] >= Hlow && temp_px[0] <= Hup &&
                            temp_px[1] >= Slow && temp_px[1] <= Sup &&
                            temp_px[2] >= Vlow && temp_px[2] <= Vup)
                        {
                            //範囲内であればHue,Saturation,Valueを0にし、白にする
                            mask_px[0] = 0x00;
                            mask_px[1] = 0x00;
                            mask_px[2] = 0x00;
                        }
                        //ピクセル1つ分ポインタを進める
                        temp_px += 3;
                        mask_px += 3;
                    }
                }
            }
            temp.Dispose();
            return dst;
        }

        private Mat GetMask2(Mat src) //InRange()とBitwiseNot()を使った方法(こっちが高速)
        {
            Mat dst = src.MedianBlur(7); //ブラー処理
            Cv2.CvtColor(dst, dst, ColorConversionCodes.BGR2HSV); //HSVに変換
            Cv2.InRange(dst, new Scalar(Hlow, Slow, Vlow), new Scalar(Hup, Sup, Vup), dst); //指定した色の範囲内の部分を黒、それ以外を白にする
            Cv2.BitwiseNot(dst, dst); //行列のすべてのビットをを反転させる
            return dst;
        }
    }
}
