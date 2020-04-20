# How to run videos in CefSharp based Browser Window using the HTML Video Tag

### Problem
CEF and subsequently [CefSharp](https://github.com/cefsharp/CefSharp/wiki/General-Usage#multimedia-audiovideo) only supports __freely available__ audio and video codecs. It cannot play .mp4 videos directly in the web pages.
To overcome this, the sample shows how anyone can convert .mp4 to [WebM](https://en.wikipedia.org/wiki/WebM) format
and also add subtitles (Text) to any video and subsequently render it using [HTML Video tag](https://www.w3schools.com/html/tryit.asp?filename=tryhtml5_video) in the CefSharp browser.

### How does it convert videos to WebM format ?
It uses a freely available tool called [FFmpeg](https://www.ffmpeg.org/download.html) to convert .mp4 to webm format.
You may further read about the FFmpeg license [here](https://www.ffmpeg.org/legal.html) and [here](https://video.stackexchange.com/a/14804).

### What is the command used to convert .mp4 to webm
Refer the documentation here - https://trac.ffmpeg.org/wiki/Encode/VP9

```ffmpeg -i myMp4Video.mp4 outputvideo.webm``` 

### How to add subtitles to the Video during conversion ?
[FFmpeg](https://trac.ffmpeg.org/) has the concept of [filters](https://trac.ffmpeg.org/wiki/HowToBurnSubtitlesIntoVideo).

Simply feed in a subtitle file of the format `.ass` - [Advanced Substation Alpha](https://www.matroska.org/technical/specs/subtitles/ssa.html) to ffmpeg on the command line.

__NB:__ Following command will convert to webm and also add subtitles as well.
```ffmpeg -y -i myMp4Video.mp4 -vf subtitles=mySubtitlefile.ass outputvideo.webm```

#### How to generate the subtitles (.ass) file ?
You can manually do it by hand using any text editor using the documentation [here](https://www.matroska.org/technical/specs/subtitles/ssa.html).

_OR_

After doing it manually, I found this handy tool - http://www.aegisub.org/downloads/, which allows you to modify / generate `.ass` file quite easily. Just play around, it's quite simple to use.

## Project overview
- Just download the project and build it using Visual Studio Editor. You may be required to [Restore the NuGet Packages](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore#restore-packages-automatically-using-visual-studio). I used VS2019 and v[79.1.36](https://github.com/cefsharp/CefSharp/releases/tag/v79.1.360) of CefSharp
- It generates the WebM format video on the fly. In the __post-build event__, I generate the WebM video from the sample mp4 video in the project
     -  `$(ProjectDir)ffmpeg\ffmpeg.exe -y -i $(ProjectDir)mp4\MySpaceVideo.mp4  -vf  subtitles=subtitle.ass  $(TargetDir)MySpaceVideo.webm`
     -  This also enables you to embed this logic into your build pipeline.
- You may notice, build _takes time_ to build because it generates the webm file with subtitles from the mp4 file in the post-build event using FFmpeg.exe
- `subtitle.ass` file in the project contains the subtitles which are applied at various frame intervals.
- Original mp4 video does not contain the subtitles. Only the generated webm video contains subtitles.
- `Video.html` file loads the generated WebM video file into the HTML [Video](https://www.w3schools.com/html/html5_video.asp) Tag.
- `MainWindow.xaml` file loads the Html file into the CefSharp browser window.
- __Output__ is in `bin/debug` folder. You will see the generated video named `MySpaceVideo.webm` alongwith the project's output exe file. 
You can also double-click the `CefSharp_Video_Sample.exe` file and run it from there directly.

###### NB: I used Paint3D on Windows 10 to generate the sample mp4 video. The background image in the video was randomly [googled](https://images.app.goo.gl/1fY1yZoR1Tajq44r9).

Happy Coding :)
