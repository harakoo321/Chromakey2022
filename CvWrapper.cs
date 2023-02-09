using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

//OpenCVSharpのラッパー
namespace Chromakey2022.CvWrapper
{
    internal class VideoCapture
    {
        OpenCvSharp.VideoCapture videoCapture;
        public VideoCapture() {
            videoCapture = new OpenCvSharp.VideoCapture();
        }

        public VideoCapture(int index)
        {
            videoCapture = new OpenCvSharp.VideoCapture(index);
        }

        public bool Open(int index)
        {
            return videoCapture.Open(index);
        }

        public bool IsOpened()
        {
            return videoCapture.IsOpened();
        }

        public bool Read(Mat image)
        {
            return videoCapture.Read(image.CVMat);
        }

        public void Dispose()
        {
            videoCapture.Dispose();
        }
    }

    internal class Mat
    {
        OpenCvSharp.Mat mat;
        public Mat()
        {
            mat = new OpenCvSharp.Mat();
        }

        public Mat(OpenCvSharp.Mat mat)
        {
            this.mat = mat;
        }

        public Mat(int rows, int cols, Mat type, double s1, double s2, double s3)
        {
            mat = new OpenCvSharp.Mat(rows, cols, type.CVMat.Type(), new Scalar(s1, s2, s3));
        }

        public OpenCvSharp.Mat CVMat
        {
            get { return mat; }
        }

        public int Width
        {
            get { return mat.Width; }
        }

        public int Height
        {
            get { return mat.Height; }
        }

        public void CopyTo(Mat dst, Mat mask)
        {
            mat.CopyTo(dst.CVMat, mask.CVMat);
        }

        public Mat Clone()
        {
            return new Mat(mat.Clone());
        }

        public ref double At<T>(int i0, int i1)
        {
            return ref mat.At<double>(i0, i1);
        }

        public Mat MedianBlur(int ksize)
        {
            return new Mat(mat.MedianBlur(ksize));
        }

        public void Dispose()
        {
            mat.Dispose();
        }
    }

    internal static class Cv2
    {
        public static Mat ImRead(string fileName)
        {
            return new Mat(OpenCvSharp.Cv2.ImRead(fileName));
        }

        public static void Resize(Mat src, Mat dst, double fx, double fy)
        {
            OpenCvSharp.Cv2.Resize(src.CVMat, dst.CVMat, new OpenCvSharp.Size(), fx, fy);
        }

        public static void FlipY(Mat src, Mat dst)
        {
            OpenCvSharp.Cv2.Flip(src.CVMat, dst.CVMat, FlipMode.Y);
        }

        public static void WaitKey(int delay)
        {
            OpenCvSharp.Cv2.WaitKey(delay);
        }

        public static void ImShow(string winName, Mat mat)
        {
            OpenCvSharp.Cv2.ImShow(winName, mat.CVMat);
        }

        public static void DestroyAllWindows()
        {
            OpenCvSharp.Cv2.DestroyAllWindows();
        }

        public static void CvtColorHSVToBGR(Mat src, Mat dst)
        {
            OpenCvSharp.Cv2.CvtColor(src.CVMat, dst.CVMat, ColorConversionCodes.HSV2BGR);
        }

        public static void CvtColorBGRToHSV(Mat src, Mat dst)
        {
            OpenCvSharp.Cv2.CvtColor(src.CVMat, dst.CVMat, ColorConversionCodes.BGR2HSV);
        }

        public static Mat GetRotationMatrix2D(float centerX, float centerY, double angle, double scale)
        {
            return new Mat(OpenCvSharp.Cv2.GetRotationMatrix2D(new Point2f(centerX, centerY), angle, scale));
        }

        public static void WarpAffine(Mat src, Mat dst, Mat m, int width, int height)
        {
            OpenCvSharp.Cv2.WarpAffine(src.CVMat, dst.CVMat, m.CVMat, new OpenCvSharp.Size(width, height), InterpolationFlags.Linear, BorderTypes.Transparent);
        }

        public static void InRange(Mat src, double lowH, double lowS, double lowV, double upH, double upS, double upV, Mat dst)
        {
            OpenCvSharp.Cv2.InRange(src.CVMat, new Scalar(lowH, lowS, lowV), new Scalar(upH, upS, upV), dst.CVMat);
        }

        public static void BitwiseNot(Mat src, Mat dst)
        {
            OpenCvSharp.Cv2.BitwiseNot(src.CVMat, dst.CVMat);
        }
    }

    internal static class BitmapConverter
    {
        public static Bitmap ToBitmap(Mat src)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src.CVMat);
        }
    }
}
