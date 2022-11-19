using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        private List<Mat> bglist = new List<Mat>();
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
            th1.Start();
        }

        public int Numofcam()   //カメラの接続台数を返す
        {
            return cntCam;
        }

        public void SetBackground(string path)   //背景画像を可変長配列bglistに追加
        {
            bglist.Add(Cv2.ImRead(path));
        }

        public void Stop()  //flgRunフラグをfalseにセット
        {
            flgRun = false;
        }

        public Bitmap Image()   //flgCapフラグをtrueにセット後、Bitmap画像を返す
        {
            flgCap = true;
            while (flgCap) { }  //flgCapがfalseになるまで待つ
            Bitmap bitmap = (Bitmap)bmp.Clone();
            bmp.Dispose();
            return bitmap;
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
                    bglist.Add(temp);
                }
            }

            while (flgRun)
            {
                Mat flame = new Mat(); //カメラ画像
                Mat mask; //マスク画像（緑部分を黒、それ以外を白）
                Mat img = new Mat(); //最終的に表示する画像
                Mat flipImg = new Mat(); //最終的に表示する反転画像

                //カメラからフレームを取得
                cap1.Read(flame);
                cap2.Read(temp);

                double resize_ratio = (double)flame.Width / (double)bglist[bgIndex].Width;  //背景画像をカメラの横幅に合わせるための倍率の算出
                Cv2.Resize(bglist[bgIndex], img, new OpenCvSharp.Size(), resize_ratio, resize_ratio); //  リサイズした背景画像の取得

                Mat converted_flame = new Mat(img.Rows, img.Cols, img.Type(), new Scalar(0,255,0)); //緑で塗りつぶした画像

                Point2f ctr = new Point2f(flame.Cols / 2, flame.Rows / 2);  //flameの中心座標の取得
                Mat mat = Cv2.GetRotationMatrix2D(ctr, Rotate, Scale);  //回転後の座標を取得 引数:中心、回転角度、大きさ
                mat.At<double>(0, 2) += TransX; //x方向への移動
                mat.At<double>(1, 2) += TransY; //y方向への移動
                Cv2.WarpAffine(flame, converted_flame, mat, img.Size(), InterpolationFlags.Linear, BorderTypes.Transparent); //アフィン変換 (元画像、変換後画像、変換行列、大きさ、補完方法、ピクセル外挿方法)

                mask = GetMask(converted_flame);//マスクの作成
                //mask = converted_flame.MedianBlur(7).CvtColor(ColorConversionCodes.BGR2HSV).InRange(new Scalar(Hlow, Slow, Vlow), new Scalar(Hup, Sup, Vup));
                //Cv2.BitwiseNot(mask, mask);

                converted_flame.CopyTo(img, mask);//マスク処理：元の画像、背景画像、マスクを合わせる
                if(flgFlip) Cv2.Flip(img, img, FlipMode.Y);

                Cv2.Flip(img, flipImg, FlipMode.Y);
                //Cv2.NamedWindow("Chromakey", WindowFlags.KeepRatio);
                //Cv2.NamedWindow("ChromakeyFlip", WindowFlags.KeepRatio);
                Cv2.ImShow("ChromakeyFlip", flipImg); //反転画像
                Cv2.ImShow("Chromakey", img); //最終的な画像

                if(flgCap)  //キャプチャー
                {
                    bmp = BitmapConverter.ToBitmap(img);
                    flgCap = false;
                }

                Cv2.WaitKey(1);

                //以下リソースの解放
                flame.Dispose();
                mask.Dispose();
                img.Dispose();
                flipImg.Dispose();
                converted_flame.Dispose();
                mat.Dispose();
            }
            cap1.Dispose();
            cap2.Dispose();
        }

        private Mat GetMask(Mat src_img)
        {
            Mat temp = src_img.Clone(); //カメラ画像
            Mat mask = new Mat(temp.Rows, temp.Cols, MatType.CV_8UC3, new Scalar(255, 255, 255));
            Cv2.MedianBlur(temp, temp, 7);
            Cv2.CvtColor(temp, temp, ColorConversionCodes.BGR2HSV); //HSV変換

            unsafe
            {
                byte* temp_px = temp.DataPointer;
                byte* mask_px = mask.DataPointer;
                for (int y = 0; y < temp.Rows; y++)
                {
                    for (int x = 0; x < temp.Cols; x++)
                    {
                        if (temp_px[0] >= Hlow && temp_px[0] <= Hup &&
                            temp_px[1] >= Slow && temp_px[1] <= Sup &&
                            temp_px[2] >= Vlow && temp_px[2] <= Vup)
                        {
                            mask_px[0] = 0x00;
                            mask_px[1] = 0x00;
                            mask_px[2] = 0x00;
                        }
                        temp_px += 3;
                        mask_px += 3;
                    }
                }
            }
            temp.Dispose();
            return mask;
        }
    }
}
