<img src="https://pbs.twimg.com/profile_images/935813842680143872/h7kvfYe6_400x400.jpg" width="150">

# DVT Weather App

|   |   |
| ------ | ------ |
| Software:  | Xamarin Forms|
| Framework: | Prism with Unity |
| Version: | "version": "3.3" |
| Platforms: | ANDROID and IOS | 

## Getting Started

### Install Visual Studio 2015

VS 2015 is required for developing Xamarin.Forms. If you do not already have it installed, you can download it [here](https://www.visualstudio.com/downloads/download-visual-studio-vs). VS 2015 Community is completely free. If you are installing VS 2015 for the first time, select the "Custom" installation type and select the following from the features list to install:

-C#/.NET (Xamarin v4.0.3)
-Android Studio
-Xcode

We also recommend installing [Microsoft Visual Studio Emulator for Android](https://www.visualstudio.com/en-us/features/msft-android-emulator-vs.aspx) as well as [Emulators for Windows Phone 8.1](https://www.microsoft.com/en-us/download/details.aspx?id=44574). If you already have VS 2015 installed, you can verify that these features are installed by modifying the VS 2015 installation via the Control Panel.

### Install Additional Features

After installing VS 2015, you will also need to install the following:

you can install these via `Tools > Android > Android SDK Manager`.
-Android SDK

### Solution Configuration

Upon opening the Xamarin.Forms solution, you will find that there are a number of errors and warnings under the Error List pane; you can resolve this by changing the filter of `Build + IntelliSense` to `Build Only`. At this point, you should be able to successfully build the solution.

# Task

1) You are required to implement one of 2 designs, the Forest design or the Sea design (see iOS Screen Designs or Android Screen Designs folders). You can choose either one.

2) The forecast must be based on the user’s current location.

3) The application should connect to the following API to collect the weather information. https://openweathermap.org/current https://openweathermap.org/forecast5

4) You will be required to change the background image depending on the type of weather (Cloudy, Sunny and Rainy). Please use the provided assets and icons.
 
### Requirments 

- [x] user’s location 
- [x] 5-day forecast.
- [x] required to implement one of 2 designs
- [x] The application should connect to the following API to collect the weather information. , https://openweathermap.org/current,   https://openweathermap.org/forecast5
- [x] You will be required to change the background image depending on the type of weather (Cloudy, Sunny and Rainy).


TODO:
- [ ] Add unit tests
- [ ] Add Sonar Cload 
- [ ] Add lister for internet and geolocation checks
- [ ] Encrypt Constants class 
- [ ] Github permissions , only update master with pull request and atleast 1 approval
