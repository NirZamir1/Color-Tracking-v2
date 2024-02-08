using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Drawing;
using FastBitmapLib;

namespace Color_Tracking_v2
{
    public struct point
    {
        public point(int x ,int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x;
        public int y;
    }
    public partial class Form1 : Form
    {
        private VideoCaptureDevice source;
        private FilterInfoCollection videoDevices;
        private int width;
        private int height;
        private float fhue;
        private float ihue;
        private float satb;
        private float brightness;
        List<point> points;
        float d_degConstant;
        public Form1()
        {
            points = new List<point>();
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                source = new VideoCaptureDevice(videoDevices[0].MonikerString);
                var max = source.VideoCapabilities[0];
                foreach(var res in source.VideoCapabilities)
                {
                    if (max.FrameSize.Width < res.FrameSize.Width)
                    {
                        max = res;
                    }
                }
                source.VideoResolution = max;
                width = source.VideoResolution.FrameSize.Width;
                height = source.VideoResolution.FrameSize.Height;
                d_degConstant = (float) 68.5f / width;
                source.NewFrame += New_Frame;
                source.Start();
            }
        }
        
        private void New_Frame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            frame.RotateFlip(RotateFlipType.RotateNoneFlipX);//mirro
           
            getMask((Bitmap)frame.Clone(), ihue, fhue, out point avg);// mask : a picture which contains only the wanted pixels in white color
            
            float average = AveragePointDistance(points, avg)/2;
            using (Graphics g = Graphics.FromImage(frame))
            {
                Pen pen = new Pen(Color.Red);
                g.DrawEllipse(pen, avg.x-5, avg.y-5, 10, 10);
            }
            FastBitmap m2 = new FastBitmap(frame.Width, frame.Height);
            //taking the average of the sorted points for more accuracy
            //taking the max of x and max of y to build a bounding rectangle
            int count = 0;
            point mid = new point(0, 0);
            int max_X = 0;
            int max_Y = 0;
            for(int i = 0; i < points.Count(); i++)
            {
                if (DistancePointFunction(points[i],avg) < average*2)
                {
                    m2.SetPixel(points[i].x, points[i].y, Color.White);
                    mid.x += points[i].x;
                    mid.y += points[i].y;
                    max_X = Math.Max(max_X, points[i].x);
                    max_Y = Math.Max(max_Y, points[i].y);
                    count++;
                }
            }
            if (count > 0)
            {
                mid.x = mid.x / count;
                mid.y = mid.y / count;
            }
            int a = (max_X - mid.x);
            int b = (max_Y - mid.y);
            using (Graphics g = Graphics.FromImage(frame))
            {
                Pen pen = new Pen(Color.Orange);
                g.DrawRectangle(pen, mid.x-a/2, mid.y-b/2, a, b);
            }
            PictureBox2.Image = m2;
            float diagonalAngle = mid.x * d_degConstant;
            Console.WriteLine(diagonalAngle);
            //mid is the correct point
            
        }
        FastBitmap DrawMask(IEnumerable<point> points, Color color , int width, int height)
        {
            FastBitmap m = new FastBitmap(width, height);
            foreach(point point in points)
            {
                m.SetPixel(point.x, point.y, color);
            }
            return m;
        }
        float DistancePointFunction(point p1, point p2) => MathF.Sqrt(MathF.Pow(p1.x - p2.x, 2) + MathF.Pow(p1.y - p2.y,2));
        float AveragePointDistance(IEnumerable<point> points, point point)
        {
            float average = 0;
            foreach(point p in points)
            {
                average += DistancePointFunction(point, p);
            }
            average = average / points.Count();
            return average;
        }
        void getMask(Bitmap Frame, double HueI, double HueF, out point avg)
        {
            avg.y = 0;
            avg.x = 0;
            points.Clear();
            float hue;
            float sat;
            float lightness;
            //---------------------------
            //using hsl color format
            // hue, saturation, lightness
            //---------------------------
            //FastBitmap fastframe = frame;
            
            for (int x = 0; x < width; x+=10)
            {
                for (int y = 0; y < height; y+=10)
                {
                    Color color = Frame.GetPixel(x, y);
                    lightness = color.GetBrightness();
                    hue = color.GetHue();
                    sat = color.GetSaturation();
                    if (hue < HueF && hue > HueI && sat > satb && lightness > brightness  && lightness < 0.65)
                    {
                        points.Add(new point(x,y));
                        avg.x += x;
                        avg.y += y;
                    }
                }
            }
            if (points.Count() > 0)
            {
                avg.x = avg.x / points.Count();
                avg.y = avg.y / points.Count();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FHueBar_Scroll(object sender, ScrollEventArgs e)
        {
            //Console.WriteLine($"Fhue bar val: {FHueBar.Value}");
            fhue = FHueBar.Value * ((float)360 / 100);

            FhueText.Text ="Finale hue:"+ fhue;

        }
        private void IHueBar_Scroll(object sender, ScrollEventArgs e)
        {
            ihue = IHueBar.Value * ((float)360 / 100);

            IHueText.Text = "Intial hue:" + ihue;

        }

        private void SatBar_Scroll(object sender, ScrollEventArgs e)
        {
            satb =(float) SatBar.Value / 100;
            SatText.Text = "Sat:" + satb;
        }

        private void LightnessBar_Scroll(object sender, ScrollEventArgs e)
        {
            brightness = (float)LightnessBar.Value / 100;
            lightText.Text = "Lightness:"+ brightness;
        }

        private void FhueText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}