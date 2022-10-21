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
        private List<string> bgpath = new List<string>();
        private int cntCam = 0, cntBg = 0; //カメラの個数,背景の個数
        private bool flgRun = false;
        private bool flgCap = false;
        private int cam1, cam2;
        private Bitmap bmp;

        public Chromakey()
        {
            using (VideoCapture cap = new VideoCapture())
            {
                cntCam = 0;
                while (true)    //カメラ接続台数確認
                {
                    cap.Open(cntCam);
                    if (cap.IsOpened() == false)
                    {
                        break;
                    }
                    cntCam++;
                }
            }
        }

        public void run(int cam1, int cam2)
        {
            flgRun = true;
            this.cam1 = cam1;
            this.cam2 = cam2;
            Thread th1 = new Thread(new ThreadStart(capture));
            th1.Start();
        }

        public int numofcam()   //カメラの接続台数を返す
        {
            return cntCam;
        }

        public void setbgpath(string str)   //背景画像のパスを可変長配列bgpathに追加
        {
            bgpath.Add(str);
        }

        public void stop()  //flgRunフラグをfalseにセット
        {
            flgRun = false;
        }

        public Bitmap image()   //flgCapフラグをtrueにセット後、スレッドを100ミリ秒停止し、Bitmap画像を返す
        {
            flgCap = true;
            Thread.Sleep(100);
            return bmp;
        }

        private void capture()
        {
            flgRun = true;
            List<Mat> bg = new List<Mat>();
            for(int i = 0; i < bgpath.Count; i++)
            {
                bg.Add(Cv2.ImRead(bgpath[i]));  //背景画像をMat型の可変長配列bgに追加
            }

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
                    bg.Add(temp);
                }
            }

            while (flgRun)
            {
                Mat src_img = new Mat(); //カメラ画像
                Mat mask = new Mat(); //マスク画像（緑部分を黒、それ以外を白）
                Mat comp; //背景画像
                Mat img = new Mat(); //最終的に表示する画像
                Mat flipImg = new Mat(); //最終的に表示する反転画像

                //カメラからフレームを取得
                cap1.Read(src_img);
                cap2.Read(temp);

                Mat src_img2 = new Mat(src_img.Rows, src_img.Cols, src_img.Type(), new Scalar(0,255,0)); //緑で塗りつぶした画像
                Point2f ctr = new Point2f(src_img.Cols / 2, src_img.Rows / 2);  //src_imgの中心座標の取得
                Mat mat = Cv2.GetRotationMatrix2D(ctr, Rotate, Scale);  //中心、回転角度、大きさ
                mat.At<double>(0, 2) += TransX;
                mat.At<double>(1, 2) += TransY;
                Cv2.WarpAffine(src_img, src_img2, mat, src_img2.Size(), InterpolationFlags.Linear, BorderTypes.Transparent); //アフィン変換 (元画像、変換後画像、変換行列、大きさ、補完方法、ピクセル外挿方法)

                mask = setMask(src_img2);//マスクの作成

                comp = bg[bgIndex].Clone(); //背景画像の取得（準備した画像、または、カメラ2からとってきた画像）

                src_img2.CopyTo(comp, mask);//マスク処理：元の画像、背景画像、マスクを合わせる
                if(flgFlip) Cv2.Flip(comp, img, FlipMode.Y);
                else img = comp.Clone();

                Cv2.Flip(comp, flipImg, FlipMode.Y);
                Cv2.ImShow("ChromakeyFlip", flipImg); //反転画像
                Cv2.ImShow("Chromakey", img); //最終的な画像
                //Mat ipl = comp; //OpenCVの画像データを管理している構造体
                //下記コードを処理中にimage()メソッドが実行されるとエラーが起こる
                bmp = new Bitmap(comp.Cols, comp.Rows, (int)comp.Step(), System.Drawing.Imaging.PixelFormat.Format24bppRgb, comp.Data);

                Cv2.WaitKey(1);

                src_img.Dispose();
                mask.Dispose();
                comp.Dispose();
                img.Dispose();
                flipImg.Dispose();
                src_img2.Dispose();
                mat.Dispose();
            }
            cap1.Dispose();
            cap2.Dispose();
        }

        private Mat setMask(Mat src_img)
        {
            Mat temp = src_img.Clone();
            Mat img = new Mat(480, 640, MatType.CV_8UC3, new Scalar(255, 255, 255));
            Cv2.MedianBlur(temp, temp, 7);
            Cv2.CvtColor(temp, temp, ColorConversionCodes.BGR2HSV); //HSV変換

            unsafe
            {
                byte* temp_px = temp.DataPointer;
                byte* img_px = img.DataPointer;
                for (int y = 0; y < 480; y++)
                {
                    for (int x = 0; x < 640; x++)
                    {
                        if (temp_px[0] >= Hlow && temp_px[0] <= Hup &&
                            temp_px[1] >= Slow && temp_px[1] <= Sup &&
                            temp_px[2] >= Vlow && temp_px[2] <= Vup)
                        {
                            img_px[0] = 0x00;
                            img_px[1] = 0x00;
                            img_px[2] = 0x00;
                        }
                        temp_px += 3;
                        img_px += 3;
                    }
                }
            }

            /*for (int y = 0; y < 480; y++)
            {
                for (int x = 0; x < 640; x++)
                {
                    Vec3b temp_px = temp.At<Vec3b>(y, x);
                    Vec3b img_px = img.At<Vec3b>(y, x);
                    if (temp_px[0] >= Hlow && temp_px[0] <= Hup &&
                        temp_px[1] >= Slow && temp_px[1] <= Sup &&
                        temp_px[2] >= Vlow && temp_px[2] <= Vup)
                    {
                        img_px[0] = 0x00;
                        img_px[1] = 0x00;
                        img_px[2] = 0x00;
                    }
                    img.Set(y, x, img_px);
                }
            }*/

            temp.Dispose();
            return img;
        }
    }
}
