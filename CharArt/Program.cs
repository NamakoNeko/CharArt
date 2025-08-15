using System.Drawing;
using System.Text;
using System.Threading.Tasks;

public class CharArt
{
    static readonly string ASSET_ROOT = Path.Combine("..", "..", "..");
    static readonly string CONFIG_FILE_PATH = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, ASSET_ROOT, "Config.txt"));
    static readonly int DOT_LOOP_LIMIT = 10;
    static string IMAGE_PATH = string.Empty;
    static string OUTPUT_FILE_PATH = string.Empty;
    static int performanceResize = 150;
    static int outputResize = 500;
    static int grayScaleLevel = 200;
    static string character = "@";
    static double delayMilliseconds = 50;

    public static async Task Main(string[] args)
    {
        Initialize();

        if (File.Exists(IMAGE_PATH))
        {
            var bitMap = new Bitmap(IMAGE_PATH);
            await Performance(new Bitmap(bitMap, new Size(performanceResize, GetNewHeight(bitMap, performanceResize))));
            Output(new Bitmap(bitMap, new Size(outputResize, GetNewHeight(bitMap, outputResize))));
        }
        else
        {
            Console.WriteLine("獲取圖片失敗");
        }
        
        Console.WriteLine("按任意鍵結束程式...");
        Console.ReadKey();
    }

    public static async Task Performance(Bitmap reSizeBitMap)
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

        var firstCharFinish = false;
        var picWriteChar = string.Empty;
        for (var height = 0; height < reSizeBitMap.Height; height++)
        {
            for (var width = 0; width < reSizeBitMap.Width; width++)
            {
                var colorOfPixel = reSizeBitMap.GetPixel(width, height);
                var grayScale = (colorOfPixel.R + colorOfPixel.G + colorOfPixel.B) / 3;
                picWriteChar = grayScale < grayScaleLevel ? character : " ";
                firstCharFinish |= grayScale < grayScaleLevel;

                Console.Write(picWriteChar);
                Console.Write(" ");
            }

            if (firstCharFinish)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(delayMilliseconds));
            }
            Console.WriteLine("");
        }
    }

    public static void Initialize()
    {
        if (File.Exists(CONFIG_FILE_PATH))
        {
            using (StreamReader reader = new StreamReader(CONFIG_FILE_PATH))
            {
                while (!reader.EndOfStream)
                {
                    var configDatas = reader.ReadLine()?.Split("=");
                    if (configDatas != null)
                    {
                        if (!string.IsNullOrEmpty(configDatas[1]))
                        {
                            switch (configDatas[0])
                            {
                                case "OutputPath":
                                    OUTPUT_FILE_PATH = Path.Combine(configDatas[1]);
                                    break;
                                case "PerformanceResizeWidth":
                                    if (int.TryParse(configDatas[1], out var performanceRewidth))
                                    {
                                        performanceResize = performanceRewidth;
                                    }
                                    break;
                                case "OutputResizeWidth":
                                    if (int.TryParse(configDatas[1], out var outpurRewidth))
                                    {
                                        outputResize = outpurRewidth;
                                    }
                                    break;
                                case "GrayScale":
                                    if (int.TryParse(configDatas[1], out var _grayScaleLevel))
                                    {
                                        grayScaleLevel = _grayScaleLevel;
                                    }
                                    break;
                                case "DelayMilliseconds":
                                    if (double.TryParse(configDatas[1], out var _delayMilliseconds))
                                    {
                                        delayMilliseconds = _delayMilliseconds;
                                    }
                                    break;
                                case "Char":
                                    character = configDatas[1];
                                    break;
                            }
                        }
                    }
                }
            }
        }

        var imageFolderPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, ASSET_ROOT, "Image"));
        var imageName = string.Empty;
        if (Directory.Exists(imageFolderPath))
        {
            var imageExtensions = new[] { "*.png", "*.jpg", "*.jpeg", "*.bmp", "*.gif" };

            foreach (var imageType in imageExtensions)
            {
                var files = Directory.GetFiles(imageFolderPath, imageType, SearchOption.TopDirectoryOnly);
                if (files?.Any() ?? false)
                {
                    IMAGE_PATH = Path.Combine(imageFolderPath, Path.GetFileName(files[0]));
                    imageName = Path.GetFileNameWithoutExtension(files[0]);
                }
            }
        }

        if (string.IsNullOrEmpty(imageName))
        {
            Console.WriteLine("指定路徑的資料夾沒有圖片");
            return;
        }

        if (string.IsNullOrEmpty(OUTPUT_FILE_PATH))
        {
            var outputFolderPath = Path.Combine(AppContext.BaseDirectory, ASSET_ROOT, "Output");
            if (!Directory.Exists(outputFolderPath))
            {
                Directory.CreateDirectory(outputFolderPath);
            }

            OUTPUT_FILE_PATH = Path.Combine(outputFolderPath, string.Format("{0}{1}", imageName , ".txt"));
        }

        if (File.Exists(OUTPUT_FILE_PATH))
        {
            File.Delete(OUTPUT_FILE_PATH);
        }
    }

    public static void Output(Bitmap resizeBitmap)
    {
        try
        {
            var stringBuilder = new StringBuilder();
            for (var height = 0; height < resizeBitmap.Height; height++)
            {
                for (var width = 0; width < resizeBitmap.Width; width++)
                {
                    var colorOfPixel = resizeBitmap.GetPixel(width, height);
                    var grayScale = (colorOfPixel.R + colorOfPixel.G + colorOfPixel.B) / 3;
                    var pixelWriteChar = grayScale < grayScaleLevel ? character : " ";

                    stringBuilder.Append(pixelWriteChar);
                    stringBuilder.Append(" ");
                }

                stringBuilder.AppendLine();
            }

            File.WriteAllText(OUTPUT_FILE_PATH, stringBuilder.ToString());
            var dotLoopTime = 0;
            while (dotLoopTime++ < DOT_LOOP_LIMIT)
            {
                Console.WriteLine(".");
            }

            Console.WriteLine($"檔案輸出成功，路徑: {Path.GetFullPath (OUTPUT_FILE_PATH)}");
        }
        catch
        {
            Console.WriteLine("無效的輸出路徑");
        }
    }

    public static int GetNewHeight(Bitmap bitmap, int resize)
    {
        var aspectRatio = (double)bitmap.Height / bitmap.Width;
        return (int)(resize * aspectRatio);
    }
}